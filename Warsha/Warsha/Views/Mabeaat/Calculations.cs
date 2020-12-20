using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warsha.Views.Mabeaat
{
    public partial class Calculations : MetroFramework.Forms.MetroForm
    {
        public Calculations()
        {
            InitializeComponent();
        }

        private void Calculations_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==string.Empty){label5.Text = "ادخل البيانات صحيحة";return;}
            if (textBox2.Text==string.Empty){label5.Text = "ادخل البيانات صحيحة";return;}
            if (textBox3.Text==string.Empty){label5.Text = "ادخل البيانات صحيحة";return;}
            if (textBox4.Text==string.Empty){label5.Text = "ادخل البيانات صحيحة";return;}
            Close();
        }
    }
}
