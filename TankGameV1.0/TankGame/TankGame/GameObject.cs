using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankGame
{
    //1.枚举类型
    enum Direction
    {
        Up,
        Down,
        Right,
        Left

    }
    
    
    
    abstract class GameObject
    {
        //2.父类的属性
        //父类的属性 XY坐标，宽度，高度，速度，生命值，方向。
        #region 游戏对象的属性
       

        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Width
        {

            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }
        public Direction Dir
        {
            get;
            set;
        }
        #endregion
        //3.父类的构造函数
        //构造函数
        //构造函数是初始化对象用的
        public GameObject (int x,int y,int width,int height,int speed,int life,Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;

        }
       
        //4.父类画图的抽象方法
        //绘图的抽象方法
        public abstract void Draw(Graphics g);
        
        
        //5.游戏对象移动的虚方法
        /// <summary>
        /// 我们在移动的时候，，是根据当前游戏对象的方向进行移动
        /// </summary>
        public virtual void Move()
        {
            switch (this.Dir )
            {
                case  Direction .Up :
                    this.Y -= this.Speed;
                    break;
                case   Direction.Down :
                    this.Y += this.Speed;
                    break;
                case Direction .Left :
                    this.X -= this.Speed;
                    break;
                case   Direction.Right :
                    this.X += this.Speed;
                    break;

            }
            //在游戏对象完成之后。我们应该判断一下，当前游戏对象是否超出当前的窗体
            if (this.X<=0)
            {
                this.X = 0;
            }
            if (this.Y<=0)
            {
                this.Y = 0;
            }
            if(this.Y >=600)
            {
                this.Y = 600;
            }
            if(this.X>=720)
            {
                this.X = 720;
            }

             
        }

        //6.获得当前对象矩形的方法
        //主要用于后面的碰撞检测
        /// <summary>
        /// 用于碰撞检测
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {

            return new Rectangle(this.X, this.Y, this.Width, this.Height);

        }

        //7.爆炸图片构造函数的父类传
        public GameObject(int x, int y):this(x,y,0,0,0,0,0)//this作用代表当前类的对象，第二个显示的调用自己类中的构造函数
        { 
        
        
        }
        //8.专门给zhuangbei的构造函数   
        //分析：由于zhuangbei类中需要调用父类的构造函数，但是调用其他的构造函数，，又未免大张旗鼓。
        //       所以好像是那个重载，方法的重载，子类的构造函数可以继承这个构造函数、、、
        public GameObject (int x,int y,int width,int height)
            :this(x,y,width ,height,0,0,0)   //this作用调用自己的构造函数
        {

        }
    }
}




