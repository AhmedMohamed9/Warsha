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
            DataGrid.DataSource = db.Products.ToList();
            DataGrid.Columns[0].Visible = false;
            DataGrid.Columns[3].Visible = false;
        }
        private void index_Load(object sender, EventArgs e)
        {
            fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Views.Montgat.AddEdit mn = new AddEdit();
            mn.ShowDialog();
            fill();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("هل متأكد من حذف العنصر المحدد", "عملية الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
            {
                models.Product ms = new models.Product();
                ms.id = Int32.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());

                crd.Montagat(ms, System.Data.Entity.EntityState.Deleted);
                fill();
                MessageBox.Show("تم الحذف بنجاح");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Views.Montgat.AddEdit mn = new AddEdit();
            mn.textBox1.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            mn.textBox2.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            mn.metroTextBox3.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            mn.Text = "تعديل المنتج";
            mn.button1.Text = "تعديل";
            mn.ShowDialog();
            fill();
        }
    }
}
