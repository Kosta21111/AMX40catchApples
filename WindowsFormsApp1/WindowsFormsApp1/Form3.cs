using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        int death;
        int resque;
        int dangerous;

        public Form3(int deaths, int resques, int danger)
        {
            InitializeComponent();

            death = deaths;
            resque = resques;
            dangerous = danger;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label6.Text = resque.ToString();
            label7.Text = death.ToString();
            label8.Text = dangerous.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
