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
namespace Warsha.Views.Goods
{
    public partial class Edit : MetroFramework.Forms.MetroForm
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            models.Good goo = new models.Good();
            goo.Name = metroTextBox1.Text;
            goo.Price = metroTextBox2.Text;
            goo.id =Int32.Parse(metroTextBox3.Text);
            db.Entry(goo).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
