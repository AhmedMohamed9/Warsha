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
using Warsha.Controler;
namespace Warsha.Views.Montgat
{
    public partial class AddEdit : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        public AddEdit()
        {
            InitializeComponent();
        }

        private void AddEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product mn = new Product();
            mn.name = textBox1.Text;
            mn.price = decimal.Parse(textBox2.Text);
            if (button1.Text== "حفظ")
            {
                crd.Montagat(mn, System.Data.Entity.EntityState.Added);
                MessageBox.Show("! تم اضافة المنتج بنجاح ");
            }
            else
            {
                mn.id =Int32.Parse(metroTextBox3.Text);
                crd.Montagat(mn, System.Data.Entity.EntityState.Modified);
                MessageBox.Show("! تم تعديل المنتج بنجاح ");
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }
    }
}
