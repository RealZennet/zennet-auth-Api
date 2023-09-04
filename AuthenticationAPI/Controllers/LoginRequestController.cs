using AuthenticationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace AuthenticationAPI.Controllers
{

    public class LoginRequestController : ApiController
    {
        [HttpGet]
        [Route("api/login/v1/user")]
        public IHttpActionResult Get()
        {
            if ()
            {

                return Ok();
            }

            return Ok(true);
        }

    }
}