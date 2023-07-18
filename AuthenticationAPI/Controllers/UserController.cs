using AuthenticationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AuthenticationAPI.Controllers
{
    public class UserController : ApiController
    {
        [Route("api/users")]
        public IHttpActionResult Post([FromBody] UserModel user)
        {
            if (!ModelState.IsValid || user == null)
            {
                return BadRequest("Error en el ingreso de datos");
            }
            user.Save();
            return Ok($"Usuario {user.CI} fue guardado con exito");
        }


    }
}