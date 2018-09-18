using Mota.CommonUtility;
using Mota.FileController;
using Mota.HeroCore;
using Mota.page;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Mota
{
    /// <summary>
    /// 游戏窗口
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// 窗体右边框放置游戏主体，左边框设置状态栏
        /// </summary>
        public static Frame GlobalRight, GlobalLeft;

        public static Viewbox GlobalViewbox;

        private Hero hero = Hero.GetInstance();

        private static MediaPlayer player = new MediaPlayer();

        /// <summary>
        /// 标识菜单栏位置
        /// </summary>
        private int itemNum = 0;

        /// <summary>
        /// 标识是否进入菜单页
        /// </summary>
        private bool isMenuOpened = false;

        /// <summary>
        /// 背景音乐的url
        /// </summary>
        private static string url;

        public MainWindow()
        {
            InitializeComponent();
            right.Navigate(Index.GetInstance());
            GlobalRight = right;
            GlobalLeft = left;
            GlobalViewbox = viewbox;
        }

        /// <summary>
        /// 播放音频
        /// </summary>
        public static void PlayMusic(string url)
        {
            player.Open(new Uri(url, UriKind.Relative));
            player.Play();
            MainWindow.url = url;
            // 为播放器添加播放结束事件
            player.MediaEnded += new EventHandler(MediaEnded);
        }

        /// <summary>
        /// 循环播放，播放结束时被调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void MediaEnded(object sender, EventArgs e)
        {
            player.Open(new Uri(url, UriKind.Relative));
            player.Play();
        }

        /// <summary>
        /// 给窗口添加键盘事件,当楼层初始化后进行处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionKeyDown(object sender, KeyEventArgs e)
        {
            if (!FloorFactory.GetInstance().IsInitialize())
            {
                return;
            }
            //对话界面
            if (hero.IsTalking)
            {
                if (e.Key == Key.Space || e.Key == Key.Enter)
                {
                    hero.NPC.NextText();
                }
                return;
            }

            // 游戏界面中
            if (!isMenuOpened)
            {
                //英雄移动和菜单项开关
                switch (e.Key)
                {
                    case Key.Up:
                        hero.MoveUp();
                        break;
                    case Key.Down:
                        hero.MoveDown();
                        break;
                    case Key.Left:
                        hero.MoveLeft();
                        break;
                    case Key.Right:
                        hero.MoveRight();
                        break;
                    case Key.Escape:
                        isMenuOpened = true;
                        GlobalLeft.Navigate(MenuLeft.GetInstance());
                        GlobalRight.Navigate(MonsterData.GetInstance());
                        MonsterData.GetInstance().ShowContentItem();
                        break;
                }
            }
            else
            {
                //菜单栏监听
                double itemTop = Canvas.GetTop(MenuLeft.ToggleCanvas);
                switch (e.Key)
                {
                    case Key.Down:
                        if (itemTop == 257)
                        {
                            Canvas.SetTop(MenuLeft.ToggleCanvas, 7);
                            itemNum = 0;
                        }
                        else
                        {
                            Canvas.SetTop(MenuLeft.ToggleCanvas, Canvas.GetTop(MenuLeft.ToggleCanvas) + 50);
                            itemNum++;
                        }
                        ShowRightWindow(itemNum);
                        break;
                    case Key.Up:
                        if (itemTop == 7)
                        {
                            Canvas.SetTop(MenuLeft.ToggleCanvas, 257);
                            itemNum = 5;
                        }
                        else
                        {
                            Canvas.SetTop(MenuLeft.ToggleCanvas, Canvas.GetTop(MenuLeft.ToggleCanvas) - 50);
                            itemNum--;
                        }
                        ShowRightWindow(itemNum);
                        break;
                    case Key.Escape:
                        isMenuOpened = false;
                        GlobalLeft.Navigate(State.GetInstance());
                        GlobalRight.Navigate(FloorFactory.GetInstance());
                        Canvas.SetTop(MenuLeft.ToggleCanvas, 7);
                        MonsterData.GetInstance().ContentItem.Children.Clear();
                        itemNum = 0;
                        break;
                }
            }        }

        /// <summary>
        /// 根据左侧菜单栏显示右侧内容
        /// </summary>
        /// <param name="num"></param>
        private void ShowRightWindow(int num)
        {
            switch (num)
            {
                case 0:
                    GlobalRight.Navigate(MonsterData.GetInstance());
                    break;
                case 1:
                    GlobalRight.Navigate(AbilityIntroduction.GetInstance());
                    break;
                case 2:
                    SaveData.Save("Save1");
                    break;
                case 3:
                    LoadData.Load("Save1");
                    break;
            }

        }
    }
}