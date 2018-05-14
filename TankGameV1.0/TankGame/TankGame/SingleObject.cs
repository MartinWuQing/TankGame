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
    /// <summary>
    /// 这个单例类用来创建我们全局唯一的游戏对象
    /// </summary>
    class SingleObject
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private SingleObject ()
        { }
           
        public static SingleObject _singleobject=null;
        public static SingleObject GetSingle()
        {
            if (_singleobject ==null)
            {
                _singleobject = new SingleObject();
            }

            return _singleobject ;

        }
        //1.存储玩家坦克对象
        public PlayerTank PT
        {
            get;
            set;

        }

        //4.将我们的敌人坦克、玩家子弹，敌人子弹、爆炸  、出生时的小星星、装备/墙 存储到泛型集合中
        List<EnemyTank> listEnemyTank = new List<EnemyTank>();
        List<PlayerZD> listPlayerZD = new List<PlayerZD>();
        List<EnemyZD> listEnemyZD = new List<EnemyZD>();
        List<Boom> listBoom = new List<Boom>();

        List<TankBorn> listTankBorn = new List<TankBorn>();
        List<Zhuangbei> listZhuangBei = new List<Zhuangbei>();
        List<Wall> listWall = new List<Wall>();

      
        
        //2.提供一个方法，将我们这个游戏对象添加到游戏当中,游戏对象很多，所以把父类传进去
       //把玩家坦克添加到游戏当中
        /// <summary>
        /// 添加游戏对象
        /// </summary>
        /// <param name="go"></param>
        public void AddGameObject(GameObject go)
        {
            //(1).添加玩家坦克
            if (go is PlayerTank )//is 表示类型转换成功为Yes不成功返回false
            {
                PT = go as PlayerTank;//as 也是类型转换，成功的话  返回对应的对象，否则返回null

            }
                //（2).添加敌人坦克对象
            else if (go is EnemyTank )
            {
                listEnemyTank.Add(go as EnemyTank);
            }
            //（3）.添加玩家子弹
            else if(go is PlayerZD )
            {
                listPlayerZD.Add (go as PlayerZD);

            }
            else if (go is EnemyZD )
            {
                listEnemyZD.Add(go as EnemyZD);

            }
            //(4.添加爆炸图
            else if(go is Boom )
            {
                listBoom.Add(go as Boom);

            }
            //（5.添加出生时的小星星
            else if(go is TankBorn )
            {
                listTankBorn.Add(go as TankBorn);
            }
            //(6.添加装备对象
            else if(go is Zhuangbei )
            {
                listZhuangBei.Add(go as Zhuangbei);

            }
            //(7.添加墙对象
            else if(go is Wall )
            {
                listWall.Add(go as Wall);
            }

        }

        //3.绘制游戏的方法
        /// <summary>
        /// 绘制游戏对象
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            //(1.画玩家坦克
            PT.Draw(g);
            //(2.画敌人坦克
            for (int i = 0; i < listEnemyTank .Count ; i++)
            {
                listEnemyTank[i].Draw(g);
            }
            //(3.绘制玩家子弹
            for (int i = 0; i < listPlayerZD .Count ; i++)
            {
                listPlayerZD[i].Draw(g);
            }
            //(4.绘制敌人子弹
            for (int i = 0; i < listEnemyZD.Count ; i++)
            {
                listEnemyZD[i].Draw(g);
            }
            //(5.绘制爆炸
            for (int i = 0; i < listBoom .Count ; i++)
            {
                listBoom[i].Draw(g);
            }
            //(6。绘制出生时的小星星
            for (int i = 0; i < listTankBorn.Count ; i++)
            {
                listTankBorn[i].Draw(g); 
            }
            //(6.绘制装备对象
            for (int i = 0; i < listZhuangBei .Count ; i++)
            {
                listZhuangBei[i].Draw(g);
            }
            //(7.绘制墙
            for (int i = 0; i < listWall .Count ; i++)
            {
                listWall[i].Draw(g);
            }
            
        }
        /// <summary>
        /// 4
        /// 碰撞检测的方法
        /// </summary>
        public void PZJC()
        {
            #region   （1.首先判断玩家的子弹是否打在了敌人的身上

            for (int i = 0; i < listPlayerZD .Count ; i++)
            {
                for (int j = 0; j < listEnemyTank.Count  ; j++)
                {
                    if(listPlayerZD [i].GetRectangle().IntersectsWith (listEnemyTank [j].GetRectangle ()))
                    {
                          //表示玩家的子弹打到敌人的身上
                        //敌人应该减少生命值
                        listEnemyTank[j].Life -= listPlayerZD[i].power ;
                        listEnemyTank[j].IsOver();
                        //当玩家坦克的子弹击中敌人坦克的时候，子弹消失
                        listPlayerZD.Remove(listPlayerZD[i]);
                        break;
                    }
                }
            }
            #endregion 

            #region    （2.判断敌人 的子弹是否打在了玩家的身上
            for (int i = 0; i < listEnemyZD .Count ; i++)
            {
                //敌人子弹的矩形区域跟玩家区域相交
                if(listEnemyZD [i].GetRectangle ().IntersectsWith (PT.GetRectangle ()))
                {

                    PT.IsOver();
                    //将敌人子弹删除
                    listEnemyZD.Remove(listEnemyZD[i]);
                    break;
                }
            }
            #endregion
            #region    （3. （自己写的）判断敌人的子弹是否打在了玩家子弹上
            for (int i = 0; i < listEnemyZD.Count ; i++)
            {
                for (int j= 0; j  < listPlayerZD .Count ; j++)
                {
                    
                
                //敌人子弹的矩形区域跟玩家子弹区域相交
                if(listEnemyZD [i].GetRectangle ().IntersectsWith (listPlayerZD[j].GetRectangle()))
                {
                    listPlayerZD.Remove(listPlayerZD[j]);
                    listEnemyZD.Remove(listEnemyZD[i]);
                    SoundPlayer sp = new SoundPlayer(Resources.hit);
                    sp.Play();
                    break;

                 } 
                }
            }


            #endregion

            #region  (4.玩家是否和产生的装备发生碰撞
            for (int i = 0; i < listZhuangBei .Count ; i++)
            {
                //玩家吃到了装备
                if(listZhuangBei [i].GetRectangle ().IntersectsWith (PT.GetRectangle ()))
                {
                    //调用JudgeZB的方法   等级++吃五角星、  
                    //注意先后顺序，先掉用后移除
                    JudgeZB(listZhuangBei[i].ZBType);
                    
                    //将装备移除
                    listZhuangBei.Remove(listZhuangBei[i]);

                   

                    //添加吃装备的声音
                    SoundPlayer sp = new SoundPlayer(Resources.add);
                    sp.Play ();
                }
            }
            #endregion
            #region 5.判断敌人是否和墙发生了碰撞
            for (int i = 0; i < listWall .Count ; i++)
            {

                for (int j = 0; j < listEnemyTank .Count ; j++)
                {
                     if(listWall [i].GetRectangle ().IntersectsWith(listEnemyTank [j].GetRectangle() ))
                     {
                         //当敌人  和墙体发生碰撞时。我们应改将敌人的坐标固定到那里
                         //碰撞的位置，不许穿过墙体
                         //需要判断敌人是从哪个方向过来发生碰撞的
                         switch (listEnemyTank[j].Dir)
                         {
                             case  Direction.Up :
                                 listEnemyTank[j].Y = listWall[i].Y + listWall[i].Height;
                                 break;
                             case  Direction.Down :
                                 listEnemyTank[j].Y = listWall[i].Y- listWall[i].Height;
                                 break;
                             case Direction.Left :
                                 listEnemyTank[j].X = listWall[i].X + listWall[i].Width ;
                                 break;
                             case Direction.Right :
                                 listEnemyTank[j].X = listWall[i].X - listWall[i].Width;
                                 break;


                         }



                     }
                }
            }


            #endregion 

        }



        //6.判断玩家吃了什么装备，然后会怎样
        public void JudgeZB(int type)
        {
            switch (type )
            {
                case 0://玩家吃到了五角星
                    //怎么让玩家子弹这速度加快
                     //ZDLevel++
                    if(PT.ZDLevel<2)
                    {
                        PT.ZDLevel++;
                    }
                    
                    break;
                case 1://吃到地雷后炸掉一片敌人
                    for (int i = 0; i < listEnemyTank .Count ; i++)
                    {
                        //把敌人塔克的生命值赋为0
                        listEnemyTank[i].Life = 0;
                       //调用敌人死亡的方法
                        listEnemyTank[i].IsOver();
                    }
                    break;
                case 2://想办法让所有敌人暂停
                  //  必须遍历所有敌人对象
                    for (int i = 0; i <listEnemyTank .Count ; i++)
                    {
                        //暂停功能--就是不让敌人坦克类的Draw方法中的Move方法失效
                        listEnemyTank[i].isStop = false;
                    }
                    
                    break;

                
            }



        }

















        //5.移除各个游戏对象
        public void RemoveGameObject(GameObject go)
        {
            if(go is Boom )
            {
                listBoom.Remove(go as Boom);
            }
            if(go is PlayerZD  )
            {
                listPlayerZD.Remove(go as PlayerZD);
            }

            if(go is EnemyZD )
            {
                listEnemyZD.Remove(go as EnemyZD);
            }
            if (go is EnemyTank )
            {
                listEnemyTank.Remove(go as EnemyTank);
            }
            if(go is TankBorn )
            {
                listTankBorn.Remove(go as TankBorn);
            }
            if(go is Zhuangbei )
            {
                listZhuangBei.Remove(go as Zhuangbei);
            }
            if(go is Wall )
            {
                listWall.Remove(go as Wall);
            }

        }
    }
}
