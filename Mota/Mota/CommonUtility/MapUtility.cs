using Mota.CellImage;
using Mota.page;
using System.Collections.Generic;
using System.Windows;
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
        private static List<IBaseImage[,]> floor_list;

        /// <summary>
        /// 存放当前楼层中所有怪物
        /// </summary>
        public static List<IBaseImage> MonsterList = new List<IBaseImage>();

        /// <summary>
        /// 存放怪物坐标
        /// </summary>
        public static List<KeyValuePair<int, int>> MonsterPosition = new List<KeyValuePair<int, int>>();

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
                panelUp.Children.Add(new FloorImage(FloorType.银墙));
                panelDown.Children.Add(new FloorImage(FloorType.银墙));
                panelLeft.Children.Add(new FloorImage(FloorType.银墙));
                panelRight.Children.Add(new FloorImage(FloorType.银墙));
            }
        }

        /// <summary>
        /// 获取楼层内容
        /// </summary>
        /// <param name="floor">表示第X层</param>
        /// <returns></returns>
        public static IBaseImage[,] GetFloor(int floor = 0)
        {
            if (floor_list == null)
            {
                ConstructList();
            }
            DrawFloor(floor_list[floor]);
            return floor_list[floor];
        }

        /// <summary>
        ///  绘制地图,剩余地图用“地板”填充,添加至panel
        /// </summary>
        /// <param name="coreImag">第X层的地图数组</param>
        private static void DrawFloor(IBaseImage[,] coreImag)
        {
            MonsterList.Clear();
            MonsterPosition.Clear();
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (coreImag[i, j].GetCoarseType() == Atype.怪物)
                    {
                        ((MonsterImage)coreImag[i, j]).ShowDamage(50 * j + 30, 50 * i + 30);
                        MonsterList.Add(coreImag[i, j]);
                        MonsterPosition.Add(new KeyValuePair<int, int>(i, j));
                    }
                    Canvas.SetLeft((UIElement)coreImag[i, j], 50 * j);
                    Canvas.SetTop((UIElement)coreImag[i, j], 50 * i);
                    Panel.SetZIndex((UIElement)coreImag[i, j], 1);
                    FloorFactory.canvas.Children.Add((UIElement)coreImag[i, j]);
                }
            }
        }

        /// <summary>
        /// 能力值更改时，更新显伤脚本
        /// </summary>
        public static void UpdateDamage()
        {
            if (MonsterList.Count > 0)
            {
                for (int i = 0; i < MonsterList.Count; i++)
                {
                    if (MonsterList[i].GetCoarseType() != Atype.地板)
                    {
                        ((MonsterImage)MonsterList[i]).ShowDamage(50 * MonsterPosition[i].Value + 30, 50 * MonsterPosition[i].Key + 30);
                    }
                }
            }
        }

        /// <summary>
        /// 在list中初始化20楼层
        /// </summary>
        private static void ConstructList()
        {
            floor_list = new List<IBaseImage[,]>();
            //在list中添加20层楼
            for (int i = 0; i < 20; i++)
            {
                floor_list.Add(new IBaseImage[11, 11]);
            }
            DesignFloor();
        }

        /// <summary>
        /// 初始化所有楼层地图内容
        /// </summary>
        private static void DesignFloor()
        {
            #region 第0层地图

            floor_list[0][0, 0] = new SpecialItemImage(SpecialItemType.怪物手册);
            floor_list[0][0, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][0, 5] = new FloorImage(FloorType.楼梯上);
            floor_list[0][0, 7] = new FloorImage(FloorType.白墙);
            floor_list[0][0, 10] = new SpecialItemImage(SpecialItemType.楼层飞跃器);

            floor_list[0][1, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][1, 7] = new FloorImage(FloorType.白墙);

            floor_list[0][2, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][2, 7] = new FloorImage(FloorType.白墙);

            floor_list[0][3, 0] = new FloorImage(FloorType.白墙);
            floor_list[0][3, 1] = new FloorImage(FloorType.白墙);
            floor_list[0][3, 2] = new DoorImage(DoorType.黄门);
            floor_list[0][3, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][3, 7] = new FloorImage(FloorType.白墙);
            floor_list[0][3, 8] = new FloorImage(FloorType.白墙);
            floor_list[0][3, 9] = new DoorImage(DoorType.铁门);
            floor_list[0][3, 10] = new FloorImage(FloorType.白墙);

            for (int i = 0; i < 11; i++)
            {
                if (i != 5)
                    floor_list[0][5, i] = new FloorImage(FloorType.熔浆);
            }
            floor_list[0][5, 5] = new KeyImage(KeyType.黄钥匙);
            floor_list[0][10, 3] = new FloorImage(FloorType.白墙);

            floor_list[0][9, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][9, 7] = new FloorImage(FloorType.白墙);

            floor_list[0][8, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][8, 7] = new FloorImage(FloorType.白墙);

            floor_list[0][7, 0] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 1] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 2] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 3] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 7] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 8] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 9] = new FloorImage(FloorType.白墙);
            floor_list[0][7, 10] = new FloorImage(FloorType.白墙);

            #endregion

            #region 第1层地图

            floor_list[1][0, 0] = new NPCImage(NPCType.老人, DialogUtility.dialog_1_0_0);
            floor_list[1][0, 3] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[1][0, 5] = new FloorImage(FloorType.楼梯下);
            floor_list[1][0, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][0, 8] = new DoorImage(DoorType.黄门);
            floor_list[1][0, 9] = new MonsterImage(MonsterType.绿史莱姆);

            floor_list[1][1, 0] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 1] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 3] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 4] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 5] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 8] = new FloorImage(FloorType.白墙);
            floor_list[1][1, 10] = new GemstoneImage(GemstoneType.红宝石);

            floor_list[1][2, 1] = new FloorImage(FloorType.白墙);
            floor_list[1][2, 3] = new MonsterImage(MonsterType.小蝙蝠);
            floor_list[1][2, 4] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[1][2, 8] = new FloorImage(FloorType.白墙);
            floor_list[1][2, 9] = new FloorImage(FloorType.白墙);
            floor_list[1][2, 10] = new FloorImage(FloorType.白墙);

            floor_list[1][3, 1] = new FloorImage(FloorType.白墙);
            floor_list[1][3, 3] = new FloorImage(FloorType.白墙);
            floor_list[1][3, 4] = new FloorImage(FloorType.白墙);
            floor_list[1][3, 5] = new FloorImage(FloorType.白墙);
            floor_list[1][3, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][3, 8] = new FloorImage(FloorType.白墙);

            floor_list[1][4, 0] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[1][4, 1] = new DoorImage(DoorType.黄门);
            floor_list[1][4, 3] = new FloorImage(FloorType.白墙);
            floor_list[1][4, 4] = new FloorImage(FloorType.白墙);
            floor_list[1][4, 5] = new FloorImage(FloorType.白墙);
            floor_list[1][4, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][4, 8] = new FloorImage(FloorType.白墙);
            floor_list[1][4, 10] = new FloorImage(FloorType.楼梯上);

            floor_list[1][5, 0] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[1][5, 1] = new FloorImage(FloorType.白墙);
            floor_list[1][5, 3] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[1][5, 5] = new KeyImage(KeyType.黄钥匙);
            floor_list[1][5, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][5, 8] = new DoorImage(DoorType.黄门);

            floor_list[1][6, 0] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[1][6, 1] = new FloorImage(FloorType.白墙);
            floor_list[1][6, 3] = new FloorImage(FloorType.白墙);
            floor_list[1][6, 5] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[1][6, 6] = new DoorImage(DoorType.黄门);
            floor_list[1][6, 8] = new FloorImage(FloorType.白墙);

            floor_list[1][7, 0] = new GemstoneImage(GemstoneType.蓝宝石);
            floor_list[1][7, 1] = new FloorImage(FloorType.白墙);
            floor_list[1][7, 2] = new FloorImage(FloorType.白墙);
            floor_list[1][7, 3] = new FloorImage(FloorType.白墙);
            floor_list[1][7, 4] = new FloorImage(FloorType.白墙);
            floor_list[1][7, 5] = new FloorImage(FloorType.白墙);
            floor_list[1][7, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][7, 8] = new FloorImage(FloorType.白墙);

            floor_list[1][8, 2] = new FloorImage(FloorType.白墙);
            floor_list[1][8, 3] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[1][8, 4] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[1][8, 5] = new GemstoneImage(GemstoneType.红宝石);
            floor_list[1][8, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][8, 8] = new FloorImage(FloorType.白墙);

            floor_list[1][9, 2] = new DoorImage(DoorType.蓝门);
            floor_list[1][9, 3] = new MonsterImage(MonsterType.小蝙蝠);
            floor_list[1][9, 4] = new MonsterImage(MonsterType.兽人);
            floor_list[1][9, 5] = new GemstoneImage(GemstoneType.红血瓶);
            floor_list[1][9, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][9, 8] = new FloorImage(FloorType.白墙);
            floor_list[1][9, 9] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[1][9, 10] = new MonsterImage(MonsterType.红史莱姆);

            floor_list[1][10, 1] = new KeyImage(KeyType.黄钥匙);
            floor_list[1][10, 2] = new FloorImage(FloorType.白墙);
            floor_list[1][10, 3] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[1][10, 4] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[1][10, 5] = new GemstoneImage(GemstoneType.蓝宝石);
            floor_list[1][10, 6] = new FloorImage(FloorType.白墙);
            floor_list[1][10, 8] = new FloorImage(FloorType.白墙);
            floor_list[1][10, 9] = new GemstoneImage(GemstoneType.蓝血瓶);
            floor_list[1][10, 10] = new NPCImage(NPCType.老人, DialogUtility.dialog_1_10_10);
            #endregion

            //默认添加地板
            foreach (IBaseImage[,] image in floor_list)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        if (image[i, j] == null)
                        {
                            image[i, j] = new FloorImage(FloorType.地板);
                        }
                    }
                }
            }
        }
    }
}