namespace NGDG2
{
    /// <summary>
    /// 게임 내 모든 아이템 (장비도 포함)
    /// 
    /// - 아이템 정보
    /// 
    /// </summary>
    public class Item
    {
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
        /// 아이템 상점 판매가격
        /// </summary>
        public int SalePrice;

        /// <summary>
        /// 아이템 등급
        /// </summary>
        public ItemRank Rank;

        public Item()
        {

        }

        public Item(string name)
        {
            Name = name;

            switch (name)
            {
                case "고블린 가죽":
                    Make(ItemRank.Normal, "고블린의 가죽이다.", 16);
                    break;
            }
        }

        public void Make(ItemRank rank, string description, int salePrice, int level = 0)
        {
            Rank = rank;
            Description = description;
            SalePrice = salePrice;
            Level = level;
        }
    }
}
