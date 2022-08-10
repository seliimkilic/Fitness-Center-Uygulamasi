using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessCenter
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            UyeEkle uyeEkle = new UyeEkle();
            uyeEkle.Show();
            this.Hide();
        }
        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            UyeleriListele uyeleriListele = new UyeleriListele();
            uyeleriListele.Show();
            this.Hide();
        }

        private void BtnGuncelleSil_Click(object sender, EventArgs e)
        {
            GuncelleveSil guncelleSil = new GuncelleveSil();
            guncelleSil.Show();
            this.Hide();
        }

        private void btnOdeme_Click(object sender, EventArgs e)
        {
            Odeme odeme = new Odeme();
            odeme.Show();
            this.Hide();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Hide();
        }
    }
}
