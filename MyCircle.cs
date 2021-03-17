using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ShapeDrawer
{
     public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Color = Color.Yellow;
            _radius = 50;
        }

        public MyCircle() : this(0,0)
        {

        }
        public int Radius
        {
            get => _radius;
            set
            {
                _radius = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
            { DrawOutline(); }
            SplashKit.FillCircle(this.Color, this.X, this.Y, Radius);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt, SplashKit.CircleAt(this.X,this.Y,Radius)); // help from my tutor Mark Noone.
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, this.X, this.Y, Radius + 4);
        }
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
