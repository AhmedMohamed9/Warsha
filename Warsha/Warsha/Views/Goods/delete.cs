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
    public partial class delete : MetroFramework.Forms.MetroForm
    {
        models.FactorManagmentEntities db = new FactorManagmentEntities();
        public delete()
        {
            InitializeComponent();
        }

        private void delete_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            models.Good goo = new models.Good();
            goo.id = Int32.Parse(metroTextBox3.Text);
            goo.Name = metroTextBox1.Text;
            goo.Price =decimal.Parse(metroTextBox2.Text);
            db.Entry(goo).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
