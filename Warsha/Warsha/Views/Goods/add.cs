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
    public partial class add : MetroFramework.Forms.MetroForm
    {
        private FactorManagmentEntities db = new FactorManagmentEntities();
        public add()
        {
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            models.Good goo = new models.Good();
            goo.Name = metroTextBox1.Text;
            goo.Price = metroTextBox2.Text;
            db.Goods.Add(goo);
            db.SaveChanges();
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
