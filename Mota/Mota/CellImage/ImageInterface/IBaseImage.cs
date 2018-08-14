using System;
using System.Windows.Media;

namespace Mota.CellImage
{
    public interface IBaseImage
    {
        /// <summary>
        /// 隐藏图片,更改为地板
        /// </summary>
        void HideImage();

        /// <summary>
        /// 获取图片类型
        /// </summary>
        Atype GetCoarseType();

        /// <summary>
        /// 获取具体类型
        /// </summary>
        Enum GetFineType();

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="player">播放器对象，每个Image都需要有自己的播放器，避免音频冲突导致前一个音频未播放完就被后一个音频取缔</param>
        /// <param name="url">音频相对地址</param>
        void PlayMusic(MediaPlayer player,string url);

        /// <summary>
        /// 获取播放器
        /// </summary>
        /// <returns></returns>
        MediaPlayer GetPlayer();

        /// <summary>
        /// 标记图片是否还存在
        /// </summary>
        /// <returns></returns>
        bool isImageExist();
    }
}
