﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Warsha.Controler;

namespace Warsha.Views.Masrofat
{

    public partial class edit : MetroFramework.Forms.MetroForm
    {
        Crud crd = new Crud();
        private static index frm;
        public edit()
        {
            InitializeComponent();
        }

        private void edit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            models.Masrofat ms = new models.Masrofat()
            {
                id=Int32.Parse(metroTextBox4.Text),
                name = metroTextBox1.Text,
                price = metroTextBox2.Text,
                notes = metroTextBox3.Text,
                date = dateTimePicker1.Value

            };
            crd.masrofat(ms, System.Data.Entity.EntityState.Modified);
            MessageBox.Show("تم التعديل بنجاح");
            Close();
        }
    }
}
