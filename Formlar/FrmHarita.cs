using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkcellGorselveNesneTabanliProgramlama601.Formlar
{
    public partial class FrmHarita : Form
    {
        public FrmHarita()
        {
            InitializeComponent();
        }

        private void PnlBolumListesi_Click(object sender, EventArgs e)
        {
            FrmBolumListesi frm = new FrmBolumListesi();
            frm.Show();
        }

        private void PnlYeniBolum_Click(object sender, EventArgs e)
        {
            FrmBolumler frm = new FrmBolumler();
            frm.Show();
        }

        private void PnlNotlar_Click(object sender, EventArgs e)
        {
            FrmNotlar frm = new FrmNotlar();
            frm.Show();
        }

        private void PnlOgrenciFormu_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm = new FrmOgrenci();
            frm.Show();
        }

        private void pnlOgrenciKayit_Click(object sender, EventArgs e)
        {
            FrmOgrenciKayit frm = new FrmOgrenciKayit();
            frm.Show();
        }


    }
}
