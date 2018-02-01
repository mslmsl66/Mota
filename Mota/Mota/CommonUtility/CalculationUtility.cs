using Mota.CellImage;
using Mota.page;

namespace Mota.CommonUtility
{
    public class CalculationUtility
    {
        private static Hero hero = Hero.GetInstance();

        private static State state = State.GetInstance();

        private static FloorFactory floorFactory = FloorFactory.GetInstance();

        /// <summary>
        /// 战斗扣除血量,加经验,金币
        /// </summary>
        /// <param name="monster"></param>
        public static bool Battle(MonsterImage monster)
        {
            int damage = CalculateDamage(monster);
            if (damage >= hero.Hp || damage == -1)
            {
                return false;
            }
            hero.Hp -= damage;
            hero.Exp += monster.Exp;
            hero.Gold += monster.Gold;
            RefreshStatus();
            return true;
        }

        /// <summary>
        /// 计算与怪物战斗的伤害
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        public static int CalculateDamage(MonsterImage monster)
        {
            if (hero.Atk <= monster.Def)
            {
                return -1;
            }
            int damage = 0;
            int monsterHp = monster.Hp;
            switch (monster.Ability)
            {
                case SpecialAbility.普通:
                    monsterHp = monsterHp - (hero.Atk - monster.Def);
                    while (monsterHp > 0)
                    {
                        damage += (monster.Atk - hero.Def);
                        monsterHp = monsterHp - (hero.Atk - monster.Def);
                    }
                    break;
                case SpecialAbility.魔攻:
                    monsterHp = monsterHp - (hero.Atk - monster.Def);
                    while (monsterHp > 0)
                    {
                        damage += monster.Atk;
                        monsterHp = monsterHp - (hero.Atk - monster.Def);
                    }
                    break;
                case SpecialAbility.坚固:
                    monsterHp = monsterHp - 1;
                    while (monsterHp > 0)
                    {
                        damage += (monster.Atk - hero.Def);
                        monsterHp = monsterHp - 1;
                    }
                    break;
                case SpecialAbility.先攻:
                    while (monsterHp > 0)
                    {
                        damage += (monster.Atk - hero.Def);
                        monsterHp = monsterHp - (hero.Atk - monster.Def);
                    }
                    break;
            }
            damage = damage - hero.Res;
            if (damage < 0)
            {
                return 0;
            }
            return damage;
        }

        /// <summary>
        /// 刷新状态栏
        /// </summary>
        public static void RefreshStatus()
        {
            state.floorNumber.Text = floorFactory.GetFloorNum().ToString() + "F";
            state.heroLevel.Text = hero.Level.ToString();
            state.heroHP.Text = hero.Hp.ToString();
            state.heroATK.Text = hero.Atk.ToString();
            state.heroDEF.Text = hero.Def.ToString();
            state.heroRES.Text = hero.Res.ToString();
            state.heroEXP.Text = hero.Exp.ToString();
            state.heroGold.Text = hero.Gold.ToString();
            state.heroYellowKey.Text = "x" + hero.YellowKey.ToString();
            state.heroBlueKey.Text = "x" + hero.BlueKey.ToString();
            state.heroRedKey.Text = "x" + hero.RedKey.ToString();
            //ShowDamage();
        }
    }
}
