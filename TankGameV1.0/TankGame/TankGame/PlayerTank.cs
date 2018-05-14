using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankGame.Properties;


namespace TankGame
{
    class PlayerTank:TankFather 
    {
        private static Image[] imgs ={
                                  Resources .p1tankU ,
                                  Resources .p1tankD ,
                                  Resources .p1tankL ,
                                  Resources.p1tankR  
                             };
        public PlayerTank (int x,int y,int speed,int life ,Direction dir)
            :base(x,y,imgs,speed,life,dir )
        {
            Born();

        }


             //6.标明子弹等级-属性

        public int ZDLevel
        {
            get;
            set;
        }









        //1.玩家按键移动方法
        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    this.Dir = Direction.Up;
                    base.Move();
                    break;
                case  Keys.A:
                    this.Dir = Direction.Left;
                    base.Move();
                    break;
                case Keys.D :
                    this.Dir = Direction.Right;
                    base.Move();
                    break;
                case  Keys.S :
                    this.Dir = Direction.Down;
                    base.Move();
                    break;
                   //发射子弹的按键
                case Keys.K :
                    Fire();
                    break;



            }
      }
        //2.重写发射子弹
        public override void Fire()
        {
            //(6.位吃装备写代码{{
            switch (ZDLevel )
            {
                case 0:
                    SingleObject.GetSingle().AddGameObject(new PlayerZD(this, 10, 10, 1));
                    break;
                case 1:
                    SingleObject.GetSingle().AddGameObject(new PlayerZD(this, 20, 10, 1));
                    break;
                case 2:
                    SingleObject.GetSingle().AddGameObject(new PlayerZD(this, 40, 10, 1));
                    break;


            }

          //当执行这个方法时，我们创建子弹对象
            SingleObject.GetSingle().AddGameObject(new PlayerZD(this,10, 10, 1));
        }

        //3.重写是否中弹的方法
        public override void IsOver()
        {
            //玩家坦克爆炸
            //SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
            //播放声音
            SoundPlayer sp = new SoundPlayer(Resources.hit);
            sp.Play();


        } 
        //4.重写坦克出生的方法
        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }

    }
}
