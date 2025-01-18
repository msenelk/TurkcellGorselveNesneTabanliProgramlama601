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

namespace TurkcellGorselveNesneTabanliProgramlama601.Formlar
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=MSENELK\SQLEXPRESS;Initial Catalog=OgrenciSinav;Integrated Security=True");
        Random random = new Random();
        public int randomOlustur1;
        public int randomOlustur2;
        public int randomToplam;
        public void FrmGiris_Load(object sender, EventArgs e)
        {
            // random sayı oluştur:
            int randomOlustur1 = random.Next(1, 10);
            int randomOlustur2 = random.Next(1, 10);
            random1.Text = randomOlustur1.ToString();
            random2.Text = randomOlustur2.ToString();
            randomToplam = randomOlustur1 + randomOlustur2;
        }



        public void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TblOgrenci where OgrNumara=@p1 and OgrSifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtNumara.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            //if (dr.Read())
            //{
            //    FrmOgrenciPanel frm= new FrmOgrenciPanel();
            // frm.numara = txtNumara.Text;
            //    frm.Show();
            //    this.Hide();
            //}
            //else
            //{
            //    MessageBox.Show("Numaranız veya şifreniz hatalıdır, lütfen tekrar deneyin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    // Giriş başarılı olmadığı için verileri temizledik.
            //    txtNumara.Clear();
            //    txtSifre.Clear();
            //    // Tekrar giriş yapması adına txtnumara fokusladık.
            //    txtNumara.Focus();
            //}


            if (randomToplam == int.Parse(txtKontrol.Text))
            {
                if (dr.Read())
                {
                    FrmOgrenciPanel frm = new FrmOgrenciPanel();
                    frm.numara = txtNumara.Text;
                    frm.Show();
                    this.Hide();
                }
            else
            {
                MessageBox.Show("Numaranız veya şifreniz hatalıdır, lütfen tekrar deneyin", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Giriş başarılı olmadığı için verileri temizledik.
                txtNumara.Clear();
                txtSifre.Clear();
                // Tekrar giriş yapması adına txtnumara fokusladık.
                txtNumara.Focus();

            }
            }
            else {
                MessageBox.Show("Doğrulama İşlemini Yanlış Yaptınız Lütfen Tekrar Deneyiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKontrol.Clear();
                txtKontrol.Focus();
            }

        }
    }
}
