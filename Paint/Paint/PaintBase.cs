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
        public enum Shape { LINE, ERASER, PEN, RECTANGLE, ELLIPSE };

        public Graphics g;
        public Pen pen;
        public Bitmap btm;
        public Point prev;
        public Shape shape;
        public PictureBox picture;
        public bool mouseClicked;

        public PaintBase (PictureBox picturebox1)
        {
            btm = new Bitmap(picture.Width, picture.Height);

            bool mouseClicked = false;
            picture = picturebox1;
            pen = new Pen(Color.Black);
            prev = new Point(0, 0);
            //g.Clear(Color.White);
            shape = Shape.PEN;
        }
        public void Draw (Graphics g, Point curPoint)
        {
            if (shape ==Shape.PEN)
            {
                g.DrawLine(pen, prev, curPoint);
                prev = curPoint;

            }
            else if (shape == Shape.RECTANGLE)
            {
                int w = Math.Abs(prev.X - curPoint.X);
                int h = Math.Abs(prev.Y - curPoint.Y);
                int MinX = Math.Min(prev.X, curPoint.X);
                int MinY = Math.Min(prev.Y, curPoint.Y);

                g.DrawRectangle(pen, MinX, MinY, w, h);
            }
        }

        public void setPenColor(Color color)
        {
            pen.Color = color;
        }
    }

}
