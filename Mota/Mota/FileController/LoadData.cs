using Mota.CellImage;
using Mota.CommonUtility;
using Mota.HeroCore;
using Mota.page;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Mota.FileController
{
    public class LoadData
    {
        private static DataLoad data;

        private static Hero hero = Hero.GetInstance();

        public static void Load(string fileName)
        {
            string path = "../../Saves/" + fileName + ".json";
            if (File.Exists(path))
            {
                Deserialize(File.ReadAllText(path));
            }
        }
        
        /// <summary>
        /// 将读取的json文本转成对象，并赋值给英雄和地图渲染
        /// </summary>
        /// <param name="str"></param>
        private static void Deserialize(string str)
        {
            data = JsonConvert.DeserializeObject<DataLoad>(str);
            hero.properties = data.Properties;
            FloorFactory.GetInstance().SetFloorNum(data.FloorNum);
            DrawFloorAndHero();
        }

        /// <summary>
        /// 重新渲染地图和英雄
        /// </summary>
        private static void DrawFloorAndHero()
        {
            // 更新英雄图片位置
            FloorFactory.GetInstance().DrawHeroImage(data.Properties.y, data.Properties.x);
            // 重新初始化地图
            MapUtility.UpdateFloor(data.Map);
            // 渲染地图
            var floorFactory = FloorFactory.GetInstance();
            hero.current_floor = floorFactory.CoreMap(data.FloorNum);
        }
        
        /// <summary>
        /// 用于读取的数据结构
        /// </summary>
        public class DataLoad
        {
            public HeroProperties Properties;
            public List<List<KeyValuePair<int, int>>> Map;
            public int FloorNum;
        }
    }
}