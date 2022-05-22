using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dental_Clinic_Managment_System
{
    public partial class Products : Form

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
        public Products()
        {
            InitializeComponent();
            ProductsDGV.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProductsDGV.Width, ProductsDGV.Height, 50, 50));

        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SaRa Ali\Documents\MusicDB.mdf;Integrated Security=True;Connect Timeout=30");
        int Key;

        bool Authenticate() //Verfication
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtcost.Text) ||
                string.IsNullOrWhiteSpace(combobrand.SelectedItem.ToString()))

                return false;
            else
                return true;
        }
        private void excute()
        {
            con.Open();
            string query = "select * from ProductsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            con.Close();

        }

        private void filter()
        {
            con.Open();
            string query = "select * from ProductsTbl where Brand='" + combosearch.SelectedItem.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV.DataSource = ds.Tables[0];
            con.Close();

        }

        private void Reset()
        {
            txtname.Text = "";
            combobrand.SelectedIndex = -1;
            combocateg.SelectedIndex = -1;
            numericqty.Value = 0;
            txtcost.Text = "";
            txtname.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
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
                    string query ="insert into ProductsTbl values('"+ txtname.Text + "', '" + combobrand.SelectedItem.ToString() + "', '" + combocateg.SelectedItem.ToString() + "', '" + numericqty.Value.ToString() + "', '" + txtcost.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Instrument Saved Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                    excute();
                    Reset();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        

        
        private void button3_Click(object sender, EventArgs e)
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
                    string query = "delete from ProductsTbl where ID= " + Key +"";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Instrument Information Deleted Successfully", "Success",
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

        

        private void Products_Load(object sender, EventArgs e)
        {
            excute();
        }

        private void button2_Click(object sender, EventArgs e)
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
                    string query = "update ProductsTbl set Name='" + txtname.Text + "', Brand='" + combobrand.SelectedItem.ToString() + "', Category='" + combocateg.SelectedItem.ToString() 
                                + "', Quantity='" + numericqty.Value.ToString() + "', Cost='" + txtcost.Text + "' where ID="+ Key +";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Instrument Information Updated Successfully", "Success",
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

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filter();
        }

        

        private void productGDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = ProductsDGV.SelectedRows[0].Cells[1].Value.ToString();
            combobrand.SelectedItem = ProductsDGV.SelectedRows[0].Cells[2].Value.ToString();
            combocateg.SelectedItem = ProductsDGV.SelectedRows[0].Cells[3].Value.ToString();
            numericqty.Value = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[4].Value.ToString());
            txtcost.Text = ProductsDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (txtname.Text == "")
            {
                Key = 0;
            }
            else
            {
               Key = Convert.ToInt32(ProductsDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            excute();
        }
    }
}
