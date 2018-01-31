using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CellImage
{
    public interface IStaticImage : IBaseImage
    {
        /// <summary>
        /// 设置图片路径
        /// </summary>
        /// <param name="path"></param>
        void SetImageSource(string path);
    }
}
