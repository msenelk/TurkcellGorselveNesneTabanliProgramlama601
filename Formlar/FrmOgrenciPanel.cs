﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurkcellGorselveNesneTabanliProgramlama601.Entity;

namespace TurkcellGorselveNesneTabanliProgramlama601.Formlar
{
    public partial class FrmOgrenciPanel : Form
    {
        public FrmOgrenciPanel()
        {
            InitializeComponent();
        }

        public string numara;
        public string txtOgrId;
        OgrenciSinavEntities db = new OgrenciSinavEntities(); 
        private void FrmOgrenciPanel_Load(object sender, EventArgs e)
        {
            txtNumara.Text = numara;
            txtOgrAd.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrAd).FirstOrDefault();
            txtOgrSoyad.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrSoyad).FirstOrDefault();
            txtOgrMail.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrEposta).FirstOrDefault();
            txtOgrSifre.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrSifre).FirstOrDefault();
            txtBolum.Text = db.TblOgrenci.Where(x => x.OgrNumara == numara).Select(y => y.OgrBolum).FirstOrDefault().ToString();

            // Numarası girilen öğrencinin ıd bilgisini kendim aldım
            txtOgrId=db.TblOgrenci.Where(x=> x.OgrNumara==numara).Select(y=>y.OgrID).FirstOrDefault().ToString();
            // Ama burada data gride yazdıramadım.
            dataGridView1.DataSource = db.TblNotlar.Where(x => x.Ogrenci == int.Parse(txtOgrId)).ToList();
        }
    }
}
