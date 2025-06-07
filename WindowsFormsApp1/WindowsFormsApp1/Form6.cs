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

namespace WindowsFormsApp1
{


    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        int[] kolvo = new int[4];

        private void Form6_Load(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

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
            }

            Leicht.Close();

            button1.Text = kolvo[0].ToString();
            button2.Text = kolvo[2].ToString();
            button3.Text = kolvo[1].ToString();
            button5.Text = kolvo[3].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заговорённый - победить, спасая малышей рядом с бомбами!\n" +
                    "\nУсловия:\n" +
                    "Допускается получение урона через бомбы;\n" +
                    "Необходимо спасти не менее 3 малышей, находящихся в зоне риска попадания бомбы;\n" +
                    "Выдаётся на 5 уровне и выше;\n\n" +
                    $"Всего получено наград: {kolvo[0]}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сердце ангела - победить, не потеряв ни одного малыша за уровень!\n" +
                    "\nУсловия:\n" +
                    "Допускается получение урона от бомб;\n" +
                    "Герой должен спасти не менее 125 малышей.\n\n" +
                    $"Всего получено наград: {kolvo[2]}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Мастер танцпола - победить, уклонившись от всех бомб босса!\n" +
                    "\nУсловия:\n" +
                    "Босс должен запустить в героя не менее 90 бомб;\n\n" +
                    $"Всего получено наград: {kolvo[1]}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;

            label1.Text = "Статистика";

            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button5.Visible = false;

            string[] stat = new string[3] { "Спасено малышей", "Упущено малышей", "Опасных спасений" };

            int count = System.IO.File.ReadAllLines("Статистика.txt").Length; // длина временного ряда
            StreamReader Leicht = new StreamReader("Статистика.txt");

            string[] xarakt = new string[count];

            for (int i = 0; i < count; i++)
            {
                xarakt[i] = Leicht.ReadLine();
            }

            label5.Text = xarakt[0].ToString();
            label6.Text = xarakt[1].ToString();
            label7.Text = xarakt[2].ToString();

            Leicht.Close();
        }

        private void достиженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;

            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;

            label1.Text = "Достижения";

            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Стальная легенда - Союзник АМХ 40, Богатырь, должен отразить не менее 10 бомб!\n" +
                    "\nУсловия:\n" +
                    "Богатырь должен уцелеть к концу уровня;\n" +
                    "Полученный и заблокированный урон должен суммарно составлять не менее 60 ед. \n" +
                    $"Всего наград получено: {kolvo[3]}");
        }
    }
}
