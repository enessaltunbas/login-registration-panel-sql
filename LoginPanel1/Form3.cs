using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace LoginPanel1
{
    public partial class Form3 : Form
    {
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
            con = new MySqlConnection("Server=localhost;Database=logregpanel;user=enes;Pwd=***;SslMode=none");
        }
        public string user;
        private void Form3_Load(object sender, EventArgs e)
        {
            cmd = new MySqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT adi ,soyadi FROM kullanici where kullaniciadi='" + user + "'";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label2.Text = dr["adi"].ToString() + " " + dr["soyadi"].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
