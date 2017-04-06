using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Asteroids
{
    class Bullet
    {
        public GraphicsPath path1 = new GraphicsPath();
        public Bullet (int x, int y)
        {
            path1.AddLine(x + 110, y + 60, x + 115, y + 75);
            path1.AddLine(x + 115, y + 75, x + 130, y + 80);
            path1.AddLine(x + 130, y + 80, x + 115, y + 85);
            path1.AddLine(x + 115, y + 85, x + 110, y + 100);
            path1.AddLine(x + 110, y + 100, x + 105, y + 85);
            path1.AddLine(x + 105, y + 85, x + 90, y + 80);
            path1.AddLine(x + 90, y + 80, x + 105, y + 75);
            path1.AddLine(x + 105, y + 75, x + 110, y + 60);
        }
    }
}
