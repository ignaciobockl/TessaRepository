using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceTessa.Application.Connection
{
    public static class ConnectionSqlServer
    {
        private const string Server = @"TessaIntimates2020.mssql.somee.com";
        private const string DataBase = "TessaIntimates2020";
        private const string User = "nacho144_SQLLogin_1";
        private const string Password = "w58ubemmkg";

        public static string GetSQLConnectionString => $"Data Source={Server}; " +
                                                       $"Initial Catalog={DataBase}; " +
                                                       $"User Id={User}; " +
                                                       $"Password={Password};";
        public static string GetWINDOWSConnectionString => $"Data Source={Server}; " +
                                                           $"Initial Catalog={DataBase}; " +
                                                           $"Integrated Security = true";
    }
}
