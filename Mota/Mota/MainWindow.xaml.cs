using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Mota.page;
using Mota.CommonUtility;

namespace Mota
{
    /// <summary>
    /// 游戏窗口
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public static Frame global_right,global_left;
        public static Viewbox global_viewbox;
        public MainWindow()
        {
            InitializeComponent();
            right.Navigate(Index.getInstance());
            global_right = right;
            global_left = left;
            global_viewbox = viewbox;
        }

        /// <summary>
        /// 给窗口添加键盘事件，当楼层初始化后进行处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directionKeyDown(object sender, KeyEventArgs e)
        {
            if (!FloorFactory.isInitialize())
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Up:
                    FloorFactory.getInstance().move(Key.Up);
                    break;
                case Key.Down:
                    FloorFactory.getInstance().move(Key.Down);
                    break;
                case Key.Left:
                    FloorFactory.getInstance().move(Key.Left);
                    break;
                case Key.Right:
                    FloorFactory.getInstance().move(Key.Right);
                    break;
            }
        }
    }
}