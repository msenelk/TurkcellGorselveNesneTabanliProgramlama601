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
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        OgrenciSinavEntities db=new OgrenciSinavEntities();
        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            listele();
            dataGridView1.Columns["OgrBolum"].Visible = false;
            dataGridView1.Columns["OgrDurum"].Visible = false;
            // Bölümleri getiriyoruz.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblBolum", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable ds = new DataTable(); // Combobox'a veri getirilirken DataTable getirilir.
            da.Fill(ds);
            cmbBolum.ValueMember = "BolumID";
            cmbBolum.DisplayMember = "BolumAd";
            cmbBolum.DataSource = ds;
            // Bölümleri getiriyoruz.
        }
        void listele()
        {
            var degerler = from x in db.TblOgrenci
                           select new
                           {
                               x.OgrID,
                               x.OgrAd,
                               x.OgrSoyad,
                               x.OgrNumara,
                               x.OgrSifre,
                               x.OgrEposta,
                               x.OgrResim,
                               x.OgrBolum,
                               x.TblBolum.BolumAd,
                               x.OgrDurum
                           };

            dataGridView1.DataSource = degerler.Where(x=>x.OgrDurum==true).ToList();
            // Satır başlıklarına isim verdik.
            dataGridView1.Columns[0].HeaderText = "Öğrenci ID";
            dataGridView1.Columns[1].HeaderText = "Öğrenci Adı";
            dataGridView1.Columns[2].HeaderText = "Öğrenci Soyadı";
            dataGridView1.Columns[3].HeaderText = "Öğrenci Numarası";
            dataGridView1.Columns[4].HeaderText = "Öğrenci Şifresi";
            dataGridView1.Columns[5].HeaderText = "Öğrenci Mail";
            dataGridView1.Columns[6].HeaderText = "Öğrenci Resim";
            dataGridView1.Columns[7].HeaderText = "Öğrenci Bölümü";
            dataGridView1.Columns[8].HeaderText = "Öğrenci Durumu";

        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtNumara.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtResim.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            cmbBolum.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
        }
    }
}
