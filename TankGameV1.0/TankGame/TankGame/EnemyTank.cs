using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using TankGame.Properties;

namespace TankGame
{
    class EnemyTank:TankFather 
    {
        private static Image[] imgs1 = {
                                       Resources.enemy1U,
                                       Resources.enemy1D,
                                       Resources.enemy1L,
                                       Resources.enemy1R
                                       };
        private static Image[] imgs2 = {
                                       Resources.enemy2U,
                                       Resources.enemy2D,
                                       Resources.enemy2L,
                                       Resources.enemy2R
                                       };
        private static Image[] imgs3 = {
                                       Resources.enemy3U,
                                       Resources.enemy3D,
                                       Resources.enemy3L,
                                       Resources.enemy3R
                                       };

        //1.存储敌人坦克的速度
        private static int _speed;
        //2.存储敌人坦克的生命
        private static int _life;

        public int EnemyTankType
        {
            get;
            set;
        }


        /// <summary>
        ///3. 通过一个静态方法设置敌人坦克的速度
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0: _speed = 5;
                    break;
                case 1: _speed = 6;
                    break;
                case 2: _speed = 7;
                    break;
            }
            return _speed;
        }


        /// <summary>
        /// 4.通过一个静态方法设置敌人坦克的生命
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    _life = 1;
                    break;
                case 1:
                    _life = 2;
                    break;
                case 2:
                    _life = 3;
                    break;
            }
            return _life;
        }



        public EnemyTank(int x, int y, int type, Direction dir)
            : base(x, y, imgs1, SetSpeed(type), SetLife(type), dir)
        {
            this.EnemyTankType = type;
            Born();
        }


        //10.吃装备让敌人暂停、
        public bool isStop = true;
        //11.吃装备让敌人暂停多长时间
        public int stoptime = 0;




        //5.向窗体当中绘制我们的敌人坦克
        public override void Draw(Graphics g)
        {

            bornTime++;
            if(bornTime %20==0)
            {
                IsMove = true;
            }
            if (IsMove)
            {
                //一绘制我们的敌人坦克 就让坦克移动
               //加一个小判断，让敌人停止和暂停一段时间内开始
                if(isStop )
                {
                   Move();
                }
                else
                {
                    stoptime++;
                    if(stoptime %50==0)
                    {
                        isStop = true;

                    }
                }

             
                switch (EnemyTankType)
                {
                    case 0:
                        switch (this.Dir)
                        {
                            case Direction.Up:
                                g.DrawImage(imgs1[0], this.X, this.Y);
                                break;
                            case Direction.Down:
                                g.DrawImage(imgs1[1], this.X, this.Y);
                                break;
                            case Direction.Left:
                                g.DrawImage(imgs1[2], this.X, this.Y);
                                break;
                            case Direction.Right:
                                g.DrawImage(imgs1[3], this.X, this.Y);
                                break;
                        }
                        break;
                    case 1:
                        switch (this.Dir)
                        {
                            case Direction.Up:
                                g.DrawImage(imgs2[0], this.X, this.Y);
                                break;
                            case Direction.Down:
                                g.DrawImage(imgs2[1], this.X, this.Y);
                                break;
                            case Direction.Left:
                                g.DrawImage(imgs2[2], this.X, this.Y);
                                break;
                            case Direction.Right:
                                g.DrawImage(imgs2[3], this.X, this.Y);
                                break;
                        }
                        break;
                    case 2:
                        switch (this.Dir)
                        {
                            case Direction.Up:
                                g.DrawImage(imgs3[0], this.X, this.Y);
                                break;
                            case Direction.Down:
                                g.DrawImage(imgs3[1], this.X, this.Y);
                                break;
                            case Direction.Left:
                                g.DrawImage(imgs3[2], this.X, this.Y);
                                break;
                            case Direction.Right:
                                g.DrawImage(imgs3[3], this.X, this.Y);
                                break;
                        }
                        break;
                }
                //一边移动，一边发子弹
                if (r.Next(0, 100) < 2)
                {
                    Fire();
                }
            }
        }


        //7.发射子弹的重写
        /// <summary>
        /// 敌人发射子弹
        /// </summary>
        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyZD(this,10,10, 1));
        }

        //8.重写是否中弹的方法就是显示爆炸的的图像。播放音乐。敌人死亡
        public override void IsOver()
        {
            //if (this.Life == 0)//敌人被击中了，并且死亡
            //{
                //出现爆炸的图像
                SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
                //被击中就删掉，删掉被击中的坦克
                SingleObject.GetSingle().RemoveGameObject(this);
                //播放爆炸音乐
                SoundPlayer sp = new SoundPlayer(Resources.fire);
                sp.Play();
            //当敌人坦克死亡的时候，会有一定的几率，在出生新的坦克
                if (r.Next(0, 100) >30)
                {
                    SingleObject.GetSingle().AddGameObject(new EnemyTank(r.Next(0, 700), r.Next(0, 600), r.Next(0, 3), Direction.Down));
                }
            //当敌人死亡的额时候有一定的几率，产生装备
            if(r.Next (0,100)>20)
            {

                SingleObject.GetSingle().AddGameObject(new Zhuangbei(this.X, this.Y, r.Next(0, 3)));

            }


            //}
            //else//敌人被击中了，但没死亡
            //{
            //     SoundPlayer sp = new SoundPlayer(Resources.hit );
            //      sp.Play();

            //}



        }
        //9.坦克出生重写
        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }



        //6.产生一个随机数，控制敌人坦克随机运动，
        //并且必须是静态的随机数
       static  Random r = new Random();

       public override void Move()
       {
           base.Move();
           //给一个很小的概率，让他进行下一步
           if (r.Next(0, 100) < 5)
           {
               switch (r.Next(0, 4))
               {
                   case 0:
                       this.Dir = Direction.Up;
                       break;
                   case 1:
                       this.Dir = Direction.Down;
                       break;
                   case 2:
                       this.Dir = Direction.Left;
                       break;
                   case 3:
                       this.Dir = Direction.Right;
                       break;
               }
           }
       }
    }
}
