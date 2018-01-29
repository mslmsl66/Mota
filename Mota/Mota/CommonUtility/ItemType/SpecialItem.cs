using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    class SpecialItem
    {
        public static String GetImagePath(SpecialItemType stype)
        {
            switch (stype)
            {
                case SpecialItemType.怪物手册:
                    return "/res/icons/item/e0.png";
                case SpecialItemType.楼层飞跃器:
                    return "/res/icons/item/e2.png";
                case SpecialItemType.大金币:
                    return "/res/icons/item/e3.png";
                case SpecialItemType.圣水:
                    return "/res/icons/item/c11.png";
                case SpecialItemType.十字架:
                    return "/res/icons/item/e9.png";
                case SpecialItemType.解毒剂:
                    return "/res/icons/item/c4.png";
                case SpecialItemType.解衰剂:
                    return "/res/icons/item/c5.png";
            }
            return null;
        }
    }

    public enum SpecialItemType { 怪物手册, 楼层飞跃器, 大金币, 圣水, 十字架, 解毒剂, 解衰剂 };
}
