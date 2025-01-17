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
using System.Data.Entity;
using DevExpress.Utils.Extensions;

namespace TurkcellGorselveNesneTabanliProgramlama601.Formlar
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            cmbDers.DisplayMember = "DersAd"; // Ön yüzde gözükecek alan
            cmbDers.ValueMember = "DersID"; // Arka yüzde gözükecek alan
            cmbDers.DataSource = db.TblDersler.ToList();
            comboBox1.DisplayMember = "DersAd"; // Ön yüzde gözükecek alan
            comboBox1.ValueMember = "DersID"; // Arka yüzde gözükecek alan
            comboBox1.DataSource = db.TblDersler.ToList();
            Listele(); // Form açılırken listeleme işi yapılacak.
        }
        private void Listele() // Listeleme için bir metot oluşturdum ki her defasında kod yazmaktansa bir kod üzerinden çağırayım.
        {
            dataGridView1.DataSource = db.Notlar3();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            TblNotlar t = new TblNotlar();
            t.Sinav1 = byte.Parse(txtSinav1.Text);
            t.Sinav2 = byte.Parse(txtSinav2.Text);
            t.Sinav3 = byte.Parse(txtSinav3.Text);
            t.Proje=byte.Parse(txtProje.Text);
            t.Quiz1=byte.Parse(txtQuiz1.Text);
            t.Quiz2=byte.Parse(txtQuiz2.Text);
            t.Ders = int.Parse(cmbDers.SelectedValue.ToString());
            t.Ogrenci=int.Parse(txtOgrenci.Text);
            t.Ortalama = int.Parse(txtOrtalama.Text);
            db.TblNotlar.Add(t);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Not Bilgisi İçin Sisteme Kaydedildi");
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            byte s1, s2, s3, q1, q2, proje;
            double ortalama;

            s1 = Convert.ToByte(txtSinav1.Text);
            s2 = Convert.ToByte(txtSinav2.Text);
            s3 = Convert.ToByte(txtSinav3.Text);
            q1 = byte.Parse(txtQuiz1.Text);
            q2 = byte.Parse(txtQuiz2.Text);
            proje=byte.Parse(txtProje.Text);
            ortalama=(s1+s2+s3+q1+q2+proje)/ 7;
            txtOrtalama.Text=ortalama.ToString(); 
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = db.View_1.ToList();
            Listele(); // Listele butonuna basıldığı zaman listeleme yapılacak.
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Combobox'da seçilen değiştiğinde oluşacak senaryo:
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotID,
                               x.TblDersler.DersAd,
                               Öğrenci_Adı= x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               // Verileri listelerken tek bir sütuna birden fazla veri yazdırmak istersek; bir tane isim adlandırarak ekleme yapıyoruz :)
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ders,
                           };
            int d = int.Parse(comboBox1.SelectedValue.ToString());
            dataGridView1.DataSource = degerler.Where(y => y.Ders ==d).ToList();
            dataGridView1.Columns["Ders"].Visible = false; // İlgili sütunu göstermiyoruz tabii bunu listelemeden sonra yapıyoruz.
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            var degerler = from x in db.TblNotlar
                           select new
                           {
                               x.NotID,
                               x.TblDersler.DersAd,
                               Öğrenci_Adı = x.TblOgrenci.OgrAd + " " + x.TblOgrenci.OgrSoyad,
                               x.Sinav1,
                               x.Sinav2,
                               x.Sinav3,
                               x.Quiz1,
                               x.Quiz2,
                               x.Proje,
                               x.Ortalama,
                               x.Ogrenci,
                           };
            int i = int.Parse(txtNumaraAra.Text);
            dataGridView1.DataSource = degerler.Where(y => y.Ogrenci == i).ToList();
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }
    }
}
