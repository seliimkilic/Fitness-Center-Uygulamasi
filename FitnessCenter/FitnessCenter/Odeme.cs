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
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-JT2ALK4\SQLEXPRESS;Database=FitnessDB;Integrated Security=True");

        private void FillName()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select Adsoyad from UyeTablo", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AdSoyad", typeof(string));
            dt.Load(rdr);
            comboBoxAdsoyad.ValueMember = "AdSoyad";
            comboBoxAdsoyad.DataSource =dt;
            baglanti.Close();
        }

        private void Uyeler()
        {
            baglanti.Open();
            string query = "select * from OdemeTablo";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            DgvOdeme.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void AdFiltrele()
        {
            baglanti.Open();
            string query = "select * from OdemeTablo where Uye='"+txtbxArama.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            DgvOdeme.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBoxAdsoyad.Text="";
            txtbxTutar.Text="";
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            FillName();
            Uyeler();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            if (comboBoxAdsoyad.Text==""|| txtbxTutar.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                //string odemeperiyot= dateTimePicker1.Value.Month.ToString() + dateTimePicker1.Value.Year.ToString();
                string odemeperiyot = dateTimePicker1.Value.Month.ToString() + "-" + dateTimePicker1.Value.Year.ToString();
                baglanti.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from OdemeTablo where Uye='"+ comboBoxAdsoyad.SelectedValue.ToString()+"' and Ay='"+odemeperiyot+"'", baglanti);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    MessageBox.Show("Zaten Ödeme Yapıldı");
                }
                else
                {
                    string query = "insert into OdemeTablo values('"+odemeperiyot+"','"+comboBoxAdsoyad.SelectedValue.ToString()+"'," + txtbxTutar.Text +")";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Tutar Başarıyla Ödendi");

                }
                baglanti.Close();
                Uyeler();
            }
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            AdFiltrele();
            txtbxArama.Text="";
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            Uyeler();
        }
    }
}
