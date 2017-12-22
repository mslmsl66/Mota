using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Mota.CommonUtility.ItemType;
using Mota.page;

namespace Mota.CommonUtility
{
    /// <summary>
    /// 地图的初始化和设计
    /// </summary>
    public class MapUtility
    {
        /// <summary>
        /// 存放楼层的list
        /// </summary>
        private static List<CellImage[,]> floor_list;

        /// <summary>
        /// 表示当前楼层中某元素的坐标位置
        /// </summary>
        public struct Position
        {
            public int x;
            public int y;

        }

        //表示英雄坐标位置
        private static Position hero_positon;

        /// <summary>
        /// 给地图添加四边
        /// </summary>
        /// <param name="panelUp">边框上部分</param>
        /// <param name="panelLeft">边框左部分</param>
        /// <param name="panelRight">边框右部分</param>
        /// <param name="panelDown">边框下部分</param>
        public static void AddBorder(WrapPanel panelUp, WrapPanel panelLeft, WrapPanel panelRight, WrapPanel panelDown)
        {
            for (int i = 0; i < 11; i++)
            {
                panelUp.Children.Add(new CellImage(CellImage.Atype.地板, Floor.FloorType.银墙));
                panelDown.Children.Add(new CellImage(CellImage.Atype.地板, Floor.FloorType.银墙));
                panelLeft.Children.Add(new CellImage(CellImage.Atype.地板, Floor.FloorType.银墙));
                panelRight.Children.Add(new CellImage(CellImage.Atype.地板, Floor.FloorType.银墙));
            }
        }

        /// <summary>
        /// 获取楼层内容
        /// </summary>
        /// <param name="floor">表示第X层</param>
        /// <returns></returns>
        public static CellImage[,] GetFloor(int floor = 0)
        {
            if (floor_list == null)
            {
                ConstructList();
            }
            DrawFloor(floor_list[floor]);
            return floor_list[floor];
        }

        /// <summary>
        ///  绘制地图，剩余地图用“地板”填充，添加至panel
        /// </summary>
        /// <param name="coreImag">第X层的地图数组</param>
        private static void DrawFloor(CellImage[,] coreImag)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (coreImag[i, j] == null)
                    {
                        coreImag[i, j] = new CellImage(CellImage.Atype.地板, Floor.FloorType.地板);
                    }
                    FloorFactory.Panel.Children.Add(coreImag[i, j]);
                }
            }
        }

        /// <summary>
        /// 在list中初始化20楼层
        /// </summary>
        private static void ConstructList()
        {
            floor_list = new List<CellImage[,]>();
            //在list中添加20层楼
            for (int i = 0; i < 20; i++)
            {
                floor_list.Add(new CellImage[11, 11]);
            }
            DesignFloor();
        }

        /// <summary>
        /// 返回英雄在当前楼层的坐标位置
        /// </summary>
        /// <returns></returns>
        public static Position GetPosition()
        {
            return hero_positon;
        }

        /// <summary>
        /// 初始化所有楼层地图内容
        /// </summary>
        private static void DesignFloor()
        {
            #region 初始化英雄
            floor_list[0][10, 10] = new CellImage(CellImage.Atype.英雄, null);
            hero_positon.x = 10;
            hero_positon.y = 10;

            #endregion
            #region 第0层地图

            floor_list[0][0, 0] = new CellImage(CellImage.Atype.特殊物品, SpecialItem.SpecialItemType.怪物手册);
            floor_list[0][0, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][0, 5] = new CellImage(CellImage.Atype.地板, Floor.FloorType.楼梯上);
            floor_list[0][0, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][0, 10] = new CellImage(CellImage.Atype.特殊物品, SpecialItem.SpecialItemType.楼层飞跃器);

            floor_list[0][1, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][1, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            floor_list[0][2, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][2, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            floor_list[0][3, 0] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][3, 1] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][3, 2] = new CellImage(CellImage.Atype.门, Door.DoorType.黄门);
            floor_list[0][3, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][3, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][3, 8] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][3, 9] = new CellImage(CellImage.Atype.门, Door.DoorType.铁门);
            floor_list[0][3, 10] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            for (int i = 0; i < 11; i++)
            {
                if (i != 5)
                    floor_list[0][5, i] = new CellImage(CellImage.Atype.地板, Floor.FloorType.熔浆, true);
            }

            floor_list[0][10, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            floor_list[0][9, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][9, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            floor_list[0][8, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][8, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            floor_list[0][7, 0] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 1] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 2] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 3] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 7] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 8] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 9] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);
            floor_list[0][7, 10] = new CellImage(CellImage.Atype.地板, Floor.FloorType.白墙);

            #endregion

        }
    }
}