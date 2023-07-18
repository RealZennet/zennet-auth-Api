using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthenticationAPI.Controllers;

namespace AuthenticationAPI.Models
{
    public class UserModel: DatabaseConnector
    {
        public int CI { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public int PhoneNumber { get; set; }

        public void Save()
        {
            this.Command.CommandText = $"INSERT INTO trabajador (ci, nom1, nom2, ape1, ape2, tel) VALUES (" +
                $"'{this.CI}', " +
                $"'{this.FirstName}'," +
                $"'{this.SecondName}', " +
                $"'{this.FirstLastName}', " +
                $"'{this.SecondLastName}', " +
                $"'{this.PhoneNumber}')";
            this.Command.ExecuteNonQuery();
        }

        public List <UserModel> GetAllUsers()
        {
            this.Command.CommandText = $"SELECT * FROM trabajador";
            this.Reader = this.Command.ExecuteReader();

            List<UserModel> result = new List<UserModel>();
            while (this.Reader.Read())
            {
                UserModel user = new UserModel();
                user.CI = Int32.Parse(this.Reader["ci"].ToString());
                user.FirstName = this.Reader["nom1"].ToString();
                user.SecondName = this.Reader["nom2"].ToString();
                user.FirstLastName = this.Reader["ape1"].ToString();
                user.SecondLastName = this.Reader["ape2"].ToString();
                user.PhoneNumber = Int32.Parse(this.Reader["tel"].ToString());
                result.Add(user);
            }
            return result;
        }

        public void DeleteUser()
        {
            this.Command.CommandText = $"DELETE FROM trabajador where ci = {this.CI}";
            this.Command.ExecuteNonQuery();
        }

        public void EditUser()
        {
            this.Command.CommandText = $"UPDATE trabajador SET nom1 = {this.FirstName}," +
                $"nom2 = {this.SecondName}," +
                $"ape1 = {this.FirstLastName}," +
                $"ape2 = {this.SecondLastName}," +
                $"tel = {this.PhoneNumber}";
            this.Command.ExecuteNonQuery();
        }
        
    }
}