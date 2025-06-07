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
        bool[] estj = new bool[3];

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

            int[] kolvo = new int[4];

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
            Sw.WriteLine($"Мастер танцпола; {kolvo[1]}");
            Sw.WriteLine($"Сердце ангела; {kolvo[2]}");
            Sw.WriteLine($"Стальная легенда; {kolvo[3]}");

            Sw.Close();

            if (estj[0])
            {
                pictureBox1.Image = System.Drawing.Image.FromFile($"Заговорённый.jpg");
                pictureBox1.Image.Tag = "Заговорённый.jpg";
            }

            if (estj[1] && pictureBox1.Image == null)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile($"Мастер танцпола.jpg");
                pictureBox1.Image.Tag = "Мастер танцпола.jpg";
            }
            else if (estj[1] && pictureBox1.Image != null)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile($"Мастер танцпола.jpg");
                pictureBox2.Image.Tag = "Мастер танцпола.jpg";
            }

            if (estj[2] && pictureBox1.Image == null)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile($"Сердце ангела.jpg");
                pictureBox1.Image.Tag = "Сердце ангела.jpg";
            }
            else if (estj[2] && pictureBox1.Image != null && pictureBox2.Image == null)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile($"Сердце ангела.jpg");
                pictureBox2.Image.Tag = "Сердце ангела.jpg";
            }
            else if (estj[2] &&pictureBox2.Image != null)
            {
                pictureBox3.Image = System.Drawing.Image.FromFile($"Сердце ангела.jpg");
                pictureBox3.Image.Tag = "Сердце ангела.jpg";
            }

            if (estj[3] && pictureBox1.Image == null)
            {
                pictureBox1.Image = System.Drawing.Image.FromFile($"Стальная легенда!.jpg");
                pictureBox1.Image.Tag = "Стальная легенда.jpg";
            }
            else if (estj[3] && pictureBox1.Image != null && pictureBox2.Image == null)
            {
                pictureBox2.Image = System.Drawing.Image.FromFile($"Стальная легенда!.jpg");
                pictureBox2.Image.Tag = "Стальная легенда.jpg";
            }
            else if (estj[3] && pictureBox2.Image != null && pictureBox3.Image == null)
            {
                pictureBox3.Image = System.Drawing.Image.FromFile($"Стальная легенда!.jpg");
                pictureBox3.Image.Tag = "Стальная легенда.jpg";
            }
            else if (estj[3] && pictureBox3.Image != null)
            {
                pictureBox4.Image = System.Drawing.Image.FromFile($"Стальная легенда!.jpg");
                pictureBox4.Image.Tag = "Стальная легенда.jpg";
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
                    "Выдаётся на 5 уровне и выше.");
            }

            if (pictureBox1.Image?.Tag?.ToString() == "Мастер танцпола.jpg")
            {
                MessageBox.Show("Мастер танцпола - победить, уклонившись от всех бомб босса!\n" +
                    "\nУсловия:\n" +
                    "Босс должен запустить в героя не менее 90 бомб.\n");
            }

            if (pictureBox1.Image?.Tag?.ToString() == "Сердце ангела.jpg")
            {
                MessageBox.Show("Сердце ангела - победить, не потеряв ни одного малыша за уровень!\n" +
                    "\nУсловия:\n" +
                    "Допускается получение урона от бомб;\n" +
                    "Герой должен спасти не менее 125 малышей.");
            }

            if (pictureBox1.Image?.Tag?.ToString() == "Стальная легенда!.jpg")
            {
                MessageBox.Show("Стальная легенда - Союзник АМХ 40, Богатырь, должен отразить не менее 10 бомб!\n" +
                    "\nУсловия:\n" +
                    "Богатырь должен уцелеть к концу уровня;\n" +
                    "Полученный и заблокированный урон должен суммарно составлять не менее 60 ед.");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image?.Tag?.ToString() == "Мастер танцпола.jpg")
            {
                MessageBox.Show("Мастер танцпола - победить, уклонившись от всех бомб босса!\n" +
                    "\nУсловия:\n" +
                    "Босс должен запустить в героя не менее 90 бомб.\n");
            }

            if (pictureBox2.Image?.Tag?.ToString() == "Сердце ангела.jpg")
            {
                MessageBox.Show("Сердце ангела - победить, не потеряв ни одного малыша за уровень!\n" +
                    "\nУсловия:\n" +
                    "Допускается получение урона от бомб;\n" +
                    "Герой должен спасти не менее 125 малышей.");
            }

            if (pictureBox2.Image?.Tag?.ToString() == "Стальная легенда!.jpg")
            {
                MessageBox.Show("Стальная легенда - Союзник АМХ 40, Богатырь, должен отразить не менее 10 бомб!\n" +
                    "\nУсловия:\n" +
                    "Богатырь должен уцелеть к концу уровня;\n" +
                    "Полученный и заблокированный урон должен суммарно составлять не менее 60 ед.");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image?.Tag?.ToString() == "Сердце ангела.jpg")
            {
                MessageBox.Show("Сердце ангела - победить, не потеряв ни одного малыша за уровень!\n" +
                    "\nУсловия:\n" +
                    "Допускается получение урона от бомб;\n" +
                    "Герой должен спасти не менее 125 малышей.");
            }

            if (pictureBox3.Image?.Tag?.ToString() == "Стальная легенда!.jpg")
            {
                MessageBox.Show("Стальная легенда - Союзник АМХ 40, Богатырь, должен отразить не менее 10 бомб!\n" +
                    "\nУсловия:\n" +
                    "Богатырь должен уцелеть к концу уровня;\n" +
                    "Полученный и заблокированный урон должен суммарно составлять не менее 60 ед.");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image?.Tag?.ToString() == "Стальная легенда!.jpg")
            {
                MessageBox.Show("Стальная легенда - Союзник АМХ 40, Богатырь, должен отразить не менее 10 бомб!\n" +
                    "\nУсловия:\n" +
                    "Богатырь должен уцелеть к концу уровня;\n" +
                    "Полученный и заблокированный урон должен суммарно составлять не менее 60 ед.");
            }
        }
    }
}
