using System;

namespace NGDG2.Screen
{
    public class Inventory : IScreen
    {
        string keyLog = string.Empty;
        Item selectedItem = null;

        public Inventory()
        {
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("인벤토리", ConsoleColor.Green);

            // 바로가기
            ScreenUtil.DrawHotKeyNavigator(new HotKeyNavigator().AddHotKey("SPACE", "장착/사용").AddHotKey("S", "판매").AddHotKey("ESC", "뒤로가기"));

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

            // 구분자
            ScreenUtil.DrawVerticalSeparator(70);

            // 아이템 정보
            if (selectedItem != null)
            {
                // 아이템 이름
                CHelper.Write(selectedItem.Name, 72, 3, selectedItem.Color);

                // 아이템 사용/장착 레벨
                if (selectedItem.Level != 0)
                    CHelper.Write($"레벨 {selectedItem.Level}", 72, 4);

                // 장비 효과 / 아이템 설명
                switch (selectedItem.Type)
                {
                    case Item.ItemType.Item:
                        CHelper.Write(selectedItem.Description, 72, 6);
                        break;

                    case Item.ItemType.Equipment:
                        for (int i = 0; i < selectedItem.EffectStrings.Count; i++)
                        {
                            CHelper.Write(selectedItem.EffectStrings[i], 72, 6 + i);
                        }
                        break;
                }

                // 판매 금액
                CHelper.Write($"{selectedItem.SalePrice} 골드", 72, 38);
            }
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                // 아이템 선택
                case ConsoleKey.D1:
                case ConsoleKey.D2:
                case ConsoleKey.D3:
                case ConsoleKey.D4:
                case ConsoleKey.D5:
                case ConsoleKey.D6:
                case ConsoleKey.D7:
                case ConsoleKey.D8:
                case ConsoleKey.D9:
                case ConsoleKey.D0:
                    if (keyLog.Length == 2)
                    {
                        keyLog = string.Empty;
                    }

                    keyLog += ((int)key - 48).ToString();

                    if (keyLog.Length == 2)
                    {
                        int num = int.Parse(keyLog);

                        if (num >= 1 && num <= Character.Inventory.Slots.Count)
                        {
                            selectedItem = Character.Inventory.Slots[num - 1].Item;
                        }
                    }
                    break;

                // 아이템 판매
                case ConsoleKey.S:
                    if (selectedItem != null)
                    {
                        // 선택한 아이템이 인벤토리에 있으면 판매
                        if (Character.Inventory.HasItem(selectedItem))
                        {
                            Character.Inventory.Remove(selectedItem, 1);
                            Character.Gold += selectedItem.SalePrice;
                        }
                    }
                    break;

                // 아이템 사용/장착
                case ConsoleKey.Spacebar:
                    if(selectedItem != null)
                    {
                        // 선택한 아이템이 인벤토리에 있으면 사용/장착
                        if (Character.Inventory.HasItem(selectedItem))
                        {
                            switch (selectedItem.Type)
                            {
                                case Item.ItemType.Item:
                                    break;

                                case Item.ItemType.Equipment:
                                    Character.MountEquipments.Equip(selectedItem.ToEquipment());
                                    break;
                            }
                        }
                    }
                    break;

                case ConsoleKey.Escape:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
                    break;
            }

            return string.Empty;
        }
    }
}
