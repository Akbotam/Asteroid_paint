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

namespace Asteroids
{
    public partial class Form1 : Form
    {
        enum Direction
        {
            UP,
            DOWN,
            RIGHT,
            LEFT,
            NONE
        };
        Direction dir;

        Bitmap bmp;
        Graphics g;
        Ship s;
        Bullet b;
        Triangle shape1, shape2, shape3, shape4;
        public static bool BulIsEx = false;
        public static int bul = 0;
        SolidBrush brush1;
        SolidBrush brush2;
        SolidBrush brush3;
        SolidBrush brush4;
        public int x = 400, y = 170;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp = new Bitmap(@"C:\Users\Андрей\Desktop\Professional English (B2)/bitmapfon.jpg");
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            brush1 = new SolidBrush(Color.White);
            brush2 = new SolidBrush(Color.Red);
            brush3 = new SolidBrush(Color.Green);
            brush4 = new SolidBrush(Color.Yellow);
            s = new Ship(x, y);
            b = new Bullet(420, 140);
            shape1 = new Triangle(0, -20);
            shape2 = new Triangle(90, 150);
            shape3 = new Triangle(500, 180);
            shape4 = new Triangle(600, -40);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) // если Enter, то происходит выстрел
            {
                BulIsEx = true; // пуля существует
                Refresh();
                pictureBox1.Image = bmp;
            }

            if (e.KeyCode == Keys.Up)
            {
                dir = Direction.UP;
            }
            if (e.KeyCode == Keys.Down)
            {
                dir = Direction.DOWN;
            }
            if (e.KeyCode == Keys.Right)
            {
                dir = Direction.RIGHT;
            }
            if (e.KeyCode == Keys.Left)
            {
                dir = Direction.LEFT;
            }
        }

        static int x1 = 0, x2 = 90, x3 = 500, x4 = 600;
        static int y1 = -20, y2 = 150, y3 = 180, y4 = -40;
        private void timer1_Tick(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            bmp = new Bitmap(@"C:\Users\Андрей\Desktop\Professional English (B2)/bitmapfon.jpg");
            g = Graphics.FromImage(bmp);

            pictureBox1.Image = bmp;

            x1++; // asteroids
            y1++;
            if (x1 == 991)
                x1 = 0;
            if (y1 == 571)
                y1 = 0;
            x2++;
            y2--;
            if (x2 == 991)
                x2 = 0;
            if (y2 == 0)
                y2 = 571;
            x3--;
            y3++;
            if (x3 == 0)
                x3 = 991;
            if (y3 == 571)
                y3 = 0;
            x4--;
            y4--;
            if (x4 == 0)
                x4 = 991;
            if (y4 == 0)
                y4 = 571;
            shape1 = new Triangle(x1, y1);
            shape2 = new Triangle(x2, y2);
            shape3 = new Triangle(x3, y3);
            shape4 = new Triangle(x4, y4);
            if (BulIsEx) // bullet
            {
                bul += 4;
                b = new Bullet(280, 120 - bul);
            }
            if (dir == Direction.UP)
            {
                s = new Ship(x, y -= 10);
            }
            if (dir == Direction.DOWN)
            {
                s = new Ship(x, y += 10);
            }
            if (dir == Direction.RIGHT)
            {
                s = new Ship(x += 10, y);
            }
            if (dir == Direction.LEFT)
            {
                s = new Ship(x -= 10, y);
            }

            Paint1();
            pictureBox1.Image = bmp;
            pictureBox1.Refresh();
        }

        

        public void Paint1()
        {
            g.FillPath(brush2, shape1.path);

            g.FillPath(brush2, shape1.path2);

            g.FillPath(brush2, shape2.path);

            g.FillPath(brush2, shape2.path2);

            g.FillPath(brush2, shape3.path);

            g.FillPath(brush2, shape3.path2);

            g.FillPath(brush2, shape4.path);

            g.FillPath(brush2, shape4.path2);


            g.FillEllipse(brush1, 70, 100, 35, 35);
            g.FillEllipse(brush1, 100, 450, 35, 35);
            g.FillEllipse(brush1, 350, 60, 35, 35);
            g.FillEllipse(brush1, 600, 90, 35, 35);
            g.FillEllipse(brush1, 940, 150, 35, 35);
            g.FillEllipse(brush1, 800, 250, 35, 35);
            g.FillEllipse(brush1, 920, 500, 35, 35);
            g.FillEllipse(brush1, 360, 400, 35, 35);

            g.DrawPath(new Pen(Color.Yellow), s.path3); // ship
            g.FillPath(brush4, s.path3);
            g.DrawPath(new Pen(Color.Green), s.path4); // gun
            g.FillPath(brush3, s.path4);

            if (BulIsEx)
            {
                g.DrawPath(new Pen(Color.Green), b.path1); //bullet
                g.FillPath(brush3, b.path1);
            }
        }
        private void Form1_Paint(object sender, EventArgs e)
        {

            //g.FillPath(brush2, shape1.path);

            //g.FillPath(brush2, shape1.path2);

            //g.FillPath(brush2, shape2.path);

            //g.FillPath(brush2, shape2.path2);

            //g.FillPath(brush2, shape3.path);

            //g.FillPath(brush2, shape3.path2);

            //g.FillPath(brush2, shape4.path);

            //g.FillPath(brush2, shape4.path2);


            //g.FillEllipse(brush1, 70, 100, 35, 35);
            //g.FillEllipse(brush1, 100, 450, 35, 35);
            //g.FillEllipse(brush1, 350, 60, 35, 35);
            //g.FillEllipse(brush1, 600, 90, 35, 35);
            //g.FillEllipse(brush1, 940, 150, 35, 35);
            //g.FillEllipse(brush1, 800, 250, 35, 35);
            //g.FillEllipse(brush1, 920, 500, 35, 35);
            //g.FillEllipse(brush1, 360, 400, 35, 35);

            //g.DrawPath(new Pen(Color.Yellow), s.path3); // ship
            //g.FillPath(brush4, s.path3);
            //g.DrawPath(new Pen(Color.Green), s.path4); // gun
            //g.FillPath(brush3, s.path4);

            //if (BulIsEx)
            //{
            //    g.DrawPath(new Pen(Color.Green), b.path1); //bullet
            //    g.FillPath(brush3, b.path1);
            //}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

 
