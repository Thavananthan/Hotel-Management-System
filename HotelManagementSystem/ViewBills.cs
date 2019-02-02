using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class ViewBills : Form
    {
        ReportDocument rd = new ReportDocument();
       
        int id;
        private string date;
        private int guestId;

        public ViewBills(String date,int id)
        {
            InitializeComponent();
            this.date = date;
            this.guestId = id;

            textBox2.Text = this.date;
            textBox1.Text = this.guestId.ToString();
          
            //DateTime oDate = DateTime.ParseExact(this.date, "yyyy-MM-dd HH:mm tt", System.Globalization.CultureInfo.InvariantCulture);
           // MessageBox.Show(oDate.ToString());

        }
 
        

        private void ViewBills_Load(object sender, EventArgs e)
        {
           
           // textBox2.Text = Convert.ToDateTime(textBox2.Text).ToString("yyyy-mm-dd hh:mi:ss.mmm");
         //  DateTime dt=DateTime.ParseExact(this.date,"yyyy-MM-dd HH:mm:ss")

         


            try
            {
                rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport4.rpt");
                connection con = new connection();
                SqlDataAdapter sad = new SqlDataAdapter("printBillforguest", con.Activecon());
                sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                sad.SelectCommand.Parameters.AddWithValue("@guestId", textBox1.Text.Trim());
             //   DateTime ad = Convert.ToDateTime(textBox2.Text.Trim());
               // sad.SelectCommand.Parameters.AddWithValue("@date", textBox2.Text);
                DataSet st = new DataSet();
                sad.Fill(st, "prinybillforguests");

                rd.SetDataSource(st);
                crystalReportViewer1.ReportSource = rd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
    }
}
