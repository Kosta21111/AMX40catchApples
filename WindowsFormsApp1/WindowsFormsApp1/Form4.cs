using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        bool[] estj = new bool[1];

        public Form4(bool[] achievements)
        {
            estj = achievements;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            int[] kolvo = new int[1];

            int count = System.IO.File.ReadAllLines("Достижения.txt").Length; // длина временного ряда
            StreamReader Leicht = new StreamReader("Достижения.txt");

            string[] xarakt = new string[count];
            string[] settings = new string[count];
            string[,] dannye = new string[count, 2];

            for (int i = 0; i < count; i++)
            {
                xarakt[i] = Leicht.ReadLine();
                settings = xarakt[i].Split(';');
                for (int j = 0; j < 2; j++)
                {
                    dannye[i, j] = settings[j];
                }
            }

            for (int i = 0; i < count; i++)
            {
                kolvo[i] = Convert.ToInt32(dannye[i, 1]);

                if (estj[i])
                {
                    kolvo[i] += 1;
                }
            }

            Leicht.Close();

            StreamWriter Sw = new StreamWriter("Достижения.txt");
            Sw.WriteLine($"Заговорённый; {kolvo[0]}");

            Sw.Close();

            if (estj[0])
            {
                pictureBox1.Image = System.Drawing.Image.FromFile($"Заговорённый.jpg");
                pictureBox1.Image.Tag = "Заговорённый.jpg";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image?.Tag?.ToString() == "Заговорённый.jpg")
            {
                MessageBox.Show("Заговорённый - победить, спасая малышей рядом с бомбами!\n" +
                    "\nУсловия:\n" +
                    "Допускается получение урона через бомбы;\n" +
                    "Необходимо спасти не менее 3 малышей, находящихся в зоне риска попадания бомбы;\n" +
                    "Выдаётся на 5 уровне и выше;");
            }
        }
    }
}
