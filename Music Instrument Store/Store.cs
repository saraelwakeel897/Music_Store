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


namespace Dental_Clinic_Managment_System
{
    public partial class Store : Form
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

        public Store()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));
            pnl.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pnl.Width, pnl.Height, 50, 50));
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void container(object _form)
        {

            if (pnl.Controls.Count > 0) pnl.Controls.Clear();
            Form form = _form as Form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnl.Controls.Add(form);
            pnl.Tag = form;
            form.Show();

        }

        
        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + lbl.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.FromArgb(145, 139, 164);
                }
            }
        }

        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;

            foreach (Control ctrl in panel2.Controls)
            {
                if (ctrl.GetType() == typeof(Label) && ctrl.Name == "lbl" + lbl.Name.Remove(0, 3))
                {
                    ctrl.ForeColor = Color.White;
                }
            }
        }

        private void lbldClients_Click(object sender, EventArgs e)
        {
            container(new Clients());
        }

        private void lblBilling_Click(object sender, EventArgs e)
        {
            container(new Billing());
        }

        private void lblProducts_Click(object sender, EventArgs e)
        {
            container(new Products());
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            container(new Users());
        }

        private void lblboard_Click(object sender, EventArgs e)
        {
            container(new Dashboard());
        }
        private void Store_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;

            r = MessageBox.Show("Do you really want to close?",
                                "Close",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
            
        }
    }
}
