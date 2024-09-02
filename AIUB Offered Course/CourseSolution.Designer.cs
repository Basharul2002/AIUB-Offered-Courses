namespace AIUB_Offered_Course
{
    partial class CourseSolution
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseSolution));
            this.main_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.data_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.top_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.online_btn = new Guna.UI2.WinForms.Guna2Button();
            this.offline_button = new Guna.UI2.WinForms.Guna2Button();
            this.main_panel.SuspendLayout();
            this.top_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.data_panel);
            this.main_panel.Controls.Add(this.top_panel);
            this.main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(798, 533);
            this.main_panel.TabIndex = 0;
            // 
            // data_panel
            // 
            this.data_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_panel.Location = new System.Drawing.Point(0, 49);
            this.data_panel.Name = "data_panel";
            this.data_panel.Size = new System.Drawing.Size(798, 484);
            this.data_panel.TabIndex = 1;
            // 
            // top_panel
            // 
            this.top_panel.Controls.Add(this.online_btn);
            this.top_panel.Controls.Add(this.offline_button);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(798, 49);
            this.top_panel.TabIndex = 0;
            // 
            // online_btn
            // 
            this.online_btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.online_btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.online_btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.online_btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.online_btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.online_btn.ForeColor = System.Drawing.Color.White;
            this.online_btn.Location = new System.Drawing.Point(343, 9);
            this.online_btn.Name = "online_btn";
            this.online_btn.Size = new System.Drawing.Size(145, 34);
            this.online_btn.TabIndex = 0;
            this.online_btn.Text = "Online";
            this.online_btn.Click += new System.EventHandler(this.online_btn_Click);
            // 
            // offline_button
            // 
            this.offline_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.offline_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.offline_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.offline_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.offline_button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.offline_button.ForeColor = System.Drawing.Color.White;
            this.offline_button.Location = new System.Drawing.Point(134, 9);
            this.offline_button.Name = "offline_button";
            this.offline_button.Size = new System.Drawing.Size(145, 34);
            this.offline_button.TabIndex = 0;
            this.offline_button.Text = "Offline";
            this.offline_button.Click += new System.EventHandler(this.offline_button_Click);
            // 
            // CourseSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 533);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CourseSolution";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AIUB Offered Courses";
            this.Load += new System.EventHandler(this.CourseSolution_Load);
            this.main_panel.ResumeLayout(false);
            this.top_panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel main_panel;
        private Guna.UI2.WinForms.Guna2Panel data_panel;
        private Guna.UI2.WinForms.Guna2Panel top_panel;
        private Guna.UI2.WinForms.Guna2Button offline_button;
        private Guna.UI2.WinForms.Guna2Button online_btn;
    }
}