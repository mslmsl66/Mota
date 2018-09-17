using Mota.HeroCore;
using Mota.page;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Mota.CellImage
{
    public class NPCImage : StaticImageImpl
    {
        public MediaPlayer npcPlayer = new MediaPlayer();

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

        /// <summary>
        /// 对话内容
        /// </summary>
        private List<string> dialog = new List<string>();

        /// <summary>
        /// 对话进度计数
        /// </summary>
        private int j = 0;

        /// <summary>
        /// 对话框
        /// </summary>
        private TextBlock textBlock;

        /// <summary>
        /// 创建一个NPC
        /// </summary>
        /// <param name="type">NPC种类</param>
        /// <param name="dialog">对话内容</param>
        public NPCImage(NPCType type, List<string> dialog) : base()
        {
            dynamicPath = GetImagePaths(type);
            SetImageSource(dynamicPath);
            this.dialog = dialog;
            coarseType = Atype.NPC;
            fineType = type;
        }

        public override MediaPlayer GetPlayer()
        {
            return npcPlayer;
        }

        /// <summary>
        /// 与NPC进行对话
        /// </summary>
        public void ShowDialog()
        {
            textBlock = new TextBlock()
            {
                Height = 150,
                Width = 550,
                FontSize = 25,
                Text = dialog[j++],
                Background = new SolidColorBrush(Color.FromArgb(240, 80, 80, 80)),
                TextWrapping = System.Windows.TextWrapping.Wrap
            };
            Canvas.SetLeft(textBlock, 0);
            Canvas.SetBottom(textBlock, 0);
            Panel.SetZIndex(textBlock, 9);
            FloorFactory.canvas.Children.Add(textBlock);
        }

        /// <summary>
        /// 显示之后的对话
        /// </summary>
        public void NextText()
        {
            if (j >= dialog.Count)
            {
                FloorFactory.canvas.Children.Remove(textBlock);
                j = 0;
                Hero.GetInstance().IsTalking = false;
            }
            else
            {
                textBlock.Text = dialog[j++];
            }
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
