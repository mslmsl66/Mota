using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;

namespace Mota.page
{
    public partial class MenuLeft : Page
    {
        private static MenuLeft instance;

        /// <summary>
        /// 标记item闪烁
        /// </summary>
        private bool toggle = false;

        /// <summary>
        /// 闪烁item
        /// </summary>
        public static Canvas ToggleCanvas;

        public MenuLeft()
        {
            InitializeComponent();
            ToggleCanvas = toggleItem;
            ToggleItem();
        }
        public static MenuLeft GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuLeft();
            }
            return instance;
        }

        /// <summary>
        /// 显示或隐藏右侧菜单项
        /// </summary>
        /// <param name="toggle"></param>
        public void SetCanvasVisibility(bool toggle)
        {
            if (toggle)
            {
                toggleItem.Visibility = Visibility.Visible;
            }
            else
            {
                toggleItem.Visibility = Visibility.Hidden;
            }
        }

        private void ToggleItem()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
        }

        /// <summary>
        /// 定时器触发任务,循环切换图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            if (toggle == false)
            {
                toggleItem.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                toggle = true;
            }
            else
            {
                toggleItem.Background = new SolidColorBrush(Color.FromRgb(150, 150, 150));
                toggle = false;
            }
        }
    }
}
