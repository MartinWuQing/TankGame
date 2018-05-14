using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankGame.Properties;

namespace TankGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //对我们的游戏进行初始化。先得写一个初始化方法
            InitialGame();
            InitialMap();
        }
        /// <summary>
        /// 1.初始化游戏。包括初始化玩家坦克对象
        /// </summary>
        private void InitialGame ()
        {
            SingleObject.GetSingle().AddGameObject(new PlayerTank(200, 200, 10, 10, Direction.Up));
            SetEnemyTank();
            
        }

        //不绕了，直接在写一个方法初始化地图
        /// <summary>
        /// 初始化游戏地图
        /// </summary>
        public  void InitialMap()
        {
            for (int i = 0; i < 10; i++)
            {
                SingleObject.GetSingle().AddGameObject(new Wall(i * 15 + 30, 100));
                SingleObject.GetSingle().AddGameObject(new Wall(95, 100 + 15 * i));

                SingleObject.GetSingle().AddGameObject(new Wall(245 - i * 7, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(245 + i * 7, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(215 + i * 15 / 2, 185));

                SingleObject.GetSingle().AddGameObject(new Wall(390 - i * 5, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(390 + i * 5, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(480 - i * 5, 100 + 15 * i));

                SingleObject.GetSingle().AddGameObject(new Wall(515, 100 + 15 * i));
                SingleObject.GetSingle().AddGameObject(new Wall(595 - i * 8, 100 + 15 * i / 2));
                SingleObject.GetSingle().AddGameObject(new Wall(530 + i * 8, 165 + 15 * i / 2));
            }
	



        }










        Random r = new Random();    

        /// <summary>
        /// 6.初始化敌人坦克对象
        /// </summary>
        public void SetEnemyTank()
        {
            for (int i = 0; i < 8; i++)
            {
                SingleObject.GetSingle().AddGameObject(new EnemyTank(r.Next(0,
                    this.Width), r.Next(0, this.Height), r.Next(0, 3), Direction.Down));
            }
        }



      
        /// <summary>
        /// 2.窗体的paint事件，确保重绘的时候不会擦掉
        /// </summary>
        /// <param name="sender">出发当前事件的对象</param>
        /// <param name="e">执行这个方法所需要的资源</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }
        /// <summary>
        /// 3..对窗体实时进行更新50ms
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
            //调用碰撞检测方法
            SingleObject.GetSingle().PZJC();

        }
        /// <summary>
        /// 4.当键按下的时候会触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           //调用方法
            SingleObject.GetSingle().PT.KeyDown(e);
        }
        /// <summary>
        /// 5.窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //1.减少闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            //(2.在程序加载的时候哦播放音乐
             SoundPlayer sp = new SoundPlayer(Resources.start );
            sp.Play();

            
        }

        public object Resourse { get; set; }
    }
}
