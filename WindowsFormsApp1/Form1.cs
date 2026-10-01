using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Point> snake = new List<Point>();
        private Point food;

        private int directionX = 0, directionY = 1;
        private int score = 0;

        private const int TileSize = 20;   
        private const int GridWidth = 20;
        private const int GridHeight = 20;

        private Timer gameTimer;
        private Random rand = new Random();
        private bool isGameOver = false;

        public Form1()
        {
            InitializeComponent();
            SetupGame();
        }

        private void SetupGame()
        {
            this.Text = "Snake Game - Scor: 0";
            this.ClientSize = new Size(GridWidth * TileSize, GridHeight * TileSize);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.DoubleBuffered = true;
            this.KeyDown += OnKeyDown;

            StartNewGame();

            gameTimer = new Timer();
            gameTimer.Interval = 120;
            gameTimer.Tick += UpdateGame;
            gameTimer.Start();
        }

        private void StartNewGame()
        {
            snake.Clear();
            snake.Add(new Point(10, 10));
            directionX = 0;
            directionY = 1;
            score = 0;
            isGameOver = false;

            GenerateFood();

            this.Text = "Snake Game - Scor: 0";
        }

        private void GenerateFood()
        {
            int x = rand.Next(0, GridWidth);
            int y = rand.Next(0, GridHeight);
            food = new Point(x, y);
        }


        private void UpdateGame(object sender, EventArgs e)
        {
            if (isGameOver)
            {
                return;
            }


            Point head = snake[0];
            Point newHead = new Point(head.X + directionX, head.Y + directionY);

            if (newHead.X < 0 || newHead.X >= GridWidth || newHead.Y < 0 || newHead.Y >= GridHeight)
            {
                GameOver();
                return;
            }

            for (int i = 0; i < snake.Count; i++)
            {
                if (snake[i] == newHead)
                {
                    GameOver();
                    return;
                }
            }

            snake.Insert(0, newHead);

            if (newHead == food)
            {
                score += 10;
                this.Text = "Snake Game - Score: " + score;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            this.Invalidate();
        }
        private void GameOver()
        {
            isGameOver = true;
            gameTimer.Stop();
            MessageBox.Show($"You just lost! Final Score: {score}\nPress Enter for playing again!");
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver && e.KeyCode == Keys.Enter)
            {
                StartNewGame();
                gameTimer.Start();
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:    if (directionY != 1)  { directionX = 0; directionY = -1; } break;
                case Keys.Down:  if (directionY != -1) { directionX = 0; directionY = 1; }  break;
                case Keys.Left:  if (directionX != 1)  { directionX = -1; directionY = 0; } break;
                case Keys.Right: if (directionX != -1) { directionX = 1; directionY = 0; }  break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;


            g.FillRectangle(Brushes.Red, food.X*TileSize, food.Y*TileSize, TileSize, TileSize);

            for (int i = 0; i < snake.Count; i++)
            {
                Brush brush = i == 0 ? Brushes.DarkGreen : Brushes.LimeGreen;
                g.FillRectangle(brush, snake[i].X * TileSize, snake[i].Y * TileSize, TileSize, TileSize);
                g.DrawRectangle(Pens.DarkOliveGreen, snake[i].X * TileSize, snake[i].Y * TileSize, TileSize, TileSize);
            }
        }
    }
}