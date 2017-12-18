using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class gemstone
    {
        public enum gemstone_type { 红宝石, 蓝宝石, 绿宝石, 铁剑, 铁盾, 银剑, 银盾, 骑士剑, 骑士盾, 圣剑, 圣盾, 红血瓶, 蓝血瓶, 绿血瓶, 黄血瓶 };

        public int atk, def, m_def, hp;
        public gemstone(gemstone_type gtype)
        {
            switch (gtype)
            {
                case gemstone_type.红宝石:
                    atk = 3; def = 0; m_def = 0; hp = 0; break;
                case gemstone_type.蓝宝石:
                    atk = 0; def = 3; m_def = 0; hp = 0; break;
                case gemstone_type.绿宝石:
                    atk = 0; def = 0; m_def = 3; hp = 0; break;
                case gemstone_type.铁剑:
                    atk = 10; def = 0; m_def = 0; hp = 0; break;
                case gemstone_type.铁盾:
                    atk = 0; def = 10; m_def = 0; hp = 0; break;
                case gemstone_type.银剑:
                    atk = 20; def = 0; m_def = 0; hp = 0; break;
                case gemstone_type.银盾:
                    atk = 0; def = 20; m_def = 0; hp = 0; break;
                case gemstone_type.骑士剑:
                    atk = 50; def = 0; m_def = 0; hp = 0; break;
                case gemstone_type.骑士盾:
                    atk = 0; def = 50; m_def = 0; hp = 0; break;
                case gemstone_type.圣剑:
                    atk = 100; def = 0; m_def = 0; hp = 0; break;
                case gemstone_type.圣盾:
                    atk = 0; def = 100; m_def = 0; hp = 0; break;
                case gemstone_type.红血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 200; break;
                case gemstone_type.蓝血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 500; break;
                case gemstone_type.绿血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 1000; break;
                case gemstone_type.黄血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 2000; break;
            }
        }

        public static String getImagePath(gemstone_type gtype)
        {
            switch (gtype)
            {
                case gemstone_type.红宝石:
                    return "/res/icons/item/d0.png";
                case gemstone_type.蓝宝石:
                    return "/res/icons/item/d1.png";
                case gemstone_type.绿宝石:
                    return "/res/icons/item/d2.png";
                case gemstone_type.铁剑:
                    return "/res/icons/equipment/a0.png";
                case gemstone_type.铁盾:
                    return "/res/icons/equipment/a8.png";
                case gemstone_type.银剑:
                    return "/res/icons/equipment/a1.png";
                case gemstone_type.银盾:
                    return "/res/icons/equipment/a9.png";
                case gemstone_type.骑士剑:
                    return "/res/icons/equipment/a2.png";
                case gemstone_type.骑士盾:
                    return "/res/icons/equipment/a10.png";
                case gemstone_type.圣剑:
                    return "/res/icons/equipment/a3.png";
                case gemstone_type.圣盾:
                    return "/res/icons/equipment/a11.png";
                case gemstone_type.红血瓶:
                    return "/res/icons/item/b0.png";
                case gemstone_type.蓝血瓶:
                    return "/res/icons/item/b1.png";
                case gemstone_type.绿血瓶:
                    return "/res/icons/item/b2.png";
                case gemstone_type.黄血瓶:
                    return "/res/icons/item/b3.png";
            }
            return null;
        }

    }
}
