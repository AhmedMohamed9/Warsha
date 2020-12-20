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
       public decimal money_done;
        public addEdit()
        {
            InitializeComponent();
        }
        void fill_combo()
        {
            metroComboBox1.DataSource = db.Products.ToList();
           metroComboBox1.ValueMember = "id";
            metroComboBox1.DisplayMember = "Name";
           
            metroComboBox3.DataSource = db.MAbeaat_Status.ToList();
           metroComboBox3.ValueMember = "id";
            metroComboBox3.DisplayMember = "Name";
        }
        void filltager()
        {
            metroComboBox2.DataSource = db.Togarrrs.ToList();
            metroComboBox2.ValueMember = "id";
            metroComboBox2.DisplayMember = "Name";
        }
        
        private void addEdit_Load(object sender, EventArgs e)
        {
            fill_combo();
            filltager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text==string.Empty)
            {
                label1.Text = "ادخل الكمية صحيحة";
                textBox2.Focus();
                return;
            }
            if (metroComboBox1.SelectedValue==null)
            {
                label1.Text = "اختار منتج صحيح";
                
                return;
            }
            models.Mabeaat mb = new models.Mabeaat();
            mb.date = dateTimePicker1.Value;
            mb.Prod_id= Int32.Parse(metroComboBox1.SelectedValue.ToString());
            mb.togarr_id = Int32.Parse(metroComboBox2.SelectedValue.ToString());
            mb.Status_id = Int32.Parse(metroComboBox3.SelectedValue.ToString());

            mb.Quantity = decimal.Parse(textBox2.Text);   
            mb.note = textBox3.Text;
            decimal price = db.Products.Where(i => i.id == mb.Prod_id).Select(i => i.price).Single();
            mb.Total_price = (price * mb.Quantity);
            ///calculations form
            Calculations cl = new Calculations();
            cl.textBox1.Text = price.ToString();
            cl.textBox2.Text = mb.Quantity.ToString();
            cl.textBox3.Text = mb.Total_price.ToString();
            cl.textBox4.Text = money_done.ToString();
         
            cl.ShowDialog();
            var mon= cl.textBox4.Text.ToString();
            mb.money_done =decimal.Parse(mon);
            mb.Total_price =decimal.Parse(cl.textBox3.Text.ToString());
            mb.money_res =mb.Total_price-mb.money_done;
            ///add to database
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

        private void metroLabel7_Click(object sender, EventArgs e)
        {
            Views.Togaar.addEdit ad = new Togaar.addEdit();
            ad.ShowDialog();
            filltager();
        }
    }
}
