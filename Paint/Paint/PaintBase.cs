using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace Paint
{

    public class PaintBase
    {
        public enum Shape { LINE, PEN, RECTANGLE, ELLIPSE, FILL};

       
        public Pen pen; 
        public Point prev;
        public Shape shape;
        public bool mouseClicked = false;

        public PaintBase ()
        {
          
            pen = new Pen(Color.Black);
            prev = new Point(0, 0);
            shape = Shape.PEN;
            
        }
        public void Draw(Graphics g, Point curPoint)
        {
            if (shape == Shape.PEN)
            {
                g.DrawLine(pen, prev, curPoint);
                prev = curPoint;

            }
        }
        public void Draw1(Graphics gpic, Point curPoint)
        {
            if (mouseClicked)
            {
                if (shape == Shape.LINE)
                {
                    gpic.DrawLine(pen, prev, curPoint);
                }

                if (shape == Shape.RECTANGLE)
                {
                    int w = Math.Abs(prev.X - curPoint.X);
                    int h = Math.Abs(prev.Y - curPoint.Y);
                    int minX = Math.Min(prev.X, curPoint.X);
                    int minY = Math.Min(prev.Y, curPoint.Y);

                    gpic.DrawRectangle(pen, minX, minY, w, h);
                }

                if (shape == Shape.ELLIPSE)
                {
                    int w = Math.Abs(prev.X - curPoint.X);
                    int h = Math.Abs(prev.Y - curPoint.Y);
                    int minX = Math.Min(prev.X, curPoint.X);
                    int minY = Math.Min(prev.Y, curPoint.Y);

                    gpic.DrawEllipse(pen, minX, minY, w, h);
                }
                  
            }
        }

        public void setPenColor(Color color)
        {
            pen.Color = color;
        }
    }

}
