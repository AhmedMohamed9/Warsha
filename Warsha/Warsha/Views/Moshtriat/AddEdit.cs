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
namespace Warsha.Views.Moshtriat
{
    public partial class AddEdit : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        FactorManagmentEntities db = new FactorManagmentEntities();
        public AddEdit()
        {
            InitializeComponent();
        }

        private void AddEdit_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            models.Moshtriat msh = new models.Moshtriat();
            msh.note = textBox1.Text;
            msh.quantity = Int32.Parse(textBox2.Text);
            msh.Date = dateTimePicker1.Value;
            msh.Goods_id = Int32.Parse(metroComboBox1.SelectedValue.ToString());
            msh.Total_price = (db.Goods.Where(i => i.id == msh.Goods_id).Select(i => i.Price).Single()) * msh.quantity;

            if (button1.Text== "أضافة")
            {
                crd.Moshtriat(msh, System.Data.Entity.EntityState.Added);
                MessageBox.Show("تم اضافة العنصر");
            }
            else
            {
                msh.id =Int32.Parse(textBox1.Text);
                crd.Moshtriat(msh, System.Data.Entity.EntityState.Modified);
                MessageBox.Show("تم اضافة العنصر");
            }
           
            
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
