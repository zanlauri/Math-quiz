using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_quiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer
        // to generate random numbers.

        Random randomizer = new Random();

        //These integer variable store the numbers
        // for the addition problem
        int addend1;
        int addend2;

        //this iontegerr variable keeps track of the
        // remaning time
        int timeLeft;

        /// <summary>
        /// Start the quiz by filling in all of the problems
        /// and starting the timer
        /// </summary>
        public void StartTheQuiz()
        {
            // Fill in the addition problem.
            //Generate two random numbers to add
            //Store the values in the variables 'addend1' and 'addend2'
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //cnvert the two randomly generated numbers
            //into strings so that they can be displayed
            //in the label controls
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //'sum' is the name of the NumericUpDown control
            //This step makes sure its value is zero before
            //adding any values to it
            sum.Value = 0;

            // start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();


        }
        /// <summary>
        /// check the answer to see is the user got everything right
        /// 
        /// </summary>
        /// <returns>True if the answer's correct, false otherwise.</returns>
        private bool CheckTheAnswer()
        {
            if (addend1 + addend2 == sum.Value)
                return true;
            else
                return false;

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                //display the new time left
                //by updating the time left label
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + "seconds";
            }
            else if (timeLeft > 0)
            {
                //if checkanswer() return false, keep counting
                //down.
                //display the new time left by updating the
                //Time Left label
                timeLeft--;
                timeLabel.Text = timeLeft + "seconds";
            }
            else
            {
                //if the use ran out of time, stop the timer, show
                //a message box, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }
    }
}
