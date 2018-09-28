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

        /// <summary>
        /// 全局播放器，专门用于播放背景音乐
        /// </summary>
        private static MediaPlayer player = new MediaPlayer();

        /// <summary>
        /// 标识左侧菜单栏位置
        /// </summary>
        private int itemNum = 0;

        /// <summary>
        /// 标识右侧菜单栏位置
        /// </summary>
        private int itemNumRight = 0;

        /// <summary>
        /// 标识是否进入菜单页
        /// </summary>
        public static bool isMenuOpened = false;

        /// <summary>
        /// 标识游戏是否开始
        /// </summary>
        public static bool isGameStarted = false;

        /// <summary>
        /// 标识是否读取记录进入游戏
        /// </summary>
        public static bool isContinue = false;

        /// <summary>
        /// 标识是否进入子菜单页
        /// </summary>
        public static bool isSecondMenuOpened = false;

        /// <summary>
        /// 背景音乐的url
        /// </summary>
        private static string url;

        private string se_success = "../../res/se/选项成功.MP3";
        private string se_fail = "../../res/se/选项失败.MP3";
        private string se_move = "../../res/se/选项移动.MP3";


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
        /// 播放特效音
        /// </summary>
        /// <param name="uri"></param>
        private void PlaySEMusic(string uri)
        {
            MediaPlayer p = new MediaPlayer();
            p.Open(new Uri(uri, UriKind.Relative));
            p.Play();
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
            if (!isGameStarted)
            {
                return;
            }
            // 读取记录的列表中
            if (isContinue)
            {
                switch (e.Key)
                {
                    case Key.Down:
                        Down();
                        break;
                    case Key.Up:
                        Up();
                        break;
                    case Key.Space:
                        // 读档
                        if (LoadData.Load("Save" + (itemNumRight + 1)))
                        {
                            // 成功
                            PlaySEMusic(se_success);
                            isContinue = false;
                            ShowMenuToggleItem(true);
                            ShowStateAndFloor();
                            itemNumRight = 0;
                        }
                        else
                        {
                            // 失败
                            PlaySEMusic(se_fail);
                        }
                        break;
                }
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
                        MonsterData.GetInstance().InitContentItem();
                        SaveAndLoadMenu.GetInstance();
                        break;
                }
            }
            // 菜单栏监听
            else
            {
                switch (e.Key)
                {
                    case Key.Down:
                        if (!isSecondMenuOpened)
                        {
                            // 左侧菜单
                            if (itemNum == 5)
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
                        }
                        else
                        {
                            Down();
                        }
                        PlaySEMusic(se_move);
                        break;
                    case Key.Up:
                        if (!isSecondMenuOpened)
                        {
                            if (itemNum == 0)
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
                        }
                        else
                        {
                            Up();
                        }
                        PlaySEMusic(se_move);
                        break;
                    case Key.Right:
                        if ((itemNum == 2 || itemNum == 3) && isSecondMenuOpened == false)
                        {
                            // 隐藏左侧闪烁条,显示右侧菜单选框
                            ShowMenuToggleItem(false);
                            isSecondMenuOpened = true;
                            PlaySEMusic(se_move);
                        }
                        break;
                    case Key.Left:
                        if ((itemNum == 2 || itemNum == 3) && isSecondMenuOpened == true)
                        {
                            // 显示左侧闪烁条，隐藏右侧菜单选框
                            ShowMenuToggleItem(true);
                            isSecondMenuOpened = false;
                            PlaySEMusic(se_move);
                        }
                        break;
                    case Key.Space:
                        if (isSecondMenuOpened)
                        {
                            if (itemNum == 2)
                            {
                                // 存档
                                SaveData.Save("Save" + (itemNumRight + 1));
                                SaveAndLoadMenu.GetInstance().UpdatePanel();
                                PlaySEMusic(se_success);
                            }
                            else
                            {
                                // 读档
                                if (LoadData.Load("Save" + (itemNumRight + 1)))
                                {
                                    // 成功
                                    PlaySEMusic(se_success);
                                    ExitMenu();
                                }
                                else
                                {
                                    // 失败
                                    PlaySEMusic(se_fail);
                                }
                            }
                        }
                        break;
                    case Key.Escape:
                        PlaySEMusic(se_move);
                        ExitMenu();
                        break;
                }
            }
        }
        
        /// <summary>
        /// 退出菜单页时，重设相关参数及页面显示等
        /// </summary>
        private void ExitMenu()
        {
            isMenuOpened = false;
            if (isSecondMenuOpened)
            {
                ShowMenuToggleItem(true);
                isSecondMenuOpened = false;
            }
            ShowStateAndFloor();
            Canvas.SetTop(MenuLeft.ToggleCanvas, 7);
            MonsterData.GetInstance().PanelItem.Children.Clear();
            itemNum = 0;
        }

        /// <summary>
        /// 显示或隐藏菜单栏闪烁条
        /// </summary>
        /// <param name="left">是否显示左侧闪烁条</param>
        private void ShowMenuToggleItem(bool left)
        {
            if (left)
            {
                MenuLeft.GetInstance().SetCanvasVisibility(true);
                SaveAndLoadMenu.GetInstance().SetCanvasVisibility(false);
            }
            else
            {
                MenuLeft.GetInstance().SetCanvasVisibility(false);
                SaveAndLoadMenu.GetInstance().SetCanvasVisibility(true);
            }
        }

        /// <summary>
        /// 显示状态栏和楼层
        /// </summary>
        private void ShowStateAndFloor()
        {
            GlobalLeft.Navigate(State.GetInstance());
            GlobalRight.Navigate(FloorFactory.GetInstance());
        }

        /// <summary>
        /// 按下键盘下键后，做处理
        /// </summary>
        private void Down()
        {
            if (itemNumRight == 7)
            {
                SaveAndLoadMenu.ToggleCanvas.Margin = new Thickness(0, 22, 0, 570);
                itemNumRight = 0;
            }
            else
            {
                SaveAndLoadMenu.ToggleCanvas.Margin = new Thickness(0, SaveAndLoadMenu.ToggleCanvas.Margin.Top + 78, 0, 570);
                itemNumRight++;
            }
            PlaySEMusic("../../res/se/选项移动.MP3");
        }

        /// <summary>
        /// 按下键盘上键后，做处理
        /// </summary>
        private void Up()
        {
            if (itemNumRight == 0)
            {
                SaveAndLoadMenu.ToggleCanvas.Margin = new Thickness(0, 568, 0, 570);
                itemNumRight = 7;
            }
            else
            {
                SaveAndLoadMenu.ToggleCanvas.Margin = new Thickness(0, SaveAndLoadMenu.ToggleCanvas.Margin.Top - 78, 0, 570);
                itemNumRight--;
            }
            PlaySEMusic("../../res/se/选项移动.MP3");
        }

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
                    GlobalRight.Navigate(SaveAndLoadMenu.GetInstance());
                    SaveAndLoadMenu.GetInstance().UpdatePanel();
                    break;
                case 3:
                    GlobalRight.Navigate(SaveAndLoadMenu.GetInstance());
                    SaveAndLoadMenu.GetInstance().UpdatePanel();
                    break;
            }
        }
    }
}