using System;

namespace NGDG2.Screen
{
    public class CharacterInfo : IScreen
    {
        public CharacterInfo()
        {
        }

        public void Show()
        {
            // 타이틀
            ScreenUtil.DrawTitle("캐릭터 정보", ConsoleColor.Green);

            // 캐릭터 스탯
            ScreenUtil.Stack(Character.Name);
            ScreenUtil.Stack(Character.Class.Value);
            ScreenUtil.Stack($"Lv {Character.Level}");
            ScreenUtil.Stack($"HP {Character.TotalAbility.HPMax}");
            ScreenUtil.Stack($"MP {Character.TotalAbility.MPMax}");
            ScreenUtil.Stack($"힘 {Character.TotalAbility.Power}");
            ScreenUtil.Stack($"체력 {Character.TotalAbility.Stamina}");
            ScreenUtil.Stack($"지능 {Character.TotalAbility.Intelli}");
            ScreenUtil.Stack($"정신력 {Character.TotalAbility.Willpower}");
            ScreenUtil.Stack($"집중력 {Character.TotalAbility.Concentration}");
            ScreenUtil.Stack($"민첩 {Character.TotalAbility.Agility}");
            ScreenUtil.Stack($"공격력 {Character.TotalAbility.Attack}");
            ScreenUtil.Stack($"방어력 {Character.TotalAbility.Defense}");
            ScreenUtil.Stack($"공격속도 {Character.TotalAbility.AttackSpeed}({Character.TotalAbility.CoolTick})");
            ScreenUtil.Stack($"명중률 {string.Format("{0:F2}%", Character.TotalAbility.Accuracy)}");
            ScreenUtil.Stack($"회피율 {string.Format("{0:F2}%", Character.TotalAbility.EvasionRate)}");
            ScreenUtil.Stack($"HP회복 {Character.TotalAbility.HPRec}");
            ScreenUtil.Stack($"MP회복 {Character.TotalAbility.MPRec}");

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
