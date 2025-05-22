using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Media;
using NAudio.Wave;

namespace WindowsFormsApp1
{

    
    public partial class Form2 : Form
    {
        bool muzlo = false;

        private int time_left = 0;
        private int score = 0;
        private int health = 5;
        private Random random = new Random();
        private Random random_bomb = new Random();
        private int gravity = 13; // Скорость падения яблок
        private int rand = 0;
        private int rand_bomba = 0;

        private int Dangerous_Rescue = 0;
        private int uroven = 0;

        private bool estj_bomby;

        private SoundPlayer sound;

        string[] achivki = new string[1] { "Заговорённый" };
        bool[] achievement = new bool[1] { false };

        private int poterano_malyshej = 0;

        public Form2(int level, int frequence_bomba, bool bomba, int frequence, int speed, int time)
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
            uroven = level;
        }

        
        private List<PictureBox> apples = new List<PictureBox>();
        private List<PictureBox> bombs = new List<PictureBox>();

        private void Form2_Load(object sender, EventArgs e)
        {
            gameTimer.Start();
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.DoubleBuffered = true; // Уменьшает мерцание
        }

        private void SpawnApple()
        {

            Random rand = new Random();

            int malysh = rand.Next(0, 8);

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

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Движение корзины влево-вправо
            if (e.KeyCode == Keys.Left && player.Left > 0)
                player.Left -= 12;
            if (e.KeyCode == Keys.Right && player.Right < this.ClientSize.Width)
                player.Left += 12;
        }

        double time = 0;

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            
        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick_1(object sender, EventArgs e)
        {

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
                sound = new SoundPlayer("Victory.wav");
                sound.Play(); // PlaySync() — если нужно ждать окончания

                

                Form3 form = new Form3(poterano_malyshej, score, Dangerous_Rescue);
                form.Show();

                if (achievement[0])
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
                    SpawnBomb();
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
            }

            foreach (var bomb in bombs.ToList())
            {
                bomb.Top += gravity * 3;

                // Если яблоко упало за экран — удаляем
                if (bomb.Top > this.ClientSize.Height)
                {
                    var explosion = new AudioFileReader("Взрыв.wav");
                    var waveOut2 = new WaveOutEvent();
                    waveOut2.Init(explosion);
                    waveOut2.Play();

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
                MessageBox.Show("Вы проиграли! Вы не уберегли малышей от беды! Как вы будете смотреть в глаза их родителям?!");
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

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
                    if (Math.Sqrt((bombY - appleY) * (bombY - appleY) + (bombX - appleX) * (bombX - appleX)) <= 100 && apple.Bounds.IntersectsWith(player.Bounds))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
