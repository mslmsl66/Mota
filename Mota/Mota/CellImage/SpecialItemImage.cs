using System;

namespace Mota.CellImage
{
    public class SpecialItemImage : StaticImageImpl
    {
        public SpecialItemImage(SpecialItemType type) : base()
        {
            SetImageSource(GetImagePath(type));
            coarseType = Atype.特殊物品;
            fineType = type;
        }

        public String GetImagePath(SpecialItemType type)
        {
            switch (type)
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
