namespace NGDG2
{
    public class Slot
    {
        public Item Item;
        public int ItemCount;

        public Slot()
        {
            Item = new Item();
            ItemCount = 0;
        }

        /// <summary>
        /// 슬롯에 아이템을 추가한다.
        /// </summary>
        /// <param name="item">아이템</param>
        /// <param name="count">아이템 개수</param>
        public void Fill(Item item, int count)
        {
            Item = item;
            ItemCount = count;
        }

        /// <summary>
        /// 슬롯에 있는 아이템을 비운다.
        /// </summary>
        public void Empty()
        {
            Item = null;
            ItemCount = 0;
        }
    }
}
