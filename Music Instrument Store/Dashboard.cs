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
    public partial class Dashboard : Form
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

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SaRa Ali\Documents\MusicDB.mdf;Integrated Security=True;Connect Timeout=30");

        public Dashboard()
        {
            InitializeComponent();
        }

        private void CountOrders()
        {
            string query = "select count(*) from BillTbl"; //Sum (Total) //count(*)
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblorder.Text = dt.Rows[0][0].ToString();
        }

        private void CountUsers()
        {
            string query = "select count(*) from UsersTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblusers.Text = dt.Rows[0][0].ToString();
        }

        private void CountProducts()
        {
            string query = "select count(*) from ProductsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblproducts.Text = dt.Rows[0][0].ToString();
        }
        
        private void CountClients()
        {
            string query = "select count(*) from ClientsTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lblclients.Text = dt.Rows[0][0].ToString();
        }

        private void CountTotal()
        {
            string query = "select sum(Total) from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            lbltotal.Text = dt.Rows[0][0].ToString();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            CountProducts();
            CountClients();
            CountUsers();
            CountOrders();
            CountTotal();
        }

        
    }
}
