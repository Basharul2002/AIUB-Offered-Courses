using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace AIUB_Offered_Course
{
    public partial class CourseSolution : Form
    {
        static CourseSolution obj;
        public CourseSolution()
        {
            InitializeComponent();

            
        }


        public static CourseSolution GetInstance
        {
            get
            {
                if (obj == null) 
                    obj = new CourseSolution();

                return obj;
            }

        }

        public Guna2Panel panelContainer
        {
            get { return data_panel; }
            set { data_panel = value; }
        }


        private void OfflineOption()
        {
            panelContainer.Controls.Clear();
            Offline offline = new Offline();
            offline.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(offline);
        }


        private void CourseSolution_Load(object sender, EventArgs e)
        {
            obj = this;

            OfflineOption();
        }
    }
}
