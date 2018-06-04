using Mota.CellImage;
using Mota.page;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

/// <summary>
/// Todo List
/// 1.显伤脚本 done
/// 2.存档读档 
/// 3.ESC界面 done
/// 4.NPC对话界面 done
/// 5.剧情
/// 6.图片 base64
/// 7.音效 音乐 特效
/// </summary>
namespace Mota.CommonUtility
{
    public class Hero
    {
        /// <summary>
        /// 血量
        /// </summary>
        private int hp = 300;

        /// <summary>
        /// 攻击力
        /// </summary>
        private int atk = 10;

        /// <summary>
        /// 防御力
        /// </summary>
        private int def = 10;

        /// <summary>
        /// 魔防
        /// </summary>
        private int res;

        /// <summary>
        /// 等级
        /// </summary>
        private int level = 1;

        /// <summary>
        /// 金币
        /// </summary>
        private int gold;

        /// <summary>
        /// 经验
        /// </summary>
        private int exp;

        /// <summary>
        /// 黄钥匙数量
        /// </summary>
        private int yellowKey;

        /// <summary>
        /// 蓝钥匙数量
        /// </summary>
        private int blueKey;

        /// <summary>
        /// 红钥匙数量
        /// </summary>
        private int redKey;

        /// <summary>
        /// 英雄位置标记
        /// </summary>
        private int x = 10;
        private int y = 10;

        private FloorFactory floorFactory;

        /// <summary>
        /// 英雄当前楼层地图
        /// </summary>
        private IBaseImage[,] current_floor;

        /// <summary>
        /// 玩家是否在进行对话
        /// </summary>
        public bool IsTalking { set; get; }

        /// <summary>
        /// 正在对话的NPC
        /// </summary>
        public NPCImage NPC { set; get; }

        private static Hero instance;

        public int Hp { get => hp; set => hp = value; }
        public int Atk { get => atk; set => atk = value; }
        public int Def { get => def; set => def = value; }
        public int Res { get => res; set => res = value; }
        public int Level { get => level; set => level = value; }
        public int Gold { get => gold; set => gold = value; }
        public int Exp { get => exp; set => exp = value; }
        public int YellowKey { get => yellowKey; set => yellowKey = value; }
        public int BlueKey { get => blueKey; set => blueKey = value; }
        public int RedKey { get => redKey; set => redKey = value; }

        private Hero()
        {
            floorFactory = FloorFactory.GetInstance();
            current_floor = floorFactory.GetCurrentFloor();
        }
        public static Hero GetInstance()
        {
            if (instance == null)
            {
                instance = new Hero();
            }
            return instance;
        }

        /// <summary>
        /// 判别碰到的类型
        /// </summary>
        /// <param name="a"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsTouch(Atype a, Enum e)
        {
            switch (a)
            {
                case Atype.地板:
                    switch (e)
                    {
                        case FloorType.地板:
                            return true;
                        case FloorType.楼梯上:
                            current_floor = floorFactory.CoreMap(floorFactory.GetFloorNum() + 1);
                            return true;
                        case FloorType.楼梯下:
                            current_floor = floorFactory.CoreMap(floorFactory.GetFloorNum() - 1);
                            return true;
                    }
                    return false;
                case Atype.门:
                    if (((DoorImage)current_floor[x, y]).isImageExist)
                    {
                        switch (e)
                        {
                            case DoorType.黄门:
                                if (YellowKey > 0)
                                {
                                    ((DoorImage)current_floor[x, y]).HideImage();
                                    YellowKey--;
                                }
                                break;
                            case DoorType.蓝门:
                                if (BlueKey > 0)
                                {
                                    ((DoorImage)current_floor[x, y]).HideImage();
                                    BlueKey--;
                                }
                                break;
                            case DoorType.红门:
                                if (RedKey > 0)
                                {
                                    ((DoorImage)current_floor[x, y]).HideImage();
                                    RedKey--;
                                }
                                break;
                            case DoorType.铁门:
                                ((DoorImage)current_floor[x, y]).HideImage();
                                break;
                        }
                        ((DoorImage)current_floor[x, y]).isImageExist = false;
                    }
                    return false;
                case Atype.宝石:
                    switch (e)
                    {
                        case GemstoneType.红宝石:
                            Atk += 3;
                            break;
                        case GemstoneType.蓝宝石:
                            Def += 3;
                            break;
                        case GemstoneType.绿宝石:
                            Res += 3;
                            break;
                        case GemstoneType.红血瓶:
                            Hp += 100;
                            break;
                        case GemstoneType.蓝血瓶:
                            Hp += 300;
                            break;
                        case GemstoneType.黄血瓶:
                            Hp += 500;
                            break;
                        case GemstoneType.绿血瓶:
                            Hp += 1000;
                            break;
                        case GemstoneType.铁剑:
                            Atk += 10;
                            break;
                        case GemstoneType.铁盾:
                            Def += 10;
                            break;
                        case GemstoneType.银剑:
                            Atk += 30;
                            break;
                        case GemstoneType.银盾:
                            Def += 30;
                            break;
                        case GemstoneType.骑士剑:
                            Atk += 70;
                            break;
                        case GemstoneType.骑士盾:
                            Def += 70;
                            break;
                        case GemstoneType.圣剑:
                            Atk += 100;
                            break;
                        case GemstoneType.圣盾:
                            Def += 100;
                            break;
                    }
                    current_floor[x, y].HideImage();
                    //更新显伤脚本
                    MapUtility.UpdateDamage();
                    return true;
                case Atype.特殊物品:
                    return true;
                case Atype.钥匙:
                    switch ((KeyType)e)
                    {
                        case KeyType.黄钥匙:
                            YellowKey++;
                            current_floor[x, y].HideImage();
                            break;
                        case KeyType.蓝钥匙:
                            BlueKey++;
                            current_floor[x, y].HideImage();
                            break;
                        case KeyType.红钥匙:
                            RedKey++;
                            current_floor[x, y].HideImage();
                            break;
                    }
                    return true;
                case Atype.怪物:
                    MonsterImage monster = new MonsterImage((MonsterType)e);
                    if (CalculationUtility.Battle(monster))
                    {
                        //删除怪物图片和显伤脚本
                        current_floor[x, y].HideImage();
                        ((MonsterImage)current_floor[x, y]).HideDamage();
                        //从列表中删除怪物和位置
                        MapUtility.MonsterList.Remove(current_floor[x, y]);
                        foreach (KeyValuePair<int, int> pair in MapUtility.MonsterPosition)
                        {
                            if (pair.Key == x && pair.Value == y)
                            {
                                MapUtility.MonsterPosition.Remove(pair);
                                break;
                            }
                        }
                    }
                    return false;
                case Atype.NPC:
                    IsTalking = true;
                    NPC = (NPCImage)current_floor[x, y];
                    ((NPCImage)current_floor[x, y]).ShowDialog();
                    break;
            }
            return false;
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        public void MoveUp()
        {
            if (x - 1 < 0)
            {
                return;
            }
            x--;
            if (IsTouch(current_floor[x, y].GetCoarseType(), current_floor[x, y].GetFineType()) == false)
            {
                x++;
                return;
            }
            else
            {
                CalculationUtility.RefreshStatus();
                Canvas.SetTop(floorFactory.GetHeroImage(), Canvas.GetTop(floorFactory.GetHeroImage()) - 50);
                floorFactory.GetHeroImage().Source = new BitmapImage(new Uri("/res/icons/characters/hero12.png", UriKind.Relative));
            }
        }

        public void MoveDown()
        {
            if (x + 1 > 10)
            {
                return;
            }
            x++;
            if (IsTouch(current_floor[x, y].GetCoarseType(), current_floor[x, y].GetFineType()) == false)
            {
                x--;
                return;
            }
            else
            {
                CalculationUtility.RefreshStatus();
                Canvas.SetTop(floorFactory.GetHeroImage(), Canvas.GetTop(floorFactory.GetHeroImage()) + 50);
                floorFactory.GetHeroImage().Source = new BitmapImage(new Uri("/res/icons/characters/hero0.png", UriKind.Relative));
            }
        }

        public void MoveLeft()
        {
            if (y - 1 < 0)
            {
                return;
            }
            y--;
            if (IsTouch(current_floor[x, y].GetCoarseType(), current_floor[x, y].GetFineType()) == false)
            {
                y++;
                return;
            }
            else
            {
                CalculationUtility.RefreshStatus();
                Canvas.SetLeft(floorFactory.GetHeroImage(), Canvas.GetLeft(floorFactory.GetHeroImage()) - 50);
                floorFactory.GetHeroImage().Source = new BitmapImage(new Uri("/res/icons/characters/hero5.png", UriKind.Relative));
            }
        }

        public void MoveRight()
        {
            if (y + 1 > 10)
            {
                return;
            }
            y++;
            if (IsTouch(current_floor[x, y].GetCoarseType(), current_floor[x, y].GetFineType()) == false)
            {
                y--;
                return;
            }
            else
            {
                CalculationUtility.RefreshStatus();
                Canvas.SetLeft(floorFactory.GetHeroImage(), Canvas.GetLeft(floorFactory.GetHeroImage()) + 50);
                floorFactory.GetHeroImage().Source = new BitmapImage(new Uri("/res/icons/characters/hero11.png", UriKind.Relative));
            }
        }
    }
}