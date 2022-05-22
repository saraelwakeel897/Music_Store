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
    public partial class Billing : Form
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
        public Billing()
        {
            InitializeComponent();
            BillingDGV.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, BillingDGV.Width, BillingDGV.Height, 50, 50));
            ProductsDGV2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ProductsDGV2.Width, ProductsDGV2.Height, 50, 50));
            ClientsDGV2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, ClientsDGV2.Width, ClientsDGV2.Height, 50, 50));
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SaRa Ali\Documents\MusicDB.mdf;Integrated Security=True;Connect Timeout=30");
        int key , stock;
        int totalprice = 0;

        bool Authenticate() //Verfication
        {
            if (string.IsNullOrWhiteSpace(txtclientname.Text) ||
                string.IsNullOrWhiteSpace(txtproductname.Text) ||
                string.IsNullOrWhiteSpace(txtprice.Text))

                return false;
            else
                return true;
        }
        
        private void excuteProducts()
        {
            con.Open();
            string query = "select ID, Name, Brand, Cost from ProductsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProductsDGV2.DataSource = ds.Tables[0];
            con.Close();

        }

        private void excuteClients()
        {
            con.Open();
            string query = "select * from ClientsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ClientsDGV2.DataSource = ds.Tables[0];
            con.Close();

        }
        
        private void excuteOrders() 
        {
            con.Open();
            string query = "select * from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillingDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Reset()
        {
            txtclientname.Text = "";
            txtproductname.Text = "";
            combobrand.SelectedIndex = -1;
            txtprice.Text = "";
            numericquantity.Value = 0;
            //pickerdate.Value.Date = 00/00/0000;
            txtclientname.Focus(); 
            lbltotal.Text = "•••••";
        }
        


        private void Billing_Load(object sender, EventArgs e)
        {
            excuteProducts();
            excuteClients();
            excuteOrders();
            
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
                    int total = Convert.ToInt32(numericquantity.Value.ToString()) * Convert.ToInt32(txtprice.Text);
                    totalprice = total + totalprice;
                    lbltotal.Text = totalprice + " $";
                    string query = "insert into BillTbl values('" + txtclientname.Text + "', '" + txtproductname.Text + "', '" + combobrand.SelectedItem.ToString() + "', '" + numericquantity.Value.ToString() + "', '" + txtprice.Text + "', '" + pickerdate.Value.ToString("dd/mm/yyyy") + "',  '" + total + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("New Order Added Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    excuteOrders();
                    
                    
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
                MessageBox.Show("Don't Keep Any Fields Blank! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from BillTbl where ID= " + key + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Information Deleted Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    excuteOrders();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
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
                    int total = Convert.ToInt32(numericquantity.Value.ToString()) * Convert.ToInt32(txtprice.Text);
                    totalprice = total + totalprice;
                    lbltotal.Text = totalprice + " $";

                    string query = "update BillTbl set Client='" + txtclientname.Text + "', Product='" + txtproductname.Text + "', Brand='" + combobrand.SelectedItem.ToString()
                                + "', Price='" + txtprice.Text + "', Date='" + pickerdate.Value.ToString("dd/mm/yyyy") + "', Total='" + total + "' where ID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Order Information Updated Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    excuteOrders();
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

        private void btnprint_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 600,600);
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        
        
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 18, FontStyle.Regular);
            e.Graphics.DrawString("-------- Music Instruments Store --------", font, Brushes.Black, 75, 20);
            e.Graphics.DrawString("-------- Billing Order --------", font, Brushes.Black, 120, 50);
            foreach (DataGridViewRow row in BillingDGV.SelectedRows)
            {
                int ProductID = Convert.ToInt32(row.Cells[0].Value);
                string ClientName = "" + row.Cells[1].Value;
                string ProductName = "" + row.Cells[2].Value;
                string Brand = "" +row.Cells[3].Value;
                int Quantity = Convert.ToInt32(row.Cells[4].Value);
                int Price = Convert.ToInt32(row.Cells[5].Value);
                string Date = "" +row.Cells[6].Value;
                int Total = Convert.ToInt32(row.Cells[7].Value );

                e.Graphics.DrawString("Order ID:  " + ProductID, font, Brushes.Black, 120, 135);
                e.Graphics.DrawString("Client Name:   " + ClientName, font, Brushes.Black, 120, 170);
                e.Graphics.DrawString("Product Name:   " + ProductName, font, Brushes.Black, 120, 205);
                e.Graphics.DrawString("Brand:  " + Brand, font, Brushes.Black, 120, 240);
                e.Graphics.DrawString("Quantity:  " + Quantity, font, Brushes.Black, 120, 275);
                e.Graphics.DrawString("Unit Price:  " + Price + " $", font, Brushes.Black, 120, 310);
                e.Graphics.DrawString("Date:  " + Date, font, Brushes.Black, 120, 345);
                e.Graphics.DrawString("Total Price:  " + Total + " $", font, Brushes.Black, 120, 450);

            }

            e.Graphics.DrawString("-------- Music Instuments Store -------- ", font, Brushes.Black, 75, 240 + 280);
        }

        private void ClientsDGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtclientname.Text = ClientsDGV2.SelectedRows[0].Cells[1].Value.ToString();
            if (txtclientname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ClientsDGV2.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void ProductsDGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtproductname.Text = ProductsDGV2.SelectedRows[0].Cells[1].Value.ToString();
            combobrand.SelectedItem= ProductsDGV2.SelectedRows[0].Cells[2].Value.ToString();
            txtprice.Text = ProductsDGV2.SelectedRows[0].Cells[3].Value.ToString();
            if (txtproductname.Text == "")
            {
                key = 0;
                stock = 0;
            }
            else
            {
                key = Convert.ToInt32(ProductsDGV2.SelectedRows[0].Cells[0].Value.ToString());
                stock = Convert.ToInt32(ProductsDGV2.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void BillingDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtclientname.Text = BillingDGV.SelectedRows[0].Cells[1].Value.ToString();
            txtproductname.Text = BillingDGV.SelectedRows[0].Cells[2].Value.ToString();
            combobrand.SelectedItem = BillingDGV.SelectedRows[0].Cells[3].Value.ToString();
            numericquantity.Value = Convert.ToInt32(BillingDGV.SelectedRows[0].Cells[4].Value.ToString());
            txtprice.Text = BillingDGV.SelectedRows[0].Cells[5].Value.ToString();
            /*string v = pickerdate.Value.ToString();
                v= BillingDGV.SelectedRows[0].Cells[5].Value.ToString();*/
            lbltotal.Text = BillingDGV.SelectedRows[0].Cells[7].Value.ToString() + " $s";

            if (txtclientname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BillingDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        
    }
}
