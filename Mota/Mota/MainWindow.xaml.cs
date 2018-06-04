using Mota.CommonUtility;
using Mota.page;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        /// 标识菜单栏位置
        /// </summary>
        private int itemNum = 0;

        /// <summary>
        /// 标识是否进入菜单页
        /// </summary>
        private bool isMenuOpened = false;

        public MainWindow()
        {
            InitializeComponent();
            right.Navigate(Index.GetInstance());
            GlobalRight = right;
            GlobalLeft = left;
            GlobalViewbox = viewbox;
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
            //菜单项监听
            if (isMenuOpened)
            {
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
                        break;
                    case Key.Enter:
                        //切换菜单项右边的显示
                        switch (itemNum)
                        {
                            case 0:
                                GlobalRight.Navigate(MonsterData.GetInstance());
                                break;
                            case 1:
                                GlobalRight.Navigate(AbilityIntroduction.GetInstance());
                                break;
                            case 4:
                                //isMenuOpened = false;
                                //GlobalLeft.Navigate(State.GetInstance());
                                //GlobalRight.Navigate(FloorFactory.GetInstance());
                                //FloorFactory.GetInstance().CoreMap();
                                break;
                        }
                        break;
                    case Key.Escape:
                        GlobalLeft.Navigate(MenuLeft.GetInstance());
                        GlobalRight.Navigate(MonsterData.GetInstance());
                        MonsterData.GetInstance().ShowContentItem();
                        break;
                }
            }
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
                    if (isMenuOpened)
                    {
                        isMenuOpened = false;
                        GlobalLeft.Navigate(State.GetInstance());
                        GlobalRight.Navigate(FloorFactory.GetInstance());
                        Canvas.SetTop(MenuLeft.ToggleCanvas, 7);
                        MonsterData.GetInstance().ContentItem.Children.Clear();
                    }
                    else
                    {
                        isMenuOpened = true;
                        GlobalLeft.Navigate(MenuLeft.GetInstance());
                        GlobalRight.Navigate(MonsterData.GetInstance());
                        MonsterData.GetInstance().ShowContentItem();
                    }
                    break;
            }
        }
    }
}