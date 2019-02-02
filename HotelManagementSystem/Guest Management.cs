using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace HotelManagementSystem
{
    public partial class Guest_Management : Form
    {
        int Id = 0;
        int roomId = 0;
        int differenceInDays = 0;
        int roomnumber;
        int Rprice = 0;
        int extr = 0;
       // int guestId;
        String Roomtype;
        int guestnum;
        int roomnum1;
        int numbercb;
        int count = 0;
        int billid = 0;
        int resernum = 0;

        public static String setvalueforText1 = "";
        public static String setvalueforText2 = "";
        public static String setvalueforText3 = "";
        public static String setvalueforText4 = "";
        public static String setvalueforText5 = "";
        public static String setvalueforText6 = "";
        public static String setvalueforText7 = "";
        public static String setvalueforText8 = "";
        public static String setvalueforText9 = "";
        public static String setvalueforText10 = "";
        public static String setvalueforText11 = "";
        public static String setvalueforText12 = "";


        public Guest_Management()
        {
            InitializeComponent();
            ActivePanel.Height = btnRegGuest.Height;
            ActivePanel.Top = btnRegGuest.Top;
            BringToFront();
            gage.Enabled = false;



            txtroomnum.Enabled = false;
            button15.Enabled = false;
            pictureBox2.Visible = false; // green tick fname
            pictureBox3.Visible = false;// error fname
            pictureBox4.Visible = false;//error lname
            pictureBox5.Visible = false;//green tick lname

            texFname.Enabled = false;
            billroomtype.Enabled = false;
            billroomnum.Enabled = false;
            billdateA.Enabled = false;
            billnumOfguest.Enabled = false;
            tnumofnight.Enabled = false;
            billdated.Enabled = false;
            totalbill.Enabled = false;
            textBox9.Enabled = false;



        }



        private void btnclose_Click(object sender, EventArgs e) // close function
        {
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e) // minimized function
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void btnRegGuest_Click(object sender, EventArgs e)  // tab connection function start
        {
            ActivePanel.Height = btnRegGuest.Height;
            ActivePanel.Top = btnRegGuest.Top;
            guestmanagement.SelectTab(0);
            label1.Text = "Guest Registration";

        }
        private void btnRoombooking_Click(object sender, EventArgs e)
        {
            ActivePanel.Height = btnRoombooking.Height;
            ActivePanel.Top = btnRoombooking.Top;
            guestmanagement.SelectTab(1);
            label1.Text = "Guest Registration";
            searchroomCheckInDetails();
            availableroom();
            CheckOutHistoryView();


        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            ActivePanel.Height = btnAddRoom.Height;
            ActivePanel.Top = btnAddRoom.Top;
            guestmanagement.SelectTab(2);
            label1.Text = "AddRoom";
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ActivePanel.Height = btnHome.Height;
            ActivePanel.Top = btnHome.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivePanel.Height = button1.Height;
            ActivePanel.Top = button1.Top;
            guestmanagement.SelectTab(3);
            label1.Text = "Bill";
            ViewBill();



        }
        private void btnreport_Click(object sender, EventArgs e) // tab connection function end
        {
            ActivePanel.Height = btnreport.Height;
            ActivePanel.Top = btnreport.Top;
            guestmanagement.SelectTab(5);
            label1.Text = "Report";

        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivePanel.Height = btnSetting.Height;
            ActivePanel.Top = btnSetting.Top;
            guestmanagement.SelectTab(4);
            label1.Text = "Setting";
        }


        private void Guest_Management_Load(object sender, EventArgs e)
        {
            reset();
            FillDataGridView();
            Roomreset();
            FillDataroomGridView();

        }



        private void label44_Click(object sender, EventArgs e)
        {

        }

        /* void addguest() {       // register guest details

             if ((gfname.Text == "") || (glname.Text == "") || (gnic.Text == "") || (ggender.Text == "") ||
            (gdatet.Text == "") || (gage.Text == "") || (gadd.Text == "") || (gphonenum.Text == ""))
             {

                 MessageBox.Show("One or more Fields are Empty..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


             }
             else
             {



                 connection con = new connection();
                 SqlCommand cmd = new SqlCommand(@"INSERT INTO [guest]
                        ([fname],[lname],[nic],[gender],[dob],[age],[address],[phonenum])

                  VALUES
                        ('" + gfname.Text + "','" + glname.Text + "','" + gnic.Text + " ','" + ggender.Text + " ','" + gdatet.Text + " ','" + gage.Text + " ','" + gadd.Text + " ','" + gphonenum.Text + "')", con.Activecon());

                 cmd.ExecuteNonQuery();

                 MessageBox.Show("Guest Added Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
             }

         }*/
        private void gfname_Leave(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(gfname.Text) || (gfname.Text).Any(char.IsDigit) || (gfname.Text).Any(char.IsPunctuation))
            {

                label59.Text = "check firstname & Enter the letter only";
                label32.ForeColor = Color.Red;
                MessageBox.Show("check firstname & Enter the letter only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //pictureBox3.Visible = true;
                //pictureBox2.Visible = false;
            }

            else
            {

                label59.Text = "";
                label32.ForeColor = Color.Black;
                //pictureBox2.Visible = true;
                //pictureBox3.Visible = false;

            }

        }
        private void captionbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(captionbox.Text) || (captionbox.Text).Any(char.IsDigit) || (captionbox.Text).Any(char.IsPunctuation))
            {

                label59.Text = "select caption";
                label32.ForeColor = Color.Red;
                MessageBox.Show("select caption mr or miss..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //pictureBox3.Visible = true;
                //pictureBox2.Visible = false;
            }

            else
            {

                label59.Text = "";
                label32.ForeColor = Color.Black;
                //pictureBox2.Visible = true;
                //pictureBox3.Visible = false;

            }
        }

        private void glname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(glname.Text) || (glname.Text).Any(char.IsDigit) || (glname.Text).Any(char.IsPunctuation))
            {

                label60.Text = "check lastname & Enter the letter only";
                label33.ForeColor = Color.Red;
                // pictureBox4.Visible = true;
                //pictureBox5.Visible = false;
                MessageBox.Show("check lasttname & Enter the letter only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {

                label60.Text = "";
                label33.ForeColor = Color.Black;
                //pictureBox4.Visible = false;
                //pictureBox5.Visible = true;
            }

        }

        private void gnic_Leave(object sender, EventArgs e)// nic validation
        {
            nicnadpasswordvalidation();
        }

        System.Text.RegularExpressions.Regex nic = new System.Text.RegularExpressions.Regex(@"^[0-9]{9}(.*)[V]{1}");
        System.Text.RegularExpressions.Regex passport = new System.Text.RegularExpressions.Regex(@"^[A-Z][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$");
        void nicnadpasswordvalidation()
        {
            if (nicbutton.Checked == true)
            {



                if (gnic.Text.Length == 9 || !nic.IsMatch(gnic.Text.Trim()) || (gnic.Text.Length > 10 || gnic.Text.Length < 10))
                {
                    MessageBox.Show("check NIC Number'111111111V'..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label67.Text = "check NIC Number'111111111V'";
                    label37.ForeColor = Color.Red;



                }
                else {
                    label67.Text = "";
                    label37.ForeColor = Color.Black;
                }
            }
            else if (passportnum.Checked == true)
            {


                if (!passport.IsMatch(gnic.Text.Trim()))
                {

                    MessageBox.Show("check passport Number'N0000000'..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    label67.Text = "check passport Number'N0000000'";
                    label37.ForeColor = Color.Red;



                }
                else {
                    label67.Text = "";
                    label37.ForeColor = Color.Black;
                }
            }

        }

        private void gage_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gage.Text) || (gage.Text).Any(char.IsLetter) || (glname.Text).Any(char.IsPunctuation))
            {

                label61.Text = " check age & Enter the number only";
                label30.ForeColor = Color.Red;




            }

            else
            {

                label61.Text = "";
                label30.ForeColor = Color.Black;

            }

        }
        System.Text.RegularExpressions.Regex phone = new System.Text.RegularExpressions.Regex(@"^[0-9]{9}");

        private void gphonenum_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(gphonenum.Text) || (gphonenum.Text).Any(char.IsLetter) || (gphonenum.Text).Any(char.IsPunctuation) || (gphonenum.Text.Length > 10 || gphonenum.Text.Length < 10))
            {

                label62.Text = " check phone number & Enter the number only";
                label31.ForeColor = Color.Red;
                MessageBox.Show("check phone number & Enter the number only must be 10", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
             
            else
            {

                label62.Text = "";
                label31.ForeColor = Color.Black;
            }
        }
        private void ggender_Leave(object sender, EventArgs e) //guest gender selection 
        {
            if (string.IsNullOrWhiteSpace(ggender.Text))
            {

                label63.Text = "Choose gender  Type";
                label35.ForeColor = Color.Red;
                MessageBox.Show("Choose gender  Type...!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {
                label63.Text = "";
                label35.ForeColor = Color.Black;

            }
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /*  private void comboBox1_Leave(object sender, EventArgs e)
          {
              if (string.IsNullOrWhiteSpace(comboBox1.Text))
              {

                  label58.Text = "Choose payment  methode";


              }
              else
              {
                  label58.Text = "";
              }

          }*/
        private void gdatet_Leave(object sender, EventArgs e)
        {
            if (gdatet.Value.Date < DateTime.Now.Date)
            {


                label68.Text = "";
                label36.ForeColor = Color.Black;
                var toady = DateTime.Today;
                var birth = gdatet.Value.Date;
                var age = toady.Year - birth.Year;

                gage.Text = age.ToString();


            }
            else {
                label68.Text = "Invalid date please Check Date....";
                label36.ForeColor = Color.Red;
                MessageBox.Show("Invalid date please Check Date.....!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);




            }

        }




        private void btnSave_Click(object sender, EventArgs e) // guest detail inser ans update functions
        {

            if ((gphonenum.Text).Any(char.IsLetter) || (gphonenum.Text.Length > 10 || gphonenum.Text.Length < 10) || (string.IsNullOrWhiteSpace(gphonenum.Text)) || (string.IsNullOrWhiteSpace(gfname.Text)) || (string.IsNullOrWhiteSpace(glname.Text)) || (string.IsNullOrWhiteSpace(gage.Text)) || (gage.Text).Any(char.IsLetter) || (string.IsNullOrWhiteSpace(gadd.Text)) || (gadd.Text.Any(char.IsPunctuation)) ||
                  string.IsNullOrWhiteSpace(gfname.Text) || (gfname.Text).Any(char.IsDigit) || (gfname.Text).Any(char.IsPunctuation) || string.IsNullOrWhiteSpace(glname.Text) || (glname.Text).Any(char.IsDigit) || (glname.Text).Any(char.IsPunctuation) || gdatet.Value.Date > DateTime.Now.Date || gnic.Text == "" || captionbox.Text == "" || ggender.Text == "" || (!(nicbutton.Checked == true || passportnum.Checked == true)))
            {

                MessageBox.Show("Please check fields..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else
            {

                if (nicbutton.Checked == true)
                {
                    if (!nic.IsMatch(gnic.Text.Trim()))
                    {
                        MessageBox.Show("check NIC Number'111111111V'..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else {
                        try
                        {
                            connection con = new connection();
                            if (btnSave.Text == "Save") // save function
                            {
                                SqlCommand cmd = new SqlCommand("AddorEditguest", con.Activecon());
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@mode", "Save");
                                cmd.Parameters.AddWithValue("@Id", 0);
                                cmd.Parameters.AddWithValue("@caption", captionbox.Text.Trim());
                                cmd.Parameters.AddWithValue("@fname", gfname.Text.Trim());
                                cmd.Parameters.AddWithValue("@lname", glname.Text.Trim());
                                if (nicbutton.Checked == true)
                                {
                                    cmd.Parameters.AddWithValue("@indentity", "NIC");
                                    cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                }
                                if (passportnum.Checked == true)
                                {

                                    cmd.Parameters.AddWithValue("@indentity", "Passport");
                                    cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                }

                                cmd.Parameters.AddWithValue("@gender", ggender.Text.Trim());
                                cmd.Parameters.AddWithValue("@dob", gdatet.Text.Trim());
                                cmd.Parameters.AddWithValue("@age", gage.Text.Trim());
                                cmd.Parameters.AddWithValue("@address", gadd.Text.Trim());
                                cmd.Parameters.AddWithValue("@phonenum", gphonenum.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", "activate");

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Guest Added Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                reset();
                            }
                            else {
                                if (MessageBox.Show("Do you Want to Update This data ", "Update data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)// Update functions
                                {
                                    gage.Enabled = true;
                                    SqlCommand cmd = new SqlCommand("AddorEditguest", con.Activecon());
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@mode", "update");
                                    cmd.Parameters.AddWithValue("@Id", Id);
                                    cmd.Parameters.AddWithValue("@caption", captionbox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@fname", gfname.Text.Trim());
                                    cmd.Parameters.AddWithValue("@lname", glname.Text.Trim());
                                    if (nicbutton.Checked == true)
                                    {
                                        cmd.Parameters.AddWithValue("@indentity", "NIC");
                                        cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                    }
                                    if (passportnum.Checked == true)
                                    {

                                        cmd.Parameters.AddWithValue("@indentity", "Passport");
                                        cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                    }
                                    cmd.Parameters.AddWithValue("@gender", ggender.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dob", gdatet.Text.Trim());
                                    cmd.Parameters.AddWithValue("@age", gage.Text.Trim());
                                    cmd.Parameters.AddWithValue("@address", gadd.Text.Trim());
                                    cmd.Parameters.AddWithValue("@phonenum", gphonenum.Text.Trim());
                                    cmd.Parameters.AddWithValue("@status", "activate");
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Guest update Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    reset();



                                }
                            }



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error ");
                        }
                        finally
                        {
                            reset();
                            FillDataGridView();


                        }

                    }

                }



                if (passportnum.Checked == true)
                {
                    if (!passport.IsMatch(gnic.Text.Trim()))
                    {
                        MessageBox.Show("check Passport Number'N0000000'..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else {
                        try
                        {
                            connection con = new connection();
                            if (btnSave.Text == "Save") // save function
                            {
                                SqlCommand cmd = new SqlCommand("AddorEditguest", con.Activecon());
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@mode", "Save");
                                cmd.Parameters.AddWithValue("@Id", 0);
                                cmd.Parameters.AddWithValue("@caption", captionbox.Text.Trim());
                                cmd.Parameters.AddWithValue("@fname", gfname.Text.Trim());
                                cmd.Parameters.AddWithValue("@lname", glname.Text.Trim());
                                if (nicbutton.Checked == true)
                                {
                                    cmd.Parameters.AddWithValue("@indentity", "NIC");
                                    cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                }
                                if (passportnum.Checked == true)
                                {

                                    cmd.Parameters.AddWithValue("@indentity", "Passport");
                                    cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                }

                                cmd.Parameters.AddWithValue("@gender", ggender.Text.Trim());
                                cmd.Parameters.AddWithValue("@dob", gdatet.Text.Trim());
                                cmd.Parameters.AddWithValue("@age", gage.Text.Trim());
                                cmd.Parameters.AddWithValue("@address", gadd.Text.Trim());
                                cmd.Parameters.AddWithValue("@phonenum", gphonenum.Text.Trim());
                                cmd.Parameters.AddWithValue("@status", "activate");

                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Guest Added Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                reset();
                            }
                            else {
                                if (MessageBox.Show("Do you Want to Update This data ", "Update data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)// Update functions
                                {
                                    gage.Enabled = true;
                                    SqlCommand cmd = new SqlCommand("AddorEditguest", con.Activecon());
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.AddWithValue("@mode", "update");
                                    cmd.Parameters.AddWithValue("@Id", Id);
                                    cmd.Parameters.AddWithValue("@caption", captionbox.Text.Trim());
                                    cmd.Parameters.AddWithValue("@fname", gfname.Text.Trim());
                                    cmd.Parameters.AddWithValue("@lname", glname.Text.Trim());
                                    if (nicbutton.Checked == true)
                                    {
                                        cmd.Parameters.AddWithValue("@indentity", "NIC");
                                        cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                    }
                                    if (passportnum.Checked == true)
                                    {

                                        cmd.Parameters.AddWithValue("@indentity", "Passport");
                                        cmd.Parameters.AddWithValue("@nic", gnic.Text.Trim());

                                    }
                                    cmd.Parameters.AddWithValue("@gender", ggender.Text.Trim());
                                    cmd.Parameters.AddWithValue("@dob", gdatet.Text.Trim());
                                    cmd.Parameters.AddWithValue("@age", gage.Text.Trim());
                                    cmd.Parameters.AddWithValue("@address", gadd.Text.Trim());
                                    cmd.Parameters.AddWithValue("@phonenum", gphonenum.Text.Trim());
                                    cmd.Parameters.AddWithValue("@status", "activate");
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show("Guest update Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    reset();



                                }
                            }



                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error ");
                        }
                        finally
                        {
                            reset();
                            FillDataGridView();


                        }

                    }


                }
            }

        }


        void FillDataGridView()
        { //  guest gird view search fuction
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter("guestVieworSearch", con.Activecon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@lname", gsearch.Text.Trim());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gdataGridView.DataSource = dt;
            // gdataGridView.Columns[0].Visible = false;


        }

        private void btngSearchR_Click(object sender, EventArgs e) // guest search button 
        {
            try
            {
                FillDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error ");
            }


        }

        private void gdataGridView_DoubleClick(object sender, EventArgs e) //double cilci grid view table update option
        {
            if (gdataGridView.CurrentRow.Index != -1)
            {
                try
                {
                    Id = Convert.ToInt32(gdataGridView.CurrentRow.Cells[0].Value.ToString());
                    captionbox.Text = gdataGridView.CurrentRow.Cells[1].Value.ToString();
                    gfname.Text = gdataGridView.CurrentRow.Cells[2].Value.ToString();
                    glname.Text = gdataGridView.CurrentRow.Cells[3].Value.ToString();
                    if (gdataGridView.CurrentRow.Cells[4].Value.ToString() == "NIC")
                    {
                        nicbutton.Checked = true;

                    }
                    else if (gdataGridView.CurrentRow.Cells[4].Value.ToString() == "Passport")
                    {
                        passportnum.Checked = true;
                    }
                    gnic.Text = gdataGridView.CurrentRow.Cells[5].Value.ToString();
                    ggender.Text = gdataGridView.CurrentRow.Cells[6].Value.ToString();
                    gdatet.Text = gdataGridView.CurrentRow.Cells[7].Value.ToString();
                    gage.Text = gdataGridView.CurrentRow.Cells[8].Value.ToString();
                    gadd.Text = gdataGridView.CurrentRow.Cells[9].Value.ToString();
                    gphonenum.Text = gdataGridView.CurrentRow.Cells[10].Value.ToString();


                    btnSave.Text = "Update";
                    BtnDelete.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("You selected Empty Row ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }





            }

        }

        void reset()
        {
            gfname.Text = glname.Text = gnic.Text = ggender.Text = gdatet.Text = gage.Text = gadd.Text = gphonenum.Text = captionbox.Text = "";
            label60.Text = null;
            label62.Text = null;
            label9.Text = null;
            label19.Text = null;
            label22.Text = null;
            label57.Text = null;

            label60.Text = null;
            label59.Text = null;
            label61.Text = null;
            label63.Text = null;
            label64.Text = null;
            label67.Text = null;
            label68.Text = null;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label33.ForeColor = Color.Black;
            label32.ForeColor = Color.Black;
            label37.ForeColor = Color.Black;
            label35.ForeColor = Color.Black;
            label36.ForeColor = Color.Black;
            label30.ForeColor = Color.Black;
            label31.ForeColor = Color.Black;



            btnSave.Text = "Save";

            Id = 0;
            BtnDelete.Enabled = false;


        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you Want to Remove This data ", "Remove data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    connection con = new connection();
                    SqlCommand cmd = new SqlCommand("deleteguest", con.Activecon());
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@Id", Id);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Guest Delete Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error ");

                }
                FillDataGridView();
                reset();
            }
        }
        //****************************************************************************END GUEST REGISTER PART********************************************************************************************

        //****************************************************************************START ADD ROOMS ***************************************************************************************************





        private void txtroomnum_Leave(object sender, EventArgs e)
        {
        }

        private void roomtype_Leave(object sender, EventArgs e) //roomtype validation 
        {

            if (string.IsNullOrWhiteSpace(roomtype.Text))
            {
                label14.ForeColor = Color.Red;
                label82.Text = "Please select the roomtype";
                MessageBox.Show("Please select the roomtype..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else
            {
                label14.ForeColor = Color.Black;
                label82.Text = " ";
            }

        }
        private void txtroomprice_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtroomprice.Text) || (txtroomprice.Text).Any(char.IsLetter) || (txtroomprice.Text).Any(char.IsPunctuation))
            {
                label83.Text = "enter the integer number only";
                label16.ForeColor = Color.Red;
                MessageBox.Show("enter the integer number only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {

                label83.Text = "";
                label16.ForeColor = Color.Black;
            }

        }
        private void txtnumofbed_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtnumofbed.Text) || (txtnumofbed.Text).Any(char.IsLetter) || (txtnumofbed.Text).Any(char.IsPunctuation))
            {
                label84.Text = "enter the integer number only";
                label13.ForeColor = Color.Red;
                MessageBox.Show("enter the integer number only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else {
                label84.Text = "";
                label13.ForeColor = Color.Black;

            }
        }







        private void btnroomadd_Click(object sender, EventArgs e) // insert or update room function
        {
            connection con = new connection();

            if ((roomtype.Text == "") || (txtroomprice.Text == "") || (txtnumofbed.Text == "") || (string.IsNullOrWhiteSpace(txtnumofbed.Text) || (txtnumofbed.Text).Any(char.IsLetter) || (txtnumofbed.Text).Any(char.IsPunctuation)) || (string.IsNullOrWhiteSpace(txtroomprice.Text) || (txtroomprice.Text).Any(char.IsLetter) || (txtroomprice.Text).Any(char.IsPunctuation)))

            {
                MessageBox.Show("One or more Fields are Empty..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else {
                try
                {
                    if (btnroomadd.Text == "ADD") // save function
                    {
                        SqlCommand cmd = new SqlCommand("Addorupdateroom", con.Activecon());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mode", "ADD");
                        //cmd.Parameters.AddWithValue("@Id",0);
                        cmd.Parameters.AddWithValue("@roomnum", 0);
                        cmd.Parameters.AddWithValue("@roomtype", roomtype.Text.Trim());
                        cmd.Parameters.AddWithValue("@roomprice", txtroomprice.Text.Trim());
                        cmd.Parameters.AddWithValue("@numOfbed ", txtnumofbed.Text.Trim());
                        cmd.Parameters.AddWithValue("@state", 0);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Room Added Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Roomreset();
                        FillDataroomGridView();

                        // getroomtype();
                    }
                    else { // room details update
                        if (MessageBox.Show("Do you Want to Update This data ", "Update data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)// Update functions
                        {
                            SqlCommand cmd = new SqlCommand("Addorupdateroom", con.Activecon());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@mode", "Update");
                            //cmd.Parameters.AddWithValue("@Id", Id);
                            cmd.Parameters.AddWithValue("@roomnum", txtroomnum.Text.Trim());
                            cmd.Parameters.AddWithValue("@roomtype", roomtype.Text.Trim());
                            cmd.Parameters.AddWithValue("@roomprice", txtroomprice.Text.Trim());
                            cmd.Parameters.AddWithValue("@numOfbed", txtnumofbed.Text.Trim());
                            cmd.Parameters.AddWithValue("@state", Id);


                            cmd.ExecuteNonQuery();

                            MessageBox.Show("room update Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Roomreset();
                            FillDataroomGridView();

                            // getroomtype();



                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error ");//MessageBox.Show("room number already insert pls try again", "Error ");
                }

            }

        }

        void FillDataroomGridView()
        { //room datagridview
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter("roomviewOrsearch", con.Activecon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@roomtype", adroomsearch.Text.Trim());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridViewrom.DataSource = dt;
            //dataGridViewrom.Columns[5].Visible = false;
            dataGridViewrom.Columns[4].Visible = false;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            FillDataroomGridView();
        }

        private void dataGridViewrom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridViewrom_DoubleClick(object sender, EventArgs e)//datagrid view room

        {
            if (dataGridViewrom.CurrentRow.Index != -1)
            {
                txtroomnum.Text = dataGridViewrom.CurrentRow.Cells[0].Value.ToString();
                roomtype.Text = dataGridViewrom.CurrentRow.Cells[1].Value.ToString();
                txtroomprice.Text = dataGridViewrom.CurrentRow.Cells[2].Value.ToString();
                txtnumofbed.Text = dataGridViewrom.CurrentRow.Cells[3].Value.ToString();
                Id = Convert.ToInt32(dataGridViewrom.CurrentRow.Cells[4].Value.ToString());
                btnroomadd.Text = "Update";
                btnDelete1.Enabled = true;
                txtroomnum.Enabled = false;


            }
        }
        void Roomreset()
        {
            txtroomnum.Text = roomtype.Text = txtroomprice.Text = txtnumofbed.Text = "";
            btnroomadd.Text = "ADD";
            txtroomnum.Enabled = false;
            btnDelete1.Enabled = false;
            label84.Text = "";
            label13.ForeColor = Color.Black;
            label83.Text = "";
            label16.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            label82.Text = " ";


        }

        private void roomrest1_Click(object sender, EventArgs e)
        {
            Roomreset();
        }

        private void btnDelete1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you Want to Remove This data ", "Remove data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    btnDelete1.Enabled = true;
                    connection con = new connection();
                    SqlCommand cmd = new SqlCommand("roomdelete", con.Activecon());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@num", txtroomnum.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Room Delete Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Roomreset();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error ");

                }
            }
        }


        //*************************************************************ADD ROOM FUNCTION***********************************************************************
        //*************************************************************CHECK IN &CHECK OUT FUNCTION START******************************************************



        private void txtguestId_Click(object sender, EventArgs e)
        {

        }
        private void comboBox2_Leave(object sender, EventArgs e)// room selection validation
        {
            if (string.IsNullOrWhiteSpace(comboBox2.Text))
            {

                label77.Text = "Choose room  Type";
                label28.ForeColor = Color.Red;
                MessageBox.Show("Choose room  Type..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else
            {
                label77.Text = "";
                label28.ForeColor = Color.Black;
                Roomtype = comboBox2.Text.Trim();
            }
        }

        private void comboBoxroomnum_Leave(object sender, EventArgs e) //room type validation 
        {

            if (string.IsNullOrWhiteSpace(comboBoxroomnum.Text))
            {

                label78.Text = "Choose room number";
                label25.ForeColor = Color.Red;
                MessageBox.Show("Choose room number..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



            }
            else
            {
                label78.Text = "";
                label25.ForeColor = Color.Black;

            }
        }


        private void txtguestId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtguestId.Text) || (txtguestId.Text).Any(char.IsLetter) || (txtguestId.Text).Any(char.IsPunctuation))
            {

                label65.Text = " check GuestId & Enter the number only";
                label27.ForeColor = Color.Red;
                MessageBox.Show("check GuestId & Enter the number only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                label65.Text = "";
                label27.ForeColor = Color.Black;
                guestnum = Convert.ToInt32(txtguestId.Text.ToString());

            }
        }



        private void numofguesttxt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(numofguesttxt.Text) || (numofguesttxt.Text).Any(char.IsLetter) || (numofguesttxt.Text).Any(char.IsPunctuation))
            {

                label66.Text = " check  & Enter the number only";
                label23.ForeColor = Color.Red;
                MessageBox.Show("check  & Enter the number only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }

            else
            {

                label66.Text = "";
                label23.ForeColor = Color.Black;
            }
        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox5.Text) || (textBox5.Text).Any(char.IsLetter) || (textBox5.Text).Any(char.IsPunctuation))
            {

                label80.Text = " check  & Enter the number only";
                label79.ForeColor = Color.Red;
                MessageBox.Show("check  & Enter the number only..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else
            {

                label80.Text = "";
                label79.ForeColor = Color.Black;
            }
        }
        /*  void getroomtype() { // roomreseversion get roomtype 
              connection con = new connection();
              SqlCommand cmd2 = new SqlCommand(@"select * From [rooms] Where [state]='" + 0 + "'", con.Activecon());
              SqlDataReader rd2 = cmd2.ExecuteReader();
              rd2.Read();
              Roomtype = (rd2["roomtype"].ToString());

          }*/





        void availableroom()
        { //  available room view
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from rooms where state=0", con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1 || dt.Rows.Count > 1)
            {
                available.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = available.Rows.Add();
                    // available.Rows[n].Cells[0].Value = (n + 1).ToString();
                    available.Rows[n].Cells[0].Value = item["roomnum"].ToString();
                    available.Rows[n].Cells[1].Value = item["roomtype"].ToString();
                    available.Rows[n].Cells[2].Value = item["roomprice"].ToString();
                    available.Rows[n].Cells[3].Value = item["nuOfbed"].ToString();
                    available.Sort(available.Columns[0], ListSortDirection.Ascending);
                    //available.Sort(available.Columns[0], ListSortDirection.Ascending);




                }
            }
            else
            {

                available.Rows.Clear();
                MessageBox.Show("There is No Room avaialble Records Found...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
        private void Avaibtnsearch_Click(object sender, EventArgs e)
        {
            availableroom();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) // get table type from database to drop down box
        {
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter(@"select roomtype From [rooms] Where [state]='" + 0 + "'", con.Activecon());
            DataTable dt = new DataTable();

            sda.Fill(dt);
            // getroomtype();
        }

        void Showroomtype()
        {
            comboBox2.Items.Clear();
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter(@"Select * From [rooms] Where [state]='" + 0 + "'", con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);


            foreach (DataRow item in dt.Rows)
            {
                comboBox2.Items.Add(item["roomtype"].ToString());
                // Roomtype=(item["roomtype"].ToString());

                //getroomtype();
            }

        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            Showroomtype();
        }

        private void comboBoxroomnum_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection con = new connection();


            SqlDataAdapter sda = new SqlDataAdapter(@"select roomnum From [rooms] Where [state]='" + 0 + "'AND [roomtype]='" + Roomtype + "'", con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        void Showroomnum()
        {
            comboBoxroomnum.Items.Clear();
            connection con = new connection();



            SqlDataAdapter SDA = new SqlDataAdapter(@"Select * From [rooms] Where [state]='" + 0 + "'AND [roomtype]='" + Roomtype + "'", con.Activecon());
            DataTable DT = new DataTable();
            SDA.Fill(DT);


            foreach (DataRow item in DT.Rows)
            {
                comboBoxroomnum.Items.Add(item["roomnum"]);

            }
        }

        private void comboBoxroomnum_DropDown(object sender, EventArgs e)
        {
            Showroomnum();
            Roomtype = null;
        }

        //check in 
        private void checkin_Click(object sender, EventArgs e)// check in function
        {
            ArrivaldateTimePicker1.Format = DateTimePickerFormat.Custom;
            ArrivaldateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            if ((comboBox2.Text == "") || (comboBoxroomnum.Text == "") || (txtguestId.Text == "") || (textBox5.Text == "") || (ArrivaldateTimePicker1.Text == "") || (numofguesttxt.Text == "") || string.IsNullOrWhiteSpace(txtguestId.Text) || (txtguestId.Text).Any(char.IsLetter) || (txtguestId.Text).Any(char.IsPunctuation) ||
              string.IsNullOrWhiteSpace(numofguesttxt.Text) || (numofguesttxt.Text).Any(char.IsLetter) || (numofguesttxt.Text).Any(char.IsPunctuation))
            {

                MessageBox.Show("One or more Fields are Empty..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {


                try
                {

                    try
                    {
                        connection connn = new connection();

                        SqlCommand cmd12 = new SqlCommand(@"Select * from Roomreservation where ReguestId='" + txtguestId.Text + "'AND roomnum='" + comboBoxroomnum.Text + "'", connn.Activecon());
                        SqlDataReader rdd = cmd12.ExecuteReader();
                        rdd.Read();

                        var ab = (rdd["currentstate"]).ToString();
                        var ba = (rdd["roombookingtype"]).ToString();


                        MessageBox.Show("already check in guest ID ..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                        if (checkin.Text == "CheckIn")
                        {
                            try
                            {
                                connection con = new connection();
                                SqlCommand cmd1 = new SqlCommand("Select * from guest where guestId='" + txtguestId.Text + "'", con.Activecon());
                                SqlDataReader rd = cmd1.ExecuteReader();
                                rd.Read();

                                String a = (rd["fname"]).ToString();
                                String b = (rd["lname"]).ToString();
                                connection conn = new connection();
                                SqlCommand smd7 = new SqlCommand(@"INSERT INTO [Roomreservation](roomtype,roomnum,ReguestId,fname,lname,arrivalDOB,numofguest,numOfnight,currentstate)VALUES('" + comboBox2.Text + "','" + comboBoxroomnum.Text + "','" + txtguestId.Text + " ','" + a + "','" + b + "','" + ArrivaldateTimePicker1.Text + "','" + numofguesttxt.Text + "','" + textBox5.Text + "','" + "IN" + "')", conn.Activecon());
                                smd7.ExecuteNonQuery();
                                checkintable();
                                MessageBox.Show("check in  Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                checkinreset();
                                searchroomCheckInDetails();
                                availableroom();

                            }
                            catch (Exception ex3) {
                                MessageBox.Show("Invalid guests ID ..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        else  {

                           

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR");

                }
            }


        }
        private void dataGridView4_DoubleClick(object sender, EventArgs e)// check in dobule click
        {
            if (dataGridView4.CurrentRow.Index != -1)
            {
                resernum = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value.ToString());
                comboBox2.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                comboBoxroomnum.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                txtguestId.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                numofguesttxt.Text = dataGridView4.CurrentRow.Cells[7].Value.ToString();
                textBox5.Text = dataGridView4.CurrentRow.Cells[8].Value.ToString();

                button15.Enabled = true;



            }
        }


        private void button15_Click(object sender, EventArgs e)// update
        {

        }

        void checkintable()
        { //table status not avaiable

            try
            {
                connection con = new connection();
                SqlCommand smd01 = new SqlCommand(@"UPDATE [rooms] SET [state]='" + 1 + "' WHERE [roomnum]='" + comboBoxroomnum.Text + "'", con.Activecon());
                smd01.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void checkoutgId_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(checkoutgId.Text) || (checkoutgId.Text).Any(char.IsLetter) || (checkoutgId.Text).Any(char.IsPunctuation))
            {

                label93.Text = " check  & Enter the number only";
                label21.ForeColor = Color.Red;
            }

            else
            {

                label93.Text = "";
                label21.ForeColor = Color.Black;

                numofroombooking();


            }
        }


        void numofroombooking()
        {//this function find guest booking rooms

            try
            {
                checkedListBox1.Items.Clear();
                connection con = new connection();
                SqlDataAdapter sda = new SqlDataAdapter(@"Select * From [Roomreservation] Where [ReguestId]='" + checkoutgId.Text + "'AND currentstate='" + "IN" + "'", con.Activecon());
                DataTable dt = new DataTable();
                sda.Fill(dt);


                foreach (DataRow item in dt.Rows)
                {


                    checkedListBox1.Items.Add(item["roomnum"].ToString());

                    // Roomtype=(item["roomtype"].ToString());

                    //getroomtype();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }



        //check out 
        private void btncheckout_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            if ((checkoutgId.Text == "") || (dateTimePicker2.Text == "") || (checkedListBox1.CheckedItems.Count==0) || (checkedListBox1.Items == null))
            {

                MessageBox.Show("One or more Fields are Empty..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {


                try
                {
                    int cd = 0;
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        if (checkedListBox1.GetItemChecked(i))
                        {


                            cd = 0;
                            numbercb = Convert.ToInt32(checkedListBox1.Items[i]);


                            connection con = new connection();

                            SqlCommand cmd1 = new SqlCommand(@"Select * from Roomreservation where ReguestId='" + checkoutgId.Text + "'AND roomnum='" + numbercb + "'", con.Activecon());
                            SqlDataReader rd = cmd1.ExecuteReader();
                            rd.Read();

                            var a = (rd["currentstate"]).ToString();
                            var b = (rd["roombookingtype"]).ToString();

                            if (a == "OUT")
                            {
                                MessageBox.Show("this guest id already Exit..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                cd = 1;
                            }
                            else {

                                try {
                                    connection conn = new connection();
                                    SqlCommand cmd = new SqlCommand(@"UPDATE [Roomreservation] SET [departuretime] ='" + dateTimePicker2.Text + " ',[currentstate]='" + "OUT" + "' WHERE [ReguestId] = '" + checkoutgId.Text + "'AND roomnum='" + numbercb + "'", conn.Activecon());



                                    cmd.ExecuteNonQuery();

                                    //smd1.ExecuteNonQuery();
                                    MessageBox.Show("check out  Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                    findroomprice();
                                    stateRemove();
                                    availableroom();


                                    CheckOutHistoryView();




                                    cd = 0;
                                }catch (Exception ex)
                {
                    MessageBox.Show("invalid input please check your Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

                            }
                        }
                    }

                    if (cd == 0)
                    {
                        calculate();


                        bill();
                        guestname();
                        guestmanagement.SelectTab(3);
                        label1.Text = "Bill";
                        checkoutreset();
                        ViewBill();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("invalid input please check your Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

                finally
                {

                }



            }

        }
        void stateRemove()
        {
            connection con = new connection();
            SqlCommand smd11 = new SqlCommand(@"UPDATE [rooms] SET [state]='" + 0 + "' WHERE [roomnum]='" + numbercb + "'", con.Activecon());
            smd11.ExecuteNonQuery();
        }

        void findroomprice()
        {


            connection con = new connection();

            SqlCommand cmd1 = new SqlCommand(@"Select * from rooms where roomnum='" + numbercb + "'", con.Activecon());
            SqlDataReader rd = cmd1.ExecuteReader();
            rd.Read();

            Rprice += Convert.ToInt32((rd["roomprice"]).ToString());



        }







        void searchroomCheckInDetails()
        { //view check in details
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter(@"Select Roomreservation,roomtype,roomnum,ReguestId,fname,lname,arrivalDOB,numofguest,numOfnight from [Roomreservation] WHERE currentstate='" + "IN" + "'AND lname LIKE'"+ textBox16.Text.Trim() + "%'", con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1 || dt.Rows.Count > 1)
            {
                dataGridView4.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView4.Rows.Add();
                    // dataGridView4.Rows[n].Cells[0].Value = (n + 1).ToString();
                    dataGridView4.Rows[n].Cells[0].Value = item["Roomreservation"].ToString();
                    dataGridView4.Rows[n].Cells[1].Value = item["roomtype"].ToString();
                    dataGridView4.Rows[n].Cells[2].Value = item["roomnum"].ToString();
                    dataGridView4.Rows[n].Cells[3].Value = item["ReguestId"].ToString();
                    dataGridView4.Rows[n].Cells[4].Value = item["fname"].ToString();
                    dataGridView4.Rows[n].Cells[5].Value = item["lname"].ToString();
                    dataGridView4.Rows[n].Cells[6].Value = item["arrivalDOB"].ToString();
                    dataGridView4.Rows[n].Cells[7].Value = item["numofguest"].ToString();
                    dataGridView4.Rows[n].Cells[8].Value = item["numOfnight"].ToString();

                    dataGridView4.Sort(dataGridView4.Columns[1], ListSortDirection.Ascending);
                    // dataGridView4.Sort(dataGridView4.Columns[0], ListSortDirection.Ascending);


                }

            }
            else {
                dataGridView4.Rows.Clear();
                MessageBox.Show("There are  No check in guests  avaialble Records Found...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //searchroomCheckInDetailsmore();


            }

        }
















        void CheckOutHistoryView()
        {

            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter(@"Select Roomreservation,roomtype,roomnum,ReguestId,fname,lname,arrivalDOB,numofguest,numOfnight,departuretime from [Roomreservation] WHERE currentstate='" + "OUT" + "'AND lname LIKE'"+ textBox1.Text.Trim() +"%'", con.Activecon());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1 || dt.Rows.Count > 1)
            {
                dataGridView2.Rows.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    int n = dataGridView2.Rows.Add();
                    // dataGridView4.Rows[n].Cells[0].Value = (n + 1).ToString();
                    dataGridView2.Rows[n].Cells[0].Value = item["Roomreservation"].ToString();
                    dataGridView2.Rows[n].Cells[1].Value = item["roomtype"].ToString();
                    dataGridView2.Rows[n].Cells[2].Value = item["roomnum"].ToString();
                    dataGridView2.Rows[n].Cells[3].Value = item["ReguestId"].ToString();
                    dataGridView2.Rows[n].Cells[4].Value = item["fname"].ToString();
                    dataGridView2.Rows[n].Cells[5].Value = item["lname"].ToString();
                    dataGridView2.Rows[n].Cells[6].Value = item["arrivalDOB"].ToString();
                    dataGridView2.Rows[n].Cells[7].Value = item["numofguest"].ToString();
                    dataGridView2.Rows[n].Cells[8].Value = item["numOfnight"].ToString();
                    dataGridView2.Rows[n].Cells[9].Value = item["departuretime"].ToString();
                    // dataGridView2.Sort(dataGridView2.Columns[1], ListSortDirection.Ascending);
                    dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);


                }

            }
            else {
                dataGridView4.Rows.Clear();
                MessageBox.Show("There are  No check out  avaialble Records Found...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }



        }

        private void button6_Click(object sender, EventArgs e) //view check out search button
        {
            CheckOutHistoryView();
        }


        private void button5_Click(object sender, EventArgs e) //view checkin search button
        {
            searchroomCheckInDetails();


        }
        private void button9_Click(object sender, EventArgs e)// check in reset button
        {
            checkinreset();
        }
        void checkinreset()
        {
            label65.Text = null;
            comboBox2.Text = null;
            comboBoxroomnum.Text = null;
            txtguestId.Text = null;
            textBox5.Text = null;
            ArrivaldateTimePicker1.Text = null;
            numofguesttxt.Text = null;
            label66.Text = null;
            label77.Text = null;
            label78.Text = null;
            label80.Text = null;
            label23.ForeColor = Color.Black;
            label25.ForeColor = Color.Black;
            label27.ForeColor = Color.Black;
            label28.ForeColor = Color.Black;
            label79.ForeColor = Color.Black;
            button15.Enabled =false;



        }

        void checkoutreset()
        {
            checkoutgId.Text = null;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }




        }





        //Bill calculation


        void calculate()
        { //get the data form the roomservation and count days one room


            try
            {
                connection con = new connection();
                SqlCommand cmd = new SqlCommand(@"Select * from Roomreservation where ReguestId='" + checkoutgId.Text + "'AND roomnum='" + numbercb + "' ", con.Activecon());
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                var a = (rd["arrivalDOB"]).ToString();
                var b = (rd["departuretime"]).ToString();
                int num = Convert.ToInt32((rd["roomnum"]).ToString());
                var format = "MM/dd/yyyy hh:mm:ss";



                DateTime t = Convert.ToDateTime(a);
                DateTime t1 = Convert.ToDateTime(b);
                DateTime h = t.Date;
                DateTime h1 = t1.Date;
                TimeSpan tspan = h1.Subtract(h);

                billroomtype.Text = (rd["roomtype"].ToString());
                billroomnum.Text = (rd["roomnum"].ToString());
                billnumOfguest.Text = (rd["numofguest"].ToString());

                roomnumber = Convert.ToInt32((rd["roomnum"].ToString()));
                textBox9.Text = (rd["ReguestId"].ToString());
                billdateA.Text = a;
                billdated.Text = b;







                differenceInDays = Convert.ToInt32(Math.Round((double)(tspan.Days))) + 1;
                tnumofnight.Text = differenceInDays.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }

            //  billdateA.Text = differenceInDays.ToString();

            //int total =( Rprice * differenceInDays);
            // totalbill.Text = Rprice.ToString();
        }


        private void texFname_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(texFname.Text) || (texFname.Text).Any(char.IsDigit) || (texFname.Text).Any(char.IsPunctuation))
            {
                label86.Text = "Enter letter only";
                label3.ForeColor = Color.Red;
            }
            else {
                label86.Text = "";
                label3.ForeColor = Color.Black;

            }

        }

        private void billroomtype_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(billroomtype.Text) || (billroomtype.Text).Any(char.IsDigit) || (billroomtype.Text).Any(char.IsPunctuation))
            {
                label87.Text = "Enter letter only";
                label11.ForeColor = Color.Red;
            }
            else {
                label87.Text = "";
                label11.ForeColor = Color.Black;

            }

        }
        private void billroomnum_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(billroomnum.Text) || (billroomnum.Text).Any(char.IsLetter) || (billroomnum.Text).Any(char.IsPunctuation))
            {

                label88.Text = " check roomnum & Enter the number only";
                label17.ForeColor = Color.Red;
            }

            else
            {
                label88.Text = "";
                label17.ForeColor = Color.Black;
            }

        }
        private void billnumOfguest_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(billnumOfguest.Text) || (billnumOfguest.Text).Any(char.IsLetter) || (billnumOfguest.Text).Any(char.IsPunctuation))
            {

                label89.Text = "Enter the number only";
                label7.ForeColor = Color.Red;
            }

            else
            {
                label89.Text = "";
                label7.ForeColor = Color.Black;
            }
        }

        private void totalbill_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(totalbill.Text) || (totalbill.Text).Any(char.IsLetter) || (totalbill.Text).Any(char.IsPunctuation))
            {

                label90.Text = "Enter the number only";
                label6.ForeColor = Color.Red;
            }

            else
            {
                label90.Text = "";
                label6.ForeColor = Color.Black;
            }
        }

        private void tnumofnight_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tnumofnight.Text) || (tnumofnight.Text).Any(char.IsLetter) || (tnumofnight.Text).Any(char.IsPunctuation))
            {

                label91.Text = "Enter the number only";
                label85.ForeColor = Color.Red;
            }

            else
            {
                label91.Text = "";
                label85.ForeColor = Color.Black;
            }


        }
        private void radioButton1_Leave(object sender, EventArgs e)
        {
            radiovalidation();
        }

        void radiovalidation()
        {
            if (!(radioButton1.Checked == true || radioButton2.Checked == true))
            {
                label92.Text = "Select  one";
            }
            else {
                label92.Text = "";
            }
        }


        private void button2_Click(object sender, EventArgs e) // bill save database from
        {
            Rprice = 0;
            if (string.IsNullOrWhiteSpace(tnumofnight.Text) || (tnumofnight.Text).Any(char.IsLetter) || (tnumofnight.Text).Any(char.IsPunctuation) || string.IsNullOrWhiteSpace(totalbill.Text) || (totalbill.Text).Any(char.IsLetter) ||
               string.IsNullOrWhiteSpace(billnumOfguest.Text) || (billnumOfguest.Text).Any(char.IsLetter) || (billnumOfguest.Text).Any(char.IsPunctuation) || string.IsNullOrWhiteSpace(billroomnum.Text) || (billroomnum.Text).Any(char.IsLetter) || (billroomnum.Text).Any(char.IsPunctuation) ||
               string.IsNullOrWhiteSpace(billroomtype.Text) || (billroomtype.Text).Any(char.IsDigit) || (billroomtype.Text).Any(char.IsPunctuation) || string.IsNullOrWhiteSpace(texFname.Text) || (texFname.Text).Any(char.IsDigit) || (texFname.Text).Any(char.IsPunctuation) || (!(radioButton1.Checked == true || radioButton2.Checked == true)))
            {

                MessageBox.Show("One or more Fields are Empty..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                connection con = new connection();
                try
                {

                    if (button2.Text == "Save") // save function
                    {
                        SqlCommand cmd = new SqlCommand("addBill", con.Activecon());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mode", "Save");
                        cmd.Parameters.AddWithValue("@billId", 0);
                        cmd.Parameters.AddWithValue("@guestname", texFname.Text.Trim());
                        cmd.Parameters.AddWithValue("@roomtype", billroomtype.Text.Trim());
                        cmd.Parameters.AddWithValue("@roomnum", billroomnum.Text.Trim());
                        DateTime ad = Convert.ToDateTime(billdateA.Text.Trim());
                        cmd.Parameters.AddWithValue("@arrivaldate", ad);
                        cmd.Parameters.AddWithValue("@numofguests", billnumOfguest.Text.Trim());
                        cmd.Parameters.AddWithValue("@numofnight", tnumofnight.Text.Trim());
                        DateTime dd = Convert.ToDateTime(billdated.Text.Trim());
                        cmd.Parameters.AddWithValue("@depaturedate", dd);
                        if (textBox6.Text == null)
                        {
                            cmd.Parameters.AddWithValue("@ExtraBill", 0);
                        }
                        else {
                            cmd.Parameters.AddWithValue("@ExtraBill", textBox6.Text.Trim());
                        }
                        if (textBox7.Text == null)
                        {
                            cmd.Parameters.AddWithValue("@discount", 0);
                        }
                        else {
                            cmd.Parameters.AddWithValue("@discount", textBox7.Text.Trim());
                        }

                        cmd.Parameters.AddWithValue("@totalbill", totalbill.Text.Trim());

                        if (radioButton1.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@paymentMeth", "card");
                        }
                        if (radioButton2.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@paymentMeth", "cash");
                        }
                        cmd.Parameters.AddWithValue("@guestId", textBox9.Text.Trim());
                        cmd.Parameters.AddWithValue("@dltstatus", "IN");
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Bill adda Successfully...!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        showbill();
                        ViewBill();
                        resetbill();


                    }
                    else if (button2.Text == "Update"){

                        SqlCommand cmd = new SqlCommand("addBill", con.Activecon());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@mode", "Update");
                        cmd.Parameters.AddWithValue("@billId", billid);
                        cmd.Parameters.AddWithValue("@guestname", texFname.Text.Trim());
                        cmd.Parameters.AddWithValue("@roomtype", billroomtype.Text.Trim());
                        cmd.Parameters.AddWithValue("@roomnum", billroomnum.Text.Trim());
                        DateTime ad = Convert.ToDateTime(billdateA.Text.Trim());
                        cmd.Parameters.AddWithValue("@arrivaldate", ad);
                        cmd.Parameters.AddWithValue("@numofguests", billnumOfguest.Text.Trim());
                        cmd.Parameters.AddWithValue("@numofnight", tnumofnight.Text.Trim());
                        DateTime dd = Convert.ToDateTime(billdated.Text.Trim());
                        cmd.Parameters.AddWithValue("@depaturedate", dd);
                      
                        if (textBox6.Text == null)
                        {
                            cmd.Parameters.AddWithValue("@ExtraBill", 0);
                        }
                        else {
                            cmd.Parameters.AddWithValue("@ExtraBill", textBox6.Text.Trim());
                        }
                        if (textBox7.Text == null)
                        {
                            cmd.Parameters.AddWithValue("@discount", 0);
                        }
                        else {
                            cmd.Parameters.AddWithValue("@discount", textBox7.Text.Trim());
                        }

                        cmd.Parameters.AddWithValue("@totalbill", totalbill.Text.Trim());

                        if (radioButton1.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@paymentMeth", "card");
                        }
                        if (radioButton2.Checked == true)
                        {
                            cmd.Parameters.AddWithValue("@paymentMeth", "cash");
                        }
                        cmd.Parameters.AddWithValue("@guestId", textBox9.Text);
                        cmd.Parameters.AddWithValue("@dltstatus", "IN");
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Bill adda Update...!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        showbill();
                        ViewBill();
                        resetbill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                finally
                {

                }
            }
        }

        void resetbill()
        {//bill text box reset
            texFname.Text = "";
            billroomtype.Text = "";
            billroomnum.Text = "";
            billdateA.Text = "";
            billnumOfguest.Text = "";
            tnumofnight.Text = "";
            billdated.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            totalbill.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            texFname.Enabled = true;
            billroomtype.Enabled = true;
            billroomnum.Enabled = true;
            billdateA.Enabled = true;
            billnumOfguest.Enabled = true;
            tnumofnight.Enabled = true;
            billdated.Enabled = true;
            totalbill.Enabled = true;
            textBox9.Text = "";
            button2.Text = "Save";

        }

    /*    void printBills() {
            setvalueforText1 = (billid.ToString());
            setvalueforText2 = (texFname.Text);
            setvalueforText3 = (billroomtype.Text);
            setvalueforText4 = (billroomnum.Text);
            setvalueforText5 = (billdateA.Text);
            setvalueforText6 = (billnumOfguest.Text);
            setvalueforText7 = (tnumofnight.Text);
            setvalueforText8 = (billdated.Text);
            setvalueforText9 = (textBox6.Text);
            setvalueforText10 = (textBox7.Text);
            setvalueforText11 = (totalbill.Text);
            if (radioButton1.Checked == true) {
                setvalueforText12 = ("card");
            }
            if (radioButton2.Checked == true) {
                setvalueforText12 = ("cash");
            }
           
           
        }*/

        private void dataGridView1_DoubleClick(object sender, EventArgs e) // double click show bill 
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                billid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                texFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                billroomtype.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                billroomnum.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                billdateA.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                billnumOfguest.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                tnumofnight.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                billdated.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                totalbill.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                if (dataGridView1.CurrentRow.Cells[11].Value.ToString() == "card")
                {
                    radioButton1.Checked = true;
                }
                if (dataGridView1.CurrentRow.Cells[11].Value.ToString() == "cash")
                {
                    radioButton2.Checked = true;
                }
                textBox9.Text= dataGridView1.CurrentRow.Cells[12].Value.ToString();


                button2.Text = "Update";
                texFname.Enabled = false;
                billroomtype.Enabled = false;
                billroomnum.Enabled = false;
                billdateA.Enabled = false;
                billnumOfguest.Enabled = false;
                tnumofnight.Enabled = false;
                billdated.Enabled = false;
                totalbill.Enabled = false;
                textBox9.Enabled = false;








            }

        }
        private void btnprint1_Click(object sender, EventArgs e) // print bill function
        {
            //showbill();
            //ViewBill();
            //printBills();
            resetbill();
            Rprice = 0;
        }

        void showbill()
        {  //show bill

            try
            {
                connection con = new connection();
                SqlCommand cmd = new SqlCommand("Select * from bill where guestID='" + textBox9.Text + "'and roomnum='" + billroomnum.Text + "'", con.Activecon());
                SqlDataReader rd = cmd.ExecuteReader();
                rd.Read();
                String date = (rd["depaturedate"].ToString());
                DateTime dd = Convert.ToDateTime(date);


                /* connection connn = new connection();
                   SqlCommand cmdd = new SqlCommand("addBill", connn.Activecon());
                   cmdd.CommandType = CommandType.StoredProcedure;
                   cmdd.Parameters.AddWithValue("@guestId", guestId);
                   cmdd.Parameters.AddWithValue("@date", dd);*/


                int id = Convert.ToInt32(textBox9.Text.ToString());

             
                ViewBills vb = new ViewBills(date,id);
                vb.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

            }

        }


        void from2clear()
        { //clear pass value to bill
            setvalueforText1 = "";
            setvalueforText2 = "";
            setvalueforText3 = "";
            setvalueforText4 = "";
            setvalueforText5 = "";
            setvalueforText6 = "";
            setvalueforText7 = "";
            setvalueforText8 = "";
            setvalueforText9 = "";
            setvalueforText10 = "";
            setvalueforText11 = "";
            setvalueforText12 = "";
        }






        void bill()
        { //calculate the room bill

            // extr = Convert.ToInt32(textBox6.Text);
            float total = (Rprice * differenceInDays);
            totalbill.Text = total.ToString();
        }
        private void textBox6_Leave(object sender, EventArgs e)//add extra bill + and totel bill;
        {



        }
        private void billAdd_Click(object sender, EventArgs e) // add bill
        {

            if (textBox6.Text == null)
            {
                float a = Convert.ToInt32(totalbill.Text.ToString());
                float b = 0;

                float finaly = a + b;
                totalbill.Text = finaly.ToString();

            }
            else {
                float a = float.Parse(totalbill.Text.ToString());
                float b = float.Parse(textBox6.Text.ToString());

                float finaly = a + b;
                totalbill.Text = finaly.ToString();
            }

        }
        private void subbill_Click(object sender, EventArgs e)//subract

        {

            if (textBox6.Text == null)
            {
                float a = float.Parse(totalbill.Text.ToString());
                float b = 0;

                float finaly = a - b;
                totalbill.Text = finaly.ToString();

            }
            else {
                float a = float.Parse(totalbill.Text.ToString());
                float b = float.Parse(textBox6.Text.ToString());

                float finaly = a - b;
                totalbill.Text = finaly.ToString();
            }

        }
        private void textBox7_Leave(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox7 == null)
            {
                float total = float.Parse(totalbill.Text.ToString());
                float netprice = total - 0;
                totalbill.Text = netprice.ToString();
            }
            else {

                float total = float.Parse((totalbill.Text.ToString()));
                float discount = float.Parse(textBox7.Text.ToString());
                float caluate_discount = (total*(discount / 100));
                float netprice = (total - caluate_discount);
                totalbill.Text = netprice.ToString();
            }
        }
        void guestname()
        {

            int gid = Convert.ToInt32(checkoutgId.Text);
            connection con = new connection();
            SqlCommand cmd2 = new SqlCommand("Select * from guest where guestId='" + gid + "'", con.Activecon());
            SqlDataReader rd2 = cmd2.ExecuteReader();
            rd2.Read();

            texFname.Text = (rd2["fname"].ToString());

        }

        void ViewBill()
        {
            connection con = new connection();
            SqlDataAdapter sda = new SqlDataAdapter("viewbilldatagried", con.Activecon());
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sda.SelectCommand.Parameters.AddWithValue("@guestname", textBox8.Text.Trim());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            //dataGridViewrom.Columns[5].Visible = false;
            // dataGridView1.Columns[4].Visible = false;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            ViewBill();
        }
        private void button14_Click(object sender, EventArgs e)// deleted bills
        {
            if (MessageBox.Show("Do you Want to Remove This data ", "Remove data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    connection con = new connection();
                    SqlCommand cmd = new SqlCommand("deletedBill", con.Activecon());
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@billId", billid);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Guest Delete Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ViewBill();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error ");

                }
            }
        }



        private void button4_Leave(object sender, EventArgs e)
        {

        }



        private void ggender_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void billdated_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void texFname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox2_Leave(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)//guests report button
        {
            guestReport dr = new guestReport();
            dr.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RoomBooking rb = new RoomBooking();
            rb.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Biilview b1 = new Biilview();
            b1.Show();
        }

        private void ArrivaldateTimePicker1_Leave(object sender, EventArgs e)
        {
            if (ArrivaldateTimePicker1.Value.Date == DateTime.Now.Date)
            {

            }
            else {
                MessageBox.Show("Please check checkin date..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dateTimePicker2_Leave(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value.Date ==DateTime.Now.Date)
            {

            }
            else {
                MessageBox.Show("Please check checkout date..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView4_Leave(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

