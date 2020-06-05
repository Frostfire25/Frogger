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
    public class Frog
    {



        /*
         * Constructor:

- Frog(initialX, initialY)
Characteristics (variables):

- sittingicon - image of sitting frog
- hoppingicon - image of jumping frog
- xpos - x coordinate of frog
- ypos - y coordinate of frog
- icon - which image should show ( 0 = sitting, 1 = jumping)
- lives - how many lives are left.
- wins - number of successful road crossings.

Actions (methods):

- verifyX - checks that X coordinate is in range
- verifyY - checks that Y coordinate is in range.
- getX - gets X coordinate
- getY - gets Y coordinate
- setX - sets X coordinate
- setY - sets Y coordinate
- setJump - sets the icon to jumping image
- setSit - sets the icon to sitting image
- hop - moves frog set number of units
         */

        //Image of the Sitting frog
        private Image SITTING_FROG = Properties.Resources.frog;
        //Immage of the Jumping Frog
        private Image JUMPING_FROG = Properties.Resources.jumping_frog;
        //Frogs image
        private Image image;

        //X position
        private int xpos;
        //Y Position
        private int ypos;

        //Lives
        private int lives = 3;

        //Frogs Picture Box
        private PictureBox frog;
        //Final Box
        private PictureBox endingBox;
        //Instance of the main class
        private frogBox instance;

        public Frog(int x, int y, PictureBox pictureBox, PictureBox endingBox, frogBox instance)
        {
            //Sets the istance
            this.instance = instance;
            //Sets the xpos
            this.xpos = x;
            //Sets the ypos
            this.ypos = y;
            //Sets the image
            this.image = SITTING_FROG;
            //Sets the frogs picturebox
            this.frog = pictureBox;
            //Sets the ending box
            this.endingBox = endingBox;

            //Stretches the background
            frog.BackgroundImageLayout = ImageLayout.Stretch;
            //Sets the frogs image
            frog.BackgroundImage = image;
            changeLocation();
        }

        /*
        public Image Sitting_Frog
        {
            get { return SITTING_FROG; }
            set { this.SITTING_FROG = value; }
        }

        public Image Jumping_Frog
        {
            get { return JUMPING_FROG; }
            set { this.SITTING_FROG = value; }
        }
        */

        //Returns the PictureBox for the frog entity
        public PictureBox FrogPictureBox
        {
            get { return this.frog;  }
            set { this.frog = value; }
        }

        //Called whena  key is pressed
        public void hop(MoveType moveType)
        {
            //Sets the background image to the Jumping Frog
            frog.BackgroundImage = JUMPING_FROG;
            //1ms delay
            //delay(1);
            //Sets the background image to the Sitting Frog
            frog.BackgroundImage = SITTING_FROG;
            //Switches the move
            switch (moveType)
            {
                //If the move is up
                case MoveType.UP:
                {
                        //It makes a new Y loc
                   int newY = frog.Location.Y - 99;
                        // if the y loc is valid
                   if(verifiyY(newY))
                        {
                            //It changes the y loc
                            ypos = newY;
                            //Moves the frog
                            changeLocation();
                            //And checks to see if the game is over
                            isCompleted();
                        }
                    } break;

                case MoveType.DOWN:
                    {
                        //It makes a new Y loc
                        int newY = frog.Location.Y + 99;
                        if (verifiyY(newY))
                        {    //It changes the y loc
                            ypos = newY;
                            //Moves the frog
                            changeLocation();
                            //And checks to see if the game is over
                            isCompleted();
                        }
                    }
                    break;

                case MoveType.LEFT:
                    {   //It makes a new X loc
                        int newX = frog.Location.X - 99;
                        if (verifiyX(newX))
                        { //It changes the x loc
                            xpos = newX;
                            //Moves the frog
                            changeLocation();
                            //And checks to see if the game is over
                            isCompleted();
                        }
                    }
                    break;

                case MoveType.RIGHT:
                    {   //It makes a new X loc
                        int newX = frog.Location.X + 99;
                        if (verifiyX(newX))
                        { //It changes the x loc
                            xpos = newX;
                            //Moves the frog
                            changeLocation();
                            //And checks to see if the game is over
                            isCompleted();
                        }
                    }
                    break;
            }
        }

        //Called whenever a frog moves
        private void isCompleted()
        {
           
            //If the frog is in the endingBox
            if(frog.Bounds.IntersectsWith(endingBox.Bounds))
            {
                //Score is upped
                instance.upScore();
                //Frog loc is reset
                xpos = 693;
                ypos = 997;
                //Frog is moved
                changeLocation();
            }
        }

        //Changes the location of the entity
        private void changeLocation()
        {
            try { 
                //Sets the location of the PictureBox to a new Point
            frog.Location = new Point(xpos, ypos);
            }
            catch (StackOverflowException e)
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

        //Returns the frogs current Image
        public Image IMAGE
        {
            get { return image; }
            set { image = value; }
        }

        //Returns the X
        public int X
        {
            get { return xpos; }
            set { xpos = value; }
        }

        //Returns the Y
        public int Y
        {
            get { return ypos; }
            set { ypos = value; }
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

        //Called when a frog gets a life removed
        public void removeLife()
        {
            //Removes a life
            lives = lives - 1;
            //Resets the frog
            xpos = 693;
            ypos = 997;
            changeLocation();
        }

        //Enums from the frog moving
        public enum MoveType
        {
            UP,
            DOWN,
            LEFT,
            RIGHT,
            NONE
        }

    }
}
