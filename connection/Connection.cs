using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.connection
{
    public class Connection
    {
        protected readonly string ConnectionString = @"Data Source=DESKTOP-8AC42VI\SQLEXPRESS; Initial Catalog=Curso; Trusted_Connection=True;";
        protected SqlConnection Conn { get; set; }

        public Connection()
        {
            Conn = new SqlConnection(ConnectionString);
            Conn.Open();
        }

        public SqlConnection GetConnection()
        {
            try
            {
                return Conn;
            }
            catch (Exception)
            {
                return Conn;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if(Conn != null && Conn.State == System.Data.ConnectionState.Open) Conn.Close();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
