using AuthenticationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AuthenticationAPI.Controllers
{
    public class UserController : ApiController
    { //Falta JWT
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

        [Route("api/users/{ci:int}")]
        public IHttpActionResult Delete(int ci)
        {
            UserModel users = new UserModel();
            var UserList = users.GetAllUsers();

            var user = UserList.FirstOrDefault(everyUser => everyUser.CI == ci);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                user.DeleteUser();
                return Ok($"El usuario {user.CI} fue eliminado correctamente");
            }
        }

        [Route("api/users")]
        public IHttpActionResult Get()
        {
            UserModel users = new UserModel();
            var listaLotes = users.GetAllUsers();
            var usersView = listaLotes.Select(everyUser => new UsersViews
            {
                CI = everyUser.CI,
                FirstName = everyUser.FirstName,
                SecondName = everyUser.SecondName,
                FirstLastName = everyUser.FirstLastName,
                SecondLastName = everyUser.SecondLastName,
                PhoneNumber = everyUser.PhoneNumber
            });
            return Ok(usersView);
        }

        [Route("api/users/{ci:int}")]
        public IHttpActionResult Get(int ci)
        {
            UserModel users = new UserModel();
            var UserList = users.GetAllUsers();

            var user = UserList.FirstOrDefault(everyUser => everyUser.CI == ci);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                var userViews = new UsersViews
                {
                    CI = user.CI,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    FirstLastName = user.SecondLastName,
                    SecondLastName = user.SecondLastName,
                    PhoneNumber = user.PhoneNumber
                };
                return Ok(userViews);
            }
        }

    }
}