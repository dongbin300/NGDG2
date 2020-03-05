using System;

namespace NGDG2
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
            ScreenUtil.Stack(Character.Class.Value);
            ScreenUtil.Stack($"Lv {Character.Level}");
            ScreenUtil.Stack($"EXP {Character.Exp}/{Character.RExp}");
            ScreenUtil.Stack($"Gold {Character.Gold}");

            // 바로가기
            CHelper.Write("[A] 저장", 80, 3);
            CHelper.Write("[S] 던전", 80, 4);
            CHelper.Write("[M] 내 캐릭터", 80, 5);
        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    //TODO: 계정 저장
                    break;
                case ConsoleKey.S:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.DungeonSelection;
                    break;
                case ConsoleKey.M:
                    ScreenManager.CurrentScreen = ScreenManager.Screen.CharacterInfo;
                    break;
            }

            return string.Empty;
        }
    }
}
