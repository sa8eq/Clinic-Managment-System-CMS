using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_UI.Visits
{
    public partial class StartVisit : Form
    {
        private int _AppID;
        public StartVisit(int appid)
        {
            InitializeComponent();
            _AppID = appid;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
