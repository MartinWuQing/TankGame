using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGame.Properties;

namespace TankGame
{
    class Zhuangbei:GameObject 
    {
        //必须标记成静态类才能让 构造函数访问到
        private  static   Image imgStar = Resources.star;
        private  static  Image imgBomb = Resources.bomb;
        private  static  Image imgTimer = Resources.timer;

        //2.来一个属性区分装备
        public int ZBType
        {
            get;
            set;
        }

        //3.装备构造函数-先在GameObject类中在写一个构造函数专门给zhuangbei的，
        public Zhuangbei (int x,int y,int type):base(x,y,imgBomb.Width ,imgBomb .Height )
        {
            this.ZBType = type;
        }

        //4.画图图
        public override void Draw(Graphics g)
        {
           switch (ZBType )
           {
               case 0:
                   g.DrawImage(imgStar, this.X, this.Y);
                   break;
               case 1:
                   g.DrawImage(imgBomb, this.X, this.Y);
                   break;
               case 2:
                   g.DrawImage(imgTimer, this.X, this.Y);
                   break;
           }
        }

    }
}
