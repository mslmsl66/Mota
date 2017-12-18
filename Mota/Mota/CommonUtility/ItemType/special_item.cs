using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    class special_item
    {
        public enum special_item_type { 怪物手册, 楼层飞跃器, 大金币, 圣水, 十字架, 解毒剂, 解衰剂};

        public static String getImagePath(special_item_type stype)
        {
            switch (stype)
            {
                case special_item_type.怪物手册:
                    return "/res/icons/item/e0.png";
                case special_item_type.楼层飞跃器:
                    return "/res/icons/item/e2.png";
                case special_item_type.大金币:
                    return "/res/icons/item/e3.png";
                case special_item_type.圣水:
                    return "/res/icons/item/c11.png";
                case special_item_type.十字架:
                    return "/res/icons/item/e9.png";
                case special_item_type.解毒剂:
                    return "/res/icons/item/c4.png";
                case special_item_type.解衰剂:
                    return "/res/icons/item/c5.png";
            }
            return null;
        }
    }
}
