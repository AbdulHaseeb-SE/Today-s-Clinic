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
    public partial class Login : Form
    {
      
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void link_signUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Permission p = new Permission();
            p.Show();
            this.Hide();

        }

        private void btn_login_Click(object sender, EventArgs e)
        {

            if (Database.conn.State == ConnectionState.Open)
            {
                Database.conn.Close();
            }
            Database.conn.Open();
            string quer = "select user_name,password from signUp where (user_name = '" + txt_username.Text + "' and password = '" + txt_password.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(quer,Database.conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
               if(dt.Rows.Count==1)
            {
                main m = new main();
                m.Show();
                this.Hide();
            }
               else
            {
                MessageBox.Show("Invalid Username or Password \n Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Database.conn.Close();
        }

        private void link_forgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPassword rp = new ResetPassword();
            rp.Show();
            this.Hide();

        }
    }
}
