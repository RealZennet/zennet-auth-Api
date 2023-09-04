using AuthenticationAPI.Controllers;
using MD5Hash;
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


        public Dictionary<string, string> LoginRequest()
        {
            Dictionary<string, string> resultado = new Dictionary<string, string>();

            
            this.Command.CommandText = $"SELECT username, pass FROM operario WHERE username = '{this.UserName}'";
            this.Reader = this.Command.ExecuteReader();

            if (this.Reader.HasRows)
            {
                this.Reader.Read();
                string dbPassword = this.Reader["pass"].ToString();

                
                if (Hash.Content(this.Password) == dbPassword)
                {
                    resultado.Add("resultado", "OK");
                    resultado.Add("tipo", "operario"); 
                    return resultado;
                }
            }

            
            this.Command.CommandText = $"SELECT username, pass FROM camionero WHERE username = '{this.UserName}'";
            this.Reader = this.Command.ExecuteReader();

            if (this.Reader.HasRows)
            {
                this.Reader.Read();
                string dbPassword = this.Reader["pass"].ToString();

                
                if (Hash.Content(this.Password) == dbPassword)
                {
                    resultado.Add("resultado", "OK");
                    resultado.Add("tipo", "camionero"); 
                    return resultado;
                }
            }

            // Si no se encontró en ninguna de las tablas o la contraseña no coincide, indica un error.
            resultado.Add("resultado", "Error");

            return resultado;
        }
    }
}