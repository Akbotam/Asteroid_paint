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
        public PaintBase paintBase;
        public Form1()
        {
            InitializeComponent();
            paintBase = new PaintBase(pictureBox1);
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
        }

        private void picturebox1_MouseMove(object sender, MouseEventArgs e)
        {    if (paintBase.mouseClicked)
            {
                paintBase.Draw(pictureBox1.CreateGraphics(), e.Location);
            }

        }

        private void picturebox1_MouseUp(object sender, MouseEventArgs e)
        {
            paintBase.mouseClicked = false;
            
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
    }
}
