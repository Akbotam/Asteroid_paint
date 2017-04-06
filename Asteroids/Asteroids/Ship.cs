using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Asteroids
{
    class Ship
    {
        public GraphicsPath path3 = new GraphicsPath(); // ship
        public GraphicsPath path4 = new GraphicsPath(); // gun
        public Ship(int x, int y)
        {
            path3.AddLine(x + 100, y + 80, x + 181, y + 120); 
            path3.AddLine(x + 181, y + 120, x + 181, y + 160); 
            path3.AddLine(x + 181, y + 160, x + 100, y + 200); 
            path3.AddLine(x + 100, y + 200, x + 19, y + 160); 
            path3.AddLine(x + 19, y + 160, x + 19, y + 120); 
            path3.AddLine(x + 19, y + 120, x + 100, y + 80); 

            path4.AddLine(x + 100, y + 100, x + 120, y + 130);
            path4.AddLine(x + 120, y + 130, x + 110, y + 130);
            path4.AddLine(x + 110, y + 130, x + 110, y + 160);
            path4.AddLine(x + 110, y + 160, x + 90, y + 160);
            path4.AddLine(x + 90, y + 160, x + 90, y + 130);
            path4.AddLine(x + 90, y + 130, x + 80, y + 130);
            path4.AddLine(x + 80, y + 130, x + 100, y + 100);
        }
    }
}
