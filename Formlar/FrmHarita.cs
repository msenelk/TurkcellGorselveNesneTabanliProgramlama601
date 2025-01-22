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

        private void pnlDersListesi_Click(object sender, EventArgs e)
        {
            FrmDersListesi frm = new FrmDersListesi();
            frm.Show();
        }

        private void pnglYardim_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu proje Turkcell Geleceği Yazanlar Eğitimi Kapsamında Hazırlanmıştır. Müfredatın son projesinde amacımız şu ana kadar öğrenmiş olduğumuz konuların bütük bir kısmını içeren örnek bir ver itabanlı proje uygulaması geliştirmektir. Projemizde akademisyen için kullanıcı adı: 0000 olup şifre: 000 şeklindedir. Akademisyen panelinden öğrenci, ders, bölüm, sınav notları gibi işlemlerin tamamı gerçekleştirilebilir. Sisteme giriş yapan öğrenci sadece kendisine ait bilgileri ve sınav notlarını görüntüler.","Yardım Penceresi",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pnlYeniDers_Click(object sender, EventArgs e)
        {
            FrmYeniDers frm = new FrmYeniDers();
            frm.Show();
        }

        private void PnglCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
