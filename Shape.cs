using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SplashKitSDK;
using System.IO;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private static Dictionary<string, Type> _ShapeClassRegistry = new Dictionary<string, Type>();
        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistry[name] = t;
        }
        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistry[name]);
        }

        
        public static string GetKey(Type newType)
        {
            foreach (string key in _ShapeClassRegistry.Keys)
            {
                if (_ShapeClassRegistry[key] == newType)
                {
                    return key;
                }
            }
            return null;
        }
        private Color _color;
        private float _x,_y;
        private bool _selected;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        { 
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
            }
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(GetKey(this.GetType()));
            writer.WriteColor(Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
            
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
        public abstract void Draw();
        

        public abstract bool IsAt(Point2D pt);


        public abstract void DrawOutline();
       
    }
}
