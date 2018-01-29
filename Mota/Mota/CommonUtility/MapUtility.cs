using Mota.CommonUtility.ItemType;
using Mota.page;
using System.Collections.Generic;
using System.Windows.Controls;

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
                panelUp.Children.Add(new CellImage(Atype.地板, FloorType.银墙));
                panelDown.Children.Add(new CellImage(Atype.地板, FloorType.银墙));
                panelLeft.Children.Add(new CellImage(Atype.地板, FloorType.银墙));
                panelRight.Children.Add(new CellImage(Atype.地板, FloorType.银墙));
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
                    Canvas.SetLeft(coreImag[i, j], 50 * j);
                    Canvas.SetTop(coreImag[i, j], 50 * i);
                    Panel.SetZIndex(coreImag[i, j], 1);
                    FloorFactory.canvas.Children.Add(coreImag[i, j]);
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
        /// 初始化所有楼层地图内容
        /// </summary>
        private static void DesignFloor()
        {
            #region 第0层地图

            floor_list[0][0, 0] = new CellImage(Atype.特殊物品, SpecialItemType.怪物手册);
            floor_list[0][0, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][0, 5] = new CellImage(Atype.地板, FloorType.楼梯上);
            floor_list[0][0, 7] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][0, 10] = new CellImage(Atype.特殊物品, SpecialItemType.楼层飞跃器);

            floor_list[0][1, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][1, 7] = new CellImage(Atype.地板, FloorType.白墙);

            floor_list[0][2, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][2, 7] = new CellImage(Atype.地板, FloorType.白墙);

            floor_list[0][3, 0] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][3, 1] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][3, 2] = new CellImage(Atype.门, DoorType.黄门);
            floor_list[0][3, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][3, 7] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][3, 8] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][3, 9] = new CellImage(Atype.门, DoorType.铁门);
            floor_list[0][3, 10] = new CellImage(Atype.地板, FloorType.白墙);

            for (int i = 0; i < 11; i++)
            {
                if (i != 5)
                    floor_list[0][5, i] = new CellImage(Atype.地板, FloorType.熔浆, true);
            }
            floor_list[0][5, 5] = new CellImage(Atype.宝石, GemstoneType.红宝石);
            floor_list[0][10, 3] = new CellImage(Atype.地板, FloorType.白墙);

            floor_list[0][9, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][9, 7] = new CellImage(Atype.地板, FloorType.白墙);

            floor_list[0][8, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][8, 7] = new CellImage(Atype.地板, FloorType.白墙);

            floor_list[0][7, 0] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 1] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 2] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 3] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 7] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 8] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 9] = new CellImage(Atype.地板, FloorType.白墙);
            floor_list[0][7, 10] = new CellImage(Atype.地板, FloorType.白墙);

            #endregion

            #region 第1层地图

            floor_list[1][0, 3] = new CellImage(Atype.怪物, MonsterType.绿史莱姆);
            floor_list[1][0, 5] = new CellImage(Atype.地板, FloorType.楼梯下);

            #endregion

            //默认添加地板
            foreach (CellImage[,] image in floor_list)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (image[i, j] == null)
                        {
                            image[i, j] = new CellImage(Atype.地板, FloorType.地板);
                        }
                    }
                }
            }
        }
    }
}