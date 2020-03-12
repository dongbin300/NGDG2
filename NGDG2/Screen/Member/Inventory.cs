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

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("ESC", "뒤로가기"));

            // 아이템 번호
            for (int i = 0; i < 36; i++)
            {
                ScreenUtil.Stack(string.Format("{0:00}", i + 1) + " | ");
            }

            // 인벤토리 슬롯
            for (int i = 0; i < Character.Inventory.Slots.Count; i++)
            {
                Slot slot = Character.Inventory.Slots[i];

                if (slot.Item == null)
                    continue;

                CHelper.Write(string.Format("{0,-20}[{1}]", slot.Item.Name, slot.ItemCount), 8 + 20 * (i / 10), 3 + (i % 10));
            }
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
