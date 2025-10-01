// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
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

        public void Setup()
        {
            // makes the program work
            Window.SetTitle("Super Duper 100% Very Hard Quiz");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;

            // adds custom colors to the rainbow array
            shineColor = [red, orange, yellow, green, blue, purple, pink];
        }

        public void Update()
        {
            Window.ClearBackground(Color.White);
            
            // elements that appear when you launch the game
            Background();
            Title();
            StartButton();
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
            // button that checks if you click it and starts the game when you do
        }
    }

}
