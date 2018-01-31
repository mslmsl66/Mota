﻿using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Mota.CellImage
{
    public class MonsterImage : DynamicImageImpl
    {
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
            }
            SetImageSource(GetImagePaths(type));
            coarseType = Atype.怪物;
            fineType = type;
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
            }
            return null;
        }
    }
    public enum MonsterType { 绿史莱姆, 红史莱姆, 小蝙蝠, 骷髅, 兽人 };

    public enum SpecialAbility { 普通, 魔攻, 坚固, 二连击, 先攻 };
}