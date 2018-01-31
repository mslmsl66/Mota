using System;

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
    }
}
