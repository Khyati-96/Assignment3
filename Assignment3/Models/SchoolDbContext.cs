using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySqlConnector;

namespace Assignment3.Models
{
    public class SchoolDbContext
    {
        //These are read-only properties that only the SchoolDbContext class can use
        private static string User { get { return "root"; } }
        private static string Password { get { return "root"; } }
        private static string Database { get { return "school"; } }
        private static string Server { get { return "localhost"; } }
        private static string Port { get { return "3306"; } }

        //ConnectionString is a series of credentials used to connect to the database
        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;
            }
        }
        /// <summary>
        /// This method returns a connection to the school database
        /// </summary>
        /// <example>
        /// private SchoolDbConect School = new SchoolDbContext();
        /// MySqlConnection Conn = School.AccessDatabase();
        /// </example>
        /// <returns>A MySqlConnection Object</returns>
        public MySqlConnection AccessDatabase()
        {
            //instantiates the MySqlConnection Class to create an object
            //which is a specific connection to our school database on port 3306
            return new MySqlConnection(ConnectionString);
        }

    }
}