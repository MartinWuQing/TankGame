using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
    class ZiDanFather:GameObject 
    {
        //1.字段
        private Image img;
        //2.属性
        public Image Img
        {
            get { return img;}
            set { img = value; }

        }
        //3.子弹威力属性
        public  int power
        {
            get;
            set ;
        }
        /// <summary>
        /// 4.构造函数
        /// </summary>
        /// <param name="tf"></param>
        /// <param name="?"></param>
        public ZiDanFather (TankFather  tf,int speed,int life ,int power,Image img):base(tf.X+tf.Width /2-6,tf.Y+tf.Height/2-6,img.Width ,img.Height,speed,life,tf.Dir )
      
        {

            this.img = img;
        }

        //5.绘制子弹图像
        public override void Draw(Graphics g)
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    break;

            }
            //在游戏对象完成之后。我们应该判断一下，当前游戏对象是否超出当前的窗体
            if (this.X <= 0)
            {
                this.X =-100;
            }
            if (this.Y <= 0)
            {
                this.Y = -100;
            }
            if (this.Y >= 700)
            {
                this.Y =800;
            }
            if (this.X >= 800)
            {
                this.X = 900;
            }

            g.DrawImage(img, this.X, this.Y);
        }





    }
}
