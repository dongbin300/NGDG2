namespace NGDG2
{
    /// <summary>
    /// 게임 내 모든 장비 (장비도 곧 아이템)
    /// 장비의 정의는 캐릭터가 착용할 수 있는 것이고, 대체로 무기나 방어구가 된다.
    /// </summary>
    public class Equipment : Item
    {
        /// <summary>
        /// 장비 부위
        /// </summary>
        public enum EquipmentPart
        {
            Weapon,
            Helmet,
            Armor,
            Pants,
            Shoes,
            Necklace,
            Ring,
            Emblem
        }

        /// <summary>
        /// 장비 유형
        /// </summary>
        public enum EquipmentType
        {
            Sword,
            Staff,
            Gun,
            LeatherHelmet,
            MetalHelmet,
            LeatherArmor,
            MetalArmor,
            LeatherTrouser,
            MetalTrouser,
            LeatherShoes,
            MetalShoes,
            SteelNecklace,
            AlloyNecklace,
            SteelRing,
            AlloyRing,
            Emblem
        }

        /// <summary>
        /// 장비 유형
        /// </summary>
        public EquipmentType Type;

        /// <summary>
        /// 장착 효과
        /// </summary>
        public Ability Effect;


        public Equipment()
        {

        }

        public Equipment(string name)
        {
            Name = name;

            switch (name)
            {
                case "낡은 검":
                    Make(1, EquipmentType.Sword, ItemRank.Normal, "p3/t15");
                    break;
                case "낡은 지팡이":
                    Make(1, EquipmentType.Staff, ItemRank.Normal, "i3/t15");
                    break;
                case "낡은 총":
                    Make(1, EquipmentType.Gun, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 가죽헬멧":
                    Make(1, EquipmentType.LeatherHelmet, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 금속헬멧":
                    Make(1, EquipmentType.MetalHelmet, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 가죽아머":
                    Make(1, EquipmentType.LeatherArmor, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 금속아머":
                    Make(1, EquipmentType.MetalArmor, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 가죽트라우저":
                    Make(1, EquipmentType.LeatherTrouser, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 금속트라우저":
                    Make(1, EquipmentType.MetalTrouser, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 가죽슈즈":
                    Make(1, EquipmentType.LeatherShoes, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 금속슈즈":
                    Make(1, EquipmentType.MetalShoes, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 강철목걸이":
                    Make(1, EquipmentType.SteelNecklace, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 합금목걸이":
                    Make(1, EquipmentType.AlloyNecklace, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 강철반지":
                    Make(1, EquipmentType.SteelRing, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 합금반지":
                    Make(1, EquipmentType.AlloyRing, ItemRank.Normal, "a3/t15");
                    break;
                case "낡은 엠블렘":
                    Make(1, EquipmentType.Emblem, ItemRank.Normal, "a3/t15");
                    break;
            }
        }

        /// <summary>
        /// 장비 생성
        /// </summary>
        /// <param name="level">장착 최소레벨</param>
        /// <param name="type">장비 유형</param>
        /// <param name="rank">아이템 등급</param>
        /// <param name="formattedEquipmentEffect">ex) "p15/s10/i7/w8/c12/a13/h150/m120/x4/y3/t165/d138/e25" => 힘 +15, 체력 +10, 지능 +7, 정신력 +8, 집중력 +12, 민첩 +13, HP MAX +150, MP MAX +120, HP회복 +4, MP회복 +3, 공격력 +165, 방어력 +138, 공격속도 +25</param>
        public void Make(int level, EquipmentType type, ItemRank rank, string formattedEquipmentEffect)
        {
            Level = level;
            Type = type;
            Rank = rank;
            Effect = new Ability(Ability.CalculateRule.Equipment);
            Effect.Reset(Ability.CalculateRule.Equipment);

            // 효과 파싱
            string[] effects = formattedEquipmentEffect.Split('/');

            foreach (string effect in effects)
            {
                // 효과 유형 분석
                string effectTypeString = effect.Substring(0, 1);

                // 효과 값 분석
                int value = int.Parse(effect.Substring(1));

                switch (effectTypeString)
                {
                    case "p":
                        Effect.Power = value;
                        break;
                    case "s":
                        Effect.Stamina = value;
                        break;
                    case "i":
                        Effect.Intelli = value;
                        break;
                    case "w":
                        Effect.Willpower = value;
                        break;
                    case "c":
                        Effect.Concentration = value;
                        break;
                    case "a":
                        Effect.Agility = value;
                        break;
                    case "h":
                        Effect.HPMax = value;
                        break;
                    case "x":
                        Effect.HPRec = value;
                        break;
                    case "m":
                        Effect.MPMax = value;
                        break;
                    case "y":
                        Effect.MPRec = value;
                        break;
                    case "t":
                        Effect.Attack = value;
                        break;
                    case "d":
                        Effect.Defense = value;
                        break;
                    case "e":
                        Effect.AttackSpeed = value;
                        break;
                }
            }
        }
    }
}
