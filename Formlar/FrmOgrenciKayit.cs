using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurkcellGorselveNesneTabanliProgramlama601.Entity;

namespace TurkcellGorselveNesneTabanliProgramlama601.Formlar
{
    public partial class FrmOgrenciKayit : Form
    {
        public FrmOgrenciKayit()
        {
            InitializeComponent();
        }
        // Data Source=MSENELK\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True;Trust Server Certificate=True
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        OgrenciSinavEntities db = new OgrenciSinavEntities();

        private void FrmOgrenciKayit_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblBolum",baglanti);
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable ds = new DataTable(); // Combobox'a veri getirilirken DataTable getirilir.
            da.Fill(ds);
            comboBox1.ValueMember = "BolumID";
            comboBox1.DisplayMember = "BolumAd";
            comboBox1.DataSource = ds;
        }

       
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if(txtOgrSifre.Text == txtOgrSifreTekrar.Text)
            {
                TblOgrenci t = new TblOgrenci();
                t.OgrAd = txtOgrAd.Text;
                t.OgrSoyad = txtOgrSoyad.Text;
                t.OgrNumara = txtOgrNumara.Text;
                t.OgrEposta = txtOgrMail.Text;
                t.OgrResim = txtOgrResim.Text;
                t.OgrSifre = txtOgrSifre.Text;
                t.OgrBolum = int.Parse(comboBox1.SelectedValue.ToString());
                db.TblOgrenci.Add(t);
                db.SaveChanges();
                MessageBox.Show("Öğrenci Bilgileri Sisteme Başarılı Bir Şekilde Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Şifreleri Birbiriyle Aynı Olacak Şekilde Yeniden Girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtOgrSifre.Clear(); // Kullanıcının girdiği veriyi siliyoruz
                txtOgrSifreTekrar.Clear();
                txtOgrSifre.Focus(); // Şifreyi tekrar yazması için focuslanıyoruz..
            }
           
        }

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            txtOgrResim.Text = openFileDialog1.FileName;
        }
    }
}
