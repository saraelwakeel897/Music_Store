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
    public partial class LoadingPanel : Form
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

        public LoadingPanel()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 50, 50));

        }

        private void Panel_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

       private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (progressBar1.Value == 100)
            {
                progressBar1.ForeColor = Color.White;
                timer1.Stop();

                this.Hide();
                Store dash = new Store();
                dash.Show();
            }
            else
            {
                progressBar1.Value += 1;
                label1.Text = (Convert.ToInt32(label1.Text) + 1).ToString();
            }
        }

        
    }
}
