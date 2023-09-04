using AuthenticationAPI.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationAPI.Models
{
    public class LoginRequestModel : DatabaseConnector
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string userRole { get; set; }

    
    }

}