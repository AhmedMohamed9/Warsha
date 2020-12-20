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
            if (metroTextBox1.Text==string.Empty)
            {
                metroTextBox1.Focus();
                label3.Text = "ادخل اسم البضاعه";
                return;
            }
            if (metroTextBox2.Text==string.Empty)
            {
                metroTextBox2.Focus();
                label3.Text = "ادخل سعر البضاعه";
                return;
            }
            models.Good goo = new models.Good();
            goo.Name = metroTextBox1.Text;
            goo.Price =decimal.Parse(metroTextBox2.Text);
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

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch==46 && metroTextBox2.Text.IndexOf('.')!=-1)
            {
                e.Handled = true;
                return ;
            }
            if (!char.IsDigit(ch) && ch !=8 && ch!=46)
            {
                e.Handled = true;
            }
        }
    }
}
