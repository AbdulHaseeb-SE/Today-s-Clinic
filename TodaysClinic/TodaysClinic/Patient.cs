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
    public partial class Patient : Form
    {
        public Patient()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            bunifuPages1.SetPage("PatientDetail");
        }

        private void radio_male_Click(object sender, EventArgs e)
        {

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

        private void btn_next_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_patientCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                Login l = new Login();
                l.Show();
                this.Hide();
            }
            else
            {
                this.Show();
                txt_patientName.Focus();
            }
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_list_Click(object sender, EventArgs e)
        {
            main mn = new main();
             mn.Show();
            this.Hide();
                
        }

        private void btn_list_Click_1(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_next_Click_1(object sender, EventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuGradientPanel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuFormDock1_FormDragging(object sender, Bunifu.UI.WinForms.BunifuFormDock.FormDraggingEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            
            
            
            /*
            int Gend;
            if (rb_male.Checked)
            {
                Gend = 0;
            }
            else
            {
                Gend = 1;
            }
            string insert;
            insert = "insert into patient (pName,pAge,pGender,Date) values ('" + txt_patientName.Text + "','" + txt_patientAge.Text + "', '" + Gend + "','" + date.Text + "' )";

            SqlCommand cmd = new SqlCommand(insert, Database.conn);
            Database.conn.Open();
            cmd.ExecuteNonQuery();
            DialogResult dr = MessageBox.Show("Patient's Data Saved Successfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {*/
           
            bunifuPages1.SetPage("Disease");
           // }

           // Database.conn.Close();
        }

        private void bunifuGradientPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_eyeDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Eye' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }
                    

                }
                else
                {

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

        private void btn_add_Click(object sender, EventArgs e)
        {
            foreach(string s in checkedListBox1.CheckedItems)
            {
                listBox2.Items.Add(s);
            }
        }

        private void btn_earDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Ear' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }
                    

                }
                else
                {

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

        private void btn_hairDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Hairs' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }

                }
                else
                {

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

        private void btn_skinDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Skin' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }

                }
                else
                {

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

        private void btn_heartDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Heart' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }

                }
                else
                {

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

        private void btn_brainDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Brain' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }

                }
                else
                {

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

        private void btn_feverCoughDiseases_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Fever,Cough' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }

                }
                else
                {

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

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                checkedListBox1.Items.Clear();
                if (checkedListBox1.Items.Count == 0)
                {
                    string quer = "select dName from Disease where category = 'Others' ";

                    Database.conn.Open();

                    SqlCommand cmd = new SqlCommand(quer, Database.conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        checkedListBox1.Items.Add(dr[0].ToString());
                    }

                }
                else
                {

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

        private void btn_remove_Click(object sender, EventArgs e)
        {
           if(listBox2.Items.Count > 0)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please Select an item first from SELECTED PROBLEMS to remove!");
            }
        }

        private void btn_saveall_click(object sender, EventArgs e)
        {
            int Gender;
            if (rb_male.Checked)
            {
                Gender = 0;
            }
            else
            {
                Gender = 1;
            }
            try
            {
                Database.conn.Open();
                SqlCommand cmd = new SqlCommand("Insert_Precord", Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                
                foreach (string s in listBox2.Items)
                {
                    
                    foreach (string s1 in listBox1.Items)

                    {
                       
                        cmd.Parameters.Clear();
                       
                            cmd.Parameters.AddWithValue("@PatientName", txt_patientName.Text);
                            cmd.Parameters.AddWithValue("@PatientAge", txt_patientAge.Text);
                            cmd.Parameters.AddWithValue("@PatientGender", Gender);
                            cmd.Parameters.AddWithValue("@Date", date.Value);
                            
                        
                        cmd.Parameters.AddWithValue("@DiseaseName", s);
                        cmd.Parameters.AddWithValue("@MedicineName", s1);
                        cmd.ExecuteNonQuery();
                    }
                         
                }
               
                
               DialogResult dr = MessageBox.Show("Successfully Added","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                if(dr== DialogResult.OK)
                {
                    bunifuPages1.SetPage("Patient");
                    txt_patientName.Text = "";
                    txt_patientAge.Text = "";

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

        private void btn_dne_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();

                Database.conn.Open();
                dt.Rows.Clear();
                SqlCommand cmd = new SqlCommand("show_medicine", Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DiseaseName",listBox2.SelectedItem.ToString());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                
                sda.Fill(dt);

                c1.DataPropertyName = dt.Columns["mName"].ToString();
                
                bunifuDataGridView1.DataSource = dt;
                

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

        private void btn_MedAdd_Click(object sender, EventArgs e)
        {


            //foreach (DataGridViewRow row in bunifuDataGridView1.SelectedRows)
            //{
            //    for (int i = 0; i < bunifuDataGridView1.SelectedRows.Count; i++)
            //    {
            //        if (listBox1.Items.Count >= 0)
            //        {
            //            listBox1.Items.Add(row.Cells[i].Value);
            //        }

            //    }

            //}

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void btn_list_Click_2(object sender, EventArgs e)
        {
            main m = new main();
            m.Show();
            this.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage("Patient");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_patientName_Validating(object sender, CancelEventArgs e)
        {
            if (Database.conn.State == ConnectionState.Open)
            {
                Database.conn.Close();
            }
            try
            {

                DataTable dt = new DataTable();

                Database.conn.Open();
            
                SqlCommand cmd = new SqlCommand("Show_Precord", Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PatientName", txt_patientName.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count >= 1 )
                {
                    p4.Visible = true;
                    p6.Visible = true;
                    
                        p1.DataPropertyName = dt.Columns["pName"].ToString();
                        p2.DataPropertyName = dt.Columns["pAge"].ToString();
                        p3.DataPropertyName = dt.Columns["Gender"].ToString();
                        p4.Visible = true;
                    
                        p4.DataPropertyName = dt.Columns["dName"].ToString();
                        p6.Visible = true;
                        p6.DataPropertyName = dt.Columns["mName"].ToString();
                        p5.DataPropertyName = dt.Columns["Date"].ToString();
                    

                        gridview_patient.DataSource = dt;
                
                   
                }
                else
                {
                   MessageBox.Show("New Patient!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txt_patientName_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void gridview_patient_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_search_Click_1(object sender, EventArgs e)
        {
            try
            {
                Database.conn.Open();
                
                SqlCommand cmd = new SqlCommand("show_allPatients",Database.conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count >= 1)
                {

                    p1.DataPropertyName = dt.Columns["pName"].ToString();
                    p2.DataPropertyName = dt.Columns["pAge"].ToString();
                    p3.DataPropertyName = dt.Columns["Gender"].ToString();
                    p4.Visible = false;
                    p5.DataPropertyName = dt.Columns["Date"].ToString();
                    p6.Visible = false;

                    gridview_patient.DataSource = dt;


                }
                else
                {
                    MessageBox.Show("No Patient Found!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_clrGV_Click(object sender, EventArgs e)
        {
           // gridview_patient.Rows.Clear();
        }

        private void bunifuDataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in bunifuDataGridView1.SelectedRows)
            {
                for (int i = 0; i < bunifuDataGridView1.SelectedRows.Count; i++)
                {
                    if (listBox1.Items.Count >= 0)
                    {
                        listBox1.Items.Add(row.Cells[i].Value);
                    }

                }

            }
        }
    }
}