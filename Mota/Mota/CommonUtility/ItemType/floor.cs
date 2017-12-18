using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class floor
    {
        public enum floor_type { 地板, 木墙, 蓝墙, 银墙, 黄墙, 紫墙, 白墙, 天空, 熔浆, 商店左, 商店中, 商店右, 楼梯上, 楼梯下, 黄门, 蓝门, 红门, 铁门 };

        public static String getImagePath(floor_type ftype)
        {
            switch (ftype)
            {
                case floor_type.地板:
                    return "/res/icons/background/0.png";
                case floor_type.木墙:
                    return "/res/icons/background/1.png";
                case floor_type.蓝墙:
                    return "/res/icons/background/2.png";
                case floor_type.银墙:
                    return "/res/icons/background/3.png";
                case floor_type.黄墙:
                    return "/res/icons/background/b2.png";
                case floor_type.紫墙:
                    return "/res/icons/background/b0.png";
                case floor_type.白墙:
                    return "/res/icons/background/b1.png";
                case floor_type.商店左:
                    return "/res/icons/background/28.png";
                case floor_type.商店右:
                    return "/res/icons/background/30.png";
                case floor_type.楼梯上:
                    return "/res/icons/background/25.png";
                case floor_type.楼梯下:
                    return "/res/icons/background/24.png";
                case floor_type.黄门:
                    return "/res/icons/background/8.png";
                case floor_type.蓝门:
                    return "/res/icons/background/9.png";
                case floor_type.红门:
                    return "/res/icons/background/10.png";
                case floor_type.铁门:
                    return "/res/icons/background/11.png";
            }
            return null;
        }

        /**
         * 返回四张图片 形成动画
         */
        public static String[] getImagePaths(floor_type ftype)
        {
            switch (ftype)
            {
                case floor_type.熔浆:
                    return new string[] { "/res/icons/background/c0.png", "/res/icons/background/c1.png", "/res/icons/background/c2.png", "/res/icons/background/c3.png" };
                case floor_type.天空:
                    return new string[] { "/res/icons/background/c8.png", "/res/icons/background/c9.png", "/res/icons/background/c10.png", "/res/icons/background/c11.png" };
                case floor_type.商店中:
                    return new string[] { "/res/icons/background/29.png", "/res/icons/background/31.png", "/res/icons/background/29.png", "/res/icons/background/31.png" };
                case floor_type.黄门:
                    return new string[] { "/res/icons/background/8.png", "/res/icons/background/12.png", "/res/icons/background/16.png", "/res/icons/background/20.png" };
                case floor_type.蓝门:
                    return new string[] { "/res/icons/background/9.png", "/res/icons/background/13.png", "/res/icons/background/17.png", "/res/icons/background/21.png" };
                case floor_type.红门:
                    return new string[] { "/res/icons/background/10.png", "/res/icons/background/14.png", "/res/icons/background/18.png", "/res/icons/background/22.png" };
                case floor_type.铁门:
                    return new string[] { "/res/icons/background/11.png", "/res/icons/background/15.png", "/res/icons/background/19.png", "/res/icons/background/23.png" };
            }
            return null;
        }
    }
}
