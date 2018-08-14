using System.Windows.Controls;
using System.Windows.Documents;

namespace Mota.page
{
    /// <summary>
    /// 英雄状态栏的page
    /// </summary>
    public partial class State : Page
    {
        private static State instance;

        /// <summary>
        /// 状态栏楼层数
        /// </summary>
        public Run floorNumber;

        /// <summary>
        /// 英雄等级
        /// </summary>
        public Run heroLevel;

        /// <summary>
        /// 英雄生命值
        /// </summary>
        public Run heroHP;

        /// <summary>
        /// 英雄攻击力
        /// </summary>
        public Run heroATK;

        /// <summary>
        /// 英雄防御力
        /// </summary>
        public Run heroDEF;

        /// <summary>
        /// 英雄魔防
        /// </summary>
        public Run heroRES;

        /// <summary>
        /// 英雄经验值
        /// </summary>
        public Run heroEXP;

        /// <summary>
        /// 英雄金币
        /// </summary>
        public Run heroGold;

        /// <summary>
        /// 英雄黄钥匙
        /// </summary>
        public Run heroYellowKey;

        /// <summary>
        /// 英雄蓝钥匙
        /// </summary>
        public Run heroBlueKey;

        /// <summary>
        /// 英雄红钥匙
        /// </summary>
        public Run heroRedKey;

        private State()
        {
            InitializeComponent();
            floorNumber = floorNum;
            heroLevel = level;
            heroHP = hp;
            heroATK = atk;
            heroDEF = def;
            heroRES = res;
            heroEXP = exp;
            heroGold = gold;
            heroYellowKey = yellowKey;
            heroRedKey = redKey;
            heroBlueKey = blueKey;
        }
        public static State GetInstance()
        {
            if (instance == null) 
            {
                instance = new State();
            }
            return instance;
        }
    }
}
