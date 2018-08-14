using System;
using System.Windows.Media;

namespace Mota.CellImage
{
    public class KeyImage : StaticImageImpl
    {
        public MediaPlayer keyPlayer = new MediaPlayer();

        public KeyImage(KeyType type) : base()
        {
            SetImageSource(GetImagePath(type));
            coarseType = Atype.钥匙;
            fineType = type;
        }

        public override MediaPlayer GetPlayer()
        {
            return keyPlayer;
        }

        public String GetImagePath(KeyType ktype)
        {
            switch (ktype)
            {
                case KeyType.黄钥匙:
                    return "/res/icons/item/a0.png";
                case KeyType.蓝钥匙:
                    return "/res/icons/item/a1.png";
                case KeyType.红钥匙:
                    return "/res/icons/item/a2.png";
            }
            return null;
        }
    }
    public enum KeyType { 黄钥匙, 蓝钥匙, 红钥匙 };
}
