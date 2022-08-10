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

namespace FitnessCenter
{
    public partial class UyeleriListele : Form
    {
        public UyeleriListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-JT2ALK4\SQLEXPRESS;Database=FitnessDB;Integrated Security=True");
        private void Uyeler()
        {
            baglanti.Open();
            string query = "select * from UyeTablo";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            DgvUyeListele.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void UyeleriListele_Load(object sender, EventArgs e)
        {
            Uyeler();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void AdFiltrele()
        {
            baglanti.Open();
            string query = "select * from UyeTablo where AdSoyad='"+txtbxUyeAra.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            DgvUyeListele.DataSource = ds.Tables[0];
            baglanti.Close();
        }

            private void btnAra_Click(object sender, EventArgs e)
        {
                AdFiltrele();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Uyeler();
        }
    }
}
