/*
  First mini-graphics-game skeleton
  Version B (based on console version B: 
  boolean for the condition)
*/

using System;

public class Game
{
    public static void Main()
    {
        bool fullScreen = false ;
        SdlHardware.Init(800, 600, 24, fullScreen);
        Image player = new Image("barra.bmp");
        Image ball1 = new Image("pokeballorigin.bmp");
        Image ball2 = new Image("superballorigin.bmp");
        Image ball3 = new Image("ultraballorigin.bmp");
        Image ball4 = new Image("masterballorigin.bmp");
        Image ball5 = new Image("voltorborigin.bmp");
        Image ball6 = new Image("angryvoltorborigin.bmp");
        Image divisory = new Image("divisoria.bmp");
        Image divisory2 = new Image("divisoria2.bmp");
        Image fruit = new Image("ultraball.bmp");

        const int xa = 12, ya = 120;     //sizes of player
        const int axe = 20, aye = 20;   //sizes of ball        
        int x = 50;
        int y = 300-ya/2;
        int x2 = 750-xa;
        int y2 = 300-ya/2;
        int score1 = 5, score2 = 5;
        int divisoryX = 400;
        int divisory2Y = 40;
        int[] fruitPosX1 = new int[score1];
        int[] fruitPosX2 = new int[score2];
        int amountOfEnemies=1;
        Random generator = new Random();
        float[] ballX = new float[amountOfEnemies];
        float[] ballY = new float[amountOfEnemies];
        for (int i = 0; i < amountOfEnemies; i++)
        {
            ballX[i] = x+xa;
            ballY[i] = y+ya/2 - aye/2;
        }

        int speed = 18;
        float ballSpeedX = 10f;
        float ballSpeedY = 10f;
        bool finished = false;
        bool pause = false;
        byte moveType = 1;


        // Game Loop
        do
        {
            // Update screen
            SdlHardware.ClearScreen();
            for (int i = 0; i < amountOfEnemies; i++)
            {
                if (ballSpeedX >= 30)
                {
                    SdlHardware.DrawHiddenImage(ball6, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX >= 26)
                {
                    SdlHardware.DrawHiddenImage(ball5, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX >= 22)
                {
                    SdlHardware.DrawHiddenImage(ball4, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX >= 18)
                {
                    SdlHardware.DrawHiddenImage(ball3, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX >= 14)
                {
                    SdlHardware.DrawHiddenImage(ball2, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX >= 10)
                {
                    SdlHardware.DrawHiddenImage(ball1, (int)ballX[i], (int)ballY[i]);
                }
                if (ballSpeedX <= -30)
                {
                    SdlHardware.DrawHiddenImage(ball6, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX <= -26)
                {
                    SdlHardware.DrawHiddenImage(ball5, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX <= -22)
                {
                    SdlHardware.DrawHiddenImage(ball4, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX <= -18)
                {
                    SdlHardware.DrawHiddenImage(ball3, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX <= -14)
                {
                    SdlHardware.DrawHiddenImage(ball2, (int)ballX[i], (int)ballY[i]);
                }
                else if (ballSpeedX <= -10)
                {
                    SdlHardware.DrawHiddenImage(ball1, (int)ballX[i], (int)ballY[i]);
                }
            }
            SdlHardware.DrawHiddenImage(player, x, y);
            SdlHardware.DrawHiddenImage(player, x2, y2);
            SdlHardware.DrawHiddenImage(divisory, divisoryX, 0);
            SdlHardware.DrawHiddenImage(divisory2, 0, divisory2Y);

            for (int i = 0; i < score1; i++)
            {
                fruitPosX1[i] = 32*i;
                SdlHardware.DrawHiddenImage(fruit, fruitPosX1[i], 0);
            }

            for (int i = 0; i < score2; i++)
            {
                fruitPosX2[i] = 415 + 32 * i;
                SdlHardware.DrawHiddenImage(fruit, fruitPosX2[i], 0);
            }
            SdlHardware.ShowHiddenScreen();


            // Check input by the user
            //player 1
            if (SdlHardware.KeyPressed(SdlHardware.KEY_DOWN) && y2 < 600-ya)
                y2 += speed;
            if (SdlHardware.KeyPressed(SdlHardware.KEY_UP) && y2 > 0)
                y2 -= speed;
            //player 2
            if (SdlHardware.KeyPressed(SdlHardware.KEY_S) && y < 600 - ya)
                y += speed;
            if (SdlHardware.KeyPressed(SdlHardware.KEY_W) && y > 0)
                y -= speed;

            

            if (SdlHardware.KeyPressed(SdlHardware.KEY_ESC))
                finished = true;
            if (SdlHardware.KeyPressed(SdlHardware.KEY_D) && moveType==1)
            {
                moveType = 0;
            }
            if (SdlHardware.KeyPressed(SdlHardware.KEY_LEFT) && moveType==2)
            {
                moveType = 3;
            }


            // Move enemies, background, etc
            if (moveType == 0)
            {
                ballX[0] += ballSpeedX;
                ballY[0] += ballSpeedY;
            }
            if (moveType == 3)
            {
                ballX[0] -= ballSpeedX;
                ballY[0] -= ballSpeedY;
            }

            else if (moveType == 1)
            {
                ballX[0] = x + xa;
                ballY[0] = y + ya / 2 - aye / 2;
            }
            else if (moveType == 2)
            {
                ballX[0] = x2 - axe;
                ballY[0] = y2 + ya / 2 - aye / 2;
            }


            // Check collisions and apply game logic
            // collision with player
            for (int i = 0; i < amountOfEnemies; i++)
            {
                if ((x + xa > ballX[i]) && (x + xa < ballX[i] + axe) &&
                    (y + ya > ballY[i]) && (y + ya < ballY[i] + aye) ||

                    (x + xa > ballX[i]) && (x + xa < ballX[i] + axe) &&
                    (y > ballY[i]) && (y < ballY[i] + aye) ||

                    (x > ballX[i]) && (x < ballX[i] + axe) &&
                    (y + ya > ballY[i]) && (y + ya < ballY[i] + aye) ||

                    (x > ballX[i]) && (x < ballX[i] + axe) &&
                    (y > ballY[i]) && (y < ballY[i] + aye))
                {
                    ballSpeedX = -ballSpeedX;
                    ballSpeedY = -ballSpeedY;
                }
            }
            // collision with walls
            for (int i = 0; i < amountOfEnemies; i++)
            {
                // collision with top and bottom
                if ( (ballY[i] < 40) || (ballY[i] + aye > 600) )
                {
                    ballSpeedY = -ballSpeedY;
                }
                // collision with players
                if ((ballX[i] < x + xa) && (ballY[i] > y) && (ballY[i] < y+ya) || 
                    (ballX[i] + axe > x2) && (ballY[i] > y2) && (ballY[i] < y2+ya) )
                {
                    ballSpeedX = -ballSpeedX;
                    if (ballSpeedX > 0)
                    {
                        ballSpeedX += 1f;
                        ballSpeedY += 1f;
                    }
                    else
                    {
                        ballSpeedX -= 1f;
                        ballSpeedY -= 1f;
                    }
                }
                // collision with sides (points)
                if (ballX[i] < 0) //Player 2 gets point
                {
                    score1--;
                    moveType = 1;
                    ballSpeedX = 10f;
                    ballSpeedY = 10f;
                }
                else if (ballX[i] > 800) //Player 1 gets point
                {
                    score2--;
                    moveType = 2;
                    ballSpeedX = 10f;
                    ballSpeedY = 10f;
                }
            }

            //Game over
            if (score1 == 0 || score2 == 0)
            {
                SdlHardware.Pause(4000);
                finished = true;
            }

            // Pause till next frame (40 ms = 25 fps)
            SdlHardware.Pause(40);
        }
        while (!finished);
        //Console.ReadLine();
    }
}