using Mota.CommonUtility;
using Mota.page;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Mota.CellImage
{
    public class MonsterImage : DynamicImageImpl
    {
        public MediaPlayer monsterPlayer = new MediaPlayer();

        /// <summary>
        /// 攻击
        /// </summary>
        public int Atk { get; }

        /// <summary>
        /// 防御
        /// </summary>
        public int Def { get; }

        /// <summary>
        /// 血量
        /// </summary>
        public int Hp { get; }

        /// <summary>
        /// 经验值
        /// </summary>
        public int Exp { get; }

        /// <summary>
        /// 金币
        /// </summary>
        public int Gold { get; }

        /// <summary>
        /// 怪物的特殊能力(只能选一种)
        /// </summary>
        public SpecialAbility Ability { get; set; }

        /// <summary>
        /// 显伤脚本TextBlock
        /// </summary>
        public TextBlock textBlock;

        public MonsterImage(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.绿史莱姆:
                    Atk = 15; Def = 3; Hp = 40; Exp = 0; Gold = 1; Ability = SpecialAbility.普通; break;
                case MonsterType.红史莱姆:
                    Atk = 20; Def = 5; Hp = 50; Exp = 1; Gold = 1; Ability = SpecialAbility.普通; break;
                case MonsterType.小蝙蝠:
                    Atk = 30; Def = 2; Hp = 41; Exp = 1; Gold = 2; Ability = SpecialAbility.先攻; break;
                case MonsterType.骷髅:
                    Atk = 50; Def = 0; Hp = 70; Exp = 1; Gold = 2; Ability = SpecialAbility.普通; break;
                case MonsterType.兽人:
                    Atk = 90; Def = 35; Hp = 140; Exp = 3; Gold = 5; Ability = SpecialAbility.普通; break;
                case MonsterType.黑史莱姆:
                    Atk = 40; Def = 15; Hp = 80; Exp = 2; Gold = 3; Ability = SpecialAbility.普通; break;
                case MonsterType.初级法师:
                    Atk = 30; Def = 10; Hp = 40; Exp = 2; Gold = 3; Ability = SpecialAbility.魔攻; break;
                case MonsterType.大蝙蝠:
                    Atk = 60; Def = 5; Hp = 80; Exp = 2; Gold = 3; Ability = SpecialAbility.二连击; break;
            }
            SetImageSource(GetImagePaths(type));
            coarseType = Atype.怪物;
            fineType = type;
        }

        public override MediaPlayer GetPlayer()
        {
            return monsterPlayer;
        }

        /// <summary>
        /// 显伤脚本
        /// </summary>
        /// <param name="monster">对应的怪物</param>
        public void ShowDamage(int left, int top)
        {
            if (textBlock != null)
            {
                HideDamage();
            }
            Run run = new Run()
            {
                Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 150, 0)),
                FontWeight = FontWeight.FromOpenTypeWeight(999)
            };
            int damage = CalculationUtility.CalculateDamage(this);
            // -1代表不可战斗显示问号
            if (damage == -1)
            {
                run.Text = "???";
            }
            else
            {
                run.Text = damage + "";
            }
            textBlock = new TextBlock(run)
            {
                Height = 20,
                FontSize = 13
            };
            Canvas.SetLeft(textBlock, left);
            Canvas.SetTop(textBlock, top);
            Panel.SetZIndex(textBlock, 9);
            FloorFactory.canvas.Children.Add(textBlock);
        }

        /// <summary>
        /// 清除显伤脚本
        /// </summary>
        public void HideDamage()
        {
            FloorFactory.canvas.Children.Remove(textBlock);
        }

        /// <summary>
        /// 返回四张图片 形成动画
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static String[] GetImagePaths(MonsterType type)
        {
            switch (type)
            {
                case MonsterType.绿史莱姆:
                    return new string[] { "/res/icons/monster/Monster01-01_01.png", "/res/icons/monster/Monster01-01_02.png", "/res/icons/monster/Monster01-01_03.png", "/res/icons/monster/Monster01-01_04.png" };
                case MonsterType.红史莱姆:
                    return new string[] { "/res/icons/monster/Monster01-01_05.png", "/res/icons/monster/Monster01-01_06.png", "/res/icons/monster/Monster01-01_07.png", "/res/icons/monster/Monster01-01_08.png" };
                case MonsterType.小蝙蝠:
                    return new string[] { "/res/icons/monster/Monster03-01_01.png", "/res/icons/monster/Monster03-01_02.png", "/res/icons/monster/Monster03-01_03.png", "/res/icons/monster/Monster03-01_04.png" };
                case MonsterType.骷髅:
                    return new string[] { "/res/icons/monster/Monster02-01_01.png", "/res/icons/monster/Monster02-01_02.png", "/res/icons/monster/Monster02-01_03.png", "/res/icons/monster/Monster02-01_04.png" };
                case MonsterType.兽人:
                    return new string[] { "/res/icons/monster/Monster09-01_01.png", "/res/icons/monster/Monster09-01_02.png", "/res/icons/monster/Monster09-01_03.png", "/res/icons/monster/Monster09-01_04.png" };
                case MonsterType.黑史莱姆:
                    return new string[] { "/res/icons/monster/Monster01-01_09.png", "/res/icons/monster/Monster01-01_10.png", "/res/icons/monster/Monster01-01_11.png", "/res/icons/monster/Monster01-01_12.png" };
                case MonsterType.初级法师:
                    return new string[] { "/res/icons/monster/Monster06-01_01.png", "/res/icons/monster/Monster06-01_02.png", "/res/icons/monster/Monster06-01_03.png", "/res/icons/monster/Monster06-01_04.png" };
                case MonsterType.大蝙蝠:
                    return new string[] { "/res/icons/monster/Monster03-01_05.png", "/res/icons/monster/Monster03-01_06.png", "/res/icons/monster/Monster03-01_07.png", "/res/icons/monster/Monster03-01_08.png" };
            }
            return null;
        }
    }
    public enum MonsterType { 绿史莱姆, 红史莱姆, 小蝙蝠, 骷髅, 兽人, 黑史莱姆, 初级法师, 大蝙蝠};

    public enum SpecialAbility { 普通, 魔攻, 坚固, 二连击, 先攻 };
}