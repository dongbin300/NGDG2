namespace NGDG2
{
    public class SkillSlot
    {
        public Skill Skill;
        public int SkillLevel;

        public SkillSlot()
        {
            Skill = new Skill();
            SkillLevel = 0;
        }

        /// <summary>
        /// 스킬북에 스킬을 추가한다.
        /// </summary>
        /// <param name="skill">스킬</param>
        /// <param name="level">스킬레벨</param>
        public void Fill(Skill skill, int level)
        {
            Skill = skill;
            SkillLevel = level;
        }

        /// <summary>
        /// 스킬북에 있는 스킬을 비운다.
        /// </summary>
        public void Empty()
        {
            Skill = null;
            SkillLevel = 0;
        }
    }
}
