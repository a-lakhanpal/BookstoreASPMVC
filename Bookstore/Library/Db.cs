using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.Library
{
    public static class Db
    {
        ///public static string reportDriver = WebConfigurationManager.AppSettings["ReportDriver"];
        public static string server = "localhost";//WebConfigurationManager.AppSettings["Server"];
        public static string database = "bookstore";
        public static string user = "root";
        //public static string reportUser = "reporter";
        public static string password = "password";
        public static string port = "3309";//WebConfigurationManager.AppSettings["Port"];
        public static string ConString = "server=" + server + ";user=" + user + ";password=" + password + ";database=" + database + ";port=" + port + ";Convert Zero Datetime=True";
    }
}