using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frogger
{
    public partial class frogBox : Form
    {
        //Frog Entity
        private Frog frogEntity;
        //List of all the DangerousEntity's
        private List<DangerousEntity> dangerousEntities;
        //If the game is in session
        private static bool inSession;
        //Lives
        private int lives;
        //Score
        private int score;
        //Timer counter;
        private int time;

        public frogBox()
        {
            InitializeComponent();
            //Setup
            setUp();      
        }

        //Ran on start
        private void setUp()
        {
            //Sets the gameOver Label to false
            gameOverLabel.Visible = false;
            //Sets the background image to the map
            this.BackgroundImage = Properties.Resources.Map;
            //Sets the BackgroundImageLayout to Strech
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //Sets Lives = 3
            this.lives = 3;
            //Sets Score = 0
            this.score = 0;
            //Sets time;
            this.time = 0;
            //Creates a new Frog
            frogEntity = new Frog(693, 997, FrogPictureBox, endingBox, this);
            //Sets the game to inSession
            inSession = true;
            //Instantiates a new Dangerous Entity List
            dangerousEntities = new List<DangerousEntity>();

            /*
             * Adds new Dangerous Entities
             */

            dangerousEntities.Add(new DangerousEntity(1029, 828,
                Properties.Resources.aquacar, true, dangerousEntity1, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(187, 737,
                Properties.Resources.bluecar, false, dangerousEntity2, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(1206, 534,
                Properties.Resources.greencar, true, dangerousEntity3, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(342, 433,
                Properties.Resources.orangecar, false, dangerousEntity4, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(975, 222,
                Properties.Resources.redcar, true, dangerousEntity5, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(12, 125,
                Properties.Resources.pinkcar, false, dangerousEntity6, frogEntity, this));

            //Doubles

            dangerousEntities.Add(new DangerousEntity(1206, 534,
                Properties.Resources.bluecar, true, dangerousEntity7, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(985, 433,
                Properties.Resources.tancar, true, dangerousEntity8, frogEntity, this));

            dangerousEntities.Add(new DangerousEntity(167, 125,
                Properties.Resources.aquacar, false, dangerousEntity9, frogEntity, this));

            //Triple 

            dangerousEntities.Add(new DangerousEntity(643, 125,
                Properties.Resources.orangecar, false, dangerousEntity10, frogEntity, this));


            //moveDangerousEntities();
            //Starts the times that moves the DangerousEntities
            //Sets the interval to 10 
            timer1.Interval = 10;
            timer1.Start();
        }
               
     
        //Returns if the game is InSession
        public static bool InSession
        {
            get { return inSession; }
            set { inSession = value; }
        }

        private void Frogger_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void frogBox_KeyPress(object sender, KeyPressEventArgs evt)
        {
            
        }

        //Ups the score
        public void upScore()
        {
            //Set's the core label to the new score
            score = score + 1;
            scoreLabel.Text = "Score ["+ score +"]";
        }

        //Whenever the frog is killed this is called.
        public void killed()
        {
            //Removes a life;
            lives = lives - 1;
            livesLabel.Text = "Lives [" + lives + "]";
            //Removes a lift from the frog
            frogEntity.removeLife();
            //If the lives are over
            if(lives <= 0)
            {
                //Game Over label is shownn
                gameOverLabel.Visible = true;
                //5 Seccond Delay
                delay(5000);
                //Game Ends
                Application.Exit();
            }
           
        }

        private void frogBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Checks key data
            switch(e.KeyData)
            {
                //If the keytata is equal to one of the for movement keys, then the frog is moved if it is allowed
                case Keys.Up: frogEntity.hop(Frog.MoveType.UP); break;
                case Keys.Down: frogEntity.hop(Frog.MoveType.DOWN); break;
                case Keys.Left: frogEntity.hop(Frog.MoveType.LEFT); break;
                case Keys.Right: frogEntity.hop(Frog.MoveType.RIGHT); break;
            }
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

        //Called on each Timer Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Time ++
            time++;
            //If the time = 1000 && the timer != 2 
            if (time == 1000 && timer1.Interval > 2) {
                //The time is reduced by 2
                timer1.Interval = timer1.Interval - 2;
            }
            //For every DangerousEntity
            foreach (DangerousEntity n in dangerousEntities)
            {
                //Move
                n.move();
            }
        }
        //Returns the Frog
        public Frog GetFrog()
        {
            return frogEntity;
        }
        //Closes the Application on Exiting
        private void frogBox_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    
}
