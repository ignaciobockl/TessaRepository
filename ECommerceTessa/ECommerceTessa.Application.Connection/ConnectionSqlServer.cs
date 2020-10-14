using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Application.Connection
{
    public static class ConnectionSqlServer
    {
        private const string Server = @"DESKTOP-AVIBG03\SQLEXPRESS";
        private const string DataBase = "Tessa";
        private const string User = "";
        private const string Password = "";

        public static string GetSQLConnectionString => $"Data Source={Server}; " +
                                                       $"Initial Catalog={DataBase}; " +
                                                       $"User Id={User}; " +
                                                       $"Password={Password};";
        public static string GetWINDOWSConnectionString => $"Data Source={Server}; " +
                                                           $"Initial Catalog={DataBase}; " +
                                                           $"Integrated Security = true";
    }
}
