using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class Monster
    {
        public int atk, def, hp, exp, gold;
        public enum MonsterType { 绿史莱姆 };
        public Monster(MonsterType gtype)
        {
            switch (gtype)
            {
                case MonsterType.绿史莱姆:
                    atk = 15; def = 3; hp = 40; exp = 1; gold = 1; break;
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
    }
}
