using Mota.CellImage;
using Mota.HeroCore;
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
            if (damage >= hero.properties.hp || damage == -1)
            {
                return false;
            }
            hero.properties.hp -= damage;
            hero.properties.exp += monster.Exp;
            hero.properties.gold += monster.Gold;
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
            if (hero.properties.atk <= monster.Def)
            {
                return -1;
            }
            int damage = 0;
            int monsterHp = monster.Hp;
            switch (monster.Ability)
            {
                case SpecialAbility.普通:
                    monsterHp = monsterHp - (hero.properties.atk - monster.Def);
                    while (monsterHp > 0)
                    {
                        damage += (monster.Atk - hero.properties.def);
                        monsterHp = monsterHp - (hero.properties.atk - monster.Def);
                    }
                    break;
                case SpecialAbility.魔攻:
                    monsterHp = monsterHp - (hero.properties.atk - monster.Def);
                    while (monsterHp > 0)
                    {
                        damage += monster.Atk;
                        monsterHp = monsterHp - (hero.properties.atk - monster.Def);
                    }
                    break;
                case SpecialAbility.坚固:
                    monsterHp = monsterHp - 1;
                    while (monsterHp > 0)
                    {
                        damage += (monster.Atk - hero.properties.def);
                        monsterHp = monsterHp - 1;
                    }
                    break;
                case SpecialAbility.先攻:
                    while (monsterHp > 0)
                    {
                        damage += (monster.Atk - hero.properties.def);
                        monsterHp = monsterHp - (hero.properties.atk - monster.Def);
                    }
                    break;
            }
            damage = damage - hero.properties.res;
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
            state.heroLevel.Text = hero.properties.level.ToString();
            state.heroHP.Text = hero.properties.hp.ToString();
            state.heroATK.Text = hero.properties.atk.ToString();
            state.heroDEF.Text = hero.properties.def.ToString();
            state.heroRES.Text = hero.properties.res.ToString();
            state.heroEXP.Text = hero.properties.exp.ToString();
            state.heroGold.Text = hero.properties.gold.ToString();
            state.heroYellowKey.Text = "x" + hero.properties.yellowKey.ToString();
            state.heroBlueKey.Text = "x" + hero.properties.blueKey.ToString();
            state.heroRedKey.Text = "x" + hero.properties.redKey.ToString();
            //ShowDamage();
        }
    }
}
