using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GttApiWeb.Helpers;
using GttApiWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Jose;

namespace GttApiWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
       
            private readonly AppDBContext _context;
        // GET: api/Certificates
        public CertificatesController(AppDBContext context)
        {
            this._context = context;
            
        }
        //GET: api/Certificates
        [HttpGet]
        public ActionResult<List<Certificates>> Get()
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var token = JWT.Decode(headerValue, "top secret");
                return this._context.Certificates.ToList();
            } catch(Exception e)
            {
                return Unauthorized();
            }
            
        }

        // GET: api/Certificates/5
        [HttpGet("{id}", Name = "GetCertificate")]
        public ActionResult<Certificates> Get(long id)
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var token = JWT.Decode(headerValue, "top secret");
                try
                {
                    Certificates CertResult = this._context.Certificates.Where(
                    cert => cert.id.Equals(id)).FirstOrDefault();
                    return CertResult;
                }
                catch (Exception)
                {
                    return NotFound();
                }
            } catch(Exception e)
            {
                return Unauthorized();
            }
            

        }

        // POST: api/Certificates
        [HttpPost]
        public ActionResult<Control> Post([FromBody] Certificates value)
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var tokenJ = JWT.Decode(headerValue, "top secret");
                // Obtenemos el string en base64 y se convierte a byte []
                byte[] arrayBytes = System.Convert.FromBase64String(value.fichero64);
                // Lo cargamos en certificate
                X509Certificate2 certificate = new X509Certificate2(arrayBytes, value.password);
                string token = certificate.ToString(true);

                //Extracción parámetros del certificado.
                value.numeroSerie = certificate.GetSerialNumberString();
                value.entidadEmisora = certificate.Issuer.ToString();
                value.subject = certificate.Subject;
                value.fechaCaducidad = certificate.NotAfter;
                this._context.Certificates.Add(value);
                this._context.SaveChanges();

                Control control = new Control(200, "Certificado añadido", "", -1, -1);
                return control;
            } catch(Exception e)
            {
                return Unauthorized();
            }
            
            
        }



        // PUT: api/Certificates/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
