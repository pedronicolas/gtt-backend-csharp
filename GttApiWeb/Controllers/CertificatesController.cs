﻿using System;
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
            } catch(Exception)
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
            } catch(Exception)
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
                try
                {
                    byte[] arrayBytes = System.Convert.FromBase64String(value.fichero64);
                    // Lo cargamos en certificate
                    X509Certificate2 certificate = new X509Certificate2(arrayBytes, value.password);
                    string token = certificate.ToString(true);

                    //Extracción parámetros del certificado.
                    value.numeroSerie = certificate.GetSerialNumberString();
                    value.entidadEmisora = certificate.Issuer.ToString();
                    value.subject = certificate.Subject;
                    value.fechaCaducidad = certificate.NotAfter;
                    value.caducado = false;
                    this._context.Certificates.Add(value);
                    this._context.SaveChanges();

                    Control control = new Control(200, "Certificado añadido");
                    return control;
                }
                catch
                {
                    Control control = new Control(409, "Contraseña Inválida");
                    return control;
                }
            } catch(Exception)
            {
                return Unauthorized();
            }
            
            
        }



        // PUT: api/Certificates/5
        [HttpPut("{id}")]
        public ActionResult<Control> Put( [FromBody] Certificates value)
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var tokenJ = JWT.Decode(headerValue, "top secret");

                Certificates CertUpdate = this._context.Certificates.Where(cert => cert.id.Equals(value.id)).First();
                if (CertUpdate != null)
                {// Obtenemos el string en base64 y se convierte a byte []
                    byte[] arrayBytes = System.Convert.FromBase64String(value.fichero64);
                    // Lo cargamos en certificate
                    X509Certificate2 certificate = new X509Certificate2(arrayBytes, value.password);
                    string token = certificate.ToString(true);

                    //Extracción parámetros del certificado.
                    CertUpdate.alias = value.alias;
                    CertUpdate.entidadEmisora = value.entidadEmisora;
                    CertUpdate.email = value.email;
                    CertUpdate.idOrga = value.idOrga;
                    CertUpdate.nombreArchivo = value.nombreArchivo;
                    CertUpdate.nombreCliente = value.nombreCliente;

                    CertUpdate.numeroSerie = certificate.GetSerialNumberString();
                    CertUpdate.entidadEmisora = certificate.Issuer.ToString();
                    CertUpdate.subject = certificate.Subject;
                    CertUpdate.fechaCaducidad = certificate.NotAfter;
                    CertUpdate.eliminado = false;
                    CertUpdate.caducado = value.caducado;

                    CertUpdate.ticket_creado = value.ticket_creado;
                    this._context.SaveChanges();

                    Control control = new Control(200, "Certificado añadido");
                    return control;
                }

                return NotFound();
            }
            catch(Exception e)
            {
                return Unauthorized();
            }

                    
           
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Control> Delete(long id)
        {
            Control control;
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var tokenJ = JWT.Decode(headerValue, "top secret");

                Certificates certDelete = this._context.Certificates.Where(emp => emp.id.Equals(id)).First();
                this._context.Certificates.Remove(certDelete);
                this._context.SaveChanges();
                return control = new Control(200, "Borrado Realizado"); 
            }
            catch(Exception)
            {
                return Unauthorized();
            }
        }
    }
}
