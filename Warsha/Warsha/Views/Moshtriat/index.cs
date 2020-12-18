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
    public partial class index : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        FactorManagmentEntities db = new FactorManagmentEntities();

        public index()
        {
            InitializeComponent();
        }
        void fill()
        {

            DataGrid.DataSource = (from sh in db.Moshtriats
                                   select new
                                   {
                                       sh.id,
                                       sh.Goods_id,
                                       sh.Good.Name,
                                       sh.Good.Price,
                                       sh.quantity,
                                       sh.Total_price,
                                       sh.Date,
                                       sh.note

                                   }).ToList();
            DataGrid.Columns[1].Visible = false;
            DataGrid.Columns[0].Visible = false;
            DataGrid.Columns[5].HeaderText = "السعر الكلى";
        }

        private void index_Load(object sender, EventArgs e)
        {

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
                models.Moshtriat ms = new models.Moshtriat();
                ms.id = Int32.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());

                crd.Moshtriat(ms, System.Data.Entity.EntityState.Deleted);
                fill();
                MessageBox.Show("تم الحذف بنجاح");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEdit ad = new AddEdit();
            ad.metroComboBox1.DataSource = db.Goods.ToList();
            ad.metroComboBox1.ValueMember = "id";
            ad.metroComboBox1.DisplayMember = "Name";
            ad.ShowDialog();

            fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEdit ad = new AddEdit();

            ad.Text = "تعديل";
            ad.button1.Text = "تعديل";

            ad.textBox1.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ad.dateTimePicker1.Text = DataGrid.CurrentRow.Cells[6].Value.ToString();
            ad.textBox2.Text = DataGrid.CurrentRow.Cells[4].Value.ToString();
            ad.textBox3.Text = DataGrid.CurrentRow.Cells[7].Value.ToString();
            ad.metroComboBox1.DataSource = db.Goods.ToList();
            ad.metroComboBox1.ValueMember = "id";
            ad.metroComboBox1.DisplayMember = "Name";
            ad.metroComboBox1.SelectedValue = Int32.Parse(DataGrid.CurrentRow.Cells[1].Value.ToString());
            ad.ShowDialog();
            fill();
        }
    }
}
