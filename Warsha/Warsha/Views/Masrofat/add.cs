using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warsha.Controler;
namespace Warsha.Views.Masrofat
{
    public partial class add : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        public add()
        {
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text==string.Empty||metroTextBox2.Text==string.Empty)
            {
                label5.Text = "ادخل البيانات سليمه";
                return;
            }
            models.Masrofat ms = new models.Masrofat()
            {
                name = metroTextBox1.Text,
                price = decimal.Parse(metroTextBox2.Text),
                notes=metroTextBox3.Text,
                date=dateTimePicker1.Value,
                Quantity=decimal.Parse(textBox1.Text)
                
            };
            crd.masrofat(ms, System.Data.Entity.EntityState.Added);
            MessageBox.Show("تم الاضافة بنجاح");
            Close();
        }

        private void metroTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && metroTextBox2.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == 46 && textBox1.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }
            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
