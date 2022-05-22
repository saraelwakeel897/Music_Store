
namespace Dental_Clinic_Managment_System
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.btnlogin = new System.Windows.Forms.Button();
            this.pnlusername = new System.Windows.Forms.Panel();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.pnlpassword = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnreset = new System.Windows.Forms.Button();
            this.lblemail = new System.Windows.Forms.Label();
            this.pnlemail = new System.Windows.Forms.Panel();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.checkboxShowPass = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(111)))), ((int)(((byte)(40)))));
            this.btnlogin.FlatAppearance.BorderSize = 0;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogin.Font = new System.Drawing.Font("Maiandra GD", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(27, 319);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(375, 54);
            this.btnlogin.TabIndex = 6;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click_1);
            // 
            // pnlusername
            // 
            this.pnlusername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(87)))), ((int)(((byte)(85)))));
            this.pnlusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(68)))), ((int)(((byte)(120)))));
            this.pnlusername.Location = new System.Drawing.Point(27, 61);
            this.pnlusername.Name = "pnlusername";
            this.pnlusername.Size = new System.Drawing.Size(375, 3);
            this.pnlusername.TabIndex = 8;
            // 
            // txtusername
            // 
            this.txtusername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtusername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusername.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(65)))), ((int)(((byte)(67)))));
            this.txtusername.Location = new System.Drawing.Point(27, 26);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(375, 30);
            this.txtusername.TabIndex = 0;
            this.txtusername.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtusername.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.BackColor = System.Drawing.Color.Transparent;
            this.lblusername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblusername.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(85)))), ((int)(((byte)(87)))));
            this.lblusername.Location = new System.Drawing.Point(27, 25);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(121, 30);
            this.lblusername.TabIndex = 10;
            this.lblusername.Text = "Username";
            this.lblusername.Click += new System.EventHandler(this.LabelEffect_Click);
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.BackColor = System.Drawing.Color.Transparent;
            this.lblpassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblpassword.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(85)))), ((int)(((byte)(87)))));
            this.lblpassword.Location = new System.Drawing.Point(27, 209);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(116, 30);
            this.lblpassword.TabIndex = 13;
            this.lblpassword.Text = "Password";
            this.lblpassword.Click += new System.EventHandler(this.LabelEffect_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtpassword.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(65)))), ((int)(((byte)(67)))));
            this.txtpassword.Location = new System.Drawing.Point(27, 210);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '•';
            this.txtpassword.Size = new System.Drawing.Size(375, 30);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtpassword.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // pnlpassword
            // 
            this.pnlpassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(85)))), ((int)(((byte)(87)))));
            this.pnlpassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(68)))), ((int)(((byte)(120)))));
            this.pnlpassword.Location = new System.Drawing.Point(27, 244);
            this.pnlpassword.Name = "pnlpassword";
            this.pnlpassword.Size = new System.Drawing.Size(375, 3);
            this.pnlpassword.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.panel1.Controls.Add(this.btnreset);
            this.panel1.Controls.Add(this.lblemail);
            this.panel1.Controls.Add(this.pnlemail);
            this.panel1.Controls.Add(this.txtemail);
            this.panel1.Controls.Add(this.checkboxShowPass);
            this.panel1.Controls.Add(this.lblusername);
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.pnlusername);
            this.panel1.Controls.Add(this.txtusername);
            this.panel1.Controls.Add(this.pnlpassword);
            this.panel1.Controls.Add(this.lblpassword);
            this.panel1.Controls.Add(this.txtpassword);
            this.panel1.Location = new System.Drawing.Point(468, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(421, 457);
            this.panel1.TabIndex = 18;
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(28)))), ((int)(((byte)(80)))));
            this.btnreset.FlatAppearance.BorderSize = 0;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Maiandra GD", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnreset.ForeColor = System.Drawing.Color.White;
            this.btnreset.Location = new System.Drawing.Point(27, 388);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(375, 54);
            this.btnreset.TabIndex = 27;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.BackColor = System.Drawing.Color.Transparent;
            this.lblemail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lblemail.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(85)))), ((int)(((byte)(87)))));
            this.lblemail.Location = new System.Drawing.Point(27, 120);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(71, 30);
            this.lblemail.TabIndex = 26;
            this.lblemail.Text = "Email";
            this.lblemail.Click += new System.EventHandler(this.LabelEffect_Click);
            // 
            // pnlemail
            // 
            this.pnlemail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(87)))), ((int)(((byte)(85)))));
            this.pnlemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(68)))), ((int)(((byte)(120)))));
            this.pnlemail.Location = new System.Drawing.Point(27, 156);
            this.pnlemail.Name = "pnlemail";
            this.pnlemail.Size = new System.Drawing.Size(375, 3);
            this.pnlemail.TabIndex = 25;
            // 
            // txtemail
            // 
            this.txtemail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.txtemail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtemail.Font = new System.Drawing.Font("Maiandra GD", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(65)))), ((int)(((byte)(67)))));
            this.txtemail.Location = new System.Drawing.Point(27, 121);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(375, 30);
            this.txtemail.TabIndex = 24;
            this.txtemail.Enter += new System.EventHandler(this.TextBox_Enter);
            this.txtemail.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // checkboxShowPass
            // 
            this.checkboxShowPass.AutoSize = true;
            this.checkboxShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkboxShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkboxShowPass.Font = new System.Drawing.Font("Maiandra GD", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.checkboxShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(85)))), ((int)(((byte)(87)))));
            this.checkboxShowPass.Location = new System.Drawing.Point(228, 273);
            this.checkboxShowPass.Name = "checkboxShowPass";
            this.checkboxShowPass.Size = new System.Drawing.Size(177, 28);
            this.checkboxShowPass.TabIndex = 23;
            this.checkboxShowPass.Text = "Show Password";
            this.checkboxShowPass.UseVisualStyleBackColor = true;
            this.checkboxShowPass.CheckedChanged += new System.EventHandler(this.checkboxShowPass_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(249)))));
            this.label6.Font = new System.Drawing.Font("Maiandra GD", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(28)))), ((int)(((byte)(80)))));
            this.label6.Location = new System.Drawing.Point(480, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(393, 56);
            this.label6.TabIndex = 17;
            this.label6.Text = "MEMBER LOGIN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(241)))), ((int)(((byte)(223)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(990, 790);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(976, 786);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Panel pnlusername;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Panel pnlpassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkboxShowPass;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Panel pnlemail;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnreset;
    }
}

