using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGame.Properties;

namespace TankGame
{
    class Wall :GameObject 
    {
        //必须是静态的
        private  static  Image img = Resources.wall;
        public Wall(int x, int y)
            : base(x, y, img.Width, img.Height)
        { 
        
        
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.X, this.Y);
        }







 }

}
