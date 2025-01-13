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
           
        }
    }
}
