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
namespace Warsha.Views.Mabeaat
{
    public partial class index : MetroFramework.Forms.MetroForm
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
        Crud crd = new Crud();
        public index()
        {
            InitializeComponent();
        }
        void fill()
        {
            DataGrid.DataSource = (from j in db.Mabeaats
                                  select new 
           {j.id,j.Prod_id,j.Product.name,j.Product.price,j.Quantity,j.Total_price,j.money_done,j.money_res,j.togarr_id,تاجر= j.Togarrr.name,j.date,j.Status_id,الحاله= j.MAbeaat_Status.name, j.note }).ToList();
            DataGrid.Columns[0].Visible = false;
            DataGrid.Columns[1].Visible = false;
            DataGrid.Columns[8].Visible = false;
            DataGrid.Columns[11].Visible = false;
        }
        void fill(string word,bool money,bool bydate,bool byduration,DateTime from,DateTime to)
        {
            var mb = (from j in db.Mabeaats
                                   where j.Product.name.Contains(word)||j.Togarrr.name.Contains(word)||j.MAbeaat_Status.name.Contains(word)
                                   select new
                                   { j.id, j.Prod_id, j.Product.name, j.Product.price, j.Quantity, j.Total_price, j.money_done, j.money_res, j.togarr_id, تاجر = j.Togarrr.name, j.date, j.Status_id, الحاله = j.MAbeaat_Status.name, j.note }).ToList();
            if (money)
            {
                mb = mb.Where(s => s.money_res > 0).ToList();
            }
            if (bydate !=false)
            {
                if (byduration==true)
                {
                    mb = mb.Where(m => m.date >= from.Date || m.date < to.Date).ToList();
                }
                else
                {
                  mb= mb.Where(m => m.date == from.Date).ToList();
                }
                
            }
            DataGrid.DataSource = mb;
        }

        private void index_Load(object sender, EventArgs e)
        {
            fill(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEdit ad = new addEdit();
            ad.money_done = 0;
            ad.ShowDialog();
            fill();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("هل متأكد من حذف العنصر المحدد", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                models.Mabeaat ms = new models.Mabeaat();
                ms.id = Int32.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());

                crd.mabeaat(ms, System.Data.Entity.EntityState.Deleted);
                fill();
                MessageBox.Show("تم الحذف بنجاح");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEdit ad = new addEdit();
            
            ad.Text = "تعديل";
            ad.button1.Text = "تعديل";
            ad.money_done=decimal.Parse(DataGrid.CurrentRow.Cells[6].Value.ToString());
            ad.textBox1.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ad.textBox2.Text = DataGrid.CurrentRow.Cells[4].Value.ToString();
            ad.textBox3.Text = DataGrid.CurrentRow.Cells[13].Value.ToString();
            ad.dateTimePicker1.Text = DataGrid.CurrentRow.Cells[10].Value.ToString();
            ad.metroComboBox1.SelectedValue =Int32.Parse(DataGrid.CurrentRow.Cells[1].Value.ToString());
            ad.metroComboBox2.SelectedValue =Int32.Parse(DataGrid.CurrentRow.Cells[8].Value.ToString());
            ad.metroComboBox3.SelectedValue =Int32.Parse(DataGrid.CurrentRow.Cells[11].Value.ToString());
            ad.ShowDialog();
            fill();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fill(textBox1.Text, checkBox1.Checked,checkBox3.Checked,checkBox2.Checked,dateTimePicker1.Value,dateTimePicker2.Value);
        }
    }
}
