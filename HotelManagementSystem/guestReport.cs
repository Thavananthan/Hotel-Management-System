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
    public partial class guestReport : Form
    {
        ReportDocument rd = new ReportDocument();
        public guestReport()
        {
            InitializeComponent();
        }

        private void guestReport_Load(object sender, EventArgs e)
        {
            searchreport();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btngSearchR_Click(object sender, EventArgs e)
        {
            searchreport();
        }

        void searchreport() {
            try
            {
                rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport1.rpt");
                connection con = new connection();
                SqlDataAdapter sad = new SqlDataAdapter("guestVieworSearchReport", con.Activecon());
                sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                sad.SelectCommand.Parameters.AddWithValue("@lname", gsearch.Text.Trim());
                DataSet st = new DataSet();
                sad.Fill(st, "guestdetails");

                rd.SetDataSource(st);
                crystalReportViewer1.ReportSource = rd;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
