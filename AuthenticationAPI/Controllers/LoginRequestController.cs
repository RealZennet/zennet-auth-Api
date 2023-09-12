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
        [Route("api/v1/login")]
        public IHttpActionResult Auth([FromBody] LoginRequestModel loginrequest)
        {
            Dictionary<string, string> authentication = loginrequest.LoginRequest();

            if (authentication["resultado"] == "OK")
            {
                return Content(HttpStatusCode.OK, authentication);
            }

            return Unauthorized();
        }

    }
}