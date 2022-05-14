using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace LoginPanel1
{
    public partial class Form1 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=logregpanel;user=enes;Pwd=***;SslMode=none");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text != "")
            {
                if (guna2TextBox2.Text != "")
                {
                    
                    string user = guna2TextBox1.Text;
                    string pass = guna2TextBox2.Text;
                    cmd = new MySqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM kullanici where kullaniciadi='" + user + "' AND sifre='" + pass + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        Form3 frm3 = new Form3();
                        frm3.user = user;
                        frm3.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre Girdiniz.");
                    }
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Şifre boş olamaz.");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı boş olamaz.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Select();
        }
    }
}
