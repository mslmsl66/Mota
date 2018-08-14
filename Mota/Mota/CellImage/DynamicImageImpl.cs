using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Mota.CellImage
{
    public class DynamicImageImpl : Image, IDynamicImage
    {
        /// <summary>
        /// 动态图片有四张,切换图片形成动画
        /// </summary>
        internal string[] dynamicPath;

        /// <summary>
        /// 切换动态图片计数
        /// </summary>
        internal int i = 0;

        /// <summary>
        /// 实现动态地图的定时器
        /// </summary>
        internal DispatcherTimer timer;

        /// <summary>
        /// 标记图片是否还存在
        /// </summary>
        public bool isImageExist = true;

        /// <summary>
        /// 细类型
        /// </summary>
        internal Enum fineType;

        /// <summary>
        /// 粗类型
        /// </summary>
        internal Atype coarseType;

        public DynamicImageImpl()
        {
            Height = 50;
            Width = 50;
        }

        /// <summary>
        /// 读取动态图图片路径,开启定时器实现动态图片
        /// </summary>
        public void SetImageSource(string[] dynamicPath)
        {
            this.dynamicPath = dynamicPath;
            Source = new BitmapImage(new Uri(dynamicPath[i], UriKind.Relative));
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(DTimerTick);
            timer.Start();
        }

        /// <summary>
        /// 设置静态图片路径
        /// </summary>
        /// <param name="path">图片路径</param>
        public void SetImageSource(string path)
        {
            Source = new BitmapImage(new Uri(path, UriKind.Relative));
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
        /// 隐藏图片,更改为地板
        /// </summary>
        public virtual void HideImage()
        {
            Source = new BitmapImage(new Uri("/res/icons/background/0.png", UriKind.Relative));
            if (timer != null)
            {
                timer.Stop();
            }
            isImageExist = false;
            coarseType = Atype.地板;
            fineType = FloorType.地板;
        }

        public Atype GetCoarseType()
        {
            return coarseType;
        }

        public Enum GetFineType()
        {
            return fineType;
        }

        public virtual void PlayMusic(MediaPlayer player,string url)
        {
            player.Open(new Uri(url, UriKind.Relative));
            player.Play();
        }

        public virtual MediaPlayer GetPlayer()
        {
            return null;
        }

        bool IBaseImage.isImageExist()
        {
            return isImageExist;
        }
    }
}
