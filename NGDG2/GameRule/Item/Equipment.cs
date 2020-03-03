namespace NGDG2
{
    /// <summary>
    /// 게임 내 모든 장비 (장비도 곧 아이템)
    /// 장비의 정의는 캐릭터가 착용할 수 있는 것이고, 대체로 무기나 방어구가 된다.
    /// </summary>
    public class Equipment : Item
    {

        public Equipment()
        {

        }

        public Equipment(string name)
        {
            Name = name;

            //TODO
        }
    }
}
