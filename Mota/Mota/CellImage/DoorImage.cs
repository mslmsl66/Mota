using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Mota.CellImage
{
    public class DoorImage : DynamicImageImpl
    {
        public MediaPlayer doorPlayer = new MediaPlayer();

        public DoorImage(DoorType type) : base()
        {
            SetImageSource(GetImagePath(type));
            //实现开门效果的数组
            dynamicPath = GetImagePaths(type);
            coarseType = Atype.门;
            fineType = type;
        }

        public override MediaPlayer GetPlayer()
        {
            return doorPlayer;
        }

        /// <summary>
        /// 切换四张图片,实现开门效果，并播放音效
        /// </summary>
        /// <param name="o"></param>
        public override void HideImage()
        {
            isImageExist = false;
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(50)
            };
            timer.Tick += new EventHandler(ChangeTick);
            timer.Start();
        }

        private void ChangeTick(object sender, EventArgs e)
        {
            if (i == 3)
            {
                Source = new BitmapImage(new Uri("/res/icons/background/0.png", UriKind.Relative));
                timer.Stop();
                return;
            }
            Source = new BitmapImage(new Uri(dynamicPath[i++], UriKind.Relative));
        }

        /// <summary>
        /// 返回单个图片路径
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static String GetImagePath(DoorType type)
        {
            switch (type)
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
        /// 返回四张图片路径,形成动画
        /// </summary>
        /// <param name="ftype">何种类型的门</param>
        /// <returns></returns>
        public String[] GetImagePaths(DoorType type)
        {
            switch (type)
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
