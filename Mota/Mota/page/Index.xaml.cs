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

        public static Index getInstance()
        {
            if (instance == null)
            {
                instance = new Index();
            }
            return instance;
        }

        /// <summary>
        /// 按钮点击事件，给panel重设置page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartClick(object sender, RoutedEventArgs e)
        {
            MainWindow.global_viewbox.Stretch = Stretch.Fill;
            MainWindow.global_left.Navigate(State.getInstance());
            MainWindow.global_right.Navigate(FloorFactory.getInstance());
        }
        private void ContinueClick(object sender, RoutedEventArgs e)
        {

            // NavigationService.GetNavigationService(this).Navigate(newUri("Page1.xaml", UriKind.Relative));

            // NavigationService.GetNavigationService(this).GoForward();//向后转
        }
        private void ExitClick(object sender, RoutedEventArgs e)
        {

            // NavigationService.GetNavigationService(this).Navigate(newUri("Page1.xaml", UriKind.Relative));

            // NavigationService.GetNavigationService(this).GoForward();//向后转
        }
    }
}
