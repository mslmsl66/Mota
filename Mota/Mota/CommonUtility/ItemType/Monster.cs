using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class Monster
    {
        /// <summary>
        /// 攻击
        /// </summary>
        public int atk { get; }

        /// <summary>
        /// 防御
        /// </summary>
        public int def { get; }

        /// <summary>
        /// 血量
        /// </summary>
        public int hp { get; }

        /// <summary>
        /// 经验值
        /// </summary>
        public int exp { get; }

        /// <summary>
        /// 金币
        /// </summary>
        public int gold { get; }

        /// <summary>
        /// 怪物的特殊能力(只能选一种)
        /// </summary>
        public SpecialAbility specialAbility { get; }

        public Monster(MonsterType gtype)
        {
            switch (gtype)
            {
                case MonsterType.绿史莱姆:
                    atk = 15; def = 3; hp = 40; exp = 0; gold = 1; specialAbility = SpecialAbility.普通; break;
                case MonsterType.红史莱姆:
                    atk = 20; def = 5; hp = 50; exp = 1; gold = 1; specialAbility = SpecialAbility.普通; break;
                case MonsterType.小蝙蝠:
                    atk = 30; def = 2; hp = 41; exp = 1; gold = 2; specialAbility = SpecialAbility.先攻; break;
                case MonsterType.骷髅:
                    atk = 50; def = 0; hp = 70; exp = 1; gold = 2; specialAbility = SpecialAbility.普通; break;
                case MonsterType.兽人:
                    atk = 90; def = 35; hp = 140; exp = 3; gold = 5; specialAbility = SpecialAbility.普通; break;
            }
        }

        /**
         * 返回四张图片 形成动画
         */
        public static String[] GetImagePaths(MonsterType mtype)
        {
            switch (mtype)
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

        public enum SpecialAbility { 普通, 魔攻, 坚固, 二连击, 先攻 };
    }

    public enum MonsterType { 绿史莱姆, 红史莱姆, 小蝙蝠, 骷髅, 兽人 };
}
