using Mota.CellImage;
using Mota.CommonUtility;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Mota.page
{
    /// <summary>
    /// 楼层工厂类,初始化楼层、保存楼层记录数组
    /// </summary>
    public partial class FloorFactory : Page
    {
        private static FloorFactory instance;

        /// <summary>
        /// 英雄图片
        /// </summary>
        private Image heroImage;

        /// <summary>
        /// 当前人物所处楼层,对应的地图数组
        /// </summary>
        private IBaseImage[,] current_floor;

        /// <summary>
        /// 核心地图panel
        /// </summary>
        public static Canvas canvas;

        /// <summary>
        /// 当前楼层
        /// </summary>
        private int floorNum;

        private FloorFactory()
        {
            InitializeComponent();
            //读取记录,获取保存的楼层
            //getRecordFloor();
            canvas = CenterCanvas;
            AddMap();
            heroImage = CreateHeroImage(500, 500);
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static FloorFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new FloorFactory();
            }
            return instance;
        }

        /// <summary>
        /// 创建英雄图片,放置顶层
        /// </summary>
        /// <returns></returns>
        internal Image CreateHeroImage(int left, int top)
        {
            Image hero = new Image();
            hero.Source = new BitmapImage(new Uri("/res/icons/characters/hero0.png", UriKind.Relative));
            hero.Height = 50;
            hero.Width = 50;
            Canvas.SetLeft(hero, left);
            Canvas.SetTop(hero, top);
            Panel.SetZIndex(hero, 9);
            canvas.Children.Add(hero);
            return hero;
        }

        /// <summary>
        /// 查看楼层是否初始化
        /// </summary>
        /// <returns></returns>
        internal bool IsInitialize()
        {
            return !(instance == null);
        }

        /// <summary>
        /// 构建地图
        /// </summary>
        internal void AddMap()
        {
            MapUtility.AddBorder(panelUp, panelLeft, panelRight, panelDown);
            current_floor = CoreMap();
        }

        /// <summary>
        /// 构建地图核心内容,并返回楼层数组
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        internal IBaseImage[,] CoreMap(int floor = 0)
        {
            floorNum = floor;
            //删除canvas容器里的元素
            canvas.Children.Clear();
            if (heroImage != null)
            {
                canvas.Children.Add(heroImage);
            }
            return MapUtility.GetFloor(floor);
        }

        /// <summary>
        /// 返回英雄所在的楼层
        /// </summary>
        /// <returns></returns>
        internal IBaseImage[,] GetCurrentFloor()
        {
            return current_floor;
        }

        /// <summary>
        /// 返回当前楼层的层数
        /// </summary>
        /// <returns></returns>
        internal int GetFloorNum()
        {
            return floorNum;
        }

        /// <summary>
        /// 返回英雄图片
        /// </summary>
        /// <returns></returns>
        internal Image GetHeroImage()
        {
            return heroImage;
        }

        /// <summary>
        /// 复原地图
        /// </summary>
        internal void ReStart()
        {
            CoreMap();
        }
    }
}