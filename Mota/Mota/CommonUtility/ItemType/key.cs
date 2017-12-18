using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class key
    {
        public enum key_type { 黄钥匙, 蓝钥匙, 红钥匙 };

        public static String getImagePath(key_type ktype)
        {
            switch (ktype)
            {
                case key_type.黄钥匙:
                    return "/res/icons/item/a0.png";
                case key_type.蓝钥匙:
                    return "/res/icons/item/a1.png";
                case key_type.红钥匙:
                    return "/res/icons/item/a2.png";

            }
            return null;
        }
    }
}
