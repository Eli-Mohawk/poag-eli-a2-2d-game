// Include the namespaces (code libraries) you need below.
using System;
using System.ComponentModel.Design;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MohawkGame2D
{
    public class Game
    {
        // keeps track of your current score (how many questions you got right)
        int playerScore = 0;

        #region Rainbow colors / array
        // custom colors for the background "shine" lines
        Color red = new Color(255, 0, 0);
        Color orange = new Color(255, 109, 36);
        Color yellow = new Color(255, 255, 0);
        Color green = new Color(69, 237, 43);
        Color blue = new Color(31, 230, 237);
        Color purple = new Color(132, 47, 212);
        Color pink = new Color(227, 34, 204);
       
        // initiates the rainbow array
        Color[] shineColor;
        #endregion

        #region Button colors
        // start button colors because cool
        Color mouseOff = new Color(100, 100, 100);
        Color mouseOn = new Color(75, 75, 75);
        Color mouseHeld = new Color(50, 50, 50);
        #endregion

        #region Screen booleans
        // booleans for each display
        bool isGameStarted = false;

        // variables for each questions completion status
        bool question1Done = false;
        bool question2Done = false;
        bool question3Done = false;
        bool question4Done = false;
        bool question5Done = false;

        // bonus text for restarting
        bool didWin = false;
        bool didEnd = false;
        bool didLose = false;
        #endregion

        #region Responses
        // array for question responses
        string[] boxA;
        string[] boxB;
        string[] boxC;
        string[] boxD;
        #endregion

        #region Startup / color array
        public void Setup()
        {
            // makes the program work
            Window.SetTitle("Super Duper 100% Very Hard Quiz");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;

            // adds custom colors to the rainbow array
            shineColor = [red, orange, yellow, green, blue, purple, pink];
        }
        #endregion

        public void Update()
        {
            Window.ClearBackground(Color.White);
            Background();

            #region Response array
            // these are here so playerScore will update for q3 (idk how else to do it)
            // options of your answers
            boxA = ["366", "10", $"{playerScore}", "mohawk", "easy"];
            boxB = ["365", "8", "5", "mowhawk", "meh"];
            boxC = ["700", "12", null, "Mohawk", "fine"];
            boxD = ["364", "11", null, "Mowhawk", "hard"];
            #endregion

            #region Title + NG+
            // displays menu until you press start
            if (isGameStarted == false)
            {
                Title();
                StartButton();

                // bonus text
                if (didWin == true)
                {
                    Text.Size = 23;
                    Text.Color = red;
                    Text.Draw("Bro... you already won.", 155, 380);
                }

                else if (didLose == true)
                {
                    Text.Size = 23;
                    Text.Color = red;
                    Text.Draw("Yeah, I would hope you try again.", 105, 380);
                }

                else if (didEnd == true)
                {
                    Text.Size = 23;
                    Text.Color = red;
                    Text.Draw("Please get more right this time.", 105, 380);
                }

                else
                {

                }
            }
            #endregion

            #region Screens
            // stops the menu specific items from being displayed and displays the new elements
            else
            {
                Score();

                if (question1Done == false)
                {
                    FirstQuestion();
                }

                else
                {
                    if (question2Done == false)
                    {
                        SecondQuestion();
                    }

                    else
                    {
                        if (question3Done == false)
                        {
                            ThirdQuesion();
                        }

                        else
                        {
                            if (question4Done == false)
                            {
                                FourthQuestion();
                            }

                            else
                            {
                                if (question5Done == false)
                                {
                                    FifthQuestion();
                                }

                                else
                                {
                                    if (playerScore == 5)
                                    {
                                        WinScreen();
                                    }

                                    else if (playerScore >= 1)
                                    {
                                        EndScreen();
                                    }

                                    else
                                    {
                                        LoseScreen();
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }

        #region Title screen
        void Background()
        {
            // makes a rectangle with a blue border
            Draw.LineSize = 50;
            Draw.LineColor = Color.DarkGray;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(600, 800));

            // generates the rainbow lines
            for (int shine = 0; shine < 14; shine++)
            {
                // seperates the rainbow lines
                int shineGap = shine * 100;

                // draws the rainbow lines
                // line 2 of this makes the array loop so that it doesnt crash
                Draw.LineSize = 30;
                Draw.LineColor = shineColor[shine % shineColor.Length];
                Draw.Line(new Vector2(0, shineGap + 20), new Vector2(shineGap + 20, 0));
            }

            // creates the main display area
            Draw.LineSize = 0;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(50, 50), new Vector2(500, 700));
        }

        void Title()
        {
            // displays the intro message with varying sizes for emphasis
            Text.Size = 50;
            Text.Color = Color.White;
            Text.Draw("Welcome!", new Vector2(200, 85));

            Text.Size = 25;
            Text.Draw("to my", new Vector2(265, 145));
            Text.Draw("Super Duper 100% Very Hard Quiz!", new Vector2(90, 185));
        }

        void StartButton()
        {
            // variables for mouse position
            float mouseX = Input.GetMouseX();
            float mouseY = Input.GetMouseY();

            // checks if your mouse is over the button
            if (mouseX <= 350 && mouseX >= 250 && mouseY <= 350 && mouseY >= 315)
            {
                // makes the button color change to feel reactive
                Draw.FillColor = mouseOn;

                // checks if left click is down when you are over the button
                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.FillColor = mouseHeld;
                }

                // starts the game when you let go off left click over the start button
                else if (Input.IsMouseButtonReleased(MouseInput.Left))
                {
                    isGameStarted = true;
                    didWin = false;
                    didLose = false;
                    didEnd = false;
                }
                else
                {

                }
            }
            else
            {
                Draw.FillColor = mouseOff;
            }

            // makes the start button
            // its here so i can make its color different based on your mouse
            Draw.LineColor = Color.White;
            Draw.LineSize = 1;
            Draw.Rectangle(new Vector2(250, 315), new Vector2(100, 35));

            // start button text
            Text.Draw("Start", new Vector2(267, 323));
        }
        #endregion

        #region Questions
        void FirstQuestion()
        {
            Text.Size = 50;
            Text.Draw("Question #1", new Vector2(150, 80));

            Text.Size = 23;
            Text.Draw("How many days are in a typical year?", new Vector2(83, 150));

            // places the option boxes
            AnswerBoxA(); 
            AnswerBoxB(); 
            AnswerBoxC(); 
            AnswerBoxD();
 
            // displays the q1 options
            Text.Color = Color.White;
            Text.Size = 25;
            Text.Draw($"{boxA[0]}", new Vector2(153, 325));
            Text.Draw($"{boxB[0]}", new Vector2(413, 325));
            Text.Draw($"{boxC[0]}", new Vector2(153, 455));
            Text.Draw($"{boxD[0]}", new Vector2(413, 455));
        }
        
        void SecondQuestion()
        {
            Text.Size = 50;
            Text.Draw("Question #2", new Vector2(150, 80));

            Text.Size = 23;
            Text.Draw("How many different colors are", new Vector2(120, 150));
            Text.Draw("currently on screen?", new Vector2(167, 180));

            AnswerBoxA(); 
            AnswerBoxB(); 
            AnswerBoxC(); 
            AnswerBoxD();

            Text.Color = Color.White;
            Text.Size = 25;
            Text.Draw($"{boxA[1]}", new Vector2(160, 325));
            Text.Draw($"{boxB[1]}", new Vector2(427, 325));
            Text.Draw($"{boxC[1]}", new Vector2(160, 455));
            Text.Draw($"{boxD[1]}", new Vector2(421, 455));
        }
        
        void ThirdQuesion()
        {
            Text.Size = 50;
            Text.Draw("Question #3", new Vector2(150, 80));

            Text.Size = 23;
            Text.Draw("What is your score?", new Vector2(180, 150));

            AnswerBoxA();
            AnswerBoxB();

            Text.Color = Color.White;
            Text.Size = 25;
            Text.Draw($"{boxA[2]}", new Vector2(165, 325));
            Text.Draw($"{boxB[2]}", new Vector2(430, 325));
        }

        void FourthQuestion()
        {
            Text.Size = 50;
            Text.Draw("Question #4", new Vector2(150, 80));

            Text.Size = 23;
            Text.Draw("What is the name of our college?", new Vector2(97, 150));

            AnswerBoxA();
            AnswerBoxB();
            AnswerBoxC();
            AnswerBoxD();

            Text.Color = Color.White;
            Text.Size = 25;
            Text.Draw($"{boxA[3]}", new Vector2(135, 325));
            Text.Draw($"{boxB[3]}", new Vector2(390, 325));
            Text.Draw($"{boxC[3]}", new Vector2(135, 455));
            Text.Draw($"{boxD[3]}", new Vector2(390, 455));
        }

        void FifthQuestion()
        {
            Text.Size = 50;
            Text.Draw("Question #5", new Vector2(150, 80));

            Text.Size = 23;
            Text.Draw("How hard was this quiz?", new Vector2(97, 150));

            AnswerBoxA();
            AnswerBoxB();
            AnswerBoxC();
            AnswerBoxD();

            Text.Color = Color.White;
            Text.Size = 25;
            Text.Draw($"{boxA[4]}", new Vector2(148, 324));
            Text.Draw($"{boxB[4]}", new Vector2(412, 325));
            Text.Draw($"{boxC[4]}", new Vector2(148, 455));
            Text.Draw($"{boxD[4]}", new Vector2(406, 455));
        }
        #endregion

        #region End screens
        void EndScreen()
        {
            Text.Size = 40;
            Text.Color = blue;
            Text.Draw("WOW! You didn't lose!", 80, 80);

            playerScore = -1;

            Restart();

            didEnd = true;
        }

        void WinScreen()
        {
            Text.Size = 40;
            Text.Color = yellow;
            Text.Draw("Congrats! You won!", 110, 80);

            playerScore = -1;

            Restart();

            didWin = true;
        }

        void LoseScreen()
        {
            Text.Size = 40;
            Text.Color = red;
            Text.Draw("You lost.", 200, 80);

            playerScore = -1;

            Restart();

            didLose = true;
        }
        #endregion

        #region Extras
        void Restart()
        {
            float restartX = Input.GetMouseX();
            float restartY = Input.GetMouseY();

            if (restartX <= 350 && restartX >= 250 && restartY <= 350 && restartY >= 315)
            {
                Draw.FillColor = mouseOn;

                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.FillColor = mouseHeld;
                }

                else if (Input.IsMouseButtonReleased(MouseInput.Left))
                {
                    isGameStarted = false;
                    question1Done = false;
                    question2Done = false;
                    question3Done = false;
                    question4Done = false;
                    question5Done = false;
                    playerScore = 0;
                }
                else
                {

                }
            }
            else
            {
                Draw.FillColor = mouseOff;
            }

            Draw.LineColor = Color.White;
            Draw.LineSize = 1;
            Draw.Rectangle(new Vector2(245, 315), new Vector2(110, 35));

            Text.Size = 23;
            Text.Color = Color.White;
            Text.Draw("Restart?", 251, 324);

        }

        void Score()
        {
            Draw.LineSize = 1;
            Draw.LineColor = Color.Gray;
            Draw.FillColor = Color.DarkGray;
            Draw.Rectangle(new Vector2(395, 0), new Vector2(205, 33));

            Text.Size = 15;
            Text.Draw($"Your current score is: {playerScore}", new Vector2(401, 9));
        }
        #endregion

        #region Answer boxes
        void AnswerBoxA()
        {
            float question1X = Input.GetMouseX();
            float question1Y = Input.GetMouseY();

            if (question1X >= 125 && question1X <= 225 && question1Y >= 320 && question1Y <= 350)
            {
                Draw.FillColor = mouseOn;

                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.FillColor = mouseHeld;
                }

                else if (Input.IsMouseButtonReleased(MouseInput.Left))
                {

                    if (question4Done == true)
                    {
                        question5Done = true;
                    }

                    else if (question3Done == true)
                    {
                        question4Done = true;
                    }

                    else if (question2Done == true)
                    {
                        question3Done = true;

                        playerScore += 1;
                    }

                    else if (question1Done == true)
                    {
                        question2Done = true;
                    }
                    else
                    {
                        question1Done = true;
                    }
                }

                else
                {

                }
            }

            else
            {
                Draw.FillColor = mouseOff;
            }

            Draw.LineSize = 1;
            Draw.LineColor = Color.White;
            Draw.Rectangle(new Vector2(125, 320), new Vector2(100, 30));
        }

        void AnswerBoxB()
        {
            float question2X = Input.GetMouseX();
            float question2Y = Input.GetMouseY();

            if (question2X >= 385 && question2X <= 485 && question2Y >= 320 && question2Y <= 350)
            {
                Draw.FillColor = mouseOn;

                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.FillColor = mouseHeld;
                }

                else if (Input.IsMouseButtonReleased(MouseInput.Left))
                {
                    if (question4Done == true)
                    {
                        question5Done = true;
                    }

                    else if (question3Done == true)
                    {
                        question4Done = true;
                    }

                    else if (question2Done == true)
                    {
                        question3Done = true;
                    }

                    else if (question1Done == true)
                    {
                        question2Done = true;
                    }
                    else
                    {
                        question1Done = true;

                        playerScore += 1;
                    }
                }

                else
                {

                }
            }

            else
            {
                Draw.FillColor = mouseOff;
            }

            Draw.LineSize = 1;
            Draw.LineColor = Color.White;
            Draw.Rectangle(new Vector2(385, 320), new Vector2(100, 30));
        }

        void AnswerBoxC()
        {
            float question3X = Input.GetMouseX();
            float question3Y = Input.GetMouseY();

            if (question3X >= 125 && question3X <= 225 && question3Y >= 450 && question3Y <= 480)
            {
                Draw.FillColor = mouseOn;

                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.FillColor = mouseHeld;
                }

                else if (Input.IsMouseButtonReleased(MouseInput.Left))
                {
                    if (question4Done == true)
                    {
                        question5Done = true;
                    }

                    else if (question3Done == true)
                    {
                        question4Done = true;

                        playerScore += 1;
                    }

                    else if (question2Done == true)
                    {
                        question3Done = true;
                    }

                    else if (question1Done == true)
                    {
                        question2Done = true;
                    }
                    else
                    {
                        question1Done = true;
                    }
                }

                else
                {

                }
            }

            else
            {
                Draw.FillColor = mouseOff;
            }

            Draw.LineSize = 1;
            Draw.LineColor = Color.White;
            Draw.Rectangle(new Vector2(125, 450), new Vector2(100, 30));
        }

        void AnswerBoxD()
        {
            float question4X = Input.GetMouseX();
            float question4Y = Input.GetMouseY();

            if (question4X >= 385 && question4X <= 485 && question4Y >= 450 && question4Y <= 480)
            {
                Draw.FillColor = mouseOn;

                if (Input.IsMouseButtonDown(MouseInput.Left))
                {
                    Draw.FillColor = mouseHeld;
                }

                else if (Input.IsMouseButtonReleased(MouseInput.Left))
                {
                    if (question4Done == true)
                    {
                        question5Done = true;

                        playerScore += 1;
                    }

                    else if (question3Done == true)
                    {
                        question4Done = true;
                    }

                    else if (question2Done == true)
                    {
                        question3Done = true;
                    }

                    else if (question1Done == true)
                    {
                        question2Done = true;

                        playerScore += 1;
                    }
                    else
                    {
                        question1Done = true;
                    }
                }

                else
                {

                }
            }

            else
            {
                Draw.FillColor = mouseOff;
            }

            Draw.LineSize = 1;
            Draw.LineColor = Color.White;
            Draw.Rectangle(new Vector2(385, 450), new Vector2(100, 30));
        }
        #endregion
    }

}
