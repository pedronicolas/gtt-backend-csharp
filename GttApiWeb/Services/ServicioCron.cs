using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GttApiWeb.Models;

namespace GttApiWeb.Services
{
    internal class ServicioCron : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        public ServicioCron(ILogger<ServicioCron> logger)
        {
            _logger = logger;
        }

        

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Arrancando el servicio");
            //Cambiar a cada 12 horas después de la exposición.
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }

        public void DoWork(object state)
        {
            var optionsBuild = new DbContextOptionsBuilder<AppDBContext>();
            optionsBuild.UseNpgsql("Host=192.168.99.100;Port=5432;Username=postgres;Password=example;Database=ApiGtt;");

            using (var context = new AppDBContext(optionsBuild.Options))
            {
                context.Certificates.Load();
                DateTime maxDateTime = DateTime.Now.AddMonths(3);
                foreach (var cert in context.Certificates.Local)
                {
                    if(cert.fechaCaducidad.AddMonths(3)<= maxDateTime)
                    {
                        cert.caducado = true;
                        cert.eliminado = true;
                        context.SaveChanges();
                    }
                    //Por si quieren ver que funciona en ese rango de tiempo.
                    //_logger.LogInformation(cert.caducado.ToString() +" : " + cert.alias);
                }

            }
            
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando el servicio");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
