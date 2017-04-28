using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics gpic;
        Graphics g;
        Color originCol;
        Color curCol;
        Queue<Point> q;
        public  static PaintBase paintBase;

        public Form1()
        {
            InitializeComponent();
            paintBase = new PaintBase();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
           // bmp = new Bitmap(@"C:\Users\Андрей\Desktop\Professional English (B2)");
            g = Graphics.FromImage(bmp);
            gpic = pictureBox1.CreateGraphics();
            pictureBox1.Image= bmp;

            q = new Queue<Point>();
        }



        private void SetPenColor_Click(object sender, EventArgs e)
        {
            Color color = ((Button)sender).BackColor;
            paintBase.setPenColor(color);
        }

        private void picturebox1_MouseDown(object sender, MouseEventArgs e)
        {
            paintBase.mouseClicked = true;
            paintBase.prev = e.Location;
            if (paintBase.shape == PaintBase.Shape.FILL)
            {
                q.Enqueue(e.Location);
                originCol = bmp.GetPixel(e.Location.X, e.Location.Y);
                curCol = paintBase.pen.Color;


                while (q.Count > 0) // add in the queue
                {
                    Point curPoint = q.Dequeue();
                    Step(curPoint.X + 1, curPoint.Y);
                    Step(curPoint.X - 1, curPoint.Y);
                    Step(curPoint.X, curPoint.Y + 1);
                    Step(curPoint.X, curPoint.Y - 1);
                }
                pictureBox1.Refresh();
            }
        }

        private void picturebox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paintBase.mouseClicked)
            {
                pictureBox1.Refresh();
                paintBase.Draw(g, e.Location);
                paintBase.Draw1(pictureBox1.CreateGraphics(), e.Location);
            }

        }

        private void picturebox1_MouseUp(object sender, MouseEventArgs e)
        {
            paintBase.Draw1(g, e.Location);
            paintBase.mouseClicked = false;
            pictureBox1.Refresh();


        }
        public void Step(int x, int y)
        {
            if (x < 0) return;
            if (y < 0) return;
            if (x >= bmp.Width) return;
            if (y >= bmp.Height) return;
            if (bmp.GetPixel(x, y) != originCol) return;
            bmp.SetPixel(x, y, curCol);
            q.Enqueue(new Point(x, y));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            paintBase.pen.Width = trackBar1.Value;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            paintBase.shape = PaintBase.Shape.RECTANGLE;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            paintBase.shape = PaintBase.Shape.PEN; 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            paintBase.shape = PaintBase.Shape.LINE;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            paintBase.shape = PaintBase.Shape.ELLIPSE;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            paintBase.shape = PaintBase.Shape.FILL;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("image");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap("image");
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
        }
    }
}
