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
    public partial class FrmBolumler : Form
    {
        public FrmBolumler()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtBolumAdi.Text == "")
            {
                errorProvider1.SetError(txtBolumAdi, "Bölüm adı boş geçilemez");
            }
            else
            {
                MessageBox.Show("Kayıt Yapıldı.");
            }
        }
    }
}
