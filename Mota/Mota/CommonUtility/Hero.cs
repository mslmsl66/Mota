using Mota.CommonUtility.ItemType;
using Mota.page;
using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
        /// 等级
        /// </summary>
        private int level;

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
        /// 英雄当前楼层
        /// </summary>
        private CellImage[,] current_floor;

        /// <summary>
        /// 状态栏
        /// </summary>
        private State state;

        private static Hero instance;
        private Hero()
        {
            floorFactory = FloorFactory.GetInstance();
            current_floor = floorFactory.GetCurrentFloor();
            state = State.GetInstance();
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
                    switch ((FloorType)e)
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
                    switch ((DoorType)e)
                    {
                        case DoorType.黄门:
                            if (yellowKey > 0)
                            {
                                current_floor[x, y].HideImage(a, DoorType.黄门);
                                yellowKey--;
                                return true;
                            }
                            break;
                        case DoorType.蓝门:
                            if (blueKey > 0)
                            {
                                current_floor[x, y].HideImage(a, DoorType.蓝门);
                                blueKey--;
                                return true;
                            }
                            break;
                        case DoorType.红门:
                            if (redKey > 0)
                            {
                                current_floor[x, y].HideImage(a, DoorType.红门);
                                redKey--;
                                return true;
                            }
                            break;
                        case DoorType.铁门:
                            current_floor[x, y].HideImage(a, DoorType.铁门);
                            break;
                    }
                    return false;
                case Atype.宝石:
                    switch (e)
                    {
                        case GemstoneType.红宝石:
                            atk += 3;
                            break;
                        case GemstoneType.蓝宝石:
                            def += 3;
                            break;
                        case GemstoneType.绿宝石:
                            res += 3;
                            break;
                        case GemstoneType.红血瓶:
                            hp += 100;
                            break;
                        case GemstoneType.蓝血瓶:
                            hp += 300;
                            break;
                        case GemstoneType.黄血瓶:
                            hp += 500;
                            break;
                        case GemstoneType.绿血瓶:
                            hp += 1000;
                            break;
                        case GemstoneType.铁剑:
                            atk += 10;
                            break;
                        case GemstoneType.铁盾:
                            def += 10;
                            break;
                        case GemstoneType.银剑:
                            atk += 30;
                            break;
                        case GemstoneType.银盾:
                            def += 30;
                            break;
                        case GemstoneType.骑士剑:
                            atk += 70;
                            break;
                        case GemstoneType.骑士盾:
                            def += 70;
                            break;
                        case GemstoneType.圣剑:
                            atk += 100;
                            break;
                        case GemstoneType.圣盾:
                            def += 100;
                            break;
                    }
                    current_floor[x, y].HideImage(a);
                    return true;
                case Atype.特殊物品:
                    return true;
                case Atype.钥匙:
                    switch ((KeyType)e)
                    {
                        case KeyType.黄钥匙:
                            yellowKey++;
                            break;
                        case KeyType.蓝钥匙:
                            blueKey++;
                            break;
                        case KeyType.红钥匙:
                            redKey++;
                            break;
                    }
                    return true;
                case Atype.怪物:
                    Monster monster = new Monster((MonsterType)e);
                    if (Battle(monster))
                    {
                        current_floor[x, y].HideImage(a);
                    }
                    return false;
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
                RefreshStatus();
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
                RefreshStatus();
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
                RefreshStatus();
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
                RefreshStatus();
                Canvas.SetLeft(floorFactory.GetHeroImage(), Canvas.GetLeft(floorFactory.GetHeroImage()) + 50);
                floorFactory.GetHeroImage().Source = new BitmapImage(new Uri("/res/icons/characters/hero11.png", UriKind.Relative));
            }
        }

        /// <summary>
        /// 计算与怪物战斗的伤害，经验，金币
        /// </summary>
        /// <param name="monster"></param>
        private bool Battle(Monster monster)
        {
            if (atk <= monster.def)
            {
                return false;
            }

            int damage = 0;
            int monsterHp = monster.hp;
            switch (monster.specialAbility)
            {
                case Monster.SpecialAbility.普通:
                    monsterHp = monsterHp - (atk - monster.def);
                    while (monsterHp > 0)
                    {
                        damage += (monster.atk - def);
                        monsterHp = monsterHp - (atk - monster.def);
                    }
                    break;
                case Monster.SpecialAbility.魔攻:
                    monsterHp = monsterHp - (atk - monster.def);
                    while (monsterHp > 0)
                    {
                        damage += monster.atk;
                        monsterHp = monsterHp - (atk - monster.def);
                    }
                    break;
                case Monster.SpecialAbility.坚固:
                    monsterHp = monsterHp - 1;
                    while (monsterHp > 0)
                    {
                        damage += (monster.atk - def);
                        monsterHp = monsterHp - 1;
                    }
                    break;
                case Monster.SpecialAbility.先攻:
                    while (monsterHp > 0)
                    {
                        damage += (monster.atk - def);
                        monsterHp = monsterHp - (atk - monster.def);
                    }
                    break;
            }
            damage -= res;
            if (damage >= hp)
            {
                return false;
            }
            else
            {
                hp -= damage;
                exp += monster.exp;
                gold += monster.gold;
                RefreshStatus();
                return true;
            }
        }

        /// <summary>
        /// 刷新状态栏
        /// </summary>
        private void RefreshStatus()
        {
            state.floorNumber.Text = floorFactory.GetFloorNum().ToString() + "F";
            state.heroLevel.Text = level.ToString();
            state.heroHP.Text = hp.ToString();
            state.heroATK.Text = atk.ToString();
            state.heroDEF.Text = def.ToString();
            state.heroRES.Text = res.ToString();
            state.heroEXP.Text = exp.ToString();
            state.heroGold.Text = gold.ToString();
            state.heroYellowKey.Text = "x" + yellowKey.ToString();
            state.heroBlueKey.Text = "x" + blueKey.ToString();
            state.heroRedKey.Text = "x" + redKey.ToString();
        }
    }
}