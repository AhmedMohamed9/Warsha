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

namespace Warsha.Views.Togaar
{
    public partial class History : MetroFramework.Forms.MetroForm
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
       public int tager_id;
        public History()
        {
            InitializeComponent();
        }
        void fill()
        {
            dataGridView1.DataSource = (from j in db.Mabeaats
                                           where j.togarr_id == tager_id
                                           select new
                                           { j.id, j.Prod_id, اسم_المنتج = j.Product.name, سعر_المنتج = j.Product.price, الكميه = j.Quantity, المبلغ = j.Total_price, المدفوع = j.money_done, المتبقى = j.money_res, j.togarr_id, تاجر = j.Togarrr.name, j.date, j.Status_id, الحاله = j.MAbeaat_Status.name, j.note }).OrderByDescending(d => d.date).ToList();

        }
        void fill(string word, bool money, bool bydate, bool byduration, DateTime from, DateTime to)
        {
            var mb = (from j in db.Mabeaats
                                        where (j.MAbeaat_Status.name.Contains(word)||j.Product.name.Contains(word))&& j.togarr_id == tager_id
                      select new
                                        { j.id, j.Prod_id, اسم_المنتج = j.Product.name, سعر_المنتج = j.Product.price, الكميه = j.Quantity, المبلغ = j.Total_price, المدفوع = j.money_done, المتبقى = j.money_res, j.togarr_id, تاجر = j.Togarrr.name, j.date, j.Status_id, الحاله = j.MAbeaat_Status.name, j.note }).OrderByDescending(d => d.date).ToList();
            if (money)
            {
                mb = mb.Where(s => s.المتبقى > 0).ToList();
            }
            if (bydate != false)
            {
                if (byduration == true)
                {
                    mb = mb.Where(m => m.date >= from.Date || m.date < to.Date).ToList();
                }
                else
                {
                    mb = mb.Where(m => m.date == from.Date).ToList();
                }

            }
            dataGridView1.DataSource = mb;
        }
        private void History_Load(object sender, EventArgs e)
        {
            fill();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[11].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fill(textBox1.Text, checkBox1.Checked, checkBox3.Checked, checkBox2.Checked, dateTimePicker1.Value, dateTimePicker2.Value);

            //fill(textBox1.Text,checkBox1.Checked);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Views.Mabeaat.addEdit ad = new Mabeaat.addEdit();

            ad.money_done = decimal.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString());
            ad.Text = "تعديل";
            ad.button1.Text = "تعديل";
            ad.textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ad.textBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            ad.textBox3.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            ad.dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            ad.metroComboBox1.SelectedValue = Int32.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            ad.metroComboBox2.SelectedValue = Int32.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
            ad.metroComboBox3.SelectedValue = Int32.Parse(dataGridView1.CurrentRow.Cells[11].Value.ToString());
            ad.ShowDialog();
            fill();
        }
    }
}
