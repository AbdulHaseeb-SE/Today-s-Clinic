using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace TodaysClinic
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent() ;
        }

        private void bunifuRadioButton1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txt_firstname.Text = "";
            txt_lastname.Text = "";
            txt_fathername.Text = "";
            txt_Uname.Text = "";
            txt_passwordEnter.Text = "";
            txt_passwordConfirm.Text = "";
            txt_email.Text = "";
            radio_male.Checked = true;
            txt_firstname.Focus();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are You Sure, You want to cancel", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
           
            if(dr == DialogResult.Yes)
            {
                Login lgn = new Login();
                lgn.Show();
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_email.Text == "" || txt_fathername.Text == "" || txt_firstname.Text == "" || txt_lastname.Text == "" || txt_Uname.Text == "" || txt_passwordEnter.Text == "")
                {
                    MessageBox.Show("Please Complete Your Information!", "Incomplete info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int Gender;
                    if (radio_male.Checked)
                    {
                        Gender = 0;
                    }
                    else
                    {
                        Gender = 1;
                    }

                     string passwordvalue;
                     if(txt_passwordEnter.Text == txt_passwordConfirm.Text )
                     {
                        passwordvalue = txt_passwordEnter.Text;
                        string insertData;
                        insertData = "insert into signUp values ('" + txt_firstname.Text + "','" + txt_lastname.Text + "','" + txt_fathername.Text + "','" + txt_Uname.Text + "','"+passwordvalue+"','" + txt_email.Text + "','" + Gender + "')";

                        SqlCommand cmd = new SqlCommand(insertData, Database.conn);
                        Database.conn.Open();
                        cmd.ExecuteNonQuery();
                        DialogResult dr = MessageBox.Show("Your account is Successfully Created.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (dr == DialogResult.OK)
                        {
                            Login lg = new Login();
                            lg.Show();
                            this.Hide();
                        }
                    }
                     else
                     {
                         MessageBox.Show("Password doesn't Match! \n Try Again!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                     }
                   
                    Database.conn.Close();

                }

            }
            catch
            {
                MessageBox.Show("Username already exist \n Try different!","Duplication Exist",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                if(Database.conn.State==ConnectionState.Open)
                {
                    Database.conn.Close();
                }
            }
        }

        private void pictureBox_maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void pictureBox_minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radio_male_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_passwordEnter_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_passwordConfirm_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_Uname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_fathername_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_firstname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_lastname_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
