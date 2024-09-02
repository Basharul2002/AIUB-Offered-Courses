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
            this.top_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.data_panel = new Guna.UI2.WinForms.Guna2Panel();
            this.main_panel.SuspendLayout();
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
            // top_panel
            // 
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(798, 49);
            this.top_panel.TabIndex = 0;
            // 
            // data_panel
            // 
            this.data_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.data_panel.Location = new System.Drawing.Point(0, 49);
            this.data_panel.Name = "data_panel";
            this.data_panel.Size = new System.Drawing.Size(798, 484);
            this.data_panel.TabIndex = 1;
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
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel main_panel;
        private Guna.UI2.WinForms.Guna2Panel data_panel;
        private Guna.UI2.WinForms.Guna2Panel top_panel;
    }
}