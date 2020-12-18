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

namespace Warsha.Views.Masrofat
{
    
    public partial class index : MetroFramework.Forms.MetroForm
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
        Crud crd = new Crud();
        public index()
        {
            InitializeComponent();
        }
        void fill_grid()
        {
            DataGrid.DataSource = db.Masrofats.ToList();
        }
        private void index_Load(object sender, EventArgs e)
        {
            fill_grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Masrofat.add frm = new add();
            frm.ShowDialog();
            fill_grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("هل متأكد من حذف العنصر المحدد","عملية الحذف",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)==DialogResult.Yes))
            {
                models.Masrofat ms = new models.Masrofat();
                ms.id =Int32.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());
               
                crd.masrofat(ms, System.Data.Entity.EntityState.Deleted);
                fill_grid();
                MessageBox.Show("تم الحذف بنجاح");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit ed = new edit();
            ed.metroTextBox4.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ed.metroTextBox1.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            ed.metroTextBox2.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            ed.metroTextBox3.Text = DataGrid.CurrentRow.Cells[3].Value.ToString();
            ed.dateTimePicker1.Text =DataGrid.CurrentRow.Cells[4].Value.ToString();
            ed.ShowDialog();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
