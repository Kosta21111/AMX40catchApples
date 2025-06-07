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

        // Для 1-10 уровней
        int[] randomizer = new int[10] { 20, 18, 18, 20, 17, 20, 20, 25, 8, 18 };
        int[] speed = new int[10] { 5, 6, 8, 10, 10, 12, 17, 20, 11, 20 };
        int[] time_left = new int[10] { 80, 80, 100, 120, 150, 180, 180, 180, 180, 180 };
        bool[] bombs = new bool[10] { false, false, true, true, true, true, true, true, true, true };
        int[] frequence_bombs = new int[10] { 0, 0, 120, 120, 80, 70, 40, 50, 120, 30 };
        int[] level = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // Для 1-10 уровней

        // Для 11-20 уровней
        int[] randomizer2 = new int[10] { 20, 20, 22, 15, 17, 12, 7, 30, 8, 50 };
        int[] speed2 = new int[10] { 9, 9, 12, 15, 10, 17, 13, 16, 14, 16 };
        int[] time_left2 = new int[10] { 180, 180, 180, 180, 300, 180, 180, 180, 180, 180 };
        bool[] bombs2 = new bool[10] { true, true, true, true, true, true, true, true, true, true };
        int[] frequence_bombs2 = new int[10] { 90, 80, 60, 80, 80, 70, 120, 25, 120, 20 };
        int[] level2 = new int[10] { 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        string[] enemies = new string[10] { "", "", "", "", "Босс 1_5.jpg", "", "", "", "", ""};
        int[] boss_hp2 = new int[10] { 0, 0, 0, 0, 2, 0, 0, 0, 0, 0};
        // Для 11-20 уровней

        // Для 21-30 уровней
        int[] randomizer3 = new int[10] { 20, 25, 80, 80, 12, 120, 7, 240, 240, 240 };
        int[] speed3 = new int[10] { 9, 12, 12, 15, 10, 10, 11, 16, 8, 16 };
        int[] time_left3 = new int[10] { 180, 180, 180, 180, 180, 180, 240, 240, 240, 240 };
        bool[] bombs3 = new bool[10] { true, true, true, true, true, true, true, true, true, true };
        int[] frequence_bombs3 = new int[10] { 50, 80, 40, 30, 80, 10, 120, 960, 7, 999999 };
        int[] frequence_energo3 = new int[10] { 120, 120, 80, 120, 240, 120, 960, 30, 999999, 10 };
        int[] level3 = new int[10] { 21, 22, 23, 24, 25, 26, 27, 28, 29, 30 };
        // Для 21-30 уровней

        // Для боссов
        string[] boss = new string[3] { "Босс 1.jpg", "Босс 2.jpg", "Босс 3.jpg" };
        int[] boss_hp = new int[3] { 3, 5, 30 };
        int[] boss_randomizer = new int[3] { 28, 18, 80 };
        int[] boss_speed = new int[3] { 12, 12, 16 };
        int[] boss_frequence_bombs = new int[3] { 80, 40, 40 };
        int[] boss_unactive_bombs = new int[3] { 360, 360, 200 };
        // Для боссов

        // Союзники
        bool shved;
        bool bogatyr;
        // Союзники
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

        private void button11_Click(object sender, EventArgs e)
        {
            shved = false;
            bogatyr = false;
            Form5 form = new Form5(bogatyr, shved, boss[0], boss_unactive_bombs[0], boss_frequence_bombs[0], boss_hp[0], boss_speed[0], boss_randomizer[0]);
            form.Show();
        }

        private void достиженияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            shved = false;
            Form7 form = new Form7(shved, level2[0], frequence_bombs2[0], bombs2[0], randomizer2[0], speed2[0], time_left2[0], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            shved = false;
            Form7 form = new Form7(shved, level2[1], frequence_bombs2[1], bombs2[1], randomizer2[1], speed2[1], time_left2[1], enemies[1], boss_hp2[1]);
            form.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            shved = false;
            Form7 form = new Form7(shved, level2[2], frequence_bombs2[2], bombs2[2], randomizer2[2], speed2[2], time_left2[2], enemies[2], boss_hp2[2]);
            form.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            shved = false;
            Form7 form = new Form7(shved, level2[3], frequence_bombs2[3], bombs2[3], randomizer2[3], speed2[3], time_left2[3], enemies[3], boss_hp2[3]);
            form.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            shved = false;
            bogatyr = false;
            Form5 form = new Form5(bogatyr, shved, enemies[4], 200, 40, 2, 14, 15);
            form.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            shved = true;
            Form7 form = new Form7(shved, level2[5], frequence_bombs2[5], bombs2[5], randomizer2[5], speed2[5], time_left2[5], enemies[5], boss_hp2[5]);
            form.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            shved = true;
            Form7 form = new Form7(shved, level2[6], frequence_bombs2[6], bombs2[6], randomizer2[6], speed2[6], time_left2[6], enemies[6], boss_hp2[6]);
            form.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            shved = true;
            Form7 form = new Form7(shved, level2[7], frequence_bombs2[7], bombs2[7], randomizer2[7], speed2[7], time_left2[7], enemies[7], boss_hp2[7]);
            form.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            shved = true;
            Form7 form = new Form7(shved, level2[8], frequence_bombs2[8], bombs2[8], randomizer2[8], speed2[8], time_left2[8], enemies[8], boss_hp2[8]);
            form.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            shved = true;
            Form7 form = new Form7(shved, level2[9], frequence_bombs2[9], bombs2[9], randomizer2[9], speed2[9], time_left2[9], enemies[9], boss_hp2[9]);
            form.Show();
        }

        private void button22_Click(object sender, EventArgs e)
        {

            MessageBox.Show(" - 'Слушай, малыш!' - насторожённо произнёс швед. ' - Я вспомнил, какие планы у этого мерзавца-переростка, " +
                "носящего название Е 100. Они похожи на проект Вавилонский башни. Танки со всего мира начали объединяться, чтобы никакие различия не могли порождать войны... " +
                "И кому-то это невыгодно, и он хочет, чтобы каждый был сам за себя! Этот безумец использует своих единомышленников, они не дадут тебе так просто подобраться к нему. Либо взорвут, либо " +
                "отправят малышей на переработку.'\n" +
                "' - Но зачем им это нужно?' - спросил AMX 40.\n" +
                "' - А чёрт его знает, что за тараканы у них в стальных башнях, малой!'\n" +
                " Мы постарались незаметно подобраться к очередной темнице, в которой сидели малыши, как вдруг над нами появился очередной " +
                "противник. Мы кое-как успели отреагировать на зажжённый фитиль падавшей на нас бомбы и увернуться от взрывной волны. Нас ждало " +
                "жесточайшее сопротивление!");
            

            shved = true;
            bogatyr = false;
            Form5 form = new Form5(bogatyr, shved, boss[1], boss_unactive_bombs[1], boss_frequence_bombs[1], boss_hp[1], boss_speed[1], boss_randomizer[1]);
            form.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" - 'Это безумие!' - наблюдая за происходящим, возмущался Дедушка-Швед.\n" +
                "'Эти негодяи используют оружие по последнему слову техники! Они пытаются внедрить свой деспотичный строй! \n" +
                "Чего только они ни сделают, чтобы танки разных национальностей возненавидели друг друга! Моя жена - AMX 38! \n" +
                "Я не позволю рассорить француженку и шведа!'\n" +
                "   - 'Понимаю твой гнев...' - ответил AMX 40. ' Их надо остановить, иначе проект Вавилонской башни будет воплощён " +
                "в реальность!'\n" +
                " - 'Будь осторожен... И меня не забывай звать на помощь, если что...'");

            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[0], frequence_bombs3[0], frequence_energo3[0], bombs3[0], randomizer3[0], speed3[0], time_left3[0], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[1], frequence_bombs3[1], frequence_energo3[1], bombs3[1], randomizer3[1], speed3[1], time_left3[1], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[2], frequence_bombs3[2], frequence_energo3[2], bombs3[2], randomizer3[2], speed3[2], time_left3[2], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[3], frequence_bombs3[3], frequence_energo3[3], bombs3[3], randomizer3[3], speed3[3], time_left3[3], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[4], frequence_bombs3[4], frequence_energo3[4], bombs3[4], randomizer3[4], speed3[4], time_left3[4], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[5], frequence_bombs3[5], frequence_energo3[5], bombs3[5], randomizer3[5], speed3[5], time_left3[5], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[6], frequence_bombs3[6], frequence_energo3[6], bombs3[6], randomizer3[6], speed3[6], time_left3[6], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[7], frequence_bombs3[7], frequence_energo3[7], bombs3[7], randomizer3[7], speed3[7], time_left3[7], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[8], frequence_bombs3[8], frequence_energo3[8], bombs3[8], randomizer3[8], speed3[8], time_left3[8], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button32_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form10 form = new Form10(bogatyr, shved, level3[9], frequence_bombs3[9], frequence_energo3[9], bombs3[9], randomizer3[9], speed3[9], time_left3[9], enemies[0], boss_hp2[0]);
            form.Show();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            shved = true;
            bogatyr = true;
            Form5 form = new Form5(bogatyr, shved, boss[2], boss_unactive_bombs[2], boss_frequence_bombs[2], boss_hp[2], boss_speed[2], boss_randomizer[2]);
            form.Show();
        }
    }
}
