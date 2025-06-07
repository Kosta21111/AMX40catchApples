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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private List<PictureBox> Hints = new List<PictureBox>();
        private List<ProgressBar> Progress = new List<ProgressBar>();
        private List<Label> Lab = new List<Label>();

        private void Form9_Load(object sender, EventArgs e)
        {
            
            timer1.Start();
            button1.Enabled = false;

            Random rand = new Random();

            int podskazka = rand.Next(0, 6);

            if (podskazka == 0)
            {
                var hint = new PictureBox
                {
                    Image = Image.FromFile("Подсказка 1.jpg"),
                    Size = new Size(715, 354),
                    BackColor = Color.Transparent,
                    Location = new Point(150, 150),
                };

                Hints.Add(hint);
                this.Controls.Add(hint);

                var Prog = new ProgressBar
                {
                    Maximum = 1000,
                    Value = 0,
                    Size = new Size(500, 50),
                    Location = new Point(hint.Left, hint.Bottom + 20),
                };

                label1.Location = new Point(hint.Left, hint.Top - 20);
                label2.Location = new Point(hint.Left, hint.Bottom + 50);

                label1.Text = "Универсальный ассистент";
                label2.Text = "Вашему герою сложно бороться с трудностями в одиночку.\nИспользуйте Дедушку-Шведа: он способен подавать " +
                    "дополнительные бомбы \nв борьбе с боссами, а также за Вас подбирать падающих малышей.";

                button1.Location = new Point(label1.Right + 30, label1.Top - 50);

                Progress.Add(Prog);
                this.Controls.Add(Prog);
            }

            if (podskazka == 1)
            {
                var hint = new PictureBox
                {
                    Image = Image.FromFile("Подсказка 2.jpg"),
                    Size = new Size(567, 247),
                    BackColor = Color.Transparent,
                    Location = new Point(150, 150),
                };

                Hints.Add(hint);
                this.Controls.Add(hint);

                var Prog = new ProgressBar
                {
                    Maximum = 1000,
                    Value = 0,
                    Size = new Size(500, 50),
                    Location = new Point(hint.Left, hint.Bottom + 20),
                };

                label1.Location = new Point(hint.Left, hint.Top - 50);
                label2.Location = new Point(hint.Left, hint.Bottom + 50);

                label1.Text = "Наименьший ущерб";
                label2.Text = "Если вы видите малышей рядом с бомбой, подумайте, \nлучше попасть под неё и спасти детей\n" +
                    "или благополучно избежать удара, но потерять их? \nЧем дольше AMX 40 живёт, тем больше шансов\n" +
                    "сорвать коварные планы E 100!";

                button1.Location = new Point(label1.Right + 30, label1.Top - 50);

                Progress.Add(Prog);
                this.Controls.Add(Prog);
            }

            if (podskazka == 2)
            {
                var hint = new PictureBox
                {
                    Image = Image.FromFile("Подсказка 3.jpg"),
                    Size = new Size(768, 282),
                    BackColor = Color.Transparent,
                    Location = new Point(150, 150),
                };

                Hints.Add(hint);
                this.Controls.Add(hint);

                var Prog = new ProgressBar
                {
                    Maximum = 1000,
                    Value = 0,
                    Size = new Size(500, 50),
                    Location = new Point(hint.Left, hint.Bottom + 20),
                };

                label1.Location = new Point(hint.Left, hint.Top - 50);
                label2.Location = new Point(hint.Left, hint.Bottom + 50);

                label1.Text = "Борьба с боссом";
                label2.Text = "В сражениях с боссами будут попадаться незажжённые бомбы. \n" +
                    "Подбирайте их, чтобы победить злодея как можно быстрее!\n" +
                    "С каждым ударом они будут становиться более опасными!";

                button1.Location = new Point(label1.Right + 30, label1.Top - 50);

                Progress.Add(Prog);
                this.Controls.Add(Prog);
            }

            if (podskazka == 3)
            {
                var hint = new PictureBox
                {
                    Image = Image.FromFile("Подсказка 4.jpg"),
                    Size = new Size(867, 306),
                    BackColor = Color.Transparent,
                    Location = new Point(70, 150),
                };

                Hints.Add(hint);
                this.Controls.Add(hint);

                var Prog = new ProgressBar
                {
                    Maximum = 1000,
                    Value = 0,
                    Size = new Size(500, 50),
                    Location = new Point(hint.Left, hint.Bottom + 20),
                };

                label1.Location = new Point(hint.Left, hint.Top - 50);
                label2.Location = new Point(hint.Left, hint.Bottom + 50);

                label1.Text = "Условия победы - уровни по сюжету";
                label2.Text = "В обычных уровнях главное условие победы - \n" +
                    "не растерять критическое количество малышей и не получить \n" +
                    "существенный ущерб в течение определённого времени. При \n" +
                    "достижении 2-й фазы уровня частота падения бомб возрастает!";

                button1.Location = new Point(label1.Right + 30, label1.Top - 50);

                Progress.Add(Prog);
                this.Controls.Add(Prog);
            }

            if (podskazka == 4)
            {
                var hint = new PictureBox
                {
                    Image = Image.FromFile("Подсказка 5.jpg"),
                    Size = new Size(867, 306),
                    BackColor = Color.Transparent,
                    Location = new Point(70, 150),
                };

                Hints.Add(hint);
                this.Controls.Add(hint);

                var Prog = new ProgressBar
                {
                    Maximum = 1000,
                    Value = 0,
                    Size = new Size(500, 50),
                    Location = new Point(hint.Left, hint.Bottom + 20),
                };

                label1.Location = new Point(hint.Left, hint.Top - 50);
                label2.Location = new Point(hint.Left, hint.Bottom + 50);

                label1.Text = "Условия победы - уровни с боссом";
                label2.Text = "В уровнях с боссом достижение победы возможно \n" +
                    "лишь уничтожением злодея! Его необходимо сразить \n" +
                    "как можно скорее! Здесь время играет не на Вас!";

                button1.Location = new Point(label1.Right + 30, label1.Top - 50);

                Progress.Add(Prog);
                this.Controls.Add(Prog);
            }

            if (podskazka == 5)
            {
                var hint = new PictureBox
                {
                    Image = Image.FromFile("Подсказка 6.jpg"),
                    Size = new Size(478, 346),
                    BackColor = Color.Transparent,
                    Location = new Point(70, 150),
                };

                Hints.Add(hint);
                this.Controls.Add(hint);

                var Prog = new ProgressBar
                {
                    Maximum = 1000,
                    Value = 0,
                    Size = new Size(500, 50),
                    Location = new Point(hint.Left, hint.Bottom + 20),
                };

                label1.Location = new Point(hint.Left, hint.Top - 50);
                label2.Location = new Point(hint.Left, hint.Bottom + 50);

                label1.Text = "Стальной супергерой со сковородой";
                label2.Text = "Не брезгуйте помощью Богатыря! \nОн в самый подходящий момент способен принять урон " +
                    "\nна себя, тем самым спасти AMX 40! Кроме того, \nон прочнее синего малыша в 8 (!!!) раз!";

                button1.Location = new Point(label1.Right + 30, label1.Top - 50);

                Progress.Add(Prog);
                this.Controls.Add(Prog);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var prog in Progress)
            {
                prog.Value += 20;

                if (prog.Value == prog.Maximum)
                {
                    timer1.Stop();
                    button1.Enabled = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
