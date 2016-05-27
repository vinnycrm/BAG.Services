using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace BAG.CommonConstants
{
    public class General
    {
         public static string SQL_CONN_STRING = @"data source=VINAY-PC\SQLEXPRESS;initial catalog=BAG;persist security info=True;user id=sa;password=sa";
        // public static string SQL_CONN_STRING = @"Data Source=supraj-pc\supraj;Initial Catalog=BAG;Integrated Security=True";
        // public static string SQL_CONN_STRING = @"Data Source=184.168.194.70;Initial Catalog=BAG;User ID=prayog;Password=p@123456";

        public static SqlConnection GetConnection()
        {
            SqlConnection dbconnection = new SqlConnection(General.SQL_CONN_STRING);
            try
            {
                dbconnection.Open();
                return dbconnection;
            }
            catch (System.InvalidOperationException e)
            {
                Console.Write(e);
                return null;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                Console.Write(e);
                return null;
            }
        }

    }
}
