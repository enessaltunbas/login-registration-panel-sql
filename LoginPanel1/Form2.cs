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
    public partial class Form2 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=logregpanel;user=enes;Pwd=***;SslMode=none");
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Select();
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
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        public Boolean userkontrol()
        {
            string user = guna2TextBox4.Text;
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kullanici where kullaniciadi='" + user + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return true;
            }
            con.Close();
            return false;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {


            if(userkontrol() == false)
            { 
                if(guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
                {
                    if(guna2TextBox4.Text != "")
                    {
                        if(guna2TextBox3.Text != "")
                        { 
                            if(guna2TextBox5.Text != "")
                            {
                                if(guna2TextBox5.Text == guna2TextBox6.Text)
                                {
                                    
                                    con.Open();
                                    MySqlCommand komute = new MySqlCommand("insert into kullanici values (@e1,@e2,@e3,@e4,@e5)", con);
                                    komute.Parameters.AddWithValue("@e1", guna2TextBox4.Text);
                                    komute.Parameters.AddWithValue("@e2", guna2TextBox3.Text);
                                    komute.Parameters.AddWithValue("@e3", guna2TextBox5.Text);
                                    komute.Parameters.AddWithValue("@e4", guna2TextBox1.Text);
                                    komute.Parameters.AddWithValue("@e5", guna2TextBox2.Text);
                                    komute.ExecuteNonQuery();
                                    MessageBox.Show("Kullanıcı başarıyla kayıt edildi.");
                                    Form1 frm1 = new Form1();
                                    frm1.Show();
                                    this.Hide();
                                    con.Close();
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Şifrelerinizin aynı olması gerekmekte.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Şifreniz boş olamaz.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Epostanız boş olamaz.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı boş olamaz.");
                    }
                }
                else
                {
                    MessageBox.Show("Adınız ve soyadınız boş olamaz.");
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı adı zaten mevcut.");
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            guna2TextBox1.Text = guna2TextBox1.Text.ToUpper();
        }

        private void guna2TextBox2_Leave(object sender, EventArgs e)
        {
            guna2TextBox2.Text = guna2TextBox2.Text.ToUpper();
        }
    }
}
