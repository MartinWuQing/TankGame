using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TankGame.Properties;

namespace TankGame
{
    class Boom:GameObject 
    {
        //1.导入爆炸图片
        private Image[] imgs ={
                                   Resources.blast1 ,
                                   Resources.blast2 ,
                                   Resources.blast3 ,
                                   Resources.blast4 ,
                                   Resources.blast5 ,
                                   Resources.blast6 ,
                                   Resources.blast7 ,
                                   Resources.blast8 ,
                               };
        //2.构造函数
        public Boom (int x,int y)  :base(x,y)
        {

        }
        //3.重写绘制图像的方法
        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length ; i++)
            {
                g.DrawImage(imgs[i], this.X, this.Y);
             }
            //爆炸播放完成之后，就删除游戏对象
            SingleObject.GetSingle().RemoveGameObject(this);
        }


    }
}
