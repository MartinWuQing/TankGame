using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGame.Properties;

namespace TankGame
{
    class TankBorn:GameObject 
    {
        private Image[] imgs ={
                                   Resources.born1 ,
                                   Resources.born2 ,
                                   Resources .born3 ,
                                   Resources .born4 
                               };
        //2.在写一个构造函数
        public TankBorn (int x,int y):base(x,y)
        {

        }
        //3.绘制图像
        int time = 0;
        public override void Draw(Graphics g)
        {
            time++;
            for (int i = 0; i < imgs.Length ; i++)
            {
               switch(time%10)
               {
                   case 1:
                       g.DrawImage(imgs[0], this.X, this.Y);
                       break;
                   case 3:
                       g.DrawImage (imgs [1],this.X,this.Y );
                           break ;
                   case 5:
                       g.DrawImage (imgs [2],this.X,this.Y );
                           break ;
                   case 7:
                       
                       g.DrawImage (imgs [3],this.X,this.Y );
                           break ;

               }
            }
            //当for循环结束之后，也就是闪烁图片播放完成之后
            //这个时候我们应该将图片消除

            if (time % 5 == 0)
            {
                SingleObject.GetSingle().RemoveGameObject(this);
                //结果闪烁太快。解决方法——向上看
            }
        }

    }
}
