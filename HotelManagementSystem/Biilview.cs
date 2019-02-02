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
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class Biilview : Form
    {
        ReportDocument rd = new ReportDocument();
        public Biilview()
        {
            InitializeComponent();
        }

        private void Biilview_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);
            rdView();
        }

        void rdView()
        {

           
            try
            {
                rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport3.rpt");
                connection con = new connection();
                SqlDataAdapter sad = new SqlDataAdapter("viewBill", con.Activecon());
                sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                sad.SelectCommand.Parameters.AddWithValue("@guestname", gsearch.Text.Trim());
                DataSet st = new DataSet();
                sad.Fill(st, "ViewBiil");

                rd.SetDataSource(st);
                crystalReportViewer1.ReportSource = rd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btngSearchR_Click(object sender, EventArgs e)
        {
            rdView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport3.rpt");
                connection con = new connection();
                SqlDataAdapter sad = new SqlDataAdapter("viewbilldate", con.Activecon());
                sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                sad.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker1.Value);
                sad.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker2.Value);
                DataSet st = new DataSet();
                sad.Fill(st, "ViewBiil");

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
