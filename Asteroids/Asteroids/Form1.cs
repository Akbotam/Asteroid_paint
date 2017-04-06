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
        Bitmap bmp;
        Graphics g;
        Ship s;
        Bullet b;
        Triangle shape1, shape2, shape3, shape4;
        //Graphics gpic;
        SolidBrush brush1;
        SolidBrush brush2;
        SolidBrush brush3;
        SolidBrush brush4;

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
            s = new Ship(400, 170);
            b = new Bullet(420, 140);
            shape1 = new Triangle(0, -20);
            shape2 = new Triangle(90, 150);
            shape3 = new Triangle(500, 180);
            shape4 = new Triangle(600, -40);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, EventArgs e)
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

            g.DrawPath(new Pen(Color.Green), b.path1); //bullet
            g.FillPath(brush3, b.path1);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

 
