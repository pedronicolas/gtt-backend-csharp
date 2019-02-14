using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GttApiWeb.Models;
using GttApiWeb.Helpers;
using Jose;

namespace GttApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JiraController : ControllerBase
    {

        private readonly AppDBContext _context;

        public JiraController(AppDBContext context)
        {
            this._context = context;
            if (this._context.Jira.Count() == 0)
            {
                Jira jira = new Jira();
                jira.username = "admin";
                jira.pass = Encrypt.Hash("pedro1234");
                jira.component = "Explotacion!";
                jira.proyect = "SIT";
                jira.url = "https://pedronicolasgtt.atlassian.net/";
                jira.user_id = 1;
                this._context.Jira.Add(jira);
                this._context.SaveChanges();
            }
        }


        // GET api/Jira
        [HttpGet]
        public ActionResult<List<Jira>> GetAll()
        {
            return this._context.Jira.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Jira> Get(long id)
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var token = JWT.Decode(headerValue, "top secret");
                try
                {
                    Jira JiraResult = this._context.Jira.Where(
                    jira => jira.user_id.Equals(id)).FirstOrDefault();
                    return JiraResult;
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

        // POST api/values
        [HttpPost]
        public ActionResult<Control> Post([FromBody] Jira value)
        {
            Control control;
            Jira JiraResult;
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var token = JWT.Decode(headerValue, "top secret");
                try
                {

                    JiraResult = this._context.Jira.Where(userQ => userQ.username == value.username).First();
                }
                catch (Exception)
                {
                    JiraResult = null;
                }

                if (JiraResult == null)
                {
                    value.pass = Encrypt.Hash(value.pass);

                    this._context.Jira.Add(value);
                    this._context.SaveChanges();



                    control = new Control(200, "Usuario Guardado", "", -1, -1);
                    return control;
                }
                //Control control = new Control(401, "Incorrecto");
                control = new Control(409, "Usuario Ocupado", "", -1, -1);
                return control;
            } catch(Exception e){ return Unauthorized(); }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Control> Put(long id, [FromBody] Jira value)
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var token = JWT.Decode(headerValue, "top secret");
                try
                {
                    Jira JiraUpdate = this._context.Jira.Where(jira => jira.user_id.Equals(value.user_id)).First();
                    if (JiraUpdate != null)
                    {
                        JiraUpdate.username = value.username;
                        JiraUpdate.pass = Encrypt.Hash(value.pass);
                        JiraUpdate.proyect = value.proyect;
                        JiraUpdate.component = value.component;
                        this._context.SaveChanges();

                    }
                    Control control = new Control(200, "User Changed", "", -1, -1);
                    return control;
                }
                catch (Exception)
                {
                    Control control = new Control(409, "IncorrectUser", "", -1, -1);
                }

                return NotFound();
            } catch(Exception e)
            {
                return Unauthorized();
            }
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
