using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    class connection
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KU3ORSG\MYSQLEXPRESS;Initial Catalog=hms2018;Integrated Security=True");
        public SqlConnection Activecon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
    }
}

