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
using Warsha.models;
namespace Warsha.Views.Mabeaat
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
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            models.Mabeaat mb = new models.Mabeaat();
            mb.date = dateTimePicker1.Value;
            mb.Prod_id= Int32.Parse(metroComboBox1.SelectedValue.ToString());
            mb.Quantity = Int32.Parse(textBox2.Text);   
            mb.note = textBox3.Text;
            mb.Total_price = 
            (db.Products.Where(i => i.id == mb.Prod_id).Select(i => i.price).Single() * mb.Quantity);

            if (button1.Text== "أضافة")
            { 
            crd.mabeaat(mb, System.Data.Entity.EntityState.Added);
            MessageBox.Show("تم الاضافة بنجاح");
            }
            else
            {
                mb.id =int.Parse(textBox1.Text);
                crd.mabeaat(mb, System.Data.Entity.EntityState.Modified);
                MessageBox.Show("تم التعديل بنجاح");
            }
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
           
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
