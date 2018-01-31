using System;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Mota.CellImage
{
    public class NPCImage : StaticImageImpl
    {
        /// <summary>
        /// 动态图片有四张,切换图片形成动画
        /// </summary>
        private string[] dynamicPath;

        /// <summary>
        /// 切换动态图片计数
        /// </summary>
        private int i = 0;

        /// <summary>
        /// 实现动态地图的定时器
        /// </summary>
        private DispatcherTimer timer;

        public NPCImage(NPCType type) : base()
        {
            dynamicPath = GetImagePaths(type);
            SetImageSource(dynamicPath);
            coarseType = Atype.NPC;
            fineType = type;
        }

        /// <summary>
        /// 读取动态图图片路径,开启定时器实现动态图片
        /// </summary>
        private void SetImageSource(string[] dynamicPath)
        {
            Source = new BitmapImage(new Uri(dynamicPath[i], UriKind.Relative));
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500)
            };
            timer.Tick += new EventHandler(DTimerTick);
            timer.Start();
        }

        /// <summary>
        /// 定时器触发任务,循环切换四张图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DTimerTick(object sender, EventArgs e)
        {
            i++;
            if (i == 4)
            {
                i = 0;
            }
            Source = new BitmapImage(new Uri(dynamicPath[i], UriKind.Relative));
        }

        /// <summary>
        /// 返回四张图片 形成动画
        /// </summary>
        /// <param name="mtype"></param>
        /// <returns></returns>
        public static String[] GetImagePaths(NPCType type)
        {
            switch (type)
            {
                case NPCType.老人:
                    return new string[] { "/res/icons/characters/NPC01-01.png", "/res/icons/characters/NPC01-02.png", "/res/icons/characters/NPC01-03.png", "/res/icons/characters/NPC01-04.png" };
                case NPCType.商人:
                    return new string[] { "/res/icons/characters/NPC02-01.png", "/res/icons/characters/NPC02-02.png", "/res/icons/characters/NPC02-03.png", "/res/icons/characters/NPC02-04.png" };
                case NPCType.小偷:
                    return new string[] { "/res/icons/characters/NPC03-01.png", "/res/icons/characters/NPC03-02.png", "/res/icons/characters/NPC03-03.png", "/res/icons/characters/NPC03-04.png" };
                case NPCType.仙子:
                    return new string[] { "/res/icons/characters/NPC04-01.png", "/res/icons/characters/NPC04-02.png", "/res/icons/characters/NPC04-03.png", "/res/icons/characters/NPC04-04.png" };
                case NPCType.奇怪的老人:
                    return new string[] { "/res/icons/characters/NPC05-01.png", "/res/icons/characters/NPC05-02.png", "/res/icons/characters/NPC05-03.png", "/res/icons/characters/NPC05-04.png" };
            }
            return null;
        }
    }
    public enum NPCType { 老人, 商人, 小偷, 仙子, 奇怪的老人 };
}
