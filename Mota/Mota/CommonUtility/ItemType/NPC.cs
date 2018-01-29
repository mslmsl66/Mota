using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility.ItemType
{
    public class NPC
    {

        /**
         * 返回四张图片 形成动画
         */
        public static String[] GetImagePaths(NPCType mtype)
        {
            switch (mtype)
            {
                case NPCType.老人:
                    return new string[] { "/res/icons/characters/NPC01-01.png", "/res/icons/characters/NPC01-02.png", "/res/icons/characters/NPC01-03.png", "/res/icons/characters/NPC01-04.png" };
                case NPCType.商人:
                    return new string[] { "/res/icons/characters/NPC02-01.png", "/res/icons/characters/NPC02-02.png", "/res/icons/characters/NPC02-03.png", "/res/icons/characters/NPC02-04.png" };
                case NPCType.小偷:
                    return new string[] { "/res/icons/characters/NPC03-01.png", "/res/icons/characters/NPC03-02.png", "/res/icons/characters/NPC03-03.png", "/res/icons/characters/NPC03-04.png" };
                case NPCType.仙子:
                    return new string[] { "/res/icons/characters/NPC04-01.png", "/res/icons/characters/NPC04-02.png", "/res/icons/characters/NPC04-03.png", "/res/icons/characters/NPC04-04.png" };
                case NPCType.奇怪的老人:
                    return new string[] { "/res/icons/characters/NPC05-01.png", "/res/icons/characters/NPC05-02.png", "/res/icons/characters/NPC05-03.png", "/res/icons/characters/NPC05-04.png" };
            }
            return null;
        }
    }
    public enum NPCType { 老人, 商人, 小偷, 仙子, 奇怪的老人 };
}
