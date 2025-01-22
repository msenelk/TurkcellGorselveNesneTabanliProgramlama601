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
    public partial class FrmBolumListesi : Form
    {
        public FrmBolumListesi()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db=new OgrenciSinavEntities();
        private void FrmBolumListesi_Load(object sender, EventArgs e)
        {
            var degerler = from x in db.TblBolum
                           select new
                           {
                               x.BolumID,
                               x.BolumAd
                           };
            dataGridView1.DataSource = degerler.ToList();
            dataGridView1.Columns[0].HeaderText = "Bölüm ID"; // Sütun Adı
            dataGridView1.Columns[1].HeaderText = "Bölüm Adı";
            dataGridView1.Columns[0].Width = 100; // Sütun genişliği
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
