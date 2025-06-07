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
    public partial class Form5 : Form
    {
        string Boss;
        int UnActiveBombs;
        int ActiveBombs;
        int BossHP;
        int Gravity;
        int Malyshi;

        int hp_sojuz = 0;
        int hp_sojuz2 = 0; // ХП богатыря
        double zaryad = 0;
        double zaryad2 = 0;

        private int health = 5;
        private int score = 0;
        private int Dangerous_Rescue = 0;
        private int poterano_malyshej = 0;

        private int zapysheno_bomb = 0;
        private int vzorvano_bomb = 0;

        int blocked_damage_KV5 = 0;
        int damaged_KV5 = 0;
        int otrazheno_bomb = 0;

        bool Steel_March = false;
        bool final = false;
        double muzyka = 0;

        Random random = new Random();
        Random BossAttack = new Random();

        bool vooruzhen = false;
        bool zamedlen = false;

        double time_of_zamedl = 0;
        double time_of_energo = 0;

        double timeAttack = 0;
        int tchisloAttack = 0;

        private List<PictureBox> apples = new List<PictureBox>();
        private List<PictureBox> bombs = new List<PictureBox>();
        private List<PictureBox> UnactiveBombs = new List<PictureBox>();
        private List<PictureBox> MyBomb = new List<PictureBox>();
        private List<PictureBox> bombs_KV5 = new List<PictureBox>();
        private List<PictureBox> EN = new List<PictureBox>();

        private List<PictureBox> SavM43 = new List<PictureBox>();
        private List<PictureBox> KV5 = new List<PictureBox>();

        double secAlly = 0;
        double secAlly2 = 0;

        bool vlevo = true;
        bool vpravo = false;

        bool sojuznik;
        bool sojuznik2;

        bool gotov_KV5 = false;
        double perezaryadka_zashity = 0;

        bool yarost = false;

        private SoundPlayer sound;

        string[] achivki = new string[4] { "Заговорённый", "Мастер танцпола", "Сердце ангела", "Стальная легенда" };
        bool[] achievement = new bool[4] { false, false, false, false };

        public Form5(bool assist2, bool assist, string BossName, int UnActive, int Bombs, int HP, int Speed, int Randomizer)
        {
            this.WindowState = FormWindowState.Maximized; // ← Форма сразу развернётся!
            this.KeyPreview = true;  // ← Важно!
            this.KeyDown += KeyIsDown;



            InitializeComponent();

            Malyshi = Randomizer;
            Gravity = Speed;
            BossHP = HP;
            ActiveBombs = Bombs;
            UnActiveBombs = UnActive;
            Boss = BossName;
            sojuznik = assist;
            sojuznik2 = assist2;

            Enemy.Image = Image.FromFile(BossName);

            if (Boss == "Босс 1_5.jpg")
            {
                MessageBox.Show("   'А вот и ты, тот самый нелепый сопляк, спасающий малышей!' - неразвязно произнёс седовласый маньяк.\n" +
                    "   Я сразу его узнал... Но как? У меня в уме не укладывалось, что приличный шведский механик вдруг пал до таких непристойных\n" +
                    "дел как похищать малышей! Похоже, его надоумил тот самый, кто руководит этим порабощением сверху...\n" +
                    "   'Что тебе надо от малышей? Отпусти их, а затем мы мирно разойдёмся, будто ничего и не было...' - предложил я старому механику.\n" +
                    "   'Нееееет, сопляк! Свои кровные я так просто не отдам! Я уже договорился с главарём, что за каждую выполненную миссию\n" +
                    "он будет мне платить! Деньги мне нужны...'\n" +
                    "   Мне было одновременно жалко его и страшно от него... Кто-то сильно извратил его разум. Я понял, что этому сумасшедшему старику " +
                    "объяснять ценность чужой жизни нет смысла.\n" +
                    "   'Нет... Ты сегодняшний и ты прошлый - слишком разнитесь! Я не позволю тебе обижать невинных! Никакие деньги не стоят\n" +
                    "чужих страданий!'");

                Enemy.Width = 275;
                Enemy.Height = 158;
            }

            if (Boss == "Босс 2.jpg")
            {
                Enemy.Width = 460;
                Enemy.Height = 153;
            }
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

            if (e.KeyCode == Keys.B && vooruzhen)
            {
                vooruzhen = false;
                SpawnMyBomb();
            }

            if (e.KeyCode == Keys.H && zaryad <= 0 && secAlly <= 0 && sojuznik && hp_sojuz > 0)
            {
                secAlly += 20;

                if (secAlly > 0)
                {
                    var Ally = new PictureBox
                    {
                        Size = new Size(235, 118),
                        BackColor = Color.Red,
                        Location = new Point(random.Next(0, this.ClientSize.Width - 118), 670),

                    };
                    Ally.Image = System.Drawing.Image.FromFile($"Босс 1_5.jpg");
                    SavM43.Add(Ally);
                    this.Controls.Add(Ally);
                    HelpTimer.Start();
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
                    HelpTimer2.Start();

                    gotov_KV5 = true; // Готовность отражать бомбы
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
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

            Enemy.Image = System.Drawing.Image.FromFile(Boss);
        }

        private void SpawnEnergo()
        {
            Random Bombochka = new Random();
            var bomb = new PictureBox
            {
                Size = new Size(55, 90),
                BackColor = Color.Red,
                Location = new Point(Enemy.Location.X + 235, 0),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Энергетический снаряд.jpg");
            EN.Add(bomb);
            this.Controls.Add(bomb);
        }

        private void SpawnBomb()
        {            
            var bomb = new PictureBox
            {
                Size = new Size(56, 58),
                BackColor = Color.Red,
                Location = new Point(random.Next(0, this.ClientSize.Width - 58), 0),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Бомба.jpg");
            bombs.Add(bomb);
            this.Controls.Add(bomb);

        }

        private void SpawnMyBomb()
        {

            var bomb = new PictureBox
            {
                Size = new Size(56, 58),
                BackColor = Color.Red,
                Location = new Point(player.Location.X + 150, 850),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Бомба.jpg");
            MyBomb.Add(bomb);
            this.Controls.Add(bomb);

        }

        private void SpawnUnActiveBomb()
        {

            var bomb = new PictureBox
            {
                Size = new Size(50, 53),
                BackColor = Color.Red,
                Location = new Point(random.Next(0, this.ClientSize.Width - 53), 0),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Незажжённая бомба.jpg");
            UnactiveBombs.Add(bomb);
            this.Controls.Add(bomb);

        }

        private void SpawnApple()
        {

            Random rand = new Random();

            int malysh = rand.Next(0, 11);

            if (malysh == 0)
            {
                var apple = new PictureBox
                {
                    Size = new Size(157, 88),
                    BackColor = Color.Red,
                    Location = new Point(random.Next(0, this.ClientSize.Width - 88), 0),

                };
                apple.Image = System.Drawing.Image.FromFile($"Leichttraktor.jpg");
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
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
                apples.Add(apple);
                this.Controls.Add(apple);
            }
        }

        private void SpawnBombBoss()
        {
            zapysheno_bomb += 1;
            var bomb = new PictureBox
            {
                Size = new Size(56, 58),
                BackColor = Color.Red,
                Location = new Point(Enemy.Location.X + 235, 0),

            };
            bomb.Image = System.Drawing.Image.FromFile($"Бомба.jpg");
            bombs.Add(bomb);
            this.Controls.Add(bomb);

        }

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

            if (!Steel_March && !final)
            {
                Random set = new Random();
                int a = set.Next(0, 2);
                if (a == 0)
                {
                    sound = new SoundPlayer("Финальное сражение.wav");
                    sound.Play();

                    final = true;
                    Steel_March = false;
                }   
                else if (a == 1)
                {
                    sound = new SoundPlayer("Босс.wav");
                    sound.Play();

                    final = false;
                    Steel_March = true;
                }
            }

            // Проверка достижения "Заговорённый"
            if (!achievement[0])
            {
                if (Dangerous_Rescue >= 3)
                {
                    achievement[0] = true;
                }
            }

            // Босс
            Random rand = new Random();
            int traekt = rand.Next(0, 30);

            if (traekt == 1)
            {
                if (vpravo)
                {
                    vlevo = true;
                    vpravo = false;
                }
                else 
                { 
                    vlevo= false;
                    vpravo = true;
                }         
            }

            if (vpravo)
            {
                if (Boss == "Босс 1.jpg")
                {
                    if (BossHP == 3)
                    {
                        Enemy.Left += 15;
                    }
                    if (BossHP == 2)
                    {
                        Enemy.Left += 22;
                    }
                    if (BossHP == 1)
                    {
                        Enemy.Left += 30;
                    }
                }
                else if (Boss == "Босс 1_5.jpg")
                {
                    if (BossHP == 3)
                    {
                        Enemy.Left += 22;
                    }
                    if (BossHP == 2)
                    {
                        Enemy.Left += 29;
                    }
                    if (BossHP == 1)
                    {
                        Enemy.Left += 38;
                    }
                }
                else if (Boss == "Босс 2.jpg")
                {
                    if (BossHP == 5)
                    {
                        Enemy.Left += 12;
                    }
                    if (BossHP == 4)
                    {
                        Enemy.Left += 12;
                    }
                    if (BossHP == 3)
                    {
                        Enemy.Left += 22;
                    }
                    if (BossHP == 2)
                    {
                        Enemy.Left += 22;
                    }
                    if (BossHP == 1)
                    {
                        Enemy.Left += 30;
                    }
                }
                else if (Boss == "Босс 3.jpg")
                {
                    if (BossHP > 20)
                    {
                        Enemy.Left += 12;
                    }
                    if (BossHP > 10 &&BossHP <= 20)
                    {
                        Enemy.Left += 22;
                    }
                    if (BossHP <= 10)
                    {
                        Enemy.Left += 32;
                    }
                }
            }

            if (vlevo)
            {
                if (Boss == "Босс 1.jpg")
                {
                    if (BossHP == 3)
                    {
                        Enemy.Left -= 15;
                    }
                    if (BossHP == 2)
                    {
                        Enemy.Left -= 22;
                    }
                    if (BossHP == 1)
                    {
                        Enemy.Left -= 30;
                    }
                }
                else if (Boss == "Босс 1_5.jpg")
                {
                    if (BossHP == 3)
                    {
                        Enemy.Left -= 22;
                    }
                    if (BossHP == 2)
                    {
                        Enemy.Left -= 29;
                    }
                    if (BossHP == 1)
                    {
                        Enemy.Left -= 38;
                    }
                }
                else if (Boss == "Босс 2.jpg")
                {
                    if (BossHP == 5)
                    {
                        Enemy.Left -= 12;
                    }
                    if (BossHP == 4)
                    {
                        Enemy.Left -= 12;
                    }
                    if (BossHP == 3)
                    {
                        Enemy.Left -= 22;
                    }
                    if (BossHP == 2)
                    {
                        Enemy.Left -= 22;
                    }
                    if (BossHP == 1)
                    {
                        Enemy.Left -= 30;
                    }
                }
                else if (Boss == "Босс 3.jpg")
                {
                    if (BossHP > 20)
                    {
                        Enemy.Left -= 12;
                    }
                    if (BossHP > 10 && BossHP <= 20)
                    {
                        Enemy.Left -= 22;
                    }
                    if (BossHP <= 10)
                    {
                        Enemy.Left -= 32;
                    }
                }
            }
            

            if (Enemy.Location.X >= 1200 && vpravo)
            {
                vpravo = false;
                vlevo = true;
            }

            if (Enemy.Location.X <= 0 && vlevo)
            {
                vpravo = true;
                vlevo = false;
            }

            int chance = BossAttack.Next(0, 50);

            if (Boss == "Босс 1.jpg" || Boss == "Босс 1_5.jpg")
            {
                if (BossHP >= 3)
                {
                    chance = BossAttack.Next(0, 50);
                }

                if (BossHP == 2)
                {
                    chance = BossAttack.Next(0, 40);
                }

                if (BossHP == 1)
                {
                    chance = BossAttack.Next(0, 30);
                }
            }

            if (Boss == "Босс 2.jpg")
            {
                chance = BossAttack.Next(0, 50);
            }

            if (Boss == "Босс 3.jpg")
            {
                chance = BossAttack.Next(0, 50);
            }

            if (chance == 1 && timeAttack <= 0)
            {
                if (Boss == "Босс 1.jpg")
                {
                    if (BossHP == 3)
                    {
                        timeAttack += 5;
                    }
                    if (BossHP == 2)
                    {
                        timeAttack += 8;
                    }
                    if (BossHP == 1)
                    {
                        timeAttack += 12;
                    }
                }

                if (Boss == "Босс 1_5.jpg")
                {
                    if (BossHP == 3)
                    {
                        timeAttack += 3;
                    }
                    if (BossHP == 2)
                    {
                        timeAttack += 4;
                    }
                    if (BossHP == 1)
                    {
                        timeAttack += 6;
                    }
                }

                if (Boss == "Босс 2.jpg")
                {
                    if (BossHP >= 3)
                    {
                        timeAttack += 5;
                    }
                    if (BossHP <= 2 && BossHP > 1)
                    {
                        timeAttack += 3;
                    }
                    if (BossHP == 1)
                    {
                        timeAttack += 3;
                    }
                }

                if (Boss == "Босс 3.jpg")
                {
                    if (BossHP > 20)
                    {
                        timeAttack += 5;
                    }
                    if (BossHP <= 20 && BossHP > 10)
                    {
                        timeAttack += 8;
                    }
                    if (BossHP <= 10)
                    {
                        timeAttack += 3;
                    }
                }


                if (timeAttack > 0)
                {
                    BossTimer.Start();
                }
            }

            // Босс

            // Спаун
            if (random.Next(0, Malyshi) == 1)
                SpawnApple();

            if (random.Next(0, ActiveBombs) == 1)
                SpawnBomb();

            if (random.Next(0, UnActiveBombs) == 1)
                SpawnUnActiveBomb();

            // Спаун

            foreach (var bomb in bombs.ToList())
            {
                bomb.Top += Gravity * 3;

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
                                    TimeOfImmortal.Start();

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

            foreach (var bomb in bombs_KV5.ToList())
            {
                bomb.Top -= Gravity * 7;

                // Если яблоко упало за экран — удаляем
                if (bomb.Top > this.ClientSize.Height)
                {

                    bombs_KV5.Remove(bomb);
                    this.Controls.Remove(bomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    bombs_KV5.Remove(bomb);
                    this.Controls.Remove(bomb);
                }

                if (bomb.Bounds.IntersectsWith(Enemy.Bounds))
                {
                    BossHP -= 1;

                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    scoreLabel.Text = "Счет: " + score;
                    bombs_KV5.Remove(bomb);
                    this.Controls.Remove(bomb);

                    continue;
                }
            }

            foreach (var energ in EN.ToList())
            {
                energ.Top += Gravity * 4;

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

            foreach (var Unbomb in UnactiveBombs.ToList())
            {
                Unbomb.Top += Gravity * 3;

                // Если яблоко упало за экран — удаляем
                if (Unbomb.Top > this.ClientSize.Height)
                {

                    UnactiveBombs.Remove(Unbomb);
                    this.Controls.Remove(Unbomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    UnactiveBombs.Remove(Unbomb);
                    this.Controls.Remove(Unbomb);
                }
                // Если игрок поймал яблоко
                else if (Unbomb.Bounds.IntersectsWith(player.Bounds))
                {
                    vooruzhen = true;
                    UnactiveBombs.Remove(Unbomb);
                    this.Controls.Remove(Unbomb);
                }
            }

            foreach (var bomb in MyBomb.ToList())
            {
                bomb.Top -= Gravity * 3;

                // Если яблоко упало за экран — удаляем
                if (bomb.Top < 0)
                {

                    MyBomb.Remove(bomb);
                    this.Controls.Remove(bomb);
                    //new SoundPlayer("Смех.wav").Play(); // Не ждём окончания

                    UnactiveBombs.Remove(bomb);
                    this.Controls.Remove(bomb);
                }
                // Если игрок поймал яблоко
                else if (bomb.Bounds.IntersectsWith(Enemy.Bounds))
                {
                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

                    BossHP -= 1;
                    MyBomb.Remove(bomb);
                    this.Controls.Remove(bomb);
                }
            }

            foreach (var apple in apples.ToList())
            {
                apple.Top += Gravity;

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
                Muzlo.Stop();
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
                MessageBox.Show("Вы проиграли! Вы не уберегли малышей от беды! Как вы будете смотреть в глаза их родителям?!");

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

                this.Close();

                Form9 form = new Form9();
                form.Show();
            }

            // Если победа

            if (BossHP == 0)
            {
                gameTimer.Stop();
                if (Boss == "Босс 1_5.jpg")
                {
                    MessageBox.Show("   Между нами развязалась дуэль... Мы друг в друга кидались бомбами. Пока я отвлекал его " +
                        "внимание, малыши из ветхого жилища тайком уезжали от обезумевшего тирана.\n" +
                        "   Своё дело я сделал. Противник, будучи поверженным, уже жалобно смотрел на меня. Я видел, как по его " +
                        "седым усам проскальзывали слёзы от невыносимой боли. Он поведал мне историю, почему тот согласился выполнять " +
                        "прихоти его главаря.\n" +
                        "   'Выслушай меня, сынок!' - жалобно протянул старик. 'Я не мог тебе сказать всю правду! Когда-то я работал в " +
                        "хорошем цеху. Чинил танки, смазывал механизмы... Но наш завод закрыли... Я очень любил это место... Оно мне дарило жизнь, " +
                        "которая мне была по душе. У меня была красавица-жена, и я не мог позволить себе топтаться на месте. Я хотел обеспечить нам хорошую жизнь," +
                        " поэтому отправился искать другой завод. От такого горя я подвыпил и сам не понял, как пошёл на поводу у того Е 100. Он предложил мне похищать " +
                        "малышей за нескромную плату, и я согласился! Я подумал, что ситуация безвыходная, и окопался здесь. Иди... Иди, иди, малыш!\n " +
                        "   'Но ты же это делал ради своей семьи. Ты можешь исправиться, друг. Да, ты уже принял Тьму, но это не значит, что " +
                        "всё уже закончилось для тебя! Твоя жена искренне в тебя верит! Держи... Это немного, но, надеюсь, поможет...'\n" +
                        "   Сзади эту картину наблюдали два сбежавших малыша - МС-1 и Leichttraktor. Не успел я покинуть это место, как они тут же подъехали " +
                        "на выручку старому, но ещё не потерявшему волю к жизни танку, и протянули мешки денег. Видимо, их богатые родители жили где-то рядом.\n" +
                        "   'Это вам' - раскрывает свой мешок застенчивый Leichttraktor.\n" +
                        "   'Не печальтесь, дедушка' - скромно улыбнувшись, произнёс МС-1.\n" +
                        "   'Знаете?' - подумал старик. 'Вы неплохие ребята. Побольше бы таких! Я однозначно решил - больше никаких сделок с дьяволом! " +
                        "AMX 40, ты вернул мне ясность ума. Спасибо тебе! Хочешь, я могу отправиться с тобой! Хочу искупить вину перед детьми и моей любимой! " +
                        "Хочу быть хорошим танком. как это было и раньше!'");
                }

                if (Boss == "Босс 2.jpg")
                {
                    MessageBox.Show(" - 'С этим покончено!' - запыхавшись от напряжённой схватки, произнёс Дедушка-Швед.\n" +
                        " - 'Помогите!' - растянулся чей-то низкий крик. Отважные освободители подошли к ещё одной камере и обнаружили " +
                        "советского мастодонта. Это был КВ-5. Он жалобно смотрел на героев и молил их освободить его.\n" +
                        " - 'Я не за них! Клянусь! Эти негодяи две недели назад украли моих детей! Поэтому я здесь! Я не хотел сдаваться! " +
                        "Пожалуйста, если вы тоже сражаетесь против этого безумца, то возьмите меня с собой!'\n" +
                        "   Этот гигант сразу понравился такому малышу как AMX 40. Швед стоял позади француза, внимательно осматривая пленного и готовясь к его защите. " +
                        "Используя ненадёжную отмычку, надеясь на авось, герою всё-таки удалось вызволить КВ-5 из плена.\n" +
                        "   - 'Спасибо тебе! Меня зовут Богатырь! Верю, что ты тот, кто точно освободит их всех! Я буду защищать тебя любой ценой!' - " +
                        "произнёс КВ-5, вытащив наружу свою слегка потрескавшуюся сковородку.\n" +
                        "   - 'Эххехехехе!' - усмехнулся Дедушка-Швед. 'И чем ты будешь воевать, дружище? Этой ржавой посудиной??!'\n" +
                        "   - 'Ещё как!' - на полном серьёзе произнёс Богатырь. 'ЭТОЙ ПОСУДИНОЙ Я ОТПРАВИЛ В КОТЁЛ ДЕСЯТКИ ТАКИХ КАК ВОТ ЭТОТ ГАД' - указал он на поверженного нами противника.\n" +
                        "   - 'Эх... Ладно. Поехали вместе спасать этот мир! Втроём оборону будет проще держать! Да и не так грустно будет!' - согласился Дедушка-Швед.");
                }


                if (zapysheno_bomb >= 90 && vzorvano_bomb == 0)
                {
                    achievement[1] = true;
                }
                
                if (score >= 125 && poterano_malyshej == 0)
                {
                    achievement[2] = true;
                }

                if (damaged_KV5 + blocked_damage_KV5 >= 60 && hp_sojuz2 > 0 && otrazheno_bomb >= 10)
                {
                    achievement[3] = true;
                }

                Muzlo.Stop();
                Enemy.Visible = false;
                gameTimer.Stop();

                if (Boss == "Босс 3.jpg")
                {
                    MessageBox.Show(" - 'ЭТОГО... НЕ МОЖЕТ БЫТЬ! Вы... скрежет металла... ВЫ ЖЕ ЖАЛКИЕ ЖЕЛЕЗКИ!' - закричал Е 100.\n" +
                        "   - 'Ты украл их детство. Теперь считайся с настоящей бронёй.' - произнёс Богатырь.\n" +
                        "   - 'Ты всё ещё веришь, что война — это прогресс?' - спросил Дедушка-Швед." +
                        "'Мы тысячелетия убивали друг друга. И что? Те же окопы, только глубже. " +
                        "Ты хочешь мира, где танки не говорят, а только стреляют?'\n" +
                        "   - 'Мир... где малыши прячутся от бомб — это не эволюция! Это провал!' - добавил АМХ 40.\n" +
                        "   Е 100 пытался убежать от освободителей, но тут же сзади ему заблокировали путь десятки гневных малышей." +
                        "   - 'Мой дед сгорел в песках Африки... ради чьих-то амбиций!' - произнёс малыш Medium I. 'Уж лучше дружить!'\n" +
                        "   - 'А мы замёрзли в снегах, потому что вам нужна была нефть!' - произнесли TKS 20 и МC-1.\n" +
                        "   - 'Если бы мы не слепо повиновались в 41-м... Сколько бы живых ещё катило по дорогам?' - с грустью сказал Leichttraktor.\n" +
                        "   - 'СЛАБАКИ! Война — естественный отбор! Вы... вы просто мусор истории!' - злобно сквозь зубы процедил Е 100. 'Войны это наша эволюция, " +
                        "и её не остановить! Кто слаб, тому не суждено уцелеть. Так было всегда!'\n" +
                        "   - 'Нет. Мусор — это ты. Мы будем жить — пусть и медленнее, но вместе.' - выдал АМХ 40.");
                }

                if (Boss != "Босс 3.jpg")
                {
                    sound = new SoundPlayer("Victory.wav");
                    sound.Play(); // PlaySync() — если нужно ждать окончания
                }
                else
                {
                    sound = new SoundPlayer("Дружба.wav");
                    sound.Play(); // PlaySync() — если нужно ждать окончания
                }

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

                Form3 form = new Form3(poterano_malyshej, score, Dangerous_Rescue);
                form.Show();

                

                if (achievement[0] || achievement[1] || achievement[2] || achievement[3])
                {
                    Form4 form1 = new Form4(achievement);
                    form1.Show();
                }
            }
        }

        private void BossTimer_Tick(object sender, EventArgs e)
        {
            timeAttack -= 0.1;

            timeAttack = Math.Round(timeAttack, 1);

            if (Boss == "Босс 1.jpg")
            {
                if (BossHP == 3)
                {
                    if (timeAttack > 0 && timeAttack % 1.2 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }

                if (BossHP == 2)
                {
                    if (timeAttack > 0 && timeAttack % 1 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }

                if (BossHP == 1)
                {
                    if (timeAttack > 0 && timeAttack % 1 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }
            }

            if (Boss == "Босс 1_5.jpg")
            {
                if (BossHP == 3)
                {
                    if (timeAttack > 0 && timeAttack % 1.2 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }

                if (BossHP == 2)
                {
                    if (timeAttack > 0 && timeAttack % 0.8 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }

                if (BossHP == 1)
                {
                    if (timeAttack > 0 && timeAttack % 0.8 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }
            }

            if (Boss == "Босс 2.jpg")
            {
                if (BossHP >= 3)
                {
                    if (timeAttack > 0 && timeAttack % 1 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }

                if (BossHP <= 2)
                {
                    if (timeAttack > 0 && timeAttack % 0.5 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }
            }

            if (Boss == "Босс 3.jpg")
            {
                if (BossHP > 20)
                {
                    if (timeAttack > 0 && timeAttack % 1 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        SpawnBombBoss();
                    }
                }

                if (BossHP <= 20 && BossHP > 10)
                {
                    if (timeAttack > 0 && timeAttack % 1 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        Random g = new Random();
                        if (g.Next(0, 5) == 1)
                        { 
                            SpawnBombBoss(); 
                        }
                        else
                        {
                            SpawnEnergo();
                        }
                    }
                }

                if (BossHP <= 10)
                {
                    if (timeAttack > 0 && timeAttack % 0.5 == 0) // Примерно 5 бомб за 2.5 секунды
                    {
                        Random g = new Random();
                        if (g.Next(0, 3) == 1)
                        {
                            SpawnBombBoss();
                        }
                        else
                        {
                            SpawnEnergo();
                        }
                    }
                }
            }


            if (timeAttack <= 0)
            {
                BossTimer.Stop();
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
            }
            return false;
        }

        private void Muzlo_Tick(object sender, EventArgs e)
        {
            muzyka += 0.1;

            if (final)
            {
                if (muzyka >= 80)
                {
                    final = false;
                    Steel_March = false;

                    muzyka = 0;
                }
            }

            if (Steel_March)
            {
                if (muzyka >= 80)
                {
                    final = false;
                    Steel_March = false;

                    muzyka = 0;
                }
            }
        }

        private void HelpTimer_Tick(object sender, EventArgs e)
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
                HelpTimer.Stop();

                foreach (var tank in SavM43.ToList())
                {
                    SavM43.Remove(tank);
                    this.Controls.Remove(tank);
                }
            }

            Random Shved_Bomb = new Random();
            if (Shved_Bomb.Next(0, 80) == 1)
            {
                SpawnMyBomb();
            }
        }

        private void timerEnergo_Tick(object sender, EventArgs e)
        {
            time_of_energo -= timerEnergo.Interval * 0.001;
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

        private void HelpTimer2_Tick(object sender, EventArgs e)
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
                HelpTimer2.Stop();

                foreach (var tank in KV5.ToList())
                {
                    KV5.Remove(tank);
                    this.Controls.Remove(tank);
                }
            }
        }

        private void TimeOfImmortal_Tick(object sender, EventArgs e)
        {
            perezaryadka_zashity -= TimeOfImmortal.Interval * 0.001;

            if (perezaryadka_zashity <= 0)
            {
                foreach (var tank in KV5.ToList())
                {
                    tank.Image = Image.FromFile("КВ-5.jpg");
                    tank.Size = new Size(372, 187);
                }

                perezaryadka_zashity = 0;
                gotov_KV5 = true;
                TimeOfImmortal.Stop();
            }
        }
    }
}
