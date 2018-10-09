using Newtonsoft.Json;
using System.IO;
using Mota.HeroCore;
using System.Collections.Generic;
using Mota.CellImage;
using System;
using Mota.page;

namespace Mota.CommonUtility
{
    public class SaveData
    {
        public static void Save(string fileName)
        {
            string path = "../../Saves/" + fileName + ".json";
            File.WriteAllText(path, SaveHeroStatus());
        }

        /// <summary>
        /// 保存英雄属性
        /// </summary>
        /// <returns></returns>
        private static string SaveHeroStatus()
        {
            Hero hero = Hero.GetInstance();
            DataSave data = new DataSave
            {
                Properties = new HeroProperties()
                {
                    hp = hero.properties.hp,
                    atk = hero.properties.atk,
                    def = hero.properties.def,
                    res = hero.properties.res,
                    level = hero.properties.level,
                    gold = hero.properties.gold,
                    exp = hero.properties.exp,
                    yellowKey = hero.properties.yellowKey,
                    blueKey = hero.properties.blueKey,
                    redKey = hero.properties.redKey,
                    x = hero.properties.x,
                    y = hero.properties.y
                },
                Map = MapUtility.GetAllFloorType(),
                FloorNum = FloorFactory.GetInstance().GetFloorNum(),
                Date = DateTime.Now.ToLocalTime().ToString(),
                Price = CommonVariable.PRICE
        };
            return JsonConvert.SerializeObject(data);
        }

        /// <summary>
        /// 用于存储的数据结构
        /// </summary>
        public class DataSave
        {
            public HeroProperties Properties;
            public List<List<KeyValuePair<Atype, Enum>>> Map;
            public int FloorNum;
            public string Date;
            public int Price;
        }
    }
}
