using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mota.page
{
    /// <summary>
    /// 游戏主页面窗口（开始游戏、继续、结束）
    /// </summary>
    public partial class Index : Page
    {
        private static Index instance;
        private Index()
        {
            InitializeComponent();
        }

        public static Index GetInstance()
        {
            if (instance == null)
            {
                instance = new Index();
            }
            return instance;
        }

        /// <summary>
        /// 按钮点击事件,给panel重设置page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartClick(object sender, RoutedEventArgs e)
        {
            MainWindow.PlayMusic("../../res/bgm/0层声音.MP3");
            MainWindow.GlobalViewbox.Stretch = Stretch.Fill;
            MainWindow.GlobalLeft.Navigate(State.GetInstance());
            MainWindow.GlobalRight.Navigate(FloorFactory.GetInstance());
            MainWindow.isGameStarted = true;
        }
        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            MainWindow.isContinue = true;
            StartClick(sender,e);
            MainWindow.GlobalLeft.Navigate(MenuLeft.GetInstance());
            MainWindow.GlobalRight.Navigate(SaveAndLoadMenu.GetInstance());

            // 隐藏左侧闪烁条,显示右侧菜单选框
            MenuLeft.GetInstance().SetCanvasVisibility(false);
            SaveAndLoadMenu.GetInstance().SetCanvasVisibility(true);
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {

            // NavigationService.GetNavigationService(this).Navigate(newUri("Page1.xaml", UriKind.Relative));

            // NavigationService.GetNavigationService(this).GoForward();//向后转
        }
    }
}
