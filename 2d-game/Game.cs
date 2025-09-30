// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Color backgroundMain = new Color(130, 140, 205);
        Color backgroundShine = new Color(150, 160, 205);
        public void Setup()
        {
            Window.SetTitle("INSERT NAME HERE");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
        }
        public void Update()
        {
            Window.ClearBackground(Color.White);

            Background();
        }
        void Background()
        {
            // draws the background and the purple outline
            Draw.LineSize = 50;
            Draw.LineColor = backgroundMain;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(new Vector2(0, 0), new Vector2(600, 800));

            for (int brick = 0; brick < 35; brick++)
            {
                int brickGapL = brick * 100;

                Draw.LineSize = 30;
                Draw.LineColor = backgroundShine;
                Draw.Line(new Vector2(0, brickGapL + 20), new Vector2(brickGapL + 20, 5));
            }
        }
    }

}
