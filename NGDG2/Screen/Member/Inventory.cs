using System;

namespace NGDG2.Screen
{
    public class Inventory : IScreen
    {
        public Inventory()
        {
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("인벤토리", ConsoleColor.Green);

            // 인벤토리 슬롯
            foreach(Slot slot in Character.Inventory.Slots)
            {
                if (slot.Item == null)
                    continue;

                ScreenUtil.Stack(string.Format("{0,-20}{1,-10}", slot.Item.Name, slot.ItemCount));
            }

            // 바로가기
            CHelper.Write("[ESC] 뒤로가기", 80, 3);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Escape:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                    break;
            }

            return string.Empty;
        }
    }
}
