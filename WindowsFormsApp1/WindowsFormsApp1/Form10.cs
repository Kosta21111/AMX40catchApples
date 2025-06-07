using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WindowsFormsApp1
{
    public partial class Form10 : Form
    {
        public Form10(bool assist2, bool assist, int level, int frequence_bomba, int frequence_energo, bool bomba, int frequence, int speed, int time, string enemy, int boss_hp)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized; // ← Форма сразу развернётся!
            this.KeyPreview = true;  // ← Важно!
            this.KeyDown += KeyIsDown;

            time_left = time;
            gravity = speed;
            rand = frequence;
            estj_bomby = bomba;
            rand_bomba = frequence_bomba;
            rand_energo = frequence_energo;
            uroven = level;
            HP = boss_hp;
            BossName = enemy;
            sojuznik = assist;
            sojuznik2 = assist2;
        }

        double secAlly = 0;
        double secAlly2 = 0;
        double time = 0;

        int blocked_damage_KV5 = 0;
        int damaged_KV5 = 0;
        int otrazheno_bomb = 0;

        bool sojuznik;
        bool sojuznik2;
        bool muzlo = false;

        bool gotov_KV5 = false;
        double perezaryadka_zashity = 0;

        int hp_sojuz = 0; // ХП шведа
        int hp_sojuz2 = 0; // ХП богатыря
        double zaryad = 0;
        double zaryad2 = 0;

        private int time_left = 0;
        private int score = 0;
        private int health = 5;
        private Random random = new Random();
        private Random random_bomb = new Random();
        private int gravity = 13; // Скорость падения яблок
        private int rand = 0;
        private int rand_bomba = 0;
        private int rand_energo = 0;

        private int Dangerous_Rescue = 0;
        private int uroven = 0;

        private string BossName;
        private int HP;

        private bool estj_bomby;

        private SoundPlayer sound;

        string[] achivki = new string[4] { "Заговорённый", "Мастер танцпола", "Сердце ангела", "Стальная легенда" };
        bool[] achievement = new bool[4] { false, false, false, false };

        private int poterano_malyshej = 0;

        private List<PictureBox> apples_0_8 = new List<PictureBox>();
        private List<PictureBox> apples = new List<PictureBox>();
        private List<PictureBox> apples_1_2 = new List<PictureBox>();

        private List<PictureBox> bombs_0_8 = new List<PictureBox>();
        private List<PictureBox> bombs = new List<PictureBox>();
        private List<PictureBox> bombs_1_2 = new List<PictureBox>();

        private List<PictureBox> bombs_KV5 = new List<PictureBox>();

        private List<PictureBox> EN = new List<PictureBox>();

        private List<PictureBox> SavM43 = new List<PictureBox>();
        private List<PictureBox> KV5 = new List<PictureBox>();

        private void Form10_Load(object sender, EventArgs e)
        {
            gameTimer.Start();
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.DoubleBuffered = true; // Уменьшает мерцание

            if (sojuznik)
            {
                hp_sojuz = 10;
            }

            if (sojuznik2)
            {
                hp_sojuz2 = 40;
            }
        }

        private void SpawnApple()
        {

            Random rand = new Random();

            int malysh = rand.Next(0, 11);
            int grupp = rand.Next(0, 50);

            if (malysh == 0)
            {
                var apple = new PictureBox
                {
                    Size = new Size(157, 88),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 88), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"Leichttraktor.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 1)
            {
                var apple = new PictureBox
                {
                    Size = new Size(167, 85),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 85), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"МС-1.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 2)
            {
                var apple = new PictureBox
                {
                    Size = new Size(153, 72),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 72), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"TKS 20.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 3)
            {
                var apple = new PictureBox
                {
                    Size = new Size(106, 63),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 63), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"ELC EVEN 90.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 4)
            {
                var apple = new PictureBox
                {
                    Size = new Size(155, 92),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 92), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"L6-40.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 5)
            {
                var apple = new PictureBox
                {
                    Size = new Size(177, 103),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 103), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"Strv-m 21.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 6)
            {
                var apple = new PictureBox
                {
                    Size = new Size(147, 91),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 91), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"T1.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 7)
            {
                var apple = new PictureBox
                {
                    Size = new Size(187, 101),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 101), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"Medium I.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 8)
            {
                var apple = new PictureBox
                {
                    Size = new Size(161, 87),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 87), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"Ha-Go.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 9)
            {
                var apple = new PictureBox
                {
                    Size = new Size(192, 101),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 101), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"Kolohousenka.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
            else if (malysh == 10)
            {
                var apple = new PictureBox
                {
                    Size = new Size(178, 96),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 96), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"VAE Type B.jpg");
                if (grupp <= 30 && grupp >= 10)
                {
                    apples.Add(apple);
                }
                if (grupp < 10)
                {
                    apples_0_8.Add(apple);
                }
                if (grupp > 30)
                {
                    apples_1_2.Add(apple);
                }
                this.Controls.Add(apple);
            }
        }

        private void SpawnBomb()
        {
            Random Bombochka = new Random();
            int grupp = Bombochka.Next(0, 50);

            var bomb = new PictureBox
            {
                Size = new Size(56, 58),
                BackColor = Color.Red,
                Location = new Point(random.Next(0, this.ClientSize.Width - 58), 0),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Бомба.jpg");
            if (grupp <= 30 && grupp >= 10)
            {
                bombs.Add(bomb);
            }
            if (grupp < 10)
            {
                bombs_0_8.Add(bomb);
            }
            if (grupp > 30)
            {
                bombs_1_2.Add(bomb);
            }
            this.Controls.Add(bomb);

        }

        private void SpawnEnergo()
        {
            Random Bombochka = new Random();
            var bomb = new PictureBox
            {
                Size = new Size(55, 90),
                BackColor = Color.Red,
                Location = new Point(random.Next(0, this.ClientSize.Width - 90), 0),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Энергетический снаряд.jpg"); 
            EN.Add(bomb);
            this.Controls.Add(bomb);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Движение корзины влево-вправо

            if (!zamedlen)
            {
                if (e.KeyCode == Keys.Left && player.Left > 0)
                    player.Left -= 12;
                if (e.KeyCode == Keys.Right && player.Right < this.ClientSize.Width)
                    player.Left += 12;
            }
            else
            {
                if (e.KeyCode == Keys.Left && player.Left > 0)
                    player.Left -= 6;
                if (e.KeyCode == Keys.Right && player.Right < this.ClientSize.Width)
                    player.Left += 6;
            }

            if (e.KeyCode == Keys.H && zaryad <= 0 && secAlly <= 0 && sojuznik && hp_sojuz > 0)
            {
                secAlly += 20;

                if (secAlly > 0)
                {
                    Random r = new Random();

                    var Ally = new PictureBox
                    {
                        Size = new Size(235, 118),
                        BackColor = Color.Red,
                        Location = new Point(random.Next(0, this.ClientSize.Width - 118), 670),

                    };
                    Ally.Image = System.Drawing.Image.FromFile($"Босс 1_5.jpg");
                    SavM43.Add(Ally);
                    this.Controls.Add(Ally);
                    AllyTimer.Start();
                }
            }

            if (e.KeyCode == Keys.K && zaryad2 <= 0 && secAlly2 <= 0 && sojuznik2 && hp_sojuz2 > 0)
            {
                secAlly2 += 20;

                if (secAlly2 > 0)
                {
                    var Ally = new PictureBox
                    {
                        Size = new Size(372, 187),
                        BackColor = Color.Red,
                        Location = new Point(random.Next(player.Left - 100, player.Right + 100), 605),

                    };
                    Ally.Image = System.Drawing.Image.FromFile($"КВ-5.jpg");
                    KV5.Add(Ally);
                    this.Controls.Add(Ally);
                    AllyTimer2.Start();

                    gotov_KV5 = true; // Готовность отражать бомбы
                }
            }
        }

        private bool DangerousRescue()
        {
            foreach (var apple in apples)
            {
                Point appleLocation = apple.Location;
                int appleX = appleLocation.X + 70;
                int appleY = appleLocation.Y + 30;

                foreach (var bomb in bombs)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }

                foreach (var bomb in bombs_0_8)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }

                foreach (var bomb in bombs_1_2)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }
            }

            foreach (var apple in apples_0_8)
            {
                Point appleLocation = apple.Location;
                int appleX = appleLocation.X + 70;
                int appleY = appleLocation.Y + 30;

                foreach (var bomb in bombs)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }

                foreach (var bomb in bombs_0_8)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }

                foreach (var bomb in bombs_1_2)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }
            }

            foreach (var apple in apples_1_2)
            {
                Point appleLocation = apple.Location;
                int appleX = appleLocation.X + 70;
                int appleY = appleLocation.Y + 30;

                foreach (var bomb in bombs)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }

                foreach (var bomb in bombs_0_8)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }

                foreach (var bomb in bombs_1_2)
                {
                    Point bombLocation = bomb.Location;
                    int bombX = bombLocation.X + 28;
                    int bombY = bombLocation.Y + 29;

                    // Проверяем расстояние и временное окно
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 130 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void AllyTimer_Tick(object sender, EventArgs e)
        {
            secAlly -= 0.1;

            int minim = 1000;

            int Vert = 0;
            int Gor = 0;


            foreach (var apple in apples.ToList())
            {
                if (Vert < apple.Top)
                {
                    Vert = apple.Top;
                    Gor = apple.Left;
                }
            }

            foreach (var apple in apples_1_2.ToList())
            {
                if (Vert < apple.Top)
                {
                    Vert = apple.Top;
                    Gor = apple.Left;
                }
            }

            foreach (var apple in apples_0_8.ToList())
            {
                if (Vert < apple.Top)
                {
                    Vert = apple.Top;
                    Gor = apple.Left;
                }
            }

            foreach (var tank in SavM43.ToList())
            {
                if (Gor < tank.Left)
                {
                    if (Math.Abs(Gor - tank.Left) <= 50)
                    {

                    }
                    else
                    {
                        tank.Left -= 48;
                    }
                }
                else
                {
                    if (Math.Abs(Gor - tank.Left) <= 50)
                    {

                    }
                    else
                    {
                        tank.Left += 48;
                    }
                }
            }

            if (secAlly <= 0 || hp_sojuz <= 0)
            {
                secAlly = 0;
                zaryad += 40;
                AllyTimer.Stop();

                foreach (var tank in SavM43.ToList())
                {
                    SavM43.Remove(tank);
                    this.Controls.Remove(tank);
                }
            }
        }

        bool zamedlen = false;
        double time_of_zamedl = 0;
        double time_of_energo = 0;

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (zaryad > 0)
            {
                zaryad -= 0.1;
                zaryad = Math.Round(zaryad, 1);

                if (zaryad <= 0.1)
                {
                    zaryad = 0;
                }
            }

            if (zaryad2 > 0)
            {
                zaryad2 -= 0.1;
                zaryad2 = Math.Round(zaryad2, 1);

                if (zaryad2 <= 0.1)
                {
                    zaryad2 = 0;
                }
            }

            if (!achievement[0])
            {
                if (Dangerous_Rescue >= 3 && uroven >= 5)
                {
                    achievement[0] = true;
                }
            }

            time += gameTimer.Interval * 1f / 1000f;
            if (time >= time_left && time > 1)
            {
                gameTimer.Stop();

                if (uroven == 30)
                {
                    MessageBox.Show("   - 'Ну и пекло!' - еле передвигая потёртыми в спешке гусеницами, выдал АМХ 40. \n" +
                        "   - 'Этот злодей зашёл слишком далеко...' - возмущается Дедушка-Швед. 'Этот безумец готов " +
                        "дъяволу душу продать, лишь бы реализовать свои коварные планы...'\n" +
                        "   - 'У него в плену мои дети!' - добавил Богатырь. 'Вот бы поехать к нему сейчас, моя сковорода " +
                        "быстро бы его образумила!'\n" +
                        "   Опьянённый желанием вернуть своих детей к прежней, мирной жизни, КВ-5 уверенно помчал вперёд.\n" +
                        "   - 'Стой, Богатырь!' - сказал Дедушка-Швед. 'Мы не знаем, насколько враг силён! Побереги свои силы...\n" +
                        "Нужен план, надёжный как швейцарские часы!'" +
                        "   Вместе мы обсуждали план, как попасть внутрь обители того злодея Е 100. Много малышей было спасено ранее," +
                        " кое-кто даже перемещался по нашим горячим следам. Это были Ha-Go и ELC EVEN 90. Их верность освободителям была " +
                        "настолько высока, что они согласились разведать обстановку и найти брешь во вражеской обороне.\n" +
                        "   Вскоре малыши вернулись, даже план входа нарисовали. План, конечно, был карикатурный, но АМХ 40 быстро понял, " +
                        "что надо делать... Времени осталось мало, и небольшой отряд освободителей готовился к решающему бою!");
                }

                sound = new SoundPlayer("Victory.wav");
                sound.Play(); // PlaySync() — если нужно ждать окончания

                int count = System.IO.File.ReadAllLines("Статистика.txt").Length; // длина временного ряда
                StreamReader Leicht = new StreamReader("Статистика.txt");

                string[] xarakt = new string[count];

                for (int i = 0; i < count; i++)
                {
                    xarakt[i] = Leicht.ReadLine();
                }

                Leicht.Close();

                int spaseno = score + Convert.ToInt32(xarakt[0]);
                int destroyed = poterano_malyshej + Convert.ToInt32(xarakt[1]);
                int dang = Dangerous_Rescue + Convert.ToInt32(xarakt[2]);

                StreamWriter Sw = new StreamWriter("Статистика.txt");

                Sw.WriteLine(spaseno);
                Sw.WriteLine(destroyed);
                Sw.WriteLine(dang);

                Sw.Close();

                if (score >= 125 && poterano_malyshej == 0)
                {
                    achievement[2] = true;
                }

                if (damaged_KV5 + blocked_damage_KV5 >= 60 && hp_sojuz2 > 0 && otrazheno_bomb >= 10)
                {
                    achievement[3] = true;
                }

                Form3 form = new Form3(poterano_malyshej, score, Dangerous_Rescue);
                form.Show();

                if (achievement[0] || achievement[2] || achievement[3])
                {
                    Form4 form1 = new Form4(achievement);
                    form1.Show();
                }
            }

            if (!muzlo)
            {
                if (time_left - time < 80)
                {
                    rand_bomba = (int)(rand_bomba * 0.65);
                    rand_energo = (int)(rand_energo * 0.65);

                    muzlo = true;
                    sound = new SoundPlayer("Финальное сражение.wav");
                    sound.Play(); // PlaySync() — если нужно ждать окончания
                    /*var shoot = new AudioFileReader("Финальное сражение.wav");
                    var waveOut1 = new WaveOutEvent();
                    waveOut1.Init(shoot);
                    waveOut1.Play();*/

                    muzlo = true;
                }
            }

            // Случайное появление яблок
            if (random.Next(0, rand) == 1)
                SpawnApple();

            if (estj_bomby)
            {
                if (random.Next(0, rand_bomba) == 1)
                {
                    Random f = new Random();
                    int Attack = f.Next(0, 10);
                    if (Attack >= 2)
                    {
                        SpawnBomb();
                    }
                    else if (Attack == 1)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            SpawnBomb();
                        }
                    }
                    
                }
            }


            if (random.Next(0, rand_energo) == 1)
            {
                if (timerEnergo.Enabled)
                {

                }
                else
                {
                    time_of_energo = 5;
                    timerEnergo.Start();
                }
            }
            
            

            // Движение яблок вниз
            foreach (var apple in apples.ToList())
            {
                apple.Top += gravity;

                // Если яблоко упало за экран — удаляем
                if (apple.Top > this.ClientSize.Height)
                {
                    health -= 1;
                    poterano_malyshej += 1;

                    if (poterano_malyshej > 1)
                    {
                        achievement[0] = false;
                    }

                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    var explosion = new AudioFileReader("Смех.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    apples.Remove(apple);
                    this.Controls.Remove(apple);
                }
                // Если игрок поймал яблоко
                else if (apple.Bounds.IntersectsWith(player.Bounds))
                {
                    score++;

                    if (DangerousRescue())
                    {
                        Dangerous_Rescue += 1;
                    }

                    scoreLabel.Text = "Счет: " + score;
                    apples.Remove(apple);
                    this.Controls.Remove(apple);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (apple.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                score++;

                                scoreLabel.Text = "Счет: " + score;
                                apples.Remove(apple);
                                this.Controls.Remove(apple);
                            }
                        }
                    }
                }
            }

            foreach (var apple in apples_0_8.ToList())
            {
                apple.Top += (int)(gravity * 0.8);

                // Если яблоко упало за экран — удаляем
                if (apple.Top > this.ClientSize.Height)
                {
                    health -= 1;
                    poterano_malyshej += 1;

                    if (poterano_malyshej > 1)
                    {
                        achievement[0] = false;
                    }

                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    var explosion = new AudioFileReader("Смех.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    apples_0_8.Remove(apple);
                    this.Controls.Remove(apple);
                }
                // Если игрок поймал яблоко
                else if (apple.Bounds.IntersectsWith(player.Bounds))
                {
                    score++;

                    if (DangerousRescue())
                    {
                        Dangerous_Rescue += 1;
                    }

                    scoreLabel.Text = "Счет: " + score;
                    apples_0_8.Remove(apple);
                    this.Controls.Remove(apple);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (apple.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                score++;

                                scoreLabel.Text = "Счет: " + score;
                                apples_0_8.Remove(apple);
                                this.Controls.Remove(apple);
                            }
                        }
                    }
                }
            }

            foreach (var apple in apples_1_2.ToList())
            {
                apple.Top += (int)(gravity * 1.2);

                // Если яблоко упало за экран — удаляем
                if (apple.Top > this.ClientSize.Height)
                {
                    health -= 1;
                    poterano_malyshej += 1;

                    if (poterano_malyshej > 1)
                    {
                        achievement[0] = false;
                    }

                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    var explosion = new AudioFileReader("Смех.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    apples_1_2.Remove(apple);
                    this.Controls.Remove(apple);
                }
                // Если игрок поймал яблоко
                else if (apple.Bounds.IntersectsWith(player.Bounds))
                {
                    score++;

                    if (DangerousRescue())
                    {
                        Dangerous_Rescue += 1;
                    }

                    scoreLabel.Text = "Счет: " + score;
                    apples_1_2.Remove(apple);
                    this.Controls.Remove(apple);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (apple.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                score++;

                                scoreLabel.Text = "Счет: " + score;
                                apples_1_2.Remove(apple);
                                this.Controls.Remove(apple);
                            }
                        }
                    }
                }
            }

            foreach (var energ in EN.ToList())
            {
                energ.Top += gravity * 4;

                if (sojuznik2 && secAlly2 > 0)
                {
                    if (KV5.Count > 0)
                    {
                        foreach (var tank in KV5.ToList())
                        {
                            if (energ.Bounds.IntersectsWith(tank.Bounds))
                            {
                                hp_sojuz2 -= 1;
                                damaged_KV5 += 1;

                                var explosion = new AudioFileReader("Взрыв.wav");
                                var waveOut2 = new WaveOutEvent();
                                waveOut2.Init(explosion);
                                waveOut2.Play();

                                scoreLabel.Text = "Счет: " + score;
                                EN.Remove(energ);
                                this.Controls.Remove(energ);

                                continue;
                            }
                        }
                    }
                }

                // Если яблоко упало за экран — удаляем
                if (energ.Top > this.ClientSize.Height)
                {

                    EN.Remove(energ);
                    this.Controls.Remove(energ);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания
                }
                // Если игрок поймал яблоко
                else if (energ.Bounds.IntersectsWith(player.Bounds))
                {
                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    health -= 1;
                    zamedlen = true;
                    time_of_zamedl = 10;
                    timerZamedlenija.Start();

                    EN.Remove(energ);
                    this.Controls.Remove(energ);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (energ.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                hp_sojuz -= 1;

                                var explosion = new AudioFileReader("Взрыв.wav");
                                var waveOut2 = new WaveOutEvent();
                                waveOut2.Init(explosion);
                                waveOut2.Play();

                                scoreLabel.Text = "Счет: " + score;
                                EN.Remove(energ);
                                this.Controls.Remove(energ);
                            }
                        }
                    }
                }

                
            }


            foreach (var bomb in bombs.ToList())
            {
                bomb.Top += gravity * 3;

                // Сначала КВ-5, так как он защищает АМХ 40
                if (sojuznik2 && secAlly2 > 0)
                {
                    if (KV5.Count > 0)
                    {
                        foreach (var tank in KV5.ToList())
                        {
                            if (bomb.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                if (!gotov_KV5)
                                {
                                    hp_sojuz2 -= 2;
                                    damaged_KV5 += 2;

                                    var explosion = new AudioFileReader("Взрыв.wav");
                                    var waveOut2 = new WaveOutEvent();
                                    waveOut2.Init(explosion);
                                    waveOut2.Play();

                                    scoreLabel.Text = "Счет: " + score;
                                    bombs.Remove(bomb);
                                    this.Controls.Remove(bomb);

                                    continue;
                                }
                                else
                                {
                                    if (bomb.Left + bomb.Right / 2 >= tank.Left + tank.Right / 2)
                                    {
                                        tank.Image = Image.FromFile("КВ-5 атакует.jpg");
                                        tank.Size = new Size(350, 196);
                                    }
                                    else
                                    {
                                        tank.Image = Image.FromFile("КВ-5 атакует 2.jpg");
                                        tank.Size = new Size(307, 203);
                                    }

                                    var Bomb_KV = new PictureBox()
                                    {
                                        Image = Image.FromFile("Бомба.jpg"),
                                        Size = new Size(56, 58),
                                        BackColor = Color.Red,
                                        Location = new Point((bomb.Left + bomb.Right) / 2, (bomb.Top + bomb.Bottom) / 2)
                                    };

                                    bombs_KV5.Add(Bomb_KV);
                                    this.Controls.Add(Bomb_KV);

                                    bombs.Remove(bomb);
                                    this.Controls.Remove(bomb);

                                    var explosion = new AudioFileReader("Удар сковородой.wav");
                                    var waveOut2 = new WaveOutEvent();
                                    waveOut2.Init(explosion);
                                    waveOut2.Play();

                                    gotov_KV5 = false;
                                    perezaryadka_zashity = 0.5;
                                    blocked_damage_KV5 += 2;
                                    otrazheno_bomb += 1;
                                    TimerOfImmortal.Start();

                                    continue;
                                }
                            }
                        }
                    }
                }

                // Если яблоко упало за экран — удаляем
                if (bomb.Top > this.ClientSize.Height)
                {

                    bombs.Remove(bomb);
                    this.Controls.Remove(bomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    bombs.Remove(bomb);
                    this.Controls.Remove(bomb);
                }
                // Если игрок поймал яблоко
                else if (bomb.Bounds.IntersectsWith(player.Bounds))
                {
                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    health -= 2;
                    bombs.Remove(bomb);
                    this.Controls.Remove(bomb);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (bomb.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                hp_sojuz -= 2;

                                var explosion = new AudioFileReader("Взрыв.wav");
                                var waveOut2 = new WaveOutEvent();
                                waveOut2.Init(explosion);
                                waveOut2.Play();

                                scoreLabel.Text = "Счет: " + score;
                                bombs.Remove(bomb);
                                this.Controls.Remove(bomb);
                            }
                        }
                    }
                }                
            }

            foreach (var bomb in bombs_0_8.ToList())
            {
                bomb.Top += (int)(gravity * 3 * 0.8);

                if (sojuznik2 && secAlly2 > 0)
                {
                    if (KV5.Count > 0)
                    {
                        foreach (var tank in KV5.ToList())
                        {
                            if (bomb.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                if (!gotov_KV5)
                                {
                                    hp_sojuz2 -= 2;
                                    damaged_KV5 += 2;

                                    var explosion = new AudioFileReader("Взрыв.wav");
                                    var waveOut2 = new WaveOutEvent();
                                    waveOut2.Init(explosion);
                                    waveOut2.Play();

                                    scoreLabel.Text = "Счет: " + score;
                                    bombs_0_8.Remove(bomb);
                                    this.Controls.Remove(bomb);

                                    continue;
                                }
                                else
                                {
                                    if (bomb.Left + bomb.Right / 2 >= tank.Left + tank.Right / 2)
                                    {
                                        tank.Image = Image.FromFile("КВ-5 атакует.jpg");
                                        tank.Size = new Size(350, 196);
                                    }
                                    else
                                    {
                                        tank.Image = Image.FromFile("КВ-5 атакует 2.jpg");
                                        tank.Size = new Size(307, 203);
                                    }

                                    var Bomb_KV = new PictureBox()
                                    {
                                        Image = Image.FromFile("Бомба.jpg"),
                                        Size = new Size(56, 58),
                                        BackColor = Color.Red,
                                        Location = new Point((bomb.Left + bomb.Right) / 2, (bomb.Top + bomb.Bottom) / 2)
                                    };

                                    bombs_KV5.Add(Bomb_KV);
                                    this.Controls.Add(Bomb_KV);

                                    bombs_0_8.Remove(bomb);
                                    this.Controls.Remove(bomb);

                                    var explosion = new AudioFileReader("Удар сковородой.wav");
                                    var waveOut2 = new WaveOutEvent();
                                    waveOut2.Init(explosion);
                                    waveOut2.Play();

                                    gotov_KV5 = false;
                                    perezaryadka_zashity = 0.5;
                                    blocked_damage_KV5 += 2;
                                    otrazheno_bomb += 1;
                                    TimerOfImmortal.Start();

                                    continue;
                                }
                            }
                        }
                    }
                }

                // Если яблоко упало за экран — удаляем
                if (bomb.Top > this.ClientSize.Height)
                {

                    bombs_0_8.Remove(bomb);
                    this.Controls.Remove(bomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    bombs_0_8.Remove(bomb);
                    this.Controls.Remove(bomb);
                }
                // Если игрок поймал яблоко
                else if (bomb.Bounds.IntersectsWith(player.Bounds))
                {
                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    health -= 2;
                    bombs_0_8.Remove(bomb);
                    this.Controls.Remove(bomb);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (bomb.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                hp_sojuz -= 2;

                                var explosion = new AudioFileReader("Взрыв.wav");
                                var waveOut2 = new WaveOutEvent();
                                waveOut2.Init(explosion);
                                waveOut2.Play();

                                scoreLabel.Text = "Счет: " + score;
                                bombs_0_8.Remove(bomb);
                                this.Controls.Remove(bomb);
                            }
                        }
                    }
                }
            }

            foreach (var bomb in bombs_1_2.ToList())
            {
                bomb.Top += (int)(gravity * 3 * 1.2);

                if (sojuznik2 && secAlly2 > 0)
                {
                    if (KV5.Count > 0)
                    {
                        foreach (var tank in KV5.ToList())
                        {
                            if (bomb.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                if (!gotov_KV5)
                                {
                                    hp_sojuz2 -= 2;
                                    damaged_KV5 += 2;

                                    var explosion = new AudioFileReader("Взрыв.wav");
                                    var waveOut2 = new WaveOutEvent();
                                    waveOut2.Init(explosion);
                                    waveOut2.Play();

                                    scoreLabel.Text = "Счет: " + score;
                                    bombs_1_2.Remove(bomb);
                                    this.Controls.Remove(bomb);

                                    continue;
                                }
                                else
                                {
                                    if (bomb.Left + bomb.Right / 2 >= tank.Left + tank.Right / 2)
                                    {
                                        tank.Image = Image.FromFile("КВ-5 атакует.jpg");
                                        tank.Size = new Size(350, 196);
                                    }
                                    else
                                    {
                                        tank.Image = Image.FromFile("КВ-5 атакует 2.jpg");
                                        tank.Size = new Size(307, 203);
                                    }

                                    var Bomb_KV = new PictureBox()
                                    {
                                        Image = Image.FromFile("Бомба.jpg"),
                                        Size = new Size(56, 58),
                                        BackColor = Color.Red,
                                        Location = new Point((bomb.Left + bomb.Right) / 2, (bomb.Top + bomb.Bottom) / 2)
                                    };

                                    bombs_KV5.Add(Bomb_KV);
                                    this.Controls.Add(Bomb_KV);

                                    bombs_1_2.Remove(bomb);
                                    this.Controls.Remove(bomb);

                                    var explosion = new AudioFileReader("Удар сковородой.wav");
                                    var waveOut2 = new WaveOutEvent();
                                    waveOut2.Init(explosion);
                                    waveOut2.Play();

                                    gotov_KV5 = false;
                                    perezaryadka_zashity = 0.5;
                                    blocked_damage_KV5 += 2;
                                    otrazheno_bomb += 1;
                                    TimerOfImmortal.Start();

                                    continue;
                                }
                            }
                        }
                    }
                }

                // Если яблоко упало за экран — удаляем
                if (bomb.Top > this.ClientSize.Height)
                {

                    bombs_1_2.Remove(bomb);
                    this.Controls.Remove(bomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    bombs_1_2.Remove(bomb);
                    this.Controls.Remove(bomb);
                }
                // Если игрок поймал яблоко
                else if (bomb.Bounds.IntersectsWith(player.Bounds))
                {
                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    health -= 2;
                    bombs_1_2.Remove(bomb);
                    this.Controls.Remove(bomb);
                }

                if (sojuznik && secAlly > 0)
                {
                    if (SavM43.Count > 0)
                    {
                        foreach (var tank in SavM43.ToList())
                        {
                            if (bomb.Bounds.IntersectsWith(tank.Bounds)) // Здесь ошибка
                            {
                                hp_sojuz -= 2;

                                var explosion = new AudioFileReader("Взрыв.wav");
                                var waveOut2 = new WaveOutEvent();
                                waveOut2.Init(explosion);
                                waveOut2.Play();

                                scoreLabel.Text = "Счет: " + score;
                                bombs_1_2.Remove(bomb);
                                this.Controls.Remove(bomb);
                            }
                        }
                    }
                }
            }

            foreach (var bomb in bombs_KV5.ToList())
            {
                bomb.Top -= gravity * 5;

                // Если яблоко упало за экран — удаляем
                if (bomb.Top > this.ClientSize.Height)
                {

                    bombs_KV5.Remove(bomb);
                    this.Controls.Remove(bomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    bombs_KV5.Remove(bomb);
                    this.Controls.Remove(bomb);
                }
            }

            if (health == 4)
            {
                pictureBox1.Visible = false;
            }

            if (health == 3)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
            }

            if (health == 2)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
            }

            if (health == 1)
            {
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
            }

            if (health <= 0)
            {
                if (achievement[0])
                {
                    achievement[0] = false;
                }

                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                pictureBox5.Visible = false;
                gameTimer.Stop();
                sound = new SoundPlayer("Defeat.wav");
                sound.Play(); // PlaySync() — если нужно ждать окончания

                int count = System.IO.File.ReadAllLines("Статистика.txt").Length; // длина временного ряда
                StreamReader Leicht = new StreamReader("Статистика.txt");

                string[] xarakt = new string[count];

                for (int i = 0; i < count; i++)
                {
                    xarakt[i] = Leicht.ReadLine();
                }

                Leicht.Close();

                int spaseno = score + Convert.ToInt32(xarakt[0]);
                int destroyed = poterano_malyshej + Convert.ToInt32(xarakt[1]);
                int dang = Dangerous_Rescue + Convert.ToInt32(xarakt[2]);

                StreamWriter Sw = new StreamWriter("Статистика.txt");

                Sw.WriteLine(spaseno);
                Sw.WriteLine(destroyed);
                Sw.WriteLine(dang);

                Sw.Close();

                MessageBox.Show("Вы проиграли! Вы не уберегли малышей от беды! Как вы будете смотреть в глаза их родителям?!");

                this.Close();

                Form9 form = new Form9();
                form.Show();
            }
        }

        private void timerZamedlenija_Tick(object sender, EventArgs e)
        {
            time_of_zamedl -= timerZamedlenija.Interval * 0.001;

            if (time_of_zamedl < 0)
            {
                time_of_zamedl = 0;
                zamedlen = false;
                timerZamedlenija.Stop();
            }
        }

        private void timerEnergo_Tick(object sender, EventArgs e)
        {
            time_of_energo -= timerZamedlenija.Interval * 0.001;
            time_of_energo = Math.Round(time_of_energo, 1);

            if (time_of_energo % 0.5 == 0)
            {
                SpawnEnergo();
            }

            if (time_of_energo < 0)
            {
                time_of_energo = 0;
                timerEnergo.Stop();
            }
        }

        private void AllyTimer2_Tick(object sender, EventArgs e)
        {
            secAlly2 -= 0.1;

            foreach (var tank in KV5.ToList())
            {

                if ((player.Left + player.Right) / 2 < (tank.Left + tank.Right) / 2)
                {
                    if (Math.Abs((player.Left + player.Right) / 2 - (tank.Left + tank.Right) / 2) <= 13)
                    {

                    }
                    else
                    {
                        tank.Left -= 24;
                    }
                }
                else
                {
                    if (Math.Abs((player.Left + player.Right) / 2 - (tank.Left + tank.Right) / 2) <= 13)
                    {

                    }
                    else
                    {
                        tank.Left += 24;
                    }
                }
            }

            if (secAlly2 <= 0 || hp_sojuz2 <= 0)
            {
                secAlly2 = 0;
                zaryad2 += 40;
                AllyTimer2.Stop();

                foreach (var tank in KV5.ToList())
                {
                    KV5.Remove(tank);
                    this.Controls.Remove(tank);
                }
            }
        }

        private void TimerOfImmortal_Tick(object sender, EventArgs e)
        {
            perezaryadka_zashity -= TimerOfImmortal.Interval * 0.001;

            if (perezaryadka_zashity <= 0)
            {
                foreach (var tank in KV5.ToList())
                {
                    tank.Image = Image.FromFile("КВ-5.jpg");
                    tank.Size = new Size(372, 187);
                }

                perezaryadka_zashity = 0;
                gotov_KV5 = true;
                TimerOfImmortal.Stop();
            }
        }
    }
}
