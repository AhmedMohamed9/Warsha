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

namespace Warsha.Views.Togaar
{
    public partial class addEdit : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        FactorManagmentEntities db = new FactorManagmentEntities();
        public addEdit()
        {
            InitializeComponent();
        }

        private void addEdit_Load(object sender, EventArgs e)
        {
            metroComboBox1.DataSource = db.Togaar_type.ToList();
            metroComboBox1.DisplayMember = "name";
            metroComboBox1.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==string.Empty){textBox2.Focus();return;}
            if (textBox3.Text==string.Empty){textBox3.Focus();return;}
            models.Togarrr tg = new Togarrr()
            {
                name = textBox2.Text,
                phone =textBox3.Text,
                type_id=Int32.Parse(metroComboBox1.SelectedValue.ToString())
            };
            if (button1.Text== "اضافة")
            {
                
                crd.togaar(tg, System.Data.Entity.EntityState.Added);
                MessageBox.Show("تم الاضافة بنجاح");
            }
            else
            {
                tg.id = int.Parse(textBox1.Text);
                crd.togaar(tg, System.Data.Entity.EntityState.Modified);
                MessageBox.Show("تم التعديل بنجاح");
            }
            Close();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
            if (!char.IsDigit(ch) && ch != 8 )
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
