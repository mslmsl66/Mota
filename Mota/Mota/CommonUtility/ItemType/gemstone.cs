using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class Gemstone
    {
        public enum GemstoneType { 红宝石, 蓝宝石, 绿宝石, 铁剑, 铁盾, 银剑, 银盾, 骑士剑, 骑士盾, 圣剑, 圣盾, 红血瓶, 蓝血瓶, 绿血瓶, 黄血瓶 };

        private int atk, def, m_def, hp;
        public Gemstone(GemstoneType gtype)
        {
            switch (gtype)
            {
                case GemstoneType.红宝石:
                    atk = 3; def = 0; m_def = 0; hp = 0; break;
                case GemstoneType.蓝宝石:
                    atk = 0; def = 3; m_def = 0; hp = 0; break;
                case GemstoneType.绿宝石:
                    atk = 0; def = 0; m_def = 3; hp = 0; break;
                case GemstoneType.铁剑:
                    atk = 10; def = 0; m_def = 0; hp = 0; break;
                case GemstoneType.铁盾:
                    atk = 0; def = 10; m_def = 0; hp = 0; break;
                case GemstoneType.银剑:
                    atk = 20; def = 0; m_def = 0; hp = 0; break;
                case GemstoneType.银盾:
                    atk = 0; def = 20; m_def = 0; hp = 0; break;
                case GemstoneType.骑士剑:
                    atk = 50; def = 0; m_def = 0; hp = 0; break;
                case GemstoneType.骑士盾:
                    atk = 0; def = 50; m_def = 0; hp = 0; break;
                case GemstoneType.圣剑:
                    atk = 100; def = 0; m_def = 0; hp = 0; break;
                case GemstoneType.圣盾:
                    atk = 0; def = 100; m_def = 0; hp = 0; break;
                case GemstoneType.红血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 200; break;
                case GemstoneType.蓝血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 500; break;
                case GemstoneType.绿血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 1000; break;
                case GemstoneType.黄血瓶:
                    atk = 0; def = 0; m_def = 0; hp = 2000; break;
            }
        }

        public static String GetImagePath(GemstoneType gtype)
        {
            switch (gtype)
            {
                case GemstoneType.红宝石:
                    return "/res/icons/item/d0.png";
                case GemstoneType.蓝宝石:
                    return "/res/icons/item/d1.png";
                case GemstoneType.绿宝石:
                    return "/res/icons/item/d2.png";
                case GemstoneType.铁剑:
                    return "/res/icons/equipment/a0.png";
                case GemstoneType.铁盾:
                    return "/res/icons/equipment/a8.png";
                case GemstoneType.银剑:
                    return "/res/icons/equipment/a1.png";
                case GemstoneType.银盾:
                    return "/res/icons/equipment/a9.png";
                case GemstoneType.骑士剑:
                    return "/res/icons/equipment/a2.png";
                case GemstoneType.骑士盾:
                    return "/res/icons/equipment/a10.png";
                case GemstoneType.圣剑:
                    return "/res/icons/equipment/a3.png";
                case GemstoneType.圣盾:
                    return "/res/icons/equipment/a11.png";
                case GemstoneType.红血瓶:
                    return "/res/icons/item/b0.png";
                case GemstoneType.蓝血瓶:
                    return "/res/icons/item/b1.png";
                case GemstoneType.绿血瓶:
                    return "/res/icons/item/b2.png";
                case GemstoneType.黄血瓶:
                    return "/res/icons/item/b3.png";
            }
            return null;
        }

    }
}
