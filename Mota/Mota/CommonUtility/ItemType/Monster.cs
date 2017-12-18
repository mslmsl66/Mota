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
        public enum monster_type { 绿史莱姆 };
        public Monster(monster_type gtype)
        {
            switch (gtype)
            {
                case monster_type.绿史莱姆:
                    atk = 15; def = 3; hp = 40; exp = 1; gold = 1; break;
            }
        }

        public static String getImagePath(monster_type gtype)
        {
            switch (gtype)
            {
                case monster_type.绿史莱姆:
                    return "/res/icons/background/0.png";
            }
            return null;
        }
    }
}
