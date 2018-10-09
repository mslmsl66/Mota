using Mota.CellImage;
using Mota.CommonUtility;
using Mota.page;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

/// <summary>
/// Todo List
/// 1.显伤脚本 done
/// 2.存档读档 done
/// 3.ESC界面 done
/// 4.NPC对话界面 done
/// 5.剧情
/// 6.图片 base64
/// 7.音效 音乐 特效 done
/// 8.商店
/// </summary>
namespace Mota.HeroCore
{
    public class Hero
    {
        public HeroProperties properties = new HeroProperties();

        private FloorFactory floorFactory;

        /// <summary>
        /// 英雄当前楼层地图
        /// </summary>
        internal IBaseImage[,] current_floor;

        /// <summary>
        /// 玩家是否在进行对话
        /// </summary>
        public bool IsTalking { set; get; }

        /// <summary>
        /// 正在对话的NPC
        /// </summary>
        public NPCImage NPC { set; get; }

        /// <summary>
        /// 英雄的攻击方式
        /// </summary>
        private string weapon = CommonVariable.WEAPON_FIST;

        private static Hero instance;

        private Hero(int hp = 1000, int atk = 10, int def = 10, int res = 0, int level = 1,
            int gold = 0, int exp = 0, int yellow = 0, int blue = 0, int red = 0)
        {
            floorFactory = FloorFactory.GetInstance();
            current_floor = floorFactory.GetCurrentFloor();
        }
        public static Hero GetInstance(int hp = 1000, int atk = 10, int def = 10, int res = 0, int level = 1,
            int gold = 0, int exp = 0, int yellow = 0, int blue = 0, int red = 0)
        {
            if (instance == null)
            {
                instance = new Hero(hp, atk, def, res, level, gold, exp, yellow, blue, red);
            }
            return instance;
        }

        /// <summary>
        /// 判别碰到的类型
        /// </summary>
        /// <param name="a"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsTouch(IBaseImage image)
        {
            // 细分类
            Enum e = image.GetFineType();
            switch (image.GetCoarseType())
            {
                case Atype.地板:
                    switch (e)
                    {
                        case FloorType.地板:
                            image.PlayMusic(image.GetPlayer(),"../../res/se/走路.MP3");
                            return true;
                        case FloorType.楼梯上:
                            image.PlayMusic(image.GetPlayer(), "../../res/se/上下楼.MP3");
                            current_floor = floorFactory.CoreMap(floorFactory.GetFloorNum() + 1);
                            return true;
                        case FloorType.楼梯下:
                            image.PlayMusic(image.GetPlayer(), "../../res/se/上下楼.MP3");
                            current_floor = floorFactory.CoreMap(floorFactory.GetFloorNum() - 1);
                            return true;
                    }
                    return false;
                case Atype.门:
                    if (image.isImageExist())

                    {
                        switch (e)
                        {
                            case DoorType.黄门:
                                if (properties.yellowKey > 0)
                                {
                                    MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                                    image.HideImage();
                                    properties.yellowKey--;
                                }
                                else
                                {
                                    image.PlayMusic(image.GetPlayer(), "../../res/se/开门失败.MP3");
                                }
                                break;
                            case DoorType.蓝门:
                                if (properties.blueKey > 0)
                                {
                                    MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                                    image.HideImage();
                                    properties.blueKey--;
                                }
                                else
                                {
                                    image.PlayMusic(image.GetPlayer(), "../../res/se/开门失败.MP3");
                                }
                                break;
                            case DoorType.红门:
                                if (properties.redKey > 0)
                                {
                                    MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                                    image.HideImage();
                                    properties.redKey--;
                                }
                                else
                                {
                                    image.PlayMusic(image.GetPlayer(), "../../res/se/开门失败.MP3");
                                }
                                break;
                            case DoorType.铁门:
                                MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                                image.HideImage();
                                break;
                        }
                    }
                    return false;
                case Atype.宝石:
                    switch (e)
                    {
                        case GemstoneType.红宝石:
                            properties.atk += 3;
                            break;
                        case GemstoneType.蓝宝石:
                            properties.def += 3;
                            break;
                        case GemstoneType.绿宝石:
                            properties.res += 3;
                            break;
                        case GemstoneType.红血瓶:
                            properties.hp += 100;
                            break;
                        case GemstoneType.蓝血瓶:
                            properties.hp += 300;
                            break;
                        case GemstoneType.黄血瓶:
                            properties.hp += 500;
                            break;
                        case GemstoneType.绿血瓶:
                            properties.hp += 1000;
                            break;
                        case GemstoneType.铁剑:
                            properties.atk += 10;
                            weapon = CommonVariable.WEAPON_SWORD;
                            break;
                        case GemstoneType.铁盾:
                            properties.def += 10;
                            break;
                        case GemstoneType.银剑:
                            properties.atk += 30;
                            break;
                        case GemstoneType.银盾:
                            properties.def += 30;
                            break;
                        case GemstoneType.骑士剑:
                            properties.atk += 70;
                            break;
                        case GemstoneType.骑士盾:
                            properties.def += 70;
                            break;
                        case GemstoneType.圣剑:
                            properties.atk += 100;
                            break;
                        case GemstoneType.圣盾:
                            properties.def += 100;
                            break;
                    }
                    image.PlayMusic(image.GetPlayer(),"../../res/se/吃物品.MP3");
                    MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                    image.HideImage();
                    //更新显伤脚本
                    MapUtility.UpdateDamage();
                    return true;
                case Atype.特殊物品:
                    MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                    image.PlayMusic(image.GetPlayer(), "../../res/se/吃物品.MP3");
                    return true;
                case Atype.钥匙:
                    switch ((KeyType)e)
                    {
                        case KeyType.黄钥匙:
                            properties.yellowKey++;
                            image.HideImage();
                            break;
                        case KeyType.蓝钥匙:
                            properties.blueKey++;
                            image.HideImage();
                            break;
                        case KeyType.红钥匙:
                            properties.redKey++;
                            image.HideImage();
                            break;
                    }
                    MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));
                    image.PlayMusic(image.GetPlayer(), "../../res/se/吃物品.MP3");
                    return true;
                case Atype.怪物:
                    MonsterImage monster = new MonsterImage((MonsterType)e);
                    if (CalculationUtility.Battle(monster))
                    {
                        image.PlayMusic(image.GetPlayer(), "../../res/se/" + weapon + ".MP3");

                        //删除怪物图片和显伤脚本
                        image.HideImage();
                        ((MonsterImage)image).HideDamage();

                        //删除怪物，更改为地板
                        MapUtility.ChangeToImage(floorFactory.GetFloorNum(), properties.x, properties.y, new FloorImage(FloorType.地板));

                        //从怪物列表中删除怪物和位置
                        MapUtility.MonsterList.Remove(image);
                        foreach (KeyValuePair<int, int> pair in MapUtility.MonsterPosition)
                        {
                            if (pair.Key == properties.x && pair.Value == properties.y)
                            {
                                MapUtility.MonsterPosition.Remove(pair);
                                break;
                            }
                        }
                    }
                    return false;
                case Atype.NPC:
                    IsTalking = true;
                    NPC = (NPCImage)image;
                    NPC.ShowDialog();
                    break;
            }
            return false;
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        public void MoveUp()
        {
            if (properties.x - 1 < 0)
            {
                return;
            }
            properties.x--;
            if (IsTouch(current_floor[properties.x, properties.y]) == false)
            {
                properties.x++;
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
            if (properties.x + 1 > 10)
            {
                return;
            }
            properties.x++;
            if (IsTouch(current_floor[properties.x, properties.y]) == false)
            {
                properties.x--;
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
            if (properties.y - 1 < 0)
            {
                return;
            }
            properties.y--;
            if (IsTouch(current_floor[properties.x, properties.y]) == false)
            {
                properties.y++;
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
            if (properties.y + 1 > 10)
            {
                return;
            }
            properties.y++;
            if (IsTouch(current_floor[properties.x, properties.y]) == false)
            {
                properties.y--;
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
