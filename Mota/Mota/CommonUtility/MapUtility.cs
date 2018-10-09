using System;
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
        /// 把某一个Image删除并修改为其他Image，例如怪物死亡后改为地板
        /// </summary>
        /// <param name="floorNum"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="image"></param>
        public static void ChangeToImage(int floorNum,int x,int y,IBaseImage image)
        {
            floor_list[floorNum][x, y] = image;
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
            InitializeFloor();
        }

        /// <summary>
        /// 返回当前地图每个单元的类型
        /// </summary>
        /// <returns></returns>
        public static List<List<KeyValuePair<Atype, Enum>>> GetAllFloorType()
        {
            List<List<KeyValuePair<Atype, Enum>>> list = new List<List<KeyValuePair<Atype, Enum>>>();
            foreach (IBaseImage[,] image in floor_list)
            {
                List<KeyValuePair<Atype, Enum>> list1 = new List<KeyValuePair<Atype, Enum>>();
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        list1.Add(new KeyValuePair<Atype, Enum>(image[i, j].GetCoarseType(), image[i, j].GetFineType()));
                    }
                }
                list.Add(list1);
            }
            return list;
        }

        /// <summary>
        /// 根据参数重新初始化地图
        /// </summary>
        /// <param name="map"></param>
        /// public enum Atype { 宝石, 钥匙, 怪物, 特殊物品, 地板, 英雄, 门, NPC };
        public static void UpdateFloor(List<List<KeyValuePair<int, int>>> map)
        {
            int k = 0;
            foreach (var list in map)
            {
                for (int i = 0; i < 11; i++)
                {
                    for (int j = 0; j < 11; j++)
                    {
                        var kv = list[i * 11 + j];
                        switch (kv.Key) {
                            case 0:
                                floor_list[k][i, j] = new GemstoneImage((GemstoneType)kv.Value);
                                break;
                            case 1:
                                floor_list[k][i, j] = new KeyImage((KeyType)kv.Value);
                                break;
                            case 2:
                                floor_list[k][i, j] = new MonsterImage((MonsterType)kv.Value);
                                break;
                            case 3:
                                floor_list[k][i, j] = new SpecialItemImage((SpecialItemType)kv.Value);
                                break;
                            case 4:
                                floor_list[k][i, j] = new FloorImage((FloorType)kv.Value);
                                break;
                            case 6:
                                floor_list[k][i, j] = new DoorImage((DoorType)kv.Value);
                                break;
                        }
                    }
                }
                k++;
            }
            CalculationUtility.RefreshStatus();
        }

        /// <summary>
        /// 初始化所有楼层地图内容
        /// </summary>5p
        private static void InitializeFloor()
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

            #region 第2层地图
            floor_list[2][0, 0] = new NPCImage(NPCType.老人, DialogUtility.dialog_1_0_0);
            floor_list[2][0, 3] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[2][0, 5] = new FloorImage(FloorType.楼梯下);
            floor_list[2][0, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][0, 8] = new DoorImage(DoorType.黄门);
            floor_list[2][0, 9] = new MonsterImage(MonsterType.绿史莱姆);
                       
            floor_list[2][1, 0] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 1] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 3] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 4] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 5] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 8] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 9] = new FloorImage(FloorType.白墙);
            floor_list[2][1, 10] = new GemstoneImage(GemstoneType.红宝石);
                       
            floor_list[2][2, 1] = new FloorImage(FloorType.白墙);
            floor_list[2][2, 3] = new MonsterImage(MonsterType.小蝙蝠);
            floor_list[2][2, 4] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[2][2, 8] = new FloorImage(FloorType.白墙);
            floor_list[2][2, 9] = new FloorImage(FloorType.白墙);
                       
            floor_list[2][3, 1] = new FloorImage(FloorType.白墙);
            floor_list[2][3, 3] = new FloorImage(FloorType.白墙);
            floor_list[2][3, 4] = new FloorImage(FloorType.白墙);
            floor_list[2][3, 5] = new FloorImage(FloorType.白墙);
            floor_list[2][3, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][3, 8] = new FloorImage(FloorType.白墙);
            floor_list[2][3, 9] = new FloorImage(FloorType.白墙);

            floor_list[2][4, 0] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[2][4, 1] = new DoorImage(DoorType.黄门);
            floor_list[2][4, 3] = new FloorImage(FloorType.白墙);
            floor_list[2][4, 4] = new FloorImage(FloorType.白墙);
            floor_list[2][4, 5] = new FloorImage(FloorType.白墙);
            floor_list[2][4, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][4, 7] = new MonsterImage(MonsterType.骷髅);
            floor_list[2][4, 10] = new FloorImage(FloorType.楼梯下);
                       
            floor_list[2][5, 0] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[2][5, 1] = new FloorImage(FloorType.白墙);
            floor_list[2][5, 3] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[2][5, 5] = new KeyImage(KeyType.黄钥匙);
            floor_list[2][5, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][5, 8] = new DoorImage(DoorType.黄门);
                       
            floor_list[2][6, 0] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[2][6, 1] = new FloorImage(FloorType.白墙);
            floor_list[2][6, 3] = new FloorImage(FloorType.白墙);
            floor_list[2][6, 5] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[2][6, 6] = new DoorImage(DoorType.黄门);
            floor_list[2][6, 8] = new FloorImage(FloorType.白墙);
                       
            floor_list[2][7, 0] = new GemstoneImage(GemstoneType.蓝宝石);
            floor_list[2][7, 1] = new FloorImage(FloorType.白墙);
            floor_list[2][7, 2] = new FloorImage(FloorType.白墙);
            floor_list[2][7, 3] = new FloorImage(FloorType.白墙);
            floor_list[2][7, 4] = new FloorImage(FloorType.白墙);
            floor_list[2][7, 5] = new FloorImage(FloorType.白墙);
            floor_list[2][7, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][7, 8] = new FloorImage(FloorType.白墙);
                       
            floor_list[2][8, 2] = new FloorImage(FloorType.白墙);
            floor_list[2][8, 3] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[2][8, 4] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[2][8, 5] = new GemstoneImage(GemstoneType.红宝石);
            floor_list[2][8, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][8, 8] = new FloorImage(FloorType.白墙);
                       
            floor_list[2][9, 2] = new DoorImage(DoorType.蓝门);
            floor_list[2][9, 3] = new MonsterImage(MonsterType.小蝙蝠);
            floor_list[2][9, 4] = new MonsterImage(MonsterType.兽人);
            floor_list[2][9, 5] = new GemstoneImage(GemstoneType.红血瓶);
            floor_list[2][9, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][9, 8] = new FloorImage(FloorType.白墙);
            floor_list[2][9, 9] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[2][9, 10] = new MonsterImage(MonsterType.红史莱姆);
                       
            floor_list[2][10, 1] = new KeyImage(KeyType.黄钥匙);
            floor_list[2][10, 2] = new FloorImage(FloorType.白墙);
            floor_list[2][10, 3] = new MonsterImage(MonsterType.绿史莱姆);
            floor_list[2][10, 4] = new MonsterImage(MonsterType.红史莱姆);
            floor_list[2][10, 5] = new GemstoneImage(GemstoneType.蓝宝石);
            floor_list[2][10, 6] = new FloorImage(FloorType.白墙);
            floor_list[2][10, 8] = new FloorImage(FloorType.白墙);
            floor_list[2][10, 9] = new GemstoneImage(GemstoneType.蓝血瓶);
            floor_list[2][10, 10] = new NPCImage(NPCType.老人, DialogUtility.dialog_1_10_10);
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