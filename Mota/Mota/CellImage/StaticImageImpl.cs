using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Mota.CellImage
{
    /// <summary>
    /// 作为地图小方块的基础类
    /// </summary>
    public class StaticImageImpl : Image, IBaseImage
    {
        /// <summary>
        /// 标记图片是否还存在
        /// </summary>
        public bool isImageExist = true;

        /// <summary>
        /// 细类型
        /// </summary>
        internal Enum fineType;

        /// <summary>
        /// 粗类型
        /// </summary>
        internal Atype coarseType;

        public StaticImageImpl()
        {
            Height = 50;
            Width = 50;
        }

        /// <summary>
        /// 设置图片路径
        /// </summary>
        /// <param name="path">图片路径</param>
        public void SetImageSource(string path)
        {
            Source = new BitmapImage(new Uri(path, UriKind.Relative));
        }

        /// <summary>
        /// 隐藏图片,更改为地板
        /// </summary>
        public void HideImage()
        {
            Source = new BitmapImage(new Uri("/res/icons/background/0.png", UriKind.Relative));
        }

        public Atype GetCoarseType()
        {
            return coarseType;
        }

        public Enum GetFineType()
        {
            return fineType;
        }

        public void PlayMusic(MediaPlayer player,string url)
        {
            player.Open(new Uri(url, UriKind.Relative));
            player.Play();
        }

        public virtual MediaPlayer GetPlayer()
        {
            return null;
        }

        bool IBaseImage.isImageExist()
        {
            return isImageExist;
        }
    } 

    public enum Atype { 宝石, 钥匙, 怪物, 特殊物品, 地板, 英雄, 门, NPC };
}