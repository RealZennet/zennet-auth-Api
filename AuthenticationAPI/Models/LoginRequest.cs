﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAPI.Models
{
    public class LoginRequest
    {
        public String Username { get; set; }
        public String Password { get; set; }
    }
}