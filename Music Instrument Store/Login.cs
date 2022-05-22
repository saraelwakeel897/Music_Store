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
    public partial class Login : Form
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

        public Login()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50,50));
            btnlogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnlogin.Width, btnlogin.Height, 50, 50));
            btnreset.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnreset.Width, btnreset.Height, 50, 50));

        }

        
        ///////DataBase///////////////////////////////////////////////
        
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SaRa Ali\Documents\MusicDB.mdf;Integrated Security=True;Connect Timeout=30");

        bool Authenticate() //Verfication
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(txtpassword.Text))

                return false;
            else
                return true;
        }

        private void btnlogin_Click_1(object sender, EventArgs e)
        {
            
            if (!Authenticate())
            {
                MessageBox.Show("Don't Keep Any Textbox Blank! \nPlease Try Again", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                con.Open();
                string query = "select count(*) from UsersTbl where Name = '" + txtusername.Text + "' and Password = '" + txtpassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    //MessageBox.Show("You Are Logged In", "Success",
                    //                MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadingPanel panel = new LoadingPanel();
                    this.Hide();
                    panel.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Or Password! \nPlease Try Again", "Failed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txtusername.Text = "";
                    txtemail.Text = "";
                    txtpassword.Text = "";
                    txtusername.Focus();
                }
                con.Close();
            }
        }

        private void LabelEffect_Click(object sender, EventArgs e)
        {
            var lbl = sender as Label;
            if (lbl.Location.X == 27)
            {
                lbl.Font = new Font("Product Sans", 13);
                lbl.Cursor = Cursors.Arrow;
                lbl.Location = new Point(lbl.Location.X - 3, lbl.Location.Y - 25);
                foreach (Control txt in panel1.Controls)
                {

                    if (txt.GetType() == typeof(TextBox) && txt.Name == "txt" + lbl.Name.Remove(0, 3))
                    {
                        txt.Focus();
                    }
                }

            }
        }
        
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.FromArgb(192, 63, 39);
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.FromArgb(192, 63, 39);
                    if(ctrl.Location.X != 24)
                    {
                        ctrl.Font = new Font("Maiandra GD", 13);
                        ctrl.Cursor = Cursors.Arrow;
                        ctrl.Location = new Point(ctrl.Location.X - 3, ctrl.Location.Y - 25);
                    }
                }

            }

        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            
            foreach (Control ctrl in panel1.Controls)
            {
                if (ctrl.GetType() == typeof(Panel) && ctrl.Name == "pnl" + txt.Name.Remove(0, 3))
                {
                    ctrl.BackColor = Color.FromArgb(20, 85, 87);
                }

                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + txt.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.FromArgb(20, 85, 87);
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        txt.Clear();
                        ctrl.Font = new Font("Maiandra GD", 15);
                        ctrl.Cursor = Cursors.IBeam;
                        ctrl.Location = new Point(ctrl.Location.X + 3, ctrl.Location.Y + 25);
                    }
                }

            }

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

        private void btnreset_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtemail.Text = "";
            txtpassword.Text = "";

        }
    }
}
