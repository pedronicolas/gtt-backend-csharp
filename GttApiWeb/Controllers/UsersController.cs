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
    public class UsersController : ControllerBase
    {
        private readonly AppDBContext _context;
        public Control control;

        public UsersController(AppDBContext context)
        {
            this._context = context;
            if (this._context.Users.Count() == 0)
            {
                Users usuario = new Users();
                usuario.username = "PedroNicolas";
                usuario.password = Encrypt.Hash("1234");
                usuario.role = 0;
                this._context.Users.Add(usuario);
                this._context.SaveChanges();
            }
        }



        // GET api/users
        [HttpGet]
        public ActionResult<List<Users>> GetAll()
        {
            return this._context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(long id)
        {
            try
            {
                var headerValue = Request.Headers["Authorization"];
                var token = JWT.Decode(headerValue, "top secret");
               
                Users user = this._context.Users.Find(id);
                if (user == null)
                {
                    return NotFound("ERROR 404: User not found");
                }
                return user;
            }
            catch(Exception)
            {
                return Unauthorized();
            }

           
        }

        // POST api/users
        [HttpPost]
        public ActionResult<Control> Post([FromBody] Users value)
        {
            Users userResult ;
            try {
                userResult = this._context.Users.Where(userQ => userQ.username == value.username).First();
            }
            catch (Exception)
            {
                userResult = null;
            }

            if (userResult == null)
                {
                    value.password = Encrypt.Hash(value.password);
                   
                    this._context.Users.Add(value);
                    this._context.SaveChanges();

                return control = new Control(200,"Registro Realizado");
            }
            return control = new Control(409,"Usuario ya registrado");
            }
        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users value)
        {
            Users userUpdate = this._context.Users.Find(id);
            userUpdate.username = value.username;
            userUpdate.password = value.password;
            this._context.SaveChanges();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public ActionResult<Control> Delete(long id)
        {
            Users userDelete = this._context.Users.Where(userQ => userQ.id == id).First();
            if(userDelete == null)
            {
                return NotFound("error 404");
            }
            this._context.Remove(userDelete);
            this._context.SaveChanges();
            return control = new Control(200,"Borrado Realizado");
            
        }
    }
}
