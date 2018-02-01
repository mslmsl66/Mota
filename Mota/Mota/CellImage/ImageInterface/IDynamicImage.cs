namespace Mota.CellImage
{
    public interface IDynamicImage : IBaseImage
    {
        /// <summary>
        /// 设置动态图片路径
        /// </summary>
        /// <param name="path"></param>
        void SetImageSource(string[] path);
    }
}
