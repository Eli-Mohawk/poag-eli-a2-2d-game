// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        Color gameSkyColor = new Color(70, 175, 225); // blue color for the sky
        Color gameGroundColor = new Color(70, 225, 85); // green color for the ground
        Color bulletColor = new Color(60, 35, 10);

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Tank Blast!");
            Window.SetSize(600, 800);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //Window.ClearBackground(bulletColor);

            Window.ClearBackground(gameSkyColor);

            // draws the ground
          

            // test items
            Ground(0, 600, 650, 800);
            //  TankBullet(200, 300);
            // Ball(300, 700);
            Pointer(100, 200, 100, 200);

        }
        void Ground (int groundX1, int groundX2, int groundY1, int groundY2)
        {
            Draw.LineSize = 0;
            Draw.FillColor = gameGroundColor;
            Draw.Rectangle(groundX1, groundX2, groundY1, groundY2);
        }
        void Ball (int x, int y)
        {
            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Gray;
     

            float standby = Input.GetMouseX();

            Draw.Circle(standby, y, 7.5f);

            Draw.LineSize = 2;
            Draw.LineColor = Color.Red;
            Draw.Line(x, 300, y, 400);
        }
        void TankBullet (int x, int y)
        {
            Draw.LineSize = 2;
            Draw.FillColor = bulletColor;
            Draw.Circle(x, y, 7.5f);
        }
        void Pointer (int x, int y)
        {
            Draw.LineSize = 2;
            Draw.FillColor = Color.Red;
            Draw.LineColor = Color.Magenta;
            Draw.Line(x, 100, y, 200);
        }
    }

}
