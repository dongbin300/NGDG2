namespace NGDG2
{
    /// <summary>
    /// 게임 내 모든 아이템 (장비도 포함)
    /// </summary>
    public class Item
    {
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

        public Item()
        {

        }

        public Item(string name)
        {
            Name = name;

            // TODO
        }

    }
}
