using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FallingBall
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private int padX = 40;


        private int ballX = 0;
        private int ballY = 0;

        private int ballSpeed = 5;
        private int padSpeed = 20;


        private int horizontalWallY = 100;
        private int verticalWallX = 50;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue, padX, Form1.ActiveForm.Height - 60, 100, 15);
            e.Graphics.FillEllipse(Brushes.Red, ballX, ballY, 20, 20);


            horizontalWallY += 4;
            verticalWallX += 4;


            for (int i = 0; i < Form1.ActiveForm.Width; i += 30)
            {
                e.Graphics.FillEllipse(Brushes.Red, i, horizontalWallY, 20, 20);
            }

            for (int i = 0; i < Form1.ActiveForm.Height; i += 30)
            {
                e.Graphics.FillEllipse(Brushes.Red, verticalWallX, i, 20, 20);
            }

            if (horizontalWallY > Form1.ActiveForm.Height)
            {
                horizontalWallY = 0;
            }
            if (verticalWallX > Form1.ActiveForm.Width)
            {
                verticalWallX = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                padX += padSpeed;
            }
            if (e.KeyCode == Keys.Left)
            {
                padX -= padSpeed;
            }
            if (e.KeyCode == Keys.Enter)
            {
                //  timer1.Start();
                //label1.Text = "";
            }

            this.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ballY += ballSpeed;

            // Daca a prins bila
            if (ballY > Form1.ActiveForm.Height - 60 && ballX > padX && ballX < padX + 100)
            {
                int scor = getScor();

                if (scor % 5 == 0 && scor != 0)
                {
                    ballSpeed += 4;
                    padSpeed += 20;
                }
                updateScor(scor + 1);

                ballY = 0;
                ballX = random.Next(0, 500);

            }
            // Daca nu a prins bila
            if (ballY > Form1.ActiveForm.Height - 55)
            {
                int vieti = int.Parse(label4.Text);

                if (vieti == 1)
                {
                    label1.Visible = true;
                    timer1.Stop();
                }
                else
                {
                    ballY = 0;
                    label4.Text = (vieti - 1).ToString();
                }
            }
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
            ballX = random.Next(0, 500);

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
            true);
        }

        private int getScor()
        {
            return int.Parse(label6.Text);
        }

        private void updateScor(int newScor)
        {
            label6.Text = newScor.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
         
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
