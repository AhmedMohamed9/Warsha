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
    public partial class index : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        FactorManagmentEntities db; 
        public index()
        {
            InitializeComponent();
        }
        void fill()
        {
            db = new FactorManagmentEntities();
            DataGrid.DataSource =( from j in db.Togarrrs
                                  select new
                                  { j.id, j.name,type= j.Togaar_type.name,j.phone  }).ToList();
        }
        private void index_Load(object sender, EventArgs e)
        {
            fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addEdit ad = new addEdit();
            ad.ShowDialog();
            fill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addEdit ad = new addEdit();
            ad.Text = "تعديل";
            ad.button1.Text = "تعديل";
            ad.textBox1.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ad.textBox2.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            ad.textBox3.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            ad.ShowDialog();
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
                models.Togarrr tg = new models.Togarrr();
                tg.id = Int32.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());

                crd.togaar(tg, System.Data.Entity.EntityState.Deleted);
                fill();
                MessageBox.Show("تم الحذف بنجاح");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            History hs = new History();
            hs.tager_id= Int32.Parse(DataGrid.CurrentRow.Cells[0].Value.ToString());
            hs.Text = "معملات " + DataGrid.CurrentRow.Cells[1].Value.ToString();
            hs.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            db = new FactorManagmentEntities();
            string word = textBox1.Text;
            DataGrid.DataSource = (from j in db.Togarrrs
                                   where j.name.Contains(word)||j.phone.Contains(word)||j.Togaar_type.name.Contains(word)
                                   select new
                                   { j.id, j.name, type = j.Togaar_type.name, j.phone }).ToList();
        }
    }
}
