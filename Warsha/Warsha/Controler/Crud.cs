﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Warsha.models;
namespace Warsha.Controler
{
    class Crud
    {
        FactorManagmentEntities db = new FactorManagmentEntities();
       public void masrofat(Masrofat ms,EntityState n)
        {
            db.Entry(ms).State = n;
            db.SaveChanges();
        }
        public void Moshtriat(Moshtriat ms,EntityState n)
        {
            db.Entry(ms).State = n;
            db.SaveChanges();
        }
        public void Montagat(Product ms,EntityState n)
        {
            db.Entry(ms).State = n;
            db.SaveChanges();
        }
        public void mabeaat(Mabeaat ms,EntityState n)
        {
            db.Entry(ms).State = n;
            db.SaveChanges();
        }
        public void togaar(Togarrr ms,EntityState n)
        {
            db.Entry(ms).State = n;
            db.SaveChanges();
        }
    }
}
