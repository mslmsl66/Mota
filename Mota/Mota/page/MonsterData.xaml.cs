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
        /// 初始化怪物资料
        /// </summary>
        public void InitContentItem()
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
            TextBox name = WPFUtility.CreateTextBox(monster.GetFineType().ToString(), new SolidColorBrush(Color.FromRgb(255, 255, 255)), 80, 10);
            parennt.Children.Add(name);
            #endregion

            #region 添加怪物特殊能力
            TextBox ability = WPFUtility.CreateTextBox(monster.Ability.ToString(), new SolidColorBrush(Color.FromRgb(255, 255, 255)), 80, 35);
            parennt.Children.Add(ability);
            #endregion

            #region 添加怪物血量
            TextBox hp = WPFUtility.CreateTextBox("血量:" + monster.Hp, new SolidColorBrush(Color.FromRgb(209, 133, 42)), 200, 10);
            parennt.Children.Add(hp);
            #endregion

            #region 添加怪物攻击
            TextBox atk = WPFUtility.CreateTextBox("攻击:" + monster.Atk, new SolidColorBrush(Color.FromRgb(209, 133, 42)), 310, 10);
            parennt.Children.Add(atk);
            #endregion

            #region 添加怪物防御
            TextBox def = WPFUtility.CreateTextBox("防御:" + monster.Def, new SolidColorBrush(Color.FromRgb(209, 133, 42)), 420, 10);
            parennt.Children.Add(def);
            #endregion

            #region 添加获得的金币
            TextBox gold = WPFUtility.CreateTextBox("金币:" + monster.Gold, new SolidColorBrush(Color.FromRgb(185, 185, 40)), 200, 35);
            parennt.Children.Add(gold);
            #endregion

            #region 添加获得的经验
            TextBox exp = WPFUtility.CreateTextBox("经验:" + monster.Exp, new SolidColorBrush(Color.FromRgb(185, 185, 40)), 310, 35);
            parennt.Children.Add(exp);
            #endregion

            #region 添加打怪的损失
            string damage = CalculationUtility.CalculateDamage(monster) + "";
            if ("-1".Equals(damage))
            {
                damage = "？？？";
            }
            TextBox damageText = WPFUtility.CreateTextBox("伤害:" + damage, new SolidColorBrush(Color.FromRgb(180, 45, 45)), 420, 35);
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
            PanelItem.Children.Add(parennt);
        }
    }
}