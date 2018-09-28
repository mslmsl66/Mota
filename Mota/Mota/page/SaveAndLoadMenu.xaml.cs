using System.Windows.Controls;
using System.Windows.Media;
using Mota.CommonUtility;
using System.Windows;
using Mota.FileController;
using System.Collections.Generic;

namespace Mota.page
{
    /// <summary>
    /// SaveMenu.xaml 的交互逻辑
    /// </summary>
    public partial class SaveAndLoadMenu : Page
    {
        private static SaveAndLoadMenu instance;

        public static Canvas ToggleCanvas;

        private SaveAndLoadMenu()
        {
            InitializeComponent();
            InitPanelItem();
            ToggleCanvas = toggleItem;
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
        /// 更新Panel
        /// </summary>
        public void UpdatePanel()
        {
            PanelItem.Children.Clear();
            InitPanelItem();
        }

        /// <summary>
        /// 初始化存档栏
        /// </summary>
        private void InitPanelItem()
        {
            List<KeyValuePair<string, string>> list = LoadData.GetAllSavesDate();
            for (int i = 0; i < 8; i++)
            {
                AddChildCanvas("存档" + (i + 1), list[i].Key, list[i].Value);
            }
        }

        /// <summary>
        /// 向Panel添加显示存档独挡读档栏的Canvas
        /// </summary>
        private void AddChildCanvas(string text, string floor, string date)
        {
            Canvas parennt = new Canvas();
            if (floor != null && date != null)
            {
                TextBox textBox = WPFUtility.CreateTextBox(text, new SolidColorBrush(Color.FromRgb(255, 255, 255)), 80, 20);
                textBox.FontSize = 20;
                parennt.Children.Add(textBox);

                TextBox textBox2 = WPFUtility.CreateTextBox(floor+"F", new SolidColorBrush(Color.FromRgb(255, 255, 255)), 180, 20);
                textBox.FontSize = 20;
                parennt.Children.Add(textBox2);

                TextBox textBox3 = WPFUtility.CreateTextBox(date, new SolidColorBrush(Color.FromRgb(255, 255, 255)), 260, 20);
                textBox.FontSize = 20;
                parennt.Children.Add(textBox3);
            }
            else
            {
                TextBox textBox = WPFUtility.CreateTextBox("暂无存档", new SolidColorBrush(Color.FromRgb(255, 255, 255)), 245, 20);
                textBox.FontSize = 20;
                parennt.Children.Add(textBox);
            }

            #region 添加分割线
            Canvas canvas = new Canvas
            {
                Height = 3,
                Width = 550,
                Background = new SolidColorBrush(Color.FromRgb(200, 200, 200))
            };
            parennt.Children.Add(canvas);
            #endregion
            PanelItem.Children.Add(parennt);
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
    }
}
