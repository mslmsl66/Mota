using Mota.CellImage;
using Mota.CommonUtility;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mota.page
{
    /// <summary>
    /// MenuRight.xaml 的交互逻辑
    /// </summary>
    public partial class MonsterData : Page
    {
        private static MonsterData instance;

        private MonsterData()
        {
            InitializeComponent();
        }

        public static MonsterData GetInstance()
        {
            if (instance == null)
            {
                instance = new MonsterData();
            }
            return instance;
        }

        /// <summary>
        /// 显示怪物资料
        /// </summary>
        public void ShowContentItem()
        {
            List<MonsterType> monsterList = new List<MonsterType>();
            foreach (MonsterImage monster in MapUtility.MonsterList)
            {
                if (!monsterList.Contains((MonsterType)monster.GetFineType()))
                {
                    monsterList.Add((MonsterType)monster.GetFineType());
                    AddChildCanvas(monster);
                }
            }
        }

        /// <summary>
        /// 创建一个TextBox
        /// </summary>
        /// <param name="text">文字内容</param>
        /// <param name="color">字体颜色</param>
        /// <param name="left">离左边的距离</param>
        /// <param name="top">离顶部的距离</param>
        /// <returns></returns>
        private TextBox CreateTextBox(string text, SolidColorBrush color, int left, int top)
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

        /// <summary>
        /// 向Panel添加显示怪物资料的Canvas
        /// </summary>
        private void AddChildCanvas(MonsterImage monster)
        {
            Canvas parennt = new Canvas();
            #region 添加怪物图片
            Image image = new Image
            {
                Source = new BitmapImage(new Uri(MonsterImage.GetImagePaths((MonsterType)monster.GetFineType())[0], UriKind.Relative)),
                Height = 50,
                Width = 50,
                Margin = new Thickness(10)
            };
            parennt.Children.Add(image);
            #endregion

            #region 添加怪物名称
            TextBox name = CreateTextBox(monster.GetFineType().ToString(), new SolidColorBrush(Color.FromRgb(255, 255, 255)), 80, 10);
            parennt.Children.Add(name);
            #endregion

            #region 添加怪物特殊能力
            TextBox ability = CreateTextBox(monster.Ability.ToString(), new SolidColorBrush(Color.FromRgb(255, 255, 255)), 80, 35);
            parennt.Children.Add(ability);
            #endregion

            #region 添加怪物血量
            TextBox hp = CreateTextBox("血量:" + monster.Hp, new SolidColorBrush(Color.FromRgb(209, 133, 42)), 200, 10);
            parennt.Children.Add(hp);
            #endregion

            #region 添加怪物攻击
            TextBox atk = CreateTextBox("攻击:" + monster.Atk, new SolidColorBrush(Color.FromRgb(209, 133, 42)), 310, 10);
            parennt.Children.Add(atk);
            #endregion

            #region 添加怪物防御
            TextBox def = CreateTextBox("防御:" + monster.Def, new SolidColorBrush(Color.FromRgb(209, 133, 42)), 420, 10);
            parennt.Children.Add(def);
            #endregion

            #region 添加获得的金币
            TextBox gold = CreateTextBox("金币:" + monster.Gold, new SolidColorBrush(Color.FromRgb(185, 185, 40)), 200, 35);
            parennt.Children.Add(gold);
            #endregion

            #region 添加获得的经验
            TextBox exp = CreateTextBox("经验:" + monster.Exp, new SolidColorBrush(Color.FromRgb(185, 185, 40)), 310, 35);
            parennt.Children.Add(exp);
            #endregion

            #region 添加打怪的损失
            string damage = CalculationUtility.CalculateDamage(monster) + "";
            if ("-1".Equals(damage))
            {
                damage = "？？？";
            }
            TextBox damageText = CreateTextBox("伤害:" + damage, new SolidColorBrush(Color.FromRgb(180, 45, 45)), 420, 35);
            parennt.Children.Add(damageText);
            #endregion

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
    }
}