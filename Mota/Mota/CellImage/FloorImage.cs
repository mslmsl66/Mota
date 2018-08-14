using System;
using System.Windows.Media;

namespace Mota.CellImage
{
    public class FloorImage : DynamicImageImpl
    {
        public MediaPlayer floorPlayer = new MediaPlayer();

        public FloorImage(FloorType type) : base()
        {
            if (type == FloorType.熔浆 || type == FloorType.天空)
            {
                SetImageSource(GetImagePaths(type));
            }
            else
            {
                SetImageSource(GetImagePath(type));
            }
            coarseType = Atype.地板;
            fineType = type;
        }

        public override MediaPlayer GetPlayer()
        {
            return floorPlayer;
        }

        public String GetImagePath(FloorType type)
        {
            switch (type)
            {
                case FloorType.地板:
                    return "/res/icons/background/0.png";
                case FloorType.木墙:
                    return "/res/icons/background/1.png";
                case FloorType.蓝墙:
                    return "/res/icons/background/2.png";
                case FloorType.银墙:
                    return "/res/icons/background/3.png";
                case FloorType.黄墙:
                    return "/res/icons/background/b2.png";
                case FloorType.紫墙:
                    return "/res/icons/background/b0.png";
                case FloorType.白墙:
                    return "/res/icons/background/b1.png";
                case FloorType.商店左:
                    return "/res/icons/background/28.png";
                case FloorType.商店右:
                    return "/res/icons/background/30.png";
                case FloorType.楼梯上:
                    return "/res/icons/background/25.png";
                case FloorType.楼梯下:
                    return "/res/icons/background/24.png";
            }
            return null;
        }

        /**
         * 返回四张图片 形成动画
         */
        public String[] GetImagePaths(FloorType type)
        {
            switch (type)
            {
                case FloorType.熔浆:
                    return new string[] { "/res/icons/background/c0.png", "/res/icons/background/c1.png", "/res/icons/background/c2.png", "/res/icons/background/c3.png" };
                case FloorType.天空:
                    return new string[] { "/res/icons/background/c8.png", "/res/icons/background/c9.png", "/res/icons/background/c10.png", "/res/icons/background/c11.png" };
            }
            return null;
        }
    }
    public enum FloorType { 地板, 木墙, 蓝墙, 银墙, 黄墙, 紫墙, 白墙, 天空, 熔浆, 商店左, 商店右, 楼梯上, 楼梯下 };
}
