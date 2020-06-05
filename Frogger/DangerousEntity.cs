using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{ 
    class DangerousEntity 
    {
        //Image
        private Image image;
        //Curent xpos
        private int xpos;
        //Curent ypos
        private int ypos;

        //Starting Location X
        private int startingLocationX;
        //Starting Location Y
        private int startingLocationY;
        //If the Entity is going Left
        private bool left;
        //Frog to kill
        private Frog frog;
        //Main instance
        private frogBox instance;
        


        private PictureBox entity;
        public DangerousEntity(int x, int y, Image image, bool left, PictureBox pictureBox, Frog frog, frogBox frogger)
        {
            //Sets the entity PictureBox
            this.entity = pictureBox;
            //Sets xpos
            this.xpos = x;
            //Sets ypos
            this.ypos = y;
            //Sets frog
            this.frog = frog;
            //Sets image
            this.image = image;
            //Sets left
            this.left = left;
            //Sets instance
            this.instance = frogger;
            //Sets Entity's BackgroundImage
            this.entity.BackgroundImage = image;
            //Sets Entity's BackgroundImageLayout
            this.entity.BackgroundImageLayout = ImageLayout.Stretch;
            //Determines if it is fliped left or right
            this.entity.BackgroundImage.RotateFlip(left ? RotateFlipType.Rotate90FlipNone : RotateFlipType.Rotate270FlipNone);
            //Sets startingLocationX
            this.startingLocationX = x;
            //Sets startingLocationY
            this.startingLocationY = y;            
            //Moves the cars position
            changeLocation();
            //move();
            //Thread thread = new Thread(new ThreadStart(Run));
            //thread.Start();

        }
        private Random random = new Random();

        //Called every tick
        public void move()
        {            
            //If the car is moving left
            if (left)
                {
                //A new location is made
                    int newX = entity.Location.X - random.Next(2,11);
                //If it is verified
                    if (verifiyX(newX))
                    {
                    //New location is set
                        xpos = newX;
                    }
                    else
                    {
                    //xpos is reset to the starting location
                        xpos = 1365;
                    }
                    //Dangerous entitiy loc is changed
                    changeLocation();
                }
                else //If the car is moving right
                {
                //A new location is made
                int newX = entity.Location.X + random.Next(2, 11);
                //If it is verified
                if (verifiyX(newX))
                    {
                    //New location is set
                    xpos = newX;
                    }
                    else
                    {
                    //xpos is reset to the starting location
                    xpos = 1;
                    }
                //Dangerous entitiy loc is changed
                changeLocation();
                }
            //Checks to see if the entity is being cilled
            if(killing())            
                instance.killed();
            
           // delay(50);
        }

        //Checks to see if the frog is being killed
        private bool killing()
        {
            //If the frog is being killed true is returned
            return frog.FrogPictureBox.Bounds.IntersectsWith(entity.Bounds);
        }
        /*
        public void Run()
        {
            if (left)
            {
                int newX = entity.Location.X - 2;
                if (verifiyX(newX))
                {
                    xpos = newX;
                }
                else
                {
                    xpos = startingLocationX;
                }
                changeLocation();
            }
            else
            {
                int newX = entity.Location.X + 2;
                if (verifiyX(newX))
                {
                    xpos = newX;
                }
                else
                {
                    xpos = startingLocationX;
                }
                changeLocation();
            }
            delay(50);
        }*/


        //Changes the location of the entity
        private void changeLocation()
        {
            try
            {
                entity.Location = new Point(xpos, ypos);
            } catch(StackOverflowException e)
            {

            }
        }

        //Checks to see if the x is valid
        public bool verifiyX(int x)
        {
            //If the x is not in the values return is false
            if (x < 0 || x > 1366)
                return false;
            //If the x is in the values the return is true
            return true;
        }

        //Checks to see if the y is valid
        public bool verifiyY(int y)
        {
            //If the y is not in the values return is false
            if (y < 0 || y > 1100)
                return false;
            //If the y is in the values the return is true
            return true;
        }

        private void delay(int MilliSeconds)
        {
            //convert to seconds
            double numberOfSeconds = MilliSeconds / 1000.0;
            // add seconds to current time to find stop time
            DateTime dblWaitTil = DateTime.Now.AddSeconds(numberOfSeconds);
            // Loop to constantly check current time
            // stops when current time reaches stop time
            while (!(DateTime.Now > dblWaitTil))
            {
                // Allow windows messages to be processed
                Application.DoEvents();
            }            
        }
    }
}
