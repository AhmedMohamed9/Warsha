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
           {j.id,j.Prod_id,j.Product.name,j.Product.price,j.Quantity,j.Total_price,j.date,j.note }).ToList();
            DataGrid.Columns[0].Visible = false;
            DataGrid.Columns[1].Visible = false;
        }
        private void index_Load(object sender, EventArgs e)
        {
            fill(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEdit ad = new addEdit();
            ad.metroComboBox1.DataSource = db.Products.ToList();
            ad.metroComboBox1.ValueMember = "id";
            ad.metroComboBox1.DisplayMember = "Name";
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
            ad.metroComboBox1.DataSource = db.Products.ToList();
            ad.metroComboBox1.ValueMember = "id";
            ad.metroComboBox1.DisplayMember = "Name";
            ad.Text = "تعديل";
            ad.button1.Text = "تعديل";
            ad.textBox1.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ad.textBox2.Text = DataGrid.CurrentRow.Cells[4].Value.ToString();
            ad.textBox3.Text = DataGrid.CurrentRow.Cells[7].Value.ToString();
            ad.dateTimePicker1.Text = DataGrid.CurrentRow.Cells[6].Value.ToString();
            ad.metroComboBox1.SelectedValue =Int32.Parse(DataGrid.CurrentRow.Cells[1].Value.ToString());
            ad.ShowDialog();
            fill();
        }
    }
}
