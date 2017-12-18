using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Mota.CommonUtility.ItemType;
using System.Windows.Threading;

namespace Mota.CommonUtility
{
    /// <summary>
    /// 作为地图小方块的基础类，为方便设计，分类地图上物品的类型 
    /// </summary>
    public class CellImage : Image
    {
        private string[] dynamic_path;
        int i = 0;
        public enum atype { 宝石, 钥匙, 怪物, 特殊物品, 地板, 英雄};

        /// <summary>
        /// </summary>
        /// <param name="a">粗分类,eg:怪物</param>
        /// <param name="e">细分类,eg:绿史莱姆</param>
        /// <param name="isDynamic">是否动图</param>
        public CellImage(atype a, Enum e, bool isDynamic = false)
        {
            //图片路径
            string path = null;
            //动态图片有四张，切换图片形成动画
            string[] dynamic_path = null;
            switch (a)
            {
                case atype.宝石:
                    path = gemstone.getImagePath((gemstone.gemstone_type)e);
                    break;

                case atype.钥匙:
                    path = key.getImagePath((key.key_type)e);
                    break;

                case atype.怪物:
                    dynamic_path = null;
                    break;

                case atype.特殊物品:
                    path = special_item.getImagePath((special_item.special_item_type)e);
                    break;

                case atype.英雄:
                    path = "/res/icons/characters/hero0.png"; 
                    break;

                case atype.地板:
                    if (isDynamic == true)
                    {
                        dynamic_path = floor.getImagePaths((floor.floor_type)e);
                    }
                    else
                    {
                        path = floor.getImagePath((floor.floor_type)e);
                    } 
                    break;
            }
            if (path != null)
            {
                setImageSource(path);
            }
            else if(dynamic_path != null)
            {
                this.dynamic_path = dynamic_path;
                setImageSource();
            }
        }

        /// <summary>
        /// 设置图片路径
        /// </summary>
        /// <param name="path">图片路径</param>
        private void setImageSource(string path)
        {
            this.Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        /// <summary>
        /// 读取动态图图片路径，开启定时器实现动态图片
        /// </summary>
        private void setImageSource()
        {
            this.Source = new BitmapImage(new Uri(dynamic_path[i], UriKind.Relative));
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(dTimer_Tick);
            timer.Start();
        }

        /// <summary>
        /// 定时器触发任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dTimer_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 4)
            {
                i = 0;
            }
            this.Source = new BitmapImage(new Uri(dynamic_path[i], UriKind.Relative));   
        }
    }
}
