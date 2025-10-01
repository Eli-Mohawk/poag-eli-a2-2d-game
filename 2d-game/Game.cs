// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MohawkGame2D
{
    public class Game
    {
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

        // booleans for each display
        bool isGameStarted = false;

        // start button colors because cool
        Color mouseOff = new Color(100, 100, 100);
        Color mouseOn = new Color(75, 75, 75);
        Color mouseHeld = new Color(50, 50, 50);

        // keeps track of your current score (how many questions you got right)
        int playerScore = 0;

        // variables for each questions completion status
        bool question1Done = false;
        bool question2Done = false;
        bool question3Done = false;
        bool question4Done = false;
        bool question5Done = false;

        // array for question responses
        string[] boxA;
        string[] boxB;
        string[] boxC;
        string[] boxD;

        public void Setup()
        {
            // makes the program work
            Window.SetTitle("Super Duper 100% Very Hard Quiz");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;

            // adds custom colors to the rainbow array
            shineColor = [red, orange, yellow, green, blue, purple, pink];

            // options of your answers
            boxA = new string[366];
            boxB = new string[365];
            boxC = new string[700];
            boxD = new string[364];
        }

        public void Update()
        {
            Window.ClearBackground(Color.White);
            Background();

            Draw.LineColor = Color.Red;
            Draw.LineSize = 1;
            Draw.Line(new Vector2(300, 0), new Vector2(300, 800));
            Draw.Line(new Vector2(0, 400), new Vector2(600, 400));






            // displays menu until you press start
            if (isGameStarted == false)
            {
                Title();
                StartButton();
            }

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
                                    EndScreen();
                                }
                            }
                        }
                    }
                }
            }
        }

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
            Text.Draw("Start", new Vector2(267, 321));
        }

        void FirstQuestion()
        {
            Text.Size = 50;
            Text.Draw("Question #1", new Vector2(150, 80));

            Text.Size = 23;
            Text.Draw("How many days are in a typical year?", new Vector2(83, 150));

            AnswerBoxA(); AnswerBoxB(); AnswerBoxC(); AnswerBoxD();
 
            /// broken
            Text.Color = Color.White;
            Text.Size = 40;
            Text.Draw($"{boxA[0]}", new Vector2(125, 320));
            Text.Draw($"{boxB[0]}", new Vector2(385, 320));
            Text.Draw($"{boxC[0]}", new Vector2(125, 450));
            Text.Draw($"{boxD[0]}", new Vector2(385, 450));
        }
        
        void SecondQuestion()
        {
            Text.Draw("Question #2", new Vector2(100, 100));
        }
        
        void ThirdQuesion()
        {
            Text.Draw("Question #3", new Vector2(100, 100));
        }

        void FourthQuestion()
        {
            Text.Draw("Question #4", new Vector2(100, 100));
        }

        void FifthQuestion()
        {
            Text.Draw("Question #5", new Vector2(100, 100));
        }

        void EndScreen()
        {
            Text.Draw("Congrats!", new Vector2(100, 100));
        }

        void Restart()
        {

        }

        async void Correct()
        {
            Text.Draw("congrats!", new Vector2(300, 300));
        }

        async void Incorrect()
        {

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
    }

}
