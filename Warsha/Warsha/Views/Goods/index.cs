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

namespace Warsha.Views.Goods
{
    public partial class index : MetroFramework.Forms.MetroForm
    {
        private FactorManagmentEntities db = new FactorManagmentEntities();
        public index()
        {
            InitializeComponent();
        }
        private void fill_grid()
        {
            var good = (from g in db.Goods
                        select new { g.id, g.Name, g.Price }).ToList();
            DataGrid.DataSource = good;
        }
        private void index_Load(object sender, EventArgs e)
        {
            fill_grid();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            add ad = new add();
            ad.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            Views.Goods.Edit ed = new Edit();
            ed.metroTextBox1.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            ed.metroTextBox2.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            ed.metroTextBox3.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ed.ShowDialog();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Views.Goods.delete ed = new delete();
            ed.metroTextBox1.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            ed.metroTextBox2.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            ed.metroTextBox3.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ed.ShowDialog();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add ad = new add();
            ad.ShowDialog();
            fill_grid();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Views.Goods.Edit ed = new Edit();
            ed.metroTextBox1.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            ed.metroTextBox2.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            ed.metroTextBox3.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ed.ShowDialog();
            fill_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Views.Goods.delete ed = new delete();
            ed.metroTextBox1.Text = DataGrid.CurrentRow.Cells[1].Value.ToString();
            ed.metroTextBox2.Text = DataGrid.CurrentRow.Cells[2].Value.ToString();
            ed.metroTextBox3.Text = DataGrid.CurrentRow.Cells[0].Value.ToString();
            ed.ShowDialog();
            fill_grid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
