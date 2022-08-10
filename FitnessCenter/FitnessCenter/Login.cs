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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtbxUsername.Text="";
            txtbxPassword.Text="";
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtbxUsername.Text== "" || txtbxPassword.Text== "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz");
            }
            else if(txtbxUsername.Text=="admin" && txtbxPassword.Text== "1234")
            {
                Anasayfa anasayfa = new Anasayfa();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre girdiniz!");
            }
        }
    }
}
