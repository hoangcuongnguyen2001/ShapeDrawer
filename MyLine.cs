using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX, _endY;
        public MyLine(int x, int y)
        {
            
            this.X = x;
            this.Y = y;
            _endX = 250;
            _endY = 220;
            this.Color = Color.Black;
            
        }

        public MyLine(): this(0,0)
        {

        }

        public float EndX
        {
            get => _endX;
            set { _endX = value; }
        }

        public float EndY
        {
            get => _endY;
            set { _endY = value; }
        }
        public override void Draw()
        {
            if (Selected)
            { DrawOutline(); }
            SplashKit.DrawLine(this.Color, this.X, this.Y, EndX, EndY);
        }

        public override bool IsAt(Point2D pt)  //idea from Charlotte Pierce in HelpDesk.
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(this.X, this.Y, EndX, EndY));
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, this.X, this.Y, 3);
            SplashKit.DrawCircle(Color.Black, EndX, EndY, 3);

        }
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
        }
    }
}

