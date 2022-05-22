using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace Dental_Clinic_Managment_System
{
    public partial class Users : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );
        public Users()
        {
            InitializeComponent();
            UsersDGV.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, UsersDGV.Width, UsersDGV.Height, 50, 50));

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SaRa Ali\Documents\MusicDB.mdf;Integrated Security=True;Connect Timeout=30");
        int Key;

        bool Authenticate() //Verfication
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))

                return false;
            else
                return true;
        }

        private void excute()
        {
            con.Open();
            string query = "select * from UsersTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersDGV.DataSource = ds.Tables[0];
            con.Close();

        }

        private void search()
        {
            con.Open();
            string query = "select * from UsersTbl where Name like'%" + txtsearch.Text + "%'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            UsersDGV.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Reset()
        {
            txtusername.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";
            
        }
        private void btnregister_Click(object sender, EventArgs e)
        {

            if (!Authenticate())
            {
                MessageBox.Show("Don't Keep Any Fields Blank! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                try
                {
                    con.Open();
                    string query = "insert into UsersTbl values('" + txtusername.Text + "', '" + txtcontact.Text + "', '" + txtemail.Text + "', '" + txtpassword.Text +"')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New User Added Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    excute();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Select User To Delete! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                try
                {
                    con.Open();
                    string query = "delete from UsersTbl where ID= " + Key + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Information Deleted Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    excute();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (!Authenticate())
            {
                MessageBox.Show("Select User To Updata! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                try
                {
                    con.Open();
                    string query = "update UsersTbl set Name='" + txtusername.Text + "', Contact='" + txtcontact.Text + "', Email='" + txtemail.Text + "', Password='" + txtpassword.Text + "' where ID=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("User Information Updated Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    excute();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            }

        private void Users_Load(object sender, EventArgs e)
        {
            excute();
        }

       

        private void UsersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtusername.Text = UsersDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtcontact.Text = UsersDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtemail.Text = UsersDGV.SelectedRows[0].Cells[3].Value.ToString();
            txtpassword.Text = UsersDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (txtusername.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(UsersDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            excute();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            search();
        }

        private void checkboxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkboxShowPass.Checked)
            {
                txtpassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '•';
            }
        }
    }
}
