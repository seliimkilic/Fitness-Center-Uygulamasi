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
    public partial class UyeEkle : Form
    {
        

        
        public UyeEkle()
        {
            InitializeComponent();
        }

        private void UyeEkle_Load(object sender, EventArgs e)
        {
        

        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-JT2ALK4\SQLEXPRESS;Database=FitnessDB;Integrated Security=True");
            if (txtbxAdSoyad.Text=="" || txtbxTelNo.Text==""||txtbxYas.Text==""||txtbxTutar.Text=="")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz!");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into Uyetablo values('" + txtbxAdSoyad.Text + "','" + txtbxTelNo.Text+ "','" + comboBoxCinsiyet.SelectedItem.ToString() + "','" + txtbxYas.Text + "','" + txtbxTutar.Text + "','" + comboBoxZamanlama.SelectedItem.ToString() + "')";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Başarıyla Eklendi");
                    baglanti.Close();
                    txtbxAdSoyad.Text="";
                    txtbxTelNo.Text="";
                    txtbxTutar.Text="";
                    txtbxYas.Text="";
                    comboBoxCinsiyet.Text="";
                    comboBoxZamanlama.Text=""; 

                }
                catch (Exception Ex)
                {

                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbxAdSoyad.Text="";
            txtbxTelNo.Text="";
            txtbxTutar.Text="";
            txtbxYas.Text="";
            comboBoxCinsiyet.Text="";
            comboBoxZamanlama.Text="";
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Anasayfa anasayfa = new Anasayfa();
            anasayfa.Show();
            this.Hide();
        }
    }
}
