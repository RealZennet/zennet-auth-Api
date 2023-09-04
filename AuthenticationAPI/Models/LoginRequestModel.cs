using AuthenticationAPI.Controllers;
using MD5Hash;
using MySqlConnector;
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

            this.Command.CommandText = $"SELECT username, pass FROM trabajador WHERE username = '{this.UserName}'";
            this.Reader = this.Command.ExecuteReader();

            if (this.Reader.HasRows)
            {
                this.Reader.Read();
                string dbPassword = this.Reader["pass"].ToString();

                if (Hash.Content(this.Password) == dbPassword)
                {
                    resultado.Add("resultado", "OK");

                    if (IsInTable("camionero"))
                    {
                        resultado.Add("tipo", "camionero");
                    }
                    else if (IsInTable("operario"))
                    {
                        resultado.Add("tipo", "operario");
                    }
                    else
                    {
                        resultado.Add("tipo", "desconocido"); 
                    }

                    return resultado;
                }
            }

            resultado.Add("resultado", "Error");

            return resultado;
        }

        private bool IsInTable(string tableName)
        {
            bool isInTable = false;

            if (this.Reader != null && !this.Reader.IsClosed)
            {
                this.Reader.Close();
            }

            this.Command.CommandText = $"SELECT COUNT(*) FROM {tableName} WHERE username = '{this.UserName}'";

            try
            {
                int count = Convert.ToInt32(this.Command.ExecuteScalar());
                isInTable = count > 0;
            }
            catch (Exception)
            {
                
            }

            this.Command.CommandText = ""; 

            return isInTable;
        }


    }
}