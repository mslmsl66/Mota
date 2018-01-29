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

/// <summary>
/// Todo List
/// 1.CellImage CoreMap改变clear children逻辑
/// </summary>
namespace Mota
{
    /// <summary>
    /// 游戏窗口
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame GlobalRight, GlobalLeft;
        public static Viewbox GlobalViewbox;
        public MainWindow()
        {
            InitializeComponent();
            right.Navigate(Index.GetInstance());
            GlobalRight = right;
            GlobalLeft = left;
            GlobalViewbox = viewbox;
        }

        /// <summary>
        /// 给窗口添加键盘事件，当楼层初始化后进行处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DirectionKeyDown(object sender, KeyEventArgs e)
        {
            if (!FloorFactory.GetInstance().IsInitialize())
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Up:
                    Hero.getInstance().MoveUp();
                    break;
                case Key.Down:
                    Hero.getInstance().MoveDown();
                    break;
                case Key.Left:
                    Hero.getInstance().MoveLeft();
                    break;
                case Key.Right:
                    Hero.getInstance().MoveRight();
                    break;
            }
        }
    }
}