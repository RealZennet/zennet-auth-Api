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

    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("api/login/test")]
        public IHttpActionResult test()
        {
            return Ok(true);
        }

    }
}