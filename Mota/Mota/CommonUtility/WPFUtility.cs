using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mota.CommonUtility
{
    public class WPFUtility
    {
        /// <summary>
        /// 创建一个TextBox
        /// </summary>
        /// <param name="text">文字内容</param>
        /// <param name="color">字体颜色</param>
        /// <param name="left">离左边的距离</param>
        /// <param name="top">离顶部的距离</param>
        /// <returns></returns>
        public static TextBox CreateTextBox(string text, SolidColorBrush color, int left, int top)
        {
            TextBox textBox = new TextBox
            {
                Text = text,
                FontSize = 20,
                FontWeight = FontWeight.FromOpenTypeWeight(999),
                Foreground = color,
                Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255)),
                BorderThickness = new Thickness(0)
            };
            Canvas.SetLeft(textBox, left);
            Canvas.SetTop(textBox, top);
            return textBox;
        }
    } 
}
