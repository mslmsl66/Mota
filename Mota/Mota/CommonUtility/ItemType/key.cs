using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class Key
    {
        public enum KeyType { 黄钥匙, 蓝钥匙, 红钥匙 };

        public static String GetImagePath(KeyType ktype)
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
}
