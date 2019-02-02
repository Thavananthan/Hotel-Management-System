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
    public partial class RoomBooking : Form
    {
        ReportDocument rd = new ReportDocument();
        public RoomBooking()
        {
            InitializeComponent();
        }

        private void RoomBooking_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateTimePicker2.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1);

            try
            {
                rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport2.rpt");
                connection con = new connection();
                SqlDataAdapter sad = new SqlDataAdapter("roombookingview", con.Activecon());
                sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                sad.SelectCommand.Parameters.AddWithValue("@mode", "checkout");
                sad.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                sad.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value);
                DataSet st = new DataSet();
                sad.Fill(st, "BookingReport");

                rd.SetDataSource(st);
                crystalReportViewer1.ReportSource = rd;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
             if (radioButton1.Checked == true) {
                try
                {
                    rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport2.rpt");
                    connection con = new connection();
                    SqlDataAdapter sad = new SqlDataAdapter("roombookingview", con.Activecon());
                    sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sad.SelectCommand.Parameters.AddWithValue("@mode", "checkin");
                    sad.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                    sad.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value);

                    DataSet st = new DataSet();
                    sad.Fill(st, "BookingReport");

                    rd.SetDataSource(st);
                    crystalReportViewer1.ReportSource = rd;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else if (radioButton2.Checked == true) {

                try
                {
                    rd.Load(@"C:\Users\nanthu\Desktop\HotelManagementSystem\HotelManagementSystem\CrystalReport2.rpt");
                    connection con = new connection();
                    SqlDataAdapter sad = new SqlDataAdapter("roombookingview", con.Activecon());
                    sad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sad.SelectCommand.Parameters.AddWithValue("@mode", "checkout");
                    sad.SelectCommand.Parameters.AddWithValue("@date1", dateTimePicker1.Value);
                    sad.SelectCommand.Parameters.AddWithValue("@date2", dateTimePicker2.Value);

                    DataSet st = new DataSet();
                    sad.Fill(st, "BookingReport");

                    rd.SetDataSource(st);
                    crystalReportViewer1.ReportSource = rd;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else 
            {

                MessageBox.Show("please check your check in and check out button", "Error");
            }

        }



       
    }
}
