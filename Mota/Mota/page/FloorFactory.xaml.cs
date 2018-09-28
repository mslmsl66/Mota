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
            heroImage = CreateHeroImage();
            DrawHeroImage(10, 10);
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static FloorFactory GetInstance()
        {
            if(instance == null)
            {
                instance = new FloorFactory();
            }
            return instance;
        }

        /// <summary>
        /// 创建英雄图片,放置顶层
        /// </summary>
        /// <returns></returns>
        internal Image CreateHeroImage()
        {
            Image hero = new Image
            {
                Source = new BitmapImage(new Uri("/res/icons/characters/hero0.png", UriKind.Relative)),
                Height = 50,
                Width = 50
            };
            Panel.SetZIndex(hero, 9);
            canvas.Children.Add(hero);
            return hero;
        }

        internal void DrawHeroImage(int left, int top)
        {
            Canvas.SetLeft(heroImage, left * 50);
            Canvas.SetTop(heroImage, top * 50);
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
        /// 设置当前楼层的层数
        /// </summary>
        /// <param name="floor"></param>
        internal void SetFloorNum(int floor)
        {
            floorNum = floor;
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