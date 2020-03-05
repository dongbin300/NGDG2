using System;
using System.Collections.Generic;

namespace NGDG2
{
    /// <summary>
    /// 몬스터
    /// 
    /// - 몬스터 정보
    /// 힘,체력,지능,정신력,집중력,민첩,EXP,골드,드랍아이템
    /// 
    /// - 드랍아이템 정보
    /// 아이템이름/기대수(N마리를 잡아야 1개가 나오는 확률)
    /// 
    /// 드랍아이템은 몬스터가 생성될 때 이미 정해져있다.
    /// </summary>
    public class Monster
    {
        public string Name;
        public int Level;
        public Ability TotalAbility;
        public List<Skill> Skills;
        public long Exp;
        public long Gold;
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
                    Make(5, 4, 3, 2, 1, 1, 18, 24, "고블린 가죽/8");
                    break;
                case "고블린일병":
                    Make(10, 8, 4, 4, 1, 2, 25, 31, "고블린 가죽/8");
                    break;
                case "고블린상병":
                    Make(15, 12, 6, 5, 2, 4, 32, 38, "고블린 가죽/7");
                    break;
                case "고블린병장":
                    Make(20, 16, 7, 7, 3, 5, 41, 48, "고블린 가죽/7");
                    break;
                case "고블린하사":
                    Make(30, 20, 8, 8, 6, 10, 56, 60, "고블린 가죽/6");
                    break;
                case "고블린중사":
                    Make(40, 25, 9, 9, 6, 12, 72, 73, "고블린 가죽/6");
                    break;
                case "고블린상사":
                    Make(55, 40, 12, 12, 8, 15, 96, 95, "고블린 가죽/6");
                    break;
                case "고블린대장":
                    Make(80, 65, 15, 15, 12, 20, 135, 128, "고블린 가죽/5");
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
        /// <param name="exp">경험치</param>
        /// <param name="gold">골드</param>
        /// <param name="drop">드롭아이템</param>
        public void Make(long power, long stamina, long intelli, long willpower, long concentration, long agility, long exp, long gold, string drop = "")
        {
            SmartRandom r = new SmartRandom();

            // 편차 (+-3%) 구간 100
            Bounds staminaBounds = new Bounds(Convert.ToInt64(stamina * 0.97), Convert.ToInt64(stamina * 1.03));
            Bounds goldBounds = new Bounds(Convert.ToInt64(gold * 0.97), Convert.ToInt64(gold * 1.03));

            int staminaSection = staminaBounds.Range > 100 ? 100 : staminaBounds.Range > 5 ? 5 : 0;
            int goldSection = goldBounds.Range > 100 ? 100 : goldBounds.Range > 5 ? 5 : 0;

            long convertedStamina = staminaBounds.Get(staminaSection);
            long convertedGold = goldBounds.Get(goldSection);

            // 능력치 설정
            TotalAbility = new Ability(power, convertedStamina, intelli, willpower, concentration, agility);
            TotalAbility.Calculate();

            // HP, MP
            TotalAbility.HP = TotalAbility.HPMax;
            TotalAbility.MP = TotalAbility.MPMax;

            // 경험치, 골드
            Exp = exp;
            Gold = convertedGold;

            // 드랍아이템
            DropItems = new List<Item>();
            string[] dropData = drop.Split('/');
            for (int i = 0; i < dropData.Length / 2; i++)
            {
                Item item = new Item(dropData[i * 2]);
                int dropNumber = int.Parse(dropData[i * 2 + 1]);

                // 몬스터가 아이템을 가지고 있다!
                if (r.Next(dropNumber) == 0)
                {
                    DropItems.Add(item);
                }
            }
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
