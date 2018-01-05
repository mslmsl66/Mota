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
    /// 楼层工厂类，初始化楼层、保存楼层记录数组
    /// </summary>
    public partial class FloorFactory : Page
    {
        private static FloorFactory instance;

        /// <summary>
        /// 当前人物所处楼层，对应的地图数组
        /// </summary>
        private CellImage[,] current_floor;

        /// <summary>
        /// 核心地图panel
        /// </summary>
        public static WrapPanel Panel;

        /// <summary>
        /// 当前楼层
        /// </summary>
        private int floorNum;

        private FloorFactory()
        {
            InitializeComponent();
            //读取记录，获取保存的楼层
            //getRecordFloor();
            Panel = panelCenter;
            AddMap();
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
        /// 查看楼层是否初始化
        /// </summary>
        /// <returns></returns>
        public bool IsInitialize()
        {
            return !(instance == null);
        }

        /// <summary>
        /// 构建地图
        /// </summary>
        private void AddMap()
        {
            MapUtility.AddBorder(panelUp, panelLeft, panelRight, panelDown);
            current_floor = CoreMap();
        }

        /// <summary>
        /// 构建地图核心内容,并返回楼层数组
        /// </summary>
        /// <param name="floor"></param>
        /// <returns></returns>
        public CellImage[,] CoreMap(int floor = 0)
        {
            floorNum = floor;
            return MapUtility.GetFloor(floor);
        }

        /// <summary>
        /// 返回英雄所在的楼层
        /// </summary>
        /// <returns></returns>
        public CellImage[,] GetCurrentFloor()
        {
            return current_floor;
        }
        
        /// <summary>
        /// 返回当前楼层的层数
        /// </summary>
        /// <returns></returns>
        public int GetFloorNum()
        {
            return floorNum;
        }
    }
}