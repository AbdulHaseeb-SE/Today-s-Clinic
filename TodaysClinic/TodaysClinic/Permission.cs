using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodaysClinic
{
    public partial class Permission : Form
    {
        public Permission()
        {
            InitializeComponent();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
           // string aName,aPassword;
            //aName = "Abdul Haseeb";
            //aPassword = "zarkiqbal";
            if (txt_adminName.Text == "AbdulHaseeb" && txt_adminPassword.Text == "zarkiqbal")
            {
                SignUp s = new SignUp();
                s.Show();
                this.Hide();
            }
            else
            {
               DialogResult dr = MessageBox.Show("Invalid Admin's ID or Password \n Do you Want to try again?","Incorrect info",MessageBoxButtons.YesNo,MessageBoxIcon.Error );
            if(dr == DialogResult.Yes)
                {
                    this.Show();
                    txt_adminName.Focus();
                }
                else if (dr == DialogResult.No)
                {
                    Login l = new Login();
                    l.Show();
                    this.Hide();
                }

            }
        }

        private void btn_cancelPermission_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure, you want to cancel?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
           else
            {
                this.Show();
            }
        }

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
