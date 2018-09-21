using System.Windows.Controls;
using System.Windows.Media;
using Mota.CommonUtility;
using System.Windows;

namespace Mota.page
{
    /// <summary>
    /// SaveMenu.xaml 的交互逻辑
    /// </summary>
    public partial class SaveAndLoadMenu : Page
    {
        private static SaveAndLoadMenu instance;

        private SaveAndLoadMenu()
        {
            InitializeComponent();
        }

        public static SaveAndLoadMenu GetInstance()
        {
            if (instance == null)
            {
                instance = new SaveAndLoadMenu();
            }
            return instance;
        }

        /// <summary>
        /// 初始化存档栏
        /// </summary>
        public void InitContentItem()
        {
            for (int i = 0; i < 8; i++)
            {
                AddChildCanvas("存档" + (i + 1));
            }
        }

        /// <summary>
        /// 向Panel添加显示存档独挡读档栏的Canvas
        /// </summary>
        private void AddChildCanvas(string text)
        {
            Canvas parennt = new Canvas();
            TextBox textBox = WPFUtility.CreateTextBox(text, new SolidColorBrush(Color.FromRgb(255, 255, 255)), 245, 20);
            textBox.FontSize = 25;
            parennt.Children.Add(textBox);
            #region 添加分割线
            Canvas canvas = new Canvas
            {
                Height = 3,
                Width = 550,
                Background = new SolidColorBrush(Color.FromRgb(200, 200, 200))
            };
            parennt.Children.Add(canvas);
            #endregion
            ContentItem.Children.Add(parennt);
        }

        /// <summary>
        /// 显示或隐藏右侧菜单项
        /// </summary>
        /// <param name="toggle"></param>
        private void SetCanvasVisibility(bool toggle)
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
    }
}
