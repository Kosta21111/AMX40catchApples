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

        private int score = 0;
        private Random random = new Random();
        private int gravity = 5; // Скорость падения яблок
        private List<PictureBox> apples = new List<PictureBox>();

        private void Form1_Load(object sender, EventArgs e)
        {
            gameTimer.Start();
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.DoubleBuffered = true; // Уменьшает мерцание
        }

        private void SpawnApple()
        {
            var apple = new PictureBox
            {
                Size = new Size(26, 27),
                BackColor = Color.Red,
                Location = new Point(random.Next(0, this.ClientSize.Width - 26), 0),
                
            };
            apple.Image = System.Drawing.Image.FromFile($"Арбуз1.jpg");
            apples.Add(apple);
            this.Controls.Add(apple);
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Движение корзины влево-вправо
            if (e.KeyCode == Keys.Left && player.Left > 0)
                player.Left -= 20;
            if (e.KeyCode == Keys.Right && player.Right < this.ClientSize.Width)
                player.Left += 20;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Случайное появление яблок
            if (random.Next(0, 20) == 1)
                SpawnApple();

            // Движение яблок вниз
            foreach (var apple in apples.ToList())
            {
                apple.Top += gravity;

                // Если яблоко упало за экран — удаляем
                if (apple.Top > this.ClientSize.Height)
                {
                    apples.Remove(apple);
                    this.Controls.Remove(apple);
                }
                // Если игрок поймал яблоко
                else if (apple.Bounds.IntersectsWith(player.Bounds))
                {
                    score++;
                    scoreLabel.Text = "Счет: " + score;
                    apples.Remove(apple);
                    this.Controls.Remove(apple);
                }
            }
        }

        private void player_Click(object sender, EventArgs e)
        {

        }
    }
}
