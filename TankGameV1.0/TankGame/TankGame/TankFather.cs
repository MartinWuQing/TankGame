using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
   abstract  class TankFather:GameObject 
    {
        private Image[] imgs = new Image[] { };
        /// <summary>
        /// 1.构造函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="imgs"></param>
        /// <param name="speed"></param>
        /// <param name="life"></param>
        /// <param name="dir"></param>
        public TankFather(int x, int y, Image[] imgs, int speed, int life, Direction dir)
            : base(x, y, imgs[0].Width, imgs[0].Height, speed, life, dir)
        {
            this.imgs = imgs;//父类中必须去实现
        
        }

        //3.发射子弹的虚方法，让两个子类去重写
        public abstract void Fire();

       //4.是否中弹的方法
        public abstract void IsOver();
       //5.坦克出生的方法
        public abstract void Born();


       //6.做延时，先显示星星，再让玩家坦克出现
        public int bornTime = 0;
        public bool IsMove = false;


        /// <summary>
        /// 2.绘图
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            bornTime++;
            if(bornTime%20==0)
            {
                IsMove = true;
            }


            if (IsMove)
            {
                switch (this.Dir)
                {
                    case Direction.Up:
                        g.DrawImage(imgs[0], this.X, this.Y);
                        break;
                    case Direction.Down:
                        g.DrawImage(imgs[1], this.X, this.Y);
                        break;
                    case Direction.Left:
                        g.DrawImage(imgs[2], this.X, this.Y);
                        break;
                    case Direction.Right:
                        g.DrawImage(imgs[3], this.X, this.Y);
                        break;
                }
            }
        }
     }
}
