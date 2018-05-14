using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankGame.Properties;

namespace TankGame
{
    class PlayerZD:ZiDanFather 
    {
        //倒入玩家子弹图片
        private static Image img = Resources.tankmissile;
        //写构造函数
        public PlayerZD (TankFather tf,int speed,int life,int power):base(tf,speed,life,power ,img)
        {




        }






    }
}
