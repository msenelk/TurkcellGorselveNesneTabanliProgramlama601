using System;
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
        public int txtOgrId;
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
            txtOgrId=db.TblOgrenci.Where(x=> x.OgrNumara==numara).Select(y=>y.OgrID).FirstOrDefault();
            // Ama burada data gride yazdıramadım.
            // dataGridView1.DataSource = db.TblNotlar.Where(x => x.Ogrenci == txtOgrId).ToList();
            // Yazdırdım ama tüm veriyi çekiyormuşuz böyle :D

            // Hocanın yaptığı
            var sinavnotları = (from x in db.TblNotlar
                                select new
                                {
                                    x.TblDersler.DersAd,
                                    x.Sinav1,
                                    x.Sinav2,
                                    x.Sinav3,
                                    x.Quiz1,
                                    x.Quiz2,
                                    x.Proje,
                                    x.Ortalama,
                                    x.Ogrenci,
                                    x.TblOgrenci.OgrAd
                                }).Where(y => y.Ogrenci == txtOgrId).ToList();
            dataGridView1.DataSource = sinavnotları;
            dataGridView1.Columns[0].HeaderText = "Ders Adı";
            dataGridView1.Columns[1].HeaderText = "Sınav 1";
            dataGridView1.Columns[2].HeaderText = "Sınav 2";
            dataGridView1.Columns[3].HeaderText = "Sınav 3";
            dataGridView1.Columns[4].HeaderText = "Quiz 1";
            dataGridView1.Columns[5].HeaderText = "Quiz 2";
            dataGridView1.Columns[9].HeaderText = "Öğrenci Adı";
            dataGridView1.Columns["Ogrenci"].Visible = false;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if(txtYeniSifre.Text == txtYeniSifreTekrar.Text)
            {
                var deger = db.TblOgrenci.Find(txtOgrId);
                deger.OgrSifre = txtYeniSifre.Text;
                db.SaveChanges();
                MessageBox.Show("Şifre Değiştirme İşlemi Başarılı Bir Şekilde Gerçekleşti");
                txtYeniSifre.Clear();
                txtYeniSifreTekrar.Clear();

            }
            else
            {
                MessageBox.Show("Girdiğiniz Yeni Şifreler Birbirleriyle Uyuşmuyor.");
                txtYeniSifre.Clear();
                txtYeniSifreTekrar.Clear();
                txtYeniSifre.Focus();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Geri çıkmak istediğinizden emin misiniz?", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
            else
            {
                FrmGiris frm = new FrmGiris();
                frm.Show();
                this.Hide();

            }
            
        }
    }
}
