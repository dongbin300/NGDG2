using System;
using System.Collections.Generic;

namespace NGDG2
{
    /// <summary>
    /// 게임 내 모든 아이템 (장비도 포함)
    /// </summary>
    public class Item
    {
        /// <summary>
        /// 아이템 유형
        /// 아이템 - 장비 이외의 재료, 포션 등
        /// 장비 - 무기, 방어구, 악세서리
        /// </summary>
        public enum ItemType
        {
            Item,
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

        public Item()
        {

        }

        public Item(string name)
        {
            Type = ItemType.Item;
            Name = name;

            switch (name)
            {
                case "고블린 가죽":
                    Make(ItemRank.Normal, "고블린의 가죽이다.", 50);
                    break;

                default: // 장비 아이템
                    MakeToEquipment(name);
                    break;
            }
        }

        /// <summary>
        /// 아이템을 생성한다.
        /// </summary>
        /// <param name="rank">아이템 등급</param>
        /// <param name="description">아이템 설명</param>
        /// <param name="salePrice">아이템 판매가격</param>
        /// <param name="level">아이템 레벨</param>
        void Make(ItemRank rank = ItemRank.Normal, string description = "", int value = 0, int level = 0)
        {
            Rank = rank;
            Description = description;
            Value = value;
            Level = level;
        }

        /// <summary>
        /// 장비를 생성한다.
        /// </summary>
        /// <param name="name">아이템 이름</param>
        void MakeToEquipment(string name)
        {
            Type = ItemType.Equipment;

            var equipment = new Equipment(name);

            Rank = equipment.Rank;
            Description = equipment.Description;
            Value = equipment.Value;
            Level = equipment.Level;
            EffectStrings = equipment.EffectStrings;
            PartString = GetPartString(equipment.Part);
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

        public string GetPartString(Equipment.EquipmentPart part)
        {
            switch (part)
            {
                case Equipment.EquipmentPart.None:
                    return "";

                case Equipment.EquipmentPart.Weapon:
                    return "무기";

                case Equipment.EquipmentPart.Helmet:
                    return "모자";

                case Equipment.EquipmentPart.Armor:
                    return "상의";

                case Equipment.EquipmentPart.Trouser:
                    return "하의";

                case Equipment.EquipmentPart.Shoes:
                    return "신발";

                case Equipment.EquipmentPart.Necklace:
                    return "목걸이";

                case Equipment.EquipmentPart.Ring:
                    return "반지";

                case Equipment.EquipmentPart.Emblem:
                    return "엠블렘";

                default:
                    return "";
            }
        }
    }
}
