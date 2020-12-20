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
namespace Warsha
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void Goods_Click(object sender, EventArgs e)
        {
            Views.Goods.index goods = new Views.Goods.index();
            goods.ShowDialog();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            Views.Masrofat.index ms = new Views.Masrofat.index();
            ms.ShowDialog();
        }

        private void metroTile1_StyleChanged(object sender, EventArgs e)
        {

        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Views.Moshtriat.index frm = new Views.Moshtriat.index();
            frm.ShowDialog();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Views.Montgat.index frm = new Views.Montgat.index();
            frm.ShowDialog();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
            Views.Mabeaat.index frm = new Views.Mabeaat.index();
            frm.ShowDialog();
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            Views.summary.summary sm = new Views.summary.summary();
            sm.ShowDialog();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            Views.Togaar.index tg = new Views.Togaar.index();
            tg.ShowDialog();
        }
    }
}
