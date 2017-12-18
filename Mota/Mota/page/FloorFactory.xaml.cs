using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mota.CommonUtility;
using Mota.CommonUtility.ItemType;

namespace Mota.page
{
    /// <summary>
    /// 楼层工厂类，初始化楼层、保存楼层记录数组、控制人物移动
    /// </summary>
    public partial class FloorFactory : Page
    {
        private static FloorFactory instance;

        //当前人物所处楼层，对应的地图数组
        private CellImage[,] current_floor;

        //核心地图panel
        public static WrapPanel panel;

        private FloorFactory()
        {
            InitializeComponent();
            //读取记录，获取保存的楼层
            //getRecordFloor();
            panel = panelCenter;
            addMap();
        }

        /// <summary>
        /// 单例模式
        /// </summary>
        /// <returns></returns>
        public static FloorFactory getInstance()
        {
            if (instance == null)
            {
                instance = new FloorFactory();
            }
            return instance;
        }

        /// <summary>
        /// 给window调用查看楼层是否初始化
        /// </summary>
        /// <returns></returns>
        public static bool isInitialize()
        {
            return !(instance == null);
        }

        /// <summary>
        /// 构建地图
        /// </summary>
        private void addMap()
        {
            MapUtility.addBorder(panelUp, panelLeft, panelRight, panelDown);
            current_floor = coreMap();
        }

        /// <summary>
        /// 构建地图核心内容,并返回楼层数组
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        private CellImage[,] coreMap(int floor = 0)
        {
            return MapUtility.getFloor(floor);
        }

        int x = 0;
        int y = 0;

        /// <summary>
        /// 控制人物移动
        /// </summary>
        /// <param name="key"></param>       
        public void move(Key key)
        {
            switch (key)
            {
                case Key.Up:
                    locate(x, --y);
                    break;

                case Key.Down:
                    locate(x, ++y);
                    break;

                case Key.Left:
                    locate(--x, y);
                    break;

                case Key.Right:
                    locate(++x, y);
                    break;
            }
        }

        private void locate(int x, int y)
        {
            TransformGroup transformGroup = new TransformGroup();
            TranslateTransform translateTransform = new TranslateTransform();

            var X = 50 * x;
            var Y = 50 * y;
            translateTransform.X += X;
            translateTransform.Y += Y;

            transformGroup.Children.Add(translateTransform);

            current_floor[MapUtility.getPosition().x, MapUtility.getPosition().y].RenderTransform = transformGroup;
        }
    }
}