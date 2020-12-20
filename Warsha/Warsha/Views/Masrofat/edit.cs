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

    public partial class edit : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        
        public edit()
        {
            InitializeComponent();
        }

        private void edit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == string.Empty || metroTextBox2.Text == string.Empty)
            {
                label5.Text = "ادخل البيانات سليمه";
                return;
            }
            models.Masrofat ms = new models.Masrofat()
            {
                id=Int32.Parse(metroTextBox4.Text),
                name = metroTextBox1.Text,
                price = decimal.Parse(metroTextBox2.Text),
                notes = metroTextBox3.Text,
                date = dateTimePicker1.Value,
                Quantity=decimal.Parse(textBox1.Text)

            };
            crd.masrofat(ms, System.Data.Entity.EntityState.Modified);
            MessageBox.Show("تم التعديل بنجاح");
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
    }
}
