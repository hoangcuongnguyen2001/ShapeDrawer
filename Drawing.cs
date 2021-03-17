using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background
        {
            get => _background;
            set { _background = value; }
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;

        }
        public Drawing() : this(Color.White)
        {

        }

        public int ShapeCount
        {
            get => _shapes.Count;
        }

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void RemoveShape()//
        {
            foreach (Shape s in _shapes.ToList())
            {
                if (s.Selected)
                {
                    _shapes.Remove(s);
                }
            }
            
        }
        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape s in _shapes)
            {
                s.Draw();
         
            }
        }

        public void SelectShapeAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                    s.Selected = true;
                else
                    s.Selected = false;

            }
        }

      
        public List<Shape> SelectedShapes()
            {
            List<Shape> result = new List<Shape>();
            foreach (Shape s in result)
            {
                if (s.Selected)
                    result.Add(s);

            }
            return result;
            }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            try
            {
                writer.WriteColor(Background);
                writer.WriteLine(ShapeCount);
                foreach (Shape s in _shapes)
                {
                    s.SaveTo(writer);
                }
            }
            finally
            {
                writer.Close();
            }
         }
        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            Background = reader.ReadColor();
            int count = reader.ReadInteger();
          
           
            try
            {
                _shapes.Clear();

                for (int i = 0; i < count; ++i)
                {
                    Shape s;
                    string kind = reader.ReadLine();
                    s = Shape.CreateShape(kind);
                    s.LoadFrom(reader);
                    _shapes.Add(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
