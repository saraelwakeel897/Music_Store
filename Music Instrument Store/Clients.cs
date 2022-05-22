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
    public partial class Clients : Form
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
        public Clients()
        {
            InitializeComponent();
            ClientsDGV.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ClientsDGV.Width, ClientsDGV.Height, 50, 50));

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SaRa Ali\Documents\MusicDB.mdf;Integrated Security=True;Connect Timeout=30");
        int Key;

        bool Authenticate() //Verfication
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(txtcontact.Text))

                return false;
            else
                return true;
        }

        private void excute()
        {
            con.Open();
            string query = "select * from ClientsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ClientsDGV.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Search()
        {
            con.Open();
            string query = "select * from ClientsTbl where Name like '%" + txtsearch.Text + "%' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ClientsDGV.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Reset()
        {
            txtname.Text = "";
            txtcontact.Text = "";
            txtemail.Text = "";
            txtname.Focus();

        }

        private void btnsave_Click(object sender, EventArgs e)
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
                    string query = "insert into ClientsTbl values('" + txtname.Text + "', '" + txtcontact.Text + "', '" + txtemail.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Client Added Successfully", "Success",
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
                MessageBox.Show("Select Client to be deleted! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                try
                {
                    con.Open();
                    string query = "delete from ClientsTbl where ID= " + Key + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Information Deleted Successfully", "Success",
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
                MessageBox.Show("Select Client To Updata! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                try
                {
                    con.Open();
                    string query = "update ClientsTbl set Name='" + txtname.Text + "', Contact='" + txtcontact.Text + "', Email='" + txtemail.Text + "' where ID=" + Key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Client Information Updated Successfully", "Success",
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

        private void picrefresh_Click(object sender, EventArgs e)
        {
            excute();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            excute();
        }

        private void ClientsDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = ClientsDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtcontact.Text = ClientsDGV.SelectedRows[0].Cells[2].Value.ToString();
            txtemail.Text = ClientsDGV.SelectedRows[0].Cells[3].Value.ToString();
           
            if (txtname.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ClientsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Search();
        }


        
    }
}
