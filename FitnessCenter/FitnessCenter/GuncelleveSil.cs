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
    public partial class GuncelleveSil : Form
    {
        public GuncelleveSil()
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
            DgvGuncelleSil.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void GüncelleveSil_Load(object sender, EventArgs e)
        {
            Uyeler();
        }
        int key = 0;
        private void DgvGuncelleSil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(DgvGuncelleSil.SelectedRows[0].Cells[0].Value.ToString());
            txtbxAdSoyad.Text=DgvGuncelleSil.SelectedRows[0].Cells[1].Value.ToString();
            txtbxTelNo.Text=DgvGuncelleSil.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxCinsiyet.Text=DgvGuncelleSil.SelectedRows[0].Cells[3].Value.ToString();
            txtbxYas.Text=DgvGuncelleSil.SelectedRows[0].Cells[4].Value.ToString();
            txtbxTutar.Text=DgvGuncelleSil.SelectedRows[0].Cells[5].Value.ToString();
            comboBoxZamanlama.Text=DgvGuncelleSil.SelectedRows[0].Cells[6].Value.ToString();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbxAdSoyad.Text="";
            txtbxTelNo.Text="";
            comboBoxCinsiyet.Text="";
            txtbxYas.Text="";
            txtbxTutar.Text="";
            comboBoxZamanlama.Text="";
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Silinecek Üyeyi Seçiniz");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "delete from Uyetablo where Id=" + key + ";";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Silindi");
                    baglanti.Close();
                    Uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (key==0 || txtbxAdSoyad.Text==""||txtbxTelNo.Text==""||comboBoxCinsiyet.Text==""||txtbxYas.Text==""||txtbxTutar.Text==""||comboBoxZamanlama.Text=="")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "update UyeTablo set Adsoyad='"+txtbxAdSoyad.Text+"',Telefon='"+txtbxTelNo.Text+"',Cinsiyet='"+comboBoxCinsiyet.Text+"',Yas='"+txtbxYas.Text+"',Odeme='"+txtbxTutar.Text+"',Zamanlama='"+comboBoxZamanlama.Text+"' where Id="+key+"";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Güncellendi");
                    baglanti.Close();
                    Uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
