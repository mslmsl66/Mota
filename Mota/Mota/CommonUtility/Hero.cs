using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Mota.page;
using Mota.CommonUtility;
using Mota.CommonUtility.ItemType;
using System.Threading;

namespace Mota.CommonUtility
{
    public class Hero
    {
        /// <summary>
        /// 血量
        /// </summary>
        private int hp = 1000;

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

        private static Hero instance;
        private Hero()
        {
            floorFactory = FloorFactory.GetInstance();
            current_floor = floorFactory.GetCurrentFloor();
        }
        public static Hero getInstance()
        {
            if (instance == null)
            {
                instance = new Hero();
            }
            return instance;
        }

        /// <summary>
        /// 英雄位置标记
        /// </summary>
        private int x = 10;
        private int y = 10;

        private FloorFactory floorFactory;

        /// <summary>
        /// 英雄当前楼层
        /// </summary>
        private CellImage[,] current_floor;

        /// <summary>
        /// 判别碰到的类型
        /// </summary>
        /// <param name="a"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool IsTouch(CellImage.Atype a, Enum e)
        {
            switch (a)
            {
                case CellImage.Atype.地板:
                    if ((Floor.FloorType)e == Floor.FloorType.地板)
                    {
                        return true;
                    }
                    else if ((Floor.FloorType)e == Floor.FloorType.楼梯上)
                    {
                        current_floor = floorFactory.CoreMap(floorFactory.GetFloorNum() + 1);
                    }
                    else if ((Floor.FloorType)e == Floor.FloorType.楼梯下)
                    {
                        current_floor = floorFactory.CoreMap(floorFactory.GetFloorNum() - 1);
                    }
                    return false;
                case CellImage.Atype.门:
                    if ((Door.DoorType)e == Door.DoorType.黄门 && yellowKey > 0)
                    {
                        current_floor[y - 1, x].HideImage(a, Door.DoorType.黄门);
                        yellowKey--;
                    }
                    else if ((Door.DoorType)e == Door.DoorType.蓝门 && blueKey > 0)
                    {
                        current_floor[y - 1, x].HideImage(a, Door.DoorType.蓝门);
                        blueKey--;
                    }
                    else if ((Door.DoorType)e == Door.DoorType.红门 && redKey > 0)
                    {
                        current_floor[y - 1, x].HideImage(a, Door.DoorType.红门);
                        redKey--;
                    }
                    else if ((Door.DoorType)e == Door.DoorType.铁门)
                    {
                        current_floor[y - 1, x].HideImage(a, Door.DoorType.铁门);
                    }
                    return false;
                case CellImage.Atype.宝石:
                    switch (e)
                    {
                        case Gemstone.GemstoneType.红宝石:
                            atk += 3;
                            break;
                        case Gemstone.GemstoneType.蓝宝石:
                            def += 3;
                            break;
                        case Gemstone.GemstoneType.绿宝石:
                            res += 3;
                            break;
                        case Gemstone.GemstoneType.红血瓶:
                            hp += 100;
                            break;
                        case Gemstone.GemstoneType.蓝血瓶:
                            hp += 300;
                            break;
                        case Gemstone.GemstoneType.黄血瓶:
                            hp += 500;
                            break;
                        case Gemstone.GemstoneType.绿血瓶:
                            hp += 1000;
                            break;
                        case Gemstone.GemstoneType.铁剑:
                            atk += 10;
                            break;
                        case Gemstone.GemstoneType.铁盾:
                            def += 10;
                            break;
                        case Gemstone.GemstoneType.银剑:
                            atk += 30;
                            break;
                        case Gemstone.GemstoneType.银盾:
                            def += 30;
                            break;
                        case Gemstone.GemstoneType.骑士剑:
                            atk += 70;
                            break;
                        case Gemstone.GemstoneType.骑士盾:
                            def += 70;
                            break;
                        case Gemstone.GemstoneType.圣剑:
                            atk += 100;
                            break;
                        case Gemstone.GemstoneType.圣盾:
                            def += 100;
                            break;
                    }
                    current_floor[y - 1, x].HideImage(a);
                    return true;
                case CellImage.Atype.特殊物品:
                    return true;
                case CellImage.Atype.钥匙:
                    switch ((Key.KeyType)e)
                    {
                        case Key.KeyType.黄钥匙:
                            yellowKey++;
                            break;
                        case Key.KeyType.蓝钥匙:
                            blueKey++;
                            break;
                        case Key.KeyType.红钥匙:
                            redKey++;
                            break;
                    }
                    return true;
                case CellImage.Atype.怪物:
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 向上移动
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MoveUp()
        {
            if (y - 1 < 0)
            {
                return;
            }
            if (IsTouch(current_floor[y - 1, x].GetCoarseType(), current_floor[y - 1, x].GetFineType()) == false)
            {
                return;
            }
            else
            {
                y--;
                MoveImage();
            }
        }

        public void MoveDown()
        {
            if (y + 1 > 10)
            {
                return;
            }
            if (IsTouch(current_floor[y + 1, x].GetCoarseType(), current_floor[y + 1, x].GetFineType()) == false)
            {
                return;
            }
            else
            {
                y++;
                MoveImage();
            }
        }

        public void MoveLeft()
        {
            if (x - 1 < 0)
            {
                return;
            }
            if (IsTouch(current_floor[y, x - 1].GetCoarseType(), current_floor[y, x - 1].GetFineType()) == false)
            {
                return;
            }
            else
            {
                x--;
                MoveImage();
            }
        }

        public void MoveRight()
        {
            if (x + 1 > 10)
            {
                return;
            }
            if (IsTouch(current_floor[y, x + 1].GetCoarseType(), current_floor[y, x + 1].GetFineType()) == false)
            {
                return;
            }
            else
            {
                x++;
                MoveImage();
            }
        }

        private void MoveImage()
        {
            //图片平移
            TransformGroup transformGroup = new TransformGroup();
            TranslateTransform translateTransform = new TranslateTransform();

            translateTransform.X += 50 * (x - 10);
            translateTransform.Y += 50 * (y - 10);
            transformGroup.Children.Add(translateTransform);

            current_floor[MapUtility.GetPosition().x, MapUtility.GetPosition().y].RenderTransform = transformGroup;
        }
    }
}