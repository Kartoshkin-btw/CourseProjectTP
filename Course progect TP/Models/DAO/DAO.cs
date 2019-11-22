using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Course_progect_TP.Models.DAO
{
    public class DAO
    {
        public const string ConnectionString = @"Initial Catalog = CourseBD;" +
@"Data Source=LOCALHOST\SQLEXPRESS;" +
@"Initial Catalog=CourseBD;" +
@"Integrated Security=True;" +
@"Pooling=False";

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