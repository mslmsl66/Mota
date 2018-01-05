using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Mota.CommonUtility.ItemType;
using System.Windows.Threading;
using System.Threading;

namespace Mota.CommonUtility
{
    /// <summary>
    /// 作为地图小方块的基础类，为方便设计，分类地图上物品的类型 
    /// </summary>
    public class CellImage : Image
    {
        public enum Atype { 宝石, 钥匙, 怪物, 特殊物品, 地板, 英雄, 门 };

        /// <summary>
        /// 存放动图中各张图片的路径
        /// </summary>
        private string[] dynamic_path;

        /// <summary>
        /// 存放图片动态消失的路径
        /// </summary>
        private string[] hide_path;

        /// <summary>
        /// 图片切换计数
        /// </summary>
        int i = 0, j = 0;

        /// <summary>
        /// 实现图片动态消失的定时器
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// 粗分类、细分类
        /// </summary>
        private Atype coarse_classification;
        private Enum fine_classification;

        /// <summary>
        /// </summary>
        /// <param name="a">粗分类,eg:怪物</param>
        /// <param name="e">细分类,eg:绿史莱姆</param>
        /// <param name="isDynamic">是否动图</param>
        public CellImage(Atype a, Enum e, bool isDynamic = false)
        {
            this.coarse_classification = a;
            this.fine_classification = e;
            //图片路径
            string path = null;
            //动态图片有四张，切换图片形成动画
            string[] dynamic_path = null;
            switch (a)
            {
                case Atype.宝石:
                    path = Gemstone.GetImagePath((Gemstone.GemstoneType)e);
                    break;

                case Atype.钥匙:
                    path = Key.GetImagePath((Key.KeyType)e);
                    break;

                case Atype.怪物:
                    dynamic_path = Monster.GetImagePaths((Monster.MonsterType)e);
                    break;

                case Atype.特殊物品:
                    path = SpecialItem.GetImagePath((SpecialItem.SpecialItemType)e);
                    break;

                case Atype.英雄:
                    path = "/res/icons/characters/hero0.png";
                    break;

                case Atype.地板:
                    if (isDynamic == true)
                    {
                        dynamic_path = Floor.GetImagePaths((Floor.FloorType)e);
                    }
                    else
                    {
                        path = Floor.GetImagePath((Floor.FloorType)e);
                    }
                    break;
                case Atype.门:
                    path = Door.GetImagePath((Door.DoorType)e);
                    break;
            }
            if (path != null)
            {
                SetImageSource(path);
            }
            else if (dynamic_path != null)
            {
                this.dynamic_path = dynamic_path;
                SetImageSource();
            }
        }

        /// <summary>
        /// 设置图片路径
        /// </summary>
        /// <param name="path">图片路径</param>
        private void SetImageSource(string path)
        {
            this.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        /// <summary>
        /// 读取动态图图片路径，开启定时器实现动态图片
        /// </summary>
        private void SetImageSource()
        {
            this.Source = new BitmapImage(new Uri(dynamic_path[i], UriKind.Relative));
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(DTimerTick);
            timer.Start();
        }

        /// <summary>
        /// 定时器触发任务，循环切换四张图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DTimerTick(object sender, EventArgs e)
        {
            i++;
            if (i == 4)
            {
                i = 0;
            }
            this.Source = new BitmapImage(new Uri(dynamic_path[i], UriKind.Relative));
        }

        public Atype GetCoarseType()
        {
            return coarse_classification;
        }

        public Enum GetFineType()
        {
            return fine_classification;
        }

        /// <summary>
        /// 判断英雄触碰的类型，执行图片更改
        /// </summary>
        /// <param name="e"></param>
        public void HideImage(CellImage.Atype a, Enum e = null)
        {
            if (a == Atype.门)
            {
                hide_path = Door.GetImagePaths((Door.DoorType)e); ;
                ChangeImage(hide_path);
            }
            else
            {
                this.Source = new BitmapImage(new Uri("/res/icons/background/0.png", UriKind.Relative));
                coarse_classification = Atype.地板;
                fine_classification = Floor.FloorType.地板;
            }
        }

        /// <summary>
        /// 切换四张图片，实现关门效果
        /// </summary>
        /// <param name="o"></param>
        private void ChangeImage(String[] imageStr)
        {
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(100)
            };
            timer.Tick += new EventHandler(ChangeTick);
            timer.Start();
        }

        private void ChangeTick(object sender, EventArgs e)
        {
            if (j == 3)
            {
                this.Source = new BitmapImage(new Uri("/res/icons/background/0.png", UriKind.Relative));
                coarse_classification = Atype.地板;
                fine_classification = Floor.FloorType.地板;
                timer.Stop();

                return;
            }
            this.Source = new BitmapImage(new Uri(hide_path[j++], UriKind.Relative));
        }
    }
}