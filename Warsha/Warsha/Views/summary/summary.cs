using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warsha.models;

namespace Warsha.Views.summary
{
    public partial class summary : MetroFramework.Forms.MetroForm
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
        public summary()
        {
            InitializeComponent();
        }
        void fill(DateTime d)
        {
            if (d==null){d = DateTime.Now;}
            var masrofat =( from j in db.Masrofats
                                             where j.date.Value.Month == d.Month &&j.date.Value.Year==d.Year
                                             select  j.price);
            var Moshtriat =( from j in db.Moshtriats
                                             where j.Date.Month == d.Month &&j.Date.Year==d.Year
                                             select  j.Total_price);
            var Mabeaat =( from j in db.Mabeaats
                                             where j.date.Month == d.Month &&j.date.Year==d.Year
                                             select  j.Total_price);

            if (masrofat.Count() == 0) { metroTextBox1.Text = "0"; } else { metroTextBox1.Text = masrofat.Sum().ToString(); };
            if (Moshtriat.Count() == 0) { metroTextBox2.Text = "0"; } else { metroTextBox2.Text = Moshtriat.Sum().ToString(); };
            if (Mabeaat.Count() == 0) { metroTextBox3.Text = "0"; } else { metroTextBox3.Text = Mabeaat.Sum().ToString(); };
            
            
            metroTextBox4.Text = (decimal.Parse(metroTextBox3.Text) - (decimal.Parse(metroTextBox2.Text) + decimal.Parse(metroTextBox1.Text))).ToString();
        }
        private void summary_Load(object sender, EventArgs e)
        {
            fill(DateTime.Now);
        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            fill(dateTimePicker1.Value);
        }
    }
}
