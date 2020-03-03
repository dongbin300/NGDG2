using System;
using System.Collections.Generic;

namespace NGDG2
{
    public class Monster
    {
        public string Name;
        public int Level;
        public Ability TotalAbility;
        public List<Skill> Skills;
        public List<Item> DropItems;
        public int AttackCool;

        public Monster()
        {

        }

        public Monster(string name)
        {
            Name = name;

            switch (name)
            {
                case "고블린이병":
                    Make(5, 4, 3, 2, 1, 1);
                    break;
                case "고블린일병":
                    Make(10, 8, 4, 4, 1, 2);
                    break;
                case "고블린상병":
                    Make(15, 12, 6, 5, 2, 4);
                    break;
                case "고블린병장":
                    Make(20, 16, 7, 7, 3, 5);
                    break;
                case "고블린하사":
                    Make(30, 20, 8, 8, 6, 10);
                    break;
                case "고블린중사":
                    Make(40, 25, 9, 9, 6, 12);
                    break;
                case "고블린상사":
                    Make(55, 40, 12, 12, 8, 15);
                    break;
                case "고블린대장":
                    Make(80, 65, 15, 15, 12, 20);
                    break;
            }
        }

        /// <summary>
        /// 몬스터 생성
        /// </summary>
        /// <param name="power">힘</param>
        /// <param name="stamina">체력</param>
        /// <param name="intelli">지능</param>
        /// <param name="willpower">정신력</param>
        /// <param name="concentration">집중력</param>
        /// <param name="agility">민첩</param>
        public void Make(long power, long stamina, long intelli, long willpower, long concentration, long agility)
        {
            // 편차 (+-3%) 구간 100
            Bounds staminaBounds = new Bounds(Convert.ToInt64(stamina * 0.97), Convert.ToInt64(stamina * 1.03));

            int staminaSection = staminaBounds.Range > 100 ? 100 : staminaBounds.Range > 5 ? 5 : 0;

            long convertedStamina = staminaBounds.Get(staminaSection);

            TotalAbility = new Ability(power, convertedStamina, intelli, willpower, concentration, agility);
            TotalAbility.Calculate();

            TotalAbility.HP = TotalAbility.HPMax;
            TotalAbility.MP = TotalAbility.MPMax;
        }

        /// <summary>
        /// 몬스터에 관련된 모든 것을 연산한다.
        /// </summary>
        public void Calculate()
        {
            // 공격 쿨타임
            AttackCool = Math.Min(AttackCool + 1, TotalAbility.CoolTick);

            // 몬스터 능력치 재계산
            TotalAbility.Calculate();
        }
    }
}
