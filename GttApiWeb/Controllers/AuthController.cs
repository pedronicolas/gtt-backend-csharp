using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GttApiWeb.Helpers;
using GttApiWeb.Models;
using Jose;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GttApiWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly AppDBContext _context;
        Control control;
        public AuthController(AppDBContext context)
        {
            this._context = context;
        }
        // GET: api/Auth
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        [HttpPost]
        public ActionResult<Control> Post([FromBody] Users value)
        {

            try
            {
                Users UserResult = this._context.Users.Where(
                user => user.username.Equals(value.username)).FirstOrDefault();

                if (UserResult != null)
                {
                    if (UserResult.password == Encrypt.Hash(value.password))
                    {
                        string token = JWT.Encode(UserResult.id, "top secret", JweAlgorithm.PBES2_HS256_A128KW, JweEncryption.A256CBC_HS512);
                        string token_decoded = JWT.Decode(token, "top secret");
                        return control = new Control(200, "Login Realizado correctamente", token,UserResult.id, (int)UserResult.role);
                    }
                }
                return control = new Control( 204,"Usuario o contraseña incorrectos");

               }
            catch (Exception e)
            {
                Console.WriteLine(e);
                control = new Control(404,"Error:");
            }
            return Unauthorized();
        }

        // PUT: api/Auth/5
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
