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
                    atk = 15; def = 3; hp = 40; exp = 1; gold = 1; specialAbility = SpecialAbility.普通; break;
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
                    return new string[] { "/res/icons/monster/1_01.png", "/res/icons/monster/1_02.png", "/res/icons/monster/1_03.png", "/res/icons/monster/1_04.png" };
            }
            return null;
        }

        public enum SpecialAbility { 普通, 魔攻, 坚固, 二连击, 先攻 };
    }

    public enum MonsterType { 绿史莱姆 };
}
