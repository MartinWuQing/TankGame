using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TankGame.Properties;



namespace TankGame
{
    class EnemyZD:ZiDanFather 
    {

        //倒入玩家子弹图片
        private static Image img = Resources.enemymissile ;
        //写构造函数
        public EnemyZD (TankFather tf,int speed,int life,int power):base(tf,speed,life,power ,img)
        {




        }
    }
}
