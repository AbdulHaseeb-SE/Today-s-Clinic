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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            Database.conn.Open();

            int Gender;
            if (radio_confirmmale.Checked)
            {
                Gender = 0;
            }
            else
            {
                Gender = 1;
            }


            string querr = "select user_name,Email,gender from signUp where (user_name = '" + txt_ConfirmUname.Text + "' and Email = '" + txt_email.Text + "' and gender = '" + Gender + "' )";
            SqlDataAdapter sda = new SqlDataAdapter(querr, Database.conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                bunifuPages1.SetPage(tabPage2);
            }
            else
            {
                MessageBox.Show("Username , Email or Gender is not correct! \n Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Database.conn.Close();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {

        }

        private void btn_comfirm_Click(object sender, EventArgs e)
        {


            try
            {
                Database.conn.Open();
                SqlCommand cmd = new SqlCommand("update_Password", Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName", txt_ConfirmUname.Text);
                if (txt_newPassword.Text == txt_confPassword.Text)
                {
                    cmd.Parameters.AddWithValue("@NewPassword", txt_confPassword.Text);
                }
                else
                {
                    MessageBox.Show("Must Enter the same Password in \n New-Password Box & Confirm-New-Password Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               
                cmd.ExecuteNonQuery();
               DialogResult dr = MessageBox.Show("Your Password is changed Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if(dr == DialogResult.OK)
                {
                    Login l = new Login();
                    l.Show();
                    this.Hide();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Database.conn.Close();
            }
        }

        private void btn_goback_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }
    }
}
