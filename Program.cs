using SplashKitSDK;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Schema;
using System.IO;
using System;

namespace ShapeDrawer
{
    public static class ExtensionMethods
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }
        public static float ReadSingle(this StreamReader reader)
        {
            return Convert.ToSingle(reader.ReadLine());
        }
        public static Color ReadColor(this StreamReader reader)
        {
            return Color.RGBColor(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
        }
        public static void WriteColor(this StreamWriter writer, Color clr)
        {
            writer.WriteLine("{0}\n{1}\n{2}", clr.R, clr.G, clr.B);
        }
    }
    public class Program
    { 
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main(string[] args)
        {
            new Window("Shape Drawer", 800, 600);
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));
            Drawing newDrawing = new Drawing();
            ShapeKind KindtoAdd = ShapeKind.Circle;
            

            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
               
                if(SplashKit.KeyDown(KeyCode.RKey))
                {
                    KindtoAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyDown(KeyCode.LKey))
                {
                    KindtoAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyDown(KeyCode.CKey))
                {
                    KindtoAdd = ShapeKind.Circle;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    int x = (int)SplashKit.MouseX();
                    int y = (int)SplashKit.MouseY();

                    if  (KindtoAdd == ShapeKind.Rectangle) {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                    }


                    else if (KindtoAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                    }

                   else
                    {
                        MyLine newLine = new MyLine();
                        newShape = newLine;
                    }
                    newShape.X = x;
                    newShape.Y = y;
                    newDrawing.AddShape(newShape);

                }
                if(SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    newDrawing.SelectShapeAt(SplashKit.MousePosition());
                }
                if((SplashKit.KeyDown(KeyCode.DeleteKey))|| (SplashKit.KeyDown(KeyCode.BackspaceKey)))
                {
                    newDrawing.RemoveShape();

                }
                if (SplashKit.KeyDown(KeyCode.SpaceKey))
                {
                    newDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    newDrawing.Save("C:\\Users\\Dell\\Desktop\\newDrawing.txt");
                }

                if (SplashKit.KeyDown(KeyCode.OKey))
                {
                    try { newDrawing.Load("C:\\Users\\Dell\\Desktop\\newDrawing.txt"); }
                    catch(Exception e)
                    { Console.Error.WriteLine("Error loading file :{0}", e.Message); }
                    
                }

                newDrawing.Draw();

                SplashKit.RefreshScreen();

            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }

    }
}
