using System;
using System.Collections.Generic;
using System.Text;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        public MyRectangle(int x, int y)
        {
            this.Color = Color.Green;
            this.X = x;
            this.Y = y;
            _width = 100;
            _height = 100;


        }
        public MyRectangle(): this(0,0)
        {

        }
        public int width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        public int height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public override void Draw()
        {
            if (Selected)
            { DrawOutline(); }
            SplashKit.FillRectangle(this.Color, this.X, this.Y, width, height);
        }

        public override bool IsAt(Point2D pt)
        {
            if ((pt.X > this.X && pt.X < this.X + _width) && (pt.Y > this.Y && pt.Y < this.Y + height))

                return true;

            else
                return false;
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, this.X - 4, this.Y - 4, width + 8, height + 8);
        }
        public override void SaveTo(StreamWriter writer)
        {
            base.SaveTo(writer);
            writer.WriteLine(width);
            writer.WriteLine(height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            width = reader.ReadInteger();
            height = reader.ReadInteger();
        }
    }
}


