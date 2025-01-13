using System;
using System.Windows.Forms;
using TurkcellGorselveNesneTabanliProgramlama601.Entity;

namespace TurkcellGorselveNesneTabanliProgramlama601.Formlar
{
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBolumAdi.Text == "")
            {
                errorProvider1.SetError(txtBolumAdi, "Bölüm adı boş geçilemez");
            }
            else
            {
                TblBolum t = new TblBolum();
                t.BolumAd = txtBolumAdi.Text;
                db.TblBolum.Add(t);
                db.SaveChanges();
                MessageBox.Show("Bölüm Ekleme İşlemi Başarılı Bir Şekilde Gerçekleştirildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtBolumAdi.Clear();
            }
        }
    }
}
