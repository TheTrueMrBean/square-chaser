using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
// Daniel Bean Decemeber 16 2024 it's a square chaser game 
namespace square_chaser
{
    public partial class Form1 : Form
    {
        // makes the graphics
        Graphics g;
        // this is the random number generators
        Random randGen = new Random();
        Random randGen2 = new Random();
        // creates the rectangles
        Rectangle player1 = new Rectangle(40, 60, 15, 15);
        Rectangle player2 = new Rectangle(40, 450, 15, 15);
        Rectangle square = new Rectangle(245, 195, 15, 15);
        Rectangle speed = new Rectangle(373, 306, 10, 10);
        Rectangle Swap = new Rectangle(294, 67, 60, 60);
        
        // this makes the pen and the brushes to draw the rectangles
        Pen blue = new Pen(Color.Blue, 3);
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush yellow = new SolidBrush(Color.Yellow);
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush Blue = new SolidBrush(Color.Blue);
        // this checks to see what direction you are moving 
        bool wPressed = false;
        bool sPressed = false;
        bool upPressed = false;
        bool downPressed = false;
        bool aPressed = false;
        bool dPressed = false;
        bool leftPressed = false;
        bool rightPressed = false;
        bool active = true;
        // this is the speed and the score
        int playerSpeed = 10;
        int player2Speed = 10;
        int playerScore = 0;
        int player2Score = 0;
        int powerUp = 0;
        // this is the variable that will be changed if the player gets a power up
        string player1Condtion = "";
        string player2Condtion = "";
        // this is the soundplayers 
        SoundPlayer Horn = new SoundPlayer(Properties.Resources.Horn);
        SoundPlayer Switch = new SoundPlayer(Properties.Resources.Switch);
        SoundPlayer Speed = new SoundPlayer(Properties.Resources.Speed);
        SoundPlayer Party = new SoundPlayer(Properties.Resources.Party);


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            // this checks when your keys are released 
            switch (e.KeyCode)
            {
                case Keys.W:
                    wPressed = false;
                    break;
                case Keys.S:
                    sPressed = false;
                    break;
                case Keys.Up:
                    upPressed = false;
                    break;
                case Keys.Down:
                    downPressed = false;
                    break;
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.A:
                    aPressed = false;
                    break;
                case Keys.D:
                    dPressed = false;
                    break;

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            {
                // this checks what keys are pressed 
                switch (e.KeyCode)
                {
                    case Keys.W:
                        wPressed = true;
                        break;
                    case Keys.S:
                        sPressed = true;
                        break;
                    case Keys.Up:
                        upPressed = true;
                        break;
                    case Keys.Down:
                        downPressed = true;
                        break;
                    case Keys.Left:
                        leftPressed = true;
                        break;
                    case Keys.Right:
                        rightPressed = true;
                        break;
                    case Keys.A:
                        aPressed = true;
                        break;
                    case Keys.D:
                        dPressed = true;
                        break;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // this is what let's you move around along with moving you the other direction if you have the swap debuff
            if (aPressed == true  && active == true)
            {
                if (player1Condtion == "" && player1.X > 20)
                {
                    player1.X -= playerSpeed;
                }
                else if (player1Condtion == "Swap" && player1.X < 550)
                {
                    player1.X += playerSpeed;
                }
            }
            if (dPressed == true && active == true)
            {
                if (player1Condtion == "" && player1.X < 550)
                {
                    player1.X += playerSpeed;
                }
                else if (player1Condtion == "Swap" && player1.X > 21)
                {
                    player1.X -= playerSpeed;
                }
            }
            if (leftPressed == true  && active == true)
            {
                if (player2Condtion == "" && player2.X > 20)
                {
                    player2.X -= player2Speed;
                }
                else if (player2Condtion == "Swap" && player2.X < 550)
                {
                    player2.X += player2Speed;
                }
            }
            if (rightPressed == true && active == true)
            {
                if (player2Condtion == "" && player2.X < 550)
                {
                    player2.X += player2Speed;
                }
                else if (player2Condtion == "Swap" && player2.X > 20)
                {
                    player2.X -= player2Speed;
                }
            }
            if (wPressed == true && active == true)
            {
                if (player1Condtion == "" && player1.Y > 20)
                {
                    player1.Y -= playerSpeed;
                }
                else if (player1Condtion == "Swap" && player1.Y < 500)
                {
                    player1.Y += playerSpeed;
                }
            }
            if (sPressed == true  && active == true)
            {
                if (player1Condtion == "" && player1.Y < 500)
                {
                    player1.Y += playerSpeed;
                }
                else if (player1Condtion == "Swap" && player2.Y > 20)
                {
                    player1.Y -= playerSpeed;
                }
            }
            if (upPressed == true  && active == true)
            {
                if (player2Condtion == "" && player2.Y > 20)
                {
                    player2.Y -= player2Speed;
                }
                else if (player2Condtion == "Swap" && player2.Y < 500)
                {
                    player2.Y += player2Speed;
                }
            }
            if (downPressed == true  && active == true)
            {
                if (player2Condtion == "" && player2.Y < 500)
                {
                    player2.Y += player2Speed;
                }
                else if (player2Condtion == "Swap" && player2.Y > 20)
                {
                    player2.Y -= player2Speed;
                }
            }
            // this checks if you intersect with the white point squares 
            if (player1.IntersectsWith(square))
            {
                int random = randGen.Next(25, 521);
                int random2 = randGen.Next(25, 501);
                square = new Rectangle(random, random2, 15, 15);
                Horn.Play();
                playerScore++;
                // this checks if you intersect with the white point squares 
                if (playerScore == 5)
                {
                    label1.Text = "Player 1 has Won";
                    active = false;
                    speed = new Rectangle(900, 900, 10, 10);
                    square = new Rectangle(900, 900, 15, 15);
                    Party.Play();
                }
            }
            // this checks if you intersect with the white point squares
            if (player2.IntersectsWith(square))
            {
                int random = randGen.Next(1, 521);
                int random2 = randGen.Next(1, 501);
                square = new Rectangle(random, random2, 15, 15);
                Horn.Play();
                player2Score++;
                //checks if you have enough points to win 
                if (player2Score == 5)
                {
                    label1.Text = "Player 2 has Won";
                    active = false;
                    square = new Rectangle(900, 900, 15, 15);
                    speed = new Rectangle(900, 900, 10, 10);
                    Party.Play();
                }
            }
            // this checks if you hit the yellow speed circle and checks that you don't have swap
            if (player1.IntersectsWith(speed) && player1Condtion == "")
            {
                playerSpeed = 20;
                speed = new Rectangle(900, 900, 10, 10);
                Speed.Play();
                timer2.Enabled = true;
            }
            // this checks if you hit the yellow speed circle and checks that you don't have swap
            if (player2.IntersectsWith(speed) && player2Condtion == "")
            {
                player2Speed = 20;
                speed = new Rectangle(900, 900, 10, 10);
                Speed.Play();
                timer2.Enabled = true;
            }
            //this checks if you have hit the red swap square
            if (player1.IntersectsWith(Swap))
            {
                player1Condtion = "Swap";
                playerSpeed = 30;
                timer2.Enabled=true;
                Switch.Play();
                Swap = new Rectangle(900, 900, 60, 60);
            }
            //this checks if you have hit the red swap square
            if (player2.IntersectsWith(Swap))
            {
                player2Condtion = "Swap";
                player2Speed = 30;
                timer2.Enabled = true;
                Switch.Play();
                Swap = new Rectangle(900, 900, 60, 60);
            }
            // this makes it so you can't phase though walls 
            if (player1.Y < 25)
            {
                player1.Y = 26;
            }
            if (player1.Y > 500 )
            {
                player1.Y = 499;
            }
            if (player1.X < 25)
            {
                player1.X = 26;           
            }
            if (player1.X > 550 )
            {
                player1.X = 549;
            }
            if (player2.Y < 25)
            {
                player2.Y = 26;
            }
            if (player2.Y > 500)
            {
                player2.Y = 495;
            }
            if (player2.X < 25)
            {
                player2.X = 26;
            }
            if (player2.X > 550)
            {
                player2.X = 549;
            }
            Refresh();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            {
                {
                    // this paints all the rectangles and circles 
                    e.Graphics.FillEllipse(white, square);
                    e.Graphics.FillRectangle(red, player1);
                    e.Graphics.FillRectangle(Blue, player2);
                    e.Graphics.FillEllipse(yellow, speed);
                    e.Graphics.FillEllipse(red, Swap);
                    e.Graphics.DrawRectangle(blue, 24, 24, 545, 490);
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            // this counts the 5 seconds for the power up
            powerUp++;
            // this checks what power up or power down you have 
            if (powerUp == 5)
            {
                // if you have swap active then it give you back normal controls
                if (player1Condtion == "Swap" || player2Condtion == "Swap")
                {
                    // this checks what player has Swap active
                    if (player1Condtion == "Swap")
                    { // this gives you back normal controls and moves swap to a new location
                        player1Condtion = "";
                        powerUp = 0;
                        int random = randGen.Next(25, 521);
                        int random2 = randGen.Next(25, 501);
                        Swap = new Rectangle(random, random2, 60, 60);
                        playerSpeed = 10;
                        timer2.Enabled = false;
                        
                    }
                    else
                    {
                        // this gives you back normal controls and moves swap to a new location
                        player2Condtion = "";
                        powerUp = 0;
                        int random = randGen.Next(25, 521);
                        int random2 = randGen.Next(25, 501);
                        Swap = new Rectangle(random, random2, 60, 60);
                        player2Speed = 10;
                        timer2.Enabled = false;
                    }
                }
                // this check if you don't have Swap active you have speed boost
                else
                {
                    // this just sees who has speed up
                    if (playerSpeed == 30)
                    {
                        // this sets your speed boost to normal
                        playerSpeed = 10;
                    }
                    else
                    {
                        player2Speed = 10;
                    }
                    // this moves speed boost to a new spot 
                    powerUp = 0;
                    int random = randGen.Next(25, 521);
                    int random2 = randGen.Next(25, 501);
                    speed = new Rectangle(random, random2, 10, 10);
                    timer2.Enabled = false;
                }
            }
        }
    }
}         
                

                   
                

