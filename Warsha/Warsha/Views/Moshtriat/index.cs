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

        private void index_Load(object sender, EventArgs e)
        {
            DataGrid.DataSource = db.Moshtriats.ToList();
            
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
                DataGrid.DataSource = db.Moshtriats.ToList();
                MessageBox.Show("تم الحذف بنجاح");
            }
        }
    }
}
