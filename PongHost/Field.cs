using Common;
using System;

namespace PongHost
{
    enum Movement
    {
        None,
        Up,
        Down
    }


    internal class Rectangle //the object for the players & ball
    {
        internal int Top { get; set; }
        internal int Width { get; set; }
        internal int Height { get; set; }
        internal int Left { get; set; }
        internal int Right => Left + Width;
        internal int Bottom => Top + Height; //distance between the bottom edge of the rectangle and the top edge of the screen

        public Rectangle(int width, int height, int left, int top)
        {
            this.Width = width; //size, x
            this.Height = height; //size, y
            this.Top = top; //location, y
            this.Left = left; //location, x doesn't change for the rackets!!
        }
    }

    internal class Racket : Rectangle
    {
        public Movement movement { get; set; }

        public Racket(int width, int height, int left, int top) : base(width, height, left, top) { }
    }

    internal class Field
    {
        internal Racket player1 = new Racket(15, 100, 961, 197); //initialize the starting value
        internal Racket player2 = new Racket(15, 100, 1, 197);
        internal Rectangle ball = new Rectangle(15, 15, 493, 255);
        internal int ballX = 5; // horizontal X speed value for the ball object 
        internal int ballY = 5; // vertical Y speed value for the ball object
        internal int score1 = 0; //player1 score
        internal int score2 = 0; //player2 score
        internal int clientWidth = 976; //the width of the screen
        internal int clientHeight = 533; //the height of the screen
        internal int maxTop = 1;
        internal int minTop = 458; //client height - player height
        internal Random rand = new Random(); //to determine balls initial direction after collision
        internal int speed = 15; // influences the speed of the player's paddle movement
        internal int[] randSpeed = { 7, 8, 9, 10, 11, 12, 13 }; //might randomize ball speed

        public Field()
        {
        }

        private bool Intersects(Rectangle r1, Rectangle r2)
        {
            /* 
             * Check if the rectangles intersect by checking if one rectangle's
            ** left edge is to the right of the other rectangle's right edge
            ** or vice versa, and similarly for top/bottom edges
            **/
            bool intersectX = (r1.Left < r2.Right && r1.Right > r2.Left);
            bool intersectY = (r1.Top < r2.Bottom && r1.Bottom > r2.Top);

            // If both X and Y intersect, then the rectangles intersect
            return intersectX && intersectY;
        }

        private void WhenCollision(Rectangle ball)
        {
            int x = randSpeed[rand.Next(randSpeed.Length)]; //randomizes speeds on both axes 
            int y = randSpeed[rand.Next(randSpeed.Length)];
            if (this.ballX < 0)
            {
                this.ballX = x; //changing the direction of the ball
            }
            else
            {
                this.ballX = -x;
            }
            if (this.ballY < 0)
            {
                this.ballY = -y;
            }
            else
            {
                this.ballY = y;
            }
        }

        internal void CalcPlayerPosition(Racket racket) //returns for each seperately
        {
            //always make sure to calculate for player 1 first!!
            //the left attribute of players doesn't change throughout the game!
            //returns the top value of the racket
            if (racket.movement == Movement.Up && racket.Top > 0)
            {
                racket.Top -= this.speed;
                return;
            }
            else if (racket.movement == Movement.Down && racket.Top < minTop)
            {
                racket.Top += this.speed;
                return;
            }
        }


        internal Data GetNextFrame()
        {
            CalcPlayerPosition(this.player1);
            CalcPlayerPosition(this.player2);


            this.ball.Top -= this.ballY; // assign the ball TOP to ball Y integer
            this.ball.Left -= this.ballX; // assign the ball LEFT to ball X integer


            if (this.ball.Left < 0) //player 1 scored a point
            {
                //then
                this.ball.Left = 493; // reset the ball to the middle of the screen
                this.ball.Top = 255;
                this.ballX = -this.ballX; // change the balls direction
                this.score1++;
                

            }
            // if the ball has gone past the right through player1

            if (this.ball.Left + this.ball.Width > this.clientWidth)
            {
                // then
                this.ball.Left = 493;  // set the ball to centre of the screen
                this.ball.Top = 255;
                this.ballX = -this.ballX; // change the direction of the ball
                this.score2++; // add one to the players score
                
            }
            //controlling the ball
            // if the ball either reachers the top of the screen or the bottom
            if (this.ball.Top < 0 || ball.Top + ball.Height >= this.clientHeight)
            {
                // then
                //reverse the speed of the ball so it stays within the screen
                this.ballY = -this.ballY;
            }
            // if the ball hits the players
            if (Intersects(this.player1, this.ball) || Intersects(this.player2, this.ball))
            {
                // then bounce the ball in the other direction, randomizing the speed
                WhenCollision(this.ball);
            }

            return new Data(this.player1.Top, this.player2.Top, this.ball.Left, this.ball.Top, this.score1, this.score2);
        }

    }

}



