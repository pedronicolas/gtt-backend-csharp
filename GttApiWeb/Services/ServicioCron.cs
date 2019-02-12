using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


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
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromHours(12));
            return Task.CompletedTask;
        }

        public void DoWork(object state)
        {
            _logger.LogInformation("Ejecutando tarea");
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
