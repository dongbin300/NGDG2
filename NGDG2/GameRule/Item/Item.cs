using System;
using System.Collections.Generic;

namespace NGDG2
{
    /// <summary>
    /// 게임 내 모든 아이템 (장비도 포함)
    /// TODO :: Item을 재료, 포션, 장비 등 타입으로만 구분
    /// 기존 Equipment 클래스는 날려버림
    /// Item 클래스 안에서 모든 걸 처리함
    /// 그대신 EquipmentSystem 클래스는 남겨둠
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 아이템 유형
        /// 재료 - 각종 재료 아이템
        /// 포션 - 회복 아이템
        /// 장비 - 무기, 방어구, 악세서리, 엠블렘 아이템
        /// </summary>
        public enum ItemType
        {
            Material,
            Potion,
            Equipment
        }

        /// <summary>
        /// 아이템 등급
        /// 노말 - 하얀색
        /// 익시드 - 노란색
        /// 레어 - 하늘색
        /// 아티팩트 - 초록색
        /// 유니크 - 분홍색
        /// 에픽 - 빨간색
        /// </summary>
        public enum ItemRank
        {
            Normal,
            Exceed,
            Rare,
            Artifact,
            Unique,
            Epic
        }

        /// <summary>
        /// 아이템 유형
        /// </summary>
        public ItemType Type;

        /// <summary>
        /// 아이템 이름(ID)
        /// </summary>
        public string Name;

        /// <summary>
        /// 아이템 사용/장착레벨(기본 0)
        /// </summary>
        public int Level;

        /// <summary>
        /// 아이템 설명
        /// </summary>
        public string Description;

        /// <summary>
        /// 아이템 효과 문자열
        /// </summary>
        public List<string> EffectStrings;

        /// <summary>
        /// 아이템 부위 문자열
        /// </summary>
        public string PartString;

        /// <summary>
        /// 아이템 가치
        /// </summary>
        public int Value;

        /// <summary>
        /// 아이템 판매 가격
        /// 아이템 가치의 1/4
        /// </summary>
        public int SalePrice => Value / 4;

        /// <summary>
        /// 아이템 등급
        /// </summary>
        public ItemRank Rank;

        /// <summary>
        /// 아이템 이름 색상
        /// </summary>
        public ConsoleColor Color => GetColor(Rank);

        /// <summary>
        /// 장비 유형
        /// </summary>
        public enum EquipmentType
        {
            None,
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
        /// 장비 부위
        /// </summary>
        public enum EquipmentPart
        {
            None,
            Weapon,
            Helmet,
            Armor,
            Trouser,
            Shoes,
            Necklace,
            Ring,
            Emblem
        }

        /// <summary>
        /// 장비 유형
        /// </summary>
        public EquipmentType EqType;

        /// <summary>
        /// 장비 부위
        /// </summary>
        public EquipmentPart Part => GetEquipmentPart(EqType);

        /// <summary>
        /// 장착 효과
        /// </summary>
        public Ability Effect;

        public Item()
        {

        }

        public Item(string name)
        {
            Name = name;

            switch (name)
            {
                case "고블린 가죽":
                    Make(ItemRank.Normal, "고블린의 가죽이다.", 50);
                    break;

                case "없음":
                    Make(0, EquipmentType.None, ItemRank.Normal, "");
                    break;
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
                    Make(1, EquipmentType.LeatherHelmet, ItemRank.Normal, "i2/w2/a2/d12");
                    break;
                case "낡은 금속헬멧":
                    Make(1, EquipmentType.MetalHelmet, ItemRank.Normal, "p2/s2/c2/d18");
                    break;
                case "낡은 가죽아머":
                    Make(1, EquipmentType.LeatherArmor, ItemRank.Normal, "i4/w4/a4/d24");
                    break;
                case "낡은 금속아머":
                    Make(1, EquipmentType.MetalArmor, ItemRank.Normal, "p4/s4/c4/d36");
                    break;
                case "낡은 가죽트라우저":
                    Make(1, EquipmentType.LeatherTrouser, ItemRank.Normal, "i3/w3/a3/d18");
                    break;
                case "낡은 금속트라우저":
                    Make(1, EquipmentType.MetalTrouser, ItemRank.Normal, "p3/s3/c3/d27");
                    break;
                case "낡은 가죽슈즈":
                    Make(1, EquipmentType.LeatherShoes, ItemRank.Normal, "i2/w2/a2/d12");
                    break;
                case "낡은 금속슈즈":
                    Make(1, EquipmentType.MetalShoes, ItemRank.Normal, "p2/s2/c2/d18");
                    break;
                case "낡은 강철목걸이":
                    Make(1, EquipmentType.SteelNecklace, ItemRank.Normal, "h15/m20");
                    break;
                case "낡은 합금목걸이":
                    Make(1, EquipmentType.AlloyNecklace, ItemRank.Normal, "h20/m15");
                    break;
                case "낡은 강철반지":
                    Make(1, EquipmentType.SteelRing, ItemRank.Normal, "x1/y1");
                    break;
                case "낡은 합금반지":
                    Make(1, EquipmentType.AlloyRing, ItemRank.Normal, "x1/y1");
                    break;
                case "낡은 엠블렘":
                    Make(1, EquipmentType.Emblem, ItemRank.Normal, "p1/s1/i1/w1/c1/a1/e5");
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 아이템을 생성한다. (재료)
        /// </summary>
        /// <param name="rank">아이템 등급</param>
        /// <param name="description">아이템 설명</param>
        /// <param name="salePrice">아이템 판매가격</param>
        /// <param name="level">아이템 레벨</param>
        void Make(ItemRank rank = ItemRank.Normal, string description = "", int value = 0, int level = 0)
        {
            Type = ItemType.Material;

            Rank = rank;
            Description = description;
            Value = value;
            Level = level;
        }

        /// <summary>
        /// 아이템을 생성한다. (장비)
        /// </summary>
        /// <param name="level">장착 최소레벨</param>
        /// <param name="type">장비 유형</param>
        /// <param name="rank">아이템 등급</param>
        /// <param name="formattedEquipmentEffect">ex) "p15/s10/i7/w8/c12/a13/h150/m120/x4/y3/t165/d138/e25" => 힘 +15, 체력 +10, 지능 +7, 정신력 +8, 집중력 +12, 민첩 +13, HP MAX +150, MP MAX +120, HP회복 +4, MP회복 +3, 공격력 +165, 방어력 +138, 공격속도 +25</param>
        void Make(int level, EquipmentType type, ItemRank rank, string formattedEquipmentEffect)
        {
            Type = ItemType.Equipment;

            Level = level;
            EqType = type;
            Rank = rank;
            Effect = new Ability(Ability.CalculateRule.Equipment);
            Effect.Reset();
            EffectStrings = new List<string>();

            // 효과가 없는 장비
            if (formattedEquipmentEffect == string.Empty)
                return;

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
                        EffectStrings.Add($"힘 +{value}");
                        break;
                    case "s":
                        Effect.Stamina = value;
                        EffectStrings.Add($"체력 +{value}");
                        break;
                    case "i":
                        Effect.Intelli = value;
                        EffectStrings.Add($"지능 +{value}");
                        break;
                    case "w":
                        Effect.Willpower = value;
                        EffectStrings.Add($"정신력 +{value}");
                        break;
                    case "c":
                        Effect.Concentration = value;
                        EffectStrings.Add($"집중력 +{value}");
                        break;
                    case "a":
                        Effect.Agility = value;
                        EffectStrings.Add($"민첩 +{value}");
                        break;
                    case "h":
                        Effect.HPMax = value;
                        EffectStrings.Add($"HP MAX +{value}");
                        break;
                    case "x":
                        Effect.HPRec = value;
                        EffectStrings.Add($"HP회복 +{value}");
                        break;
                    case "m":
                        Effect.MPMax = value;
                        EffectStrings.Add($"MP MAX +{value}");
                        break;
                    case "y":
                        Effect.MPRec = value;
                        EffectStrings.Add($"MP회복 +{value}");
                        break;
                    case "t":
                        Effect.Attack = value;
                        EffectStrings.Add($"공격력 +{value}");
                        break;
                    case "d":
                        Effect.Defense = value;
                        EffectStrings.Add($"방어력 +{value}");
                        break;
                    case "e":
                        Effect.AttackSpeed = value;
                        EffectStrings.Add($"공격속도 +{value}");
                        break;
                }
            }
        }

        /// <summary>
        /// 아이템 등급에 따른 이름 색상
        /// </summary>
        /// <param name="rank">아이템 등급</param>
        /// <returns>이름 색상</returns>
        ConsoleColor GetColor(ItemRank rank)
        {
            switch (rank)
            {
                case ItemRank.Normal:
                    return ConsoleColor.White;

                case ItemRank.Exceed:
                    return ConsoleColor.Yellow;

                case ItemRank.Rare:
                    return ConsoleColor.Cyan;

                case ItemRank.Artifact:
                    return ConsoleColor.Green;

                case ItemRank.Unique:
                    return ConsoleColor.Magenta;

                case ItemRank.Epic:
                    return ConsoleColor.Red;

                default:
                    return ConsoleColor.White;
            }
        }

        public string GetPartString(EquipmentPart part)
        {
            switch (part)
            {
                case EquipmentPart.None:
                    return "";

                case EquipmentPart.Weapon:
                    return "무기";

                case EquipmentPart.Helmet:
                    return "모자";

                case EquipmentPart.Armor:
                    return "상의";

                case EquipmentPart.Trouser:
                    return "하의";

                case EquipmentPart.Shoes:
                    return "신발";

                case EquipmentPart.Necklace:
                    return "목걸이";

                case EquipmentPart.Ring:
                    return "반지";

                case EquipmentPart.Emblem:
                    return "엠블렘";

                default:
                    return "";
            }
        }

        /// <summary>
        /// 장비 유형으로 장비 부위를 구합니다.
        /// </summary>
        /// <param name="type">장비 유형</param>
        /// <returns>장비 부위</returns>
        public EquipmentPart GetEquipmentPart(EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.Sword:
                case EquipmentType.Staff:
                case EquipmentType.Gun:
                    return EquipmentPart.Weapon;

                case EquipmentType.LeatherHelmet:
                case EquipmentType.MetalHelmet:
                    return EquipmentPart.Helmet;

                case EquipmentType.LeatherArmor:
                case EquipmentType.MetalArmor:
                    return EquipmentPart.Armor;

                case EquipmentType.LeatherTrouser:
                case EquipmentType.MetalTrouser:
                    return EquipmentPart.Trouser;

                case EquipmentType.LeatherShoes:
                case EquipmentType.MetalShoes:
                    return EquipmentPart.Shoes;

                case EquipmentType.SteelNecklace:
                case EquipmentType.AlloyNecklace:
                    return EquipmentPart.Necklace;

                case EquipmentType.SteelRing:
                case EquipmentType.AlloyRing:
                    return EquipmentPart.Ring;

                case EquipmentType.Emblem:
                    return EquipmentPart.Emblem;

                default:
                    return EquipmentPart.None;
            }
        }
    }
}
