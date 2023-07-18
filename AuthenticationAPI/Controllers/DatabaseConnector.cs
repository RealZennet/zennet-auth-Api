﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationAPI.Controllers
{
    public class DatabaseConnector
    {
        public string dbip;
        public string dbUser;
        public string dbPassword;
        public string dbDatabaseName;

        public MySqlConnection Connection;
        public MySqlCommand Command;
        public MySqlDataReader Reader;

        public DatabaseConnector()
        {
            this.dbip = "localhost";
            this.dbUser = "root";
            this.dbPassword = "zackquack";
            this.dbDatabaseName = "quickcarry";

            this.Connection = new MySqlConnection(
                $"server={this.dbip};" +
                $"user={this.dbUser};" +
                $"password={this.dbPassword};" +
                $"database={this.dbDatabaseName};");

            this.Connection.Open();
            this.Command = new MySqlCommand();
            this.Command.Connection = this.Connection;
        }
    }
}