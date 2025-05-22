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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int[] randomizer = new int[10] { 20, 18, 18, 20, 17, 20, 20, 25, 8, 18 };
        int[] speed = new int[10] { 5, 6, 8, 10, 10, 12, 17, 20, 11, 20 };
        int[] time_left = new int[10] { 80, 80, 100, 120, 150, 180, 180, 180, 180, 180 };
        bool[] bombs = new bool[10] { false, false, true, true, true, true, true, true, true, true };
        int[] frequence_bombs = new int[10] { 0, 0, 120, 120, 80, 70, 40, 50, 120, 30 };
        int[] level = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[0], frequence_bombs[0], bombs[0], randomizer[0], speed[0], time_left[0]);
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[1], frequence_bombs[1], bombs[1], randomizer[1], speed[1], time_left[1]);
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[2], frequence_bombs[2], bombs[2], randomizer[2], speed[2], time_left[2]);
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[3], frequence_bombs[3], bombs[3], randomizer[3], speed[3], time_left[3]);
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[4], frequence_bombs[4], bombs[4], randomizer[4], speed[4], time_left[4]);
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[5], frequence_bombs[5], bombs[5], randomizer[5], speed[5], time_left[5]);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[6], frequence_bombs[6], bombs[6], randomizer[6], speed[6], time_left[6]);
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[7], frequence_bombs[7], bombs[7], randomizer[7], speed[7], time_left[7]);
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[8], frequence_bombs[8], bombs[8], randomizer[8], speed[8], time_left[8]);
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(level[9], frequence_bombs[9], bombs[9], randomizer[9], speed[9], time_left[9]);
            form.Show();
        }
    }
}
