using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mota.CommonUtility
{
    public class DialogUtility
    {
        /// <summary>
        /// 对话内容，变量命名为dialog_floorNum_X_Y
        /// floorNum代表楼层，X、Y代表NPC坐标
        /// </summary>
        public static List<string> dialog_1_0_0 = new List<string>() { "老人：你好，勇士。这座魔塔已经有50年没人进来过了。", "勇士：我要迎娶白富美，走上人生巅峰！" };

        public static List<string> dialog_1_10_10 = new List<string>() { "铁剑在三楼，铁盾在五楼" };

        public static List<string> dialog_2_10_10 = new List<string>() { "贪婪之神：给我"+0+"金币，你可以按1获得3攻，按2获得3防，按3获得300血" };
    }
}
