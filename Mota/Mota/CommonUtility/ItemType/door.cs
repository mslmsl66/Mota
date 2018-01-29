using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class Door
    {
        public static String GetImagePath(DoorType ftype)
        {
            switch (ftype)
            {
                case DoorType.黄门:
                    return "/res/icons/background/8.png";
                case DoorType.蓝门:
                    return "/res/icons/background/9.png";
                case DoorType.红门:
                    return "/res/icons/background/10.png";
                case DoorType.铁门:
                    return "/res/icons/background/11.png";
            }
            return null;
        }

        /// <summary>
        /// 返回四张图片 形成动画
        /// </summary>
        /// <param name="ftype">何种类型的门</param>
        /// <returns></returns>
        public static String[] GetImagePaths(DoorType ftype)
        {
            switch (ftype)
            {
                //case door_type.商店中:
                //   return new string[] { "/res/icons/background/29.png", "/res/icons/background/31.png", "/res/icons/background/29.png", "/res/icons/background/31.png" };
                case DoorType.黄门:
                    return new string[] { "/res/icons/background/12.png", "/res/icons/background/16.png", "/res/icons/background/20.png" };
                case DoorType.蓝门:
                    return new string[] { "/res/icons/background/13.png", "/res/icons/background/17.png", "/res/icons/background/21.png" };
                case DoorType.红门:
                    return new string[] { "/res/icons/background/14.png", "/res/icons/background/18.png", "/res/icons/background/22.png" };
                case DoorType.铁门:
                    return new string[] { "/res/icons/background/15.png", "/res/icons/background/19.png", "/res/icons/background/23.png" };
            }
            return null;
        }
    }

    public enum DoorType { 黄门, 蓝门, 红门, 铁门 };
}