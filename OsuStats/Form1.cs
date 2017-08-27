using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpOsu;
namespace OsuStats
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static public string url;
        void GetInfo(string key)
        {
            
            try
            {
                OsuClient osu = new OsuClient(key);
                var user = osu.GetUser(textBox1.Text)[0];
                label2.Text = "Ник: " + user.username;
                label3.Text = "Страна: " + user.country;
                label5.Text = "Level: " + Convert.ToString(user.level).Split('.')[0];
                progressBar1.Value = Convert.ToInt32(Convert.ToString(user.level).Split('.')[1].Substring(0, 2));
                label4.Text = "PP: " + Convert.ToString(user.pp_raw).Split('.')[0];
                label6.Text = "Ранк: " + user.pp_rank + " (" + user.country + ": " + user.pp_country_rank + ")";
                linkLabel1.Text = user.url;
                url = user.url;
                pictureBox1.ImageLocation = user.image;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            groupBox1.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetInfo("your key");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}
