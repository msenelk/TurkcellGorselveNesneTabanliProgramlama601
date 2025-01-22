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
    public partial class FrmDersListesi : Form
    {
        public FrmDersListesi()
        {
            InitializeComponent();
        }
        OgrenciSinavEntities db = new OgrenciSinavEntities();
        private void FrmDersListesi_Load(object sender, EventArgs e)
        {
            var derslistesi = from x in db.TblDersler
                              select new
                              {
                                  x.DersID,
                                  x.DersAd
                              };
            dataGridView1.DataSource = derslistesi.ToList();
            dataGridView1.Columns[0].HeaderText = "Ders ID";
            dataGridView1.Columns[1].HeaderText = "Ders Adı";
            dataGridView1.Columns[0].Width = 90;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
