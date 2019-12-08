using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Course_progect_TP.Models.DAO
{
    public class DefaultDAO
    {
        //public const string ConnectionString = @"Initial Catalog = aspnet-Course progect TP-20191119095126;" +
        //@"Data Source=(LocalDb)\MSSQLLocalDB;" +
        //@"Integrated Security=True;";
        string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }
        public void Disconnect()
        {
            Connection.Close();
        }
    }
}