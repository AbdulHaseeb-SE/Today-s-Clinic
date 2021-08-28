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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            bunifuPages1.SetPage(tabPage5);
        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_addPatient_Click(object sender, EventArgs e)
        {
            Patient p = new Patient();
            p.Show();
            this.Hide();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
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

        private void pictureBox_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox_minimized_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            if (bunifuGradientPanel2.Width == 250)
            {
                bunifuGradientPanel2.Width = 53;
                bunifuTransition1.ShowSync(bunifuGradientPanel2);

            }
            else
            {
                bunifuGradientPanel2.Width = 250;
                bunifuTransition1.ShowSync(bunifuGradientPanel2);

            }
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Setting");
            bunifuPages2.Visible = false;
            
        }

        private void btn_addDisease_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Add_Diseases");
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("insertinto_dmRelation", Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DiseaseCategory", DD_diseaseCategory.Text);
                cmd.Parameters.AddWithValue("@DiseaseName", txt_diseaseName.Text);
                cmd.Parameters.AddWithValue("@MedicineName", txt_medName.Text);

                Database.conn.Open();
                cmd.ExecuteNonQuery();

                DialogResult dr = MessageBox.Show("This Medicine is Sucessfully added + Do You want to ADD more medicine for Same Disease ?", "Successful", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dr == DialogResult.No)
                {
                    // DD_diseaseCategory.Focus();
                    DD_diseaseCategory.Enabled = true;
                    txt_diseaseName.Enabled = true;
                    DD_diseaseCategory.Text = "";
                    txt_diseaseName.Text = "";
                    txt_medName.Text = "";
                }
                else if (dr == DialogResult.Yes)
                {
                    txt_medName.Focus();
                    DD_diseaseCategory.Enabled = false;
                    txt_diseaseName.Enabled = false;
                    txt_medName.Text = "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Database.conn.Close();
        }

        private void DD_diseaseCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void btn_cpassword_Click(object sender, EventArgs e)
        {
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages2.Visible = true;
            bunifuPages2.SetPage(tabPage2);
            indicator1.Visible = true;
            indicator2.Visible = false;
            indicator3.Visible = false;

            try
            {
                Database.conn.Open();
                SqlCommand cmd = new SqlCommand("show_profile", Database.conn);

                SqlDataReader dr = cmd.ExecuteReader(); 
                while (dr.Read())
                {
                    txt_fname.Text = dr.GetValue(0).ToString();
                    txt_lname.Text = dr.GetValue(1).ToString();
                    txt_ftname.Text = dr.GetValue(2).ToString();
                    txt_uname.Text = dr.GetValue(3).ToString();
                    txt_gender.Text = dr.GetValue(4).ToString();
                    txt_ml.Text = dr.GetValue(5).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Database.conn.Close();
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages2.Visible = true;
            bunifuPages2.SetPage(tabPage6);
            indicator2.Visible = true;
            indicator1.Visible = false;
            indicator3.Visible = false;
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
                bunifuPages3.SetPage(tabPage8);
            }
            else
            {
                MessageBox.Show("Username , Email or Gender is not correct! \n Try Again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Database.conn.Close();
        }

        private void btn_comfirm_Click(object sender, EventArgs e)
        {

            try
            {
                Database.conn.Open();
                SqlCommand cmd = new SqlCommand("update_Password", Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserName",txt_ConfirmUname.Text);
                if (txt_newPassword.Text == txt_confPassword.Text)
                {
                    cmd.Parameters.AddWithValue("@NewPassword", txt_confPassword.Text);
                   DialogResult dr = MessageBox.Show("Succesfully changed your Password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   if(dr == DialogResult.OK)
                    {
                        bunifuPages1.SetPage(tabPage5);
                    }
                }
                else
                {
                    MessageBox.Show("Must Enter the same Password in \n New-Password Box & Confirm-New-Password Box", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                

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

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }
    }
}
