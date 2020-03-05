﻿using System;

namespace NGDG2.Screen
{
    public class GameMain : IScreen
    {
        public GameMain()
        {
            // 캐릭터 initialize
            _ = new Character();

            Character.LoadFromFile("c1.txt");
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("NGDG2 V.0.1", ConsoleColor.Green);

            // 캐릭터 스탯
            ScreenUtil.Stack(Character.Name);
            ScreenUtil.Stack(Character.Class.Value, ConsoleColor.Gray);
            ScreenUtil.Stack($"Lv {Character.Level}", ConsoleColor.Cyan);
            ScreenUtil.Stack($"EXP {Character.Exp}/{Character.RExp}", ConsoleColor.Green);
            ScreenUtil.Stack($"Gold {Character.Gold}", ConsoleColor.Yellow);

            // 바로가기
            CHelper.Write("[A] 저장", 80, 3);
            CHelper.Write("[S] 던전", 80, 4);
            CHelper.Write("[M] 내 캐릭터", 80, 5);
            CHelper.Write("[I] 인벤토리", 80, 6);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    Character.SaveToFile("c1.txt");
                    break;
                case ConsoleKey.S:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.DungeonSelection;
                    break;
                case ConsoleKey.M:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.CharacterInfo;
                    break;
                case ConsoleKey.I:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.Inventory;
                    break;
            }

            return string.Empty;
        }
    }
}
