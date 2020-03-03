using System;
using System.Collections.Generic;

namespace NGDG2
{
    /// <summary>
    /// 던전 전투 화면
    /// 
    /// - 기본 전투 룰
    /// 몬스터와의 전투는 real-time이고, 총 n번의 wave를 모두 정상적으로 마치면 던전 정복에 성공한다.
    /// 하나의 wave에는 최대 12마리의 몬스터가 등장하며, 몬스터를 모두 잡을 경우 그 wave는 끝난다.
    /// wave 하나를 마칠 경우 일정량의 HP/MP가 회복되며, HP가 0이 되는 순간 던전 정복은 실패한다.
    /// 
    /// - 공격 룰
    /// 평타나 스킬 대기 쿨타임이 완료되면 버튼을 눌러 공격할 수 있다.
    /// 기본적으로 스킬 쿨타임이 평타 쿨타임보다 길고, 공격을 하는 순간 평타, 스킬 쿨타임 둘 다 초기화된다.
    /// 평타나 스킬은 몬스터 어느 한마리를 대상으로 지정할 수 없으며, 랜덤으로 공격된다.
    /// </summary>
    public class DungeonBattle : IScreen
    {
        public int CurrentWave;

        Dungeon d;
        List<Monster> targets;
        HighlightEffect characterHit, monsterHit;

        public DungeonBattle()
        {
            targets = new List<Monster>();
            characterHit = new HighlightEffect(ConsoleColor.White, ConsoleColor.Red, 1);
            monsterHit = new HighlightEffect(ConsoleColor.White, ConsoleColor.Red, 1);
        }

        public void Make(string name)
        {
            d = new Dungeon(name);
            CurrentWave = 0;

            Character.Reset();
        }

        /// <summary>
        /// 데이터 업데이트
        /// </summary>
        public void Update()
        {
            foreach (Monster monster in d.Waves[CurrentWave].Monsters)
            {
                // 몬스터 연산
                monster.Calculate();

                // 캐릭터 공격
                if (monster.AttackCool == monster.TotalAbility.CoolTick)
                {
                    MonsterAttacksCharacter(monster);
                    monster.AttackCool = 0;

                    characterHit.Start();
                }
            }
        }


        public void Show()
        {
            // 업데이트
            Update();

            // 타이틀
            ScreenUtil.DrawTitle($"{d.Name} WAVE {CurrentWave + 1}");

            // 구분자
            ScreenUtil.DrawSeparator(25);

            // 몬스터
            foreach (Monster monster in d.Waves[CurrentWave].Monsters)
            {
                if (targets.Contains(monster))
                {
                    ScreenUtil.StackHighlight(string.Format("{0,-12}{1,-20}", monster.Name, monster.TotalAbility.HP.ToString()), monsterHit);
                }
                else
                {
                    ScreenUtil.Stack(string.Format("{0,-12}{1,-20}", monster.Name, monster.TotalAbility.HP.ToString()));
                }

            }

            // 캐릭터
            CHelper.DrawBar(ScreenUtil.Left, 26, Character.AttackCool, Character.AttackCool == Character.TotalAbility.CoolTick ? ConsoleColor.Green : ConsoleColor.White);
            CHelper.DrawBar(ScreenUtil.Left + Character.AttackCool, 26, Character.TotalAbility.CoolTick - Character.AttackCool, ConsoleColor.DarkGray);
            CHelper.WriteHighlight($"HP {Character.TotalAbility.HP}/{Character.TotalAbility.HPMax}", ScreenUtil.Left, 27, characterHit);

        }

        public string React(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    if (Character.AttackCool == Character.TotalAbility.CoolTick)
                    {
                        CharacterAttacksMonster();
                        Character.AttackCool = 0;

                        monsterHit.Start();
                    }
                    break;
            }

            return string.Empty;
        }

        /// <summary>
        /// 캐릭터가 몬스터를 공격한다. (평타)
        /// 평타는 무조건 대상 하나만 공격할 수 있다.
        /// TODO: 명중률, 회피율 구현
        /// </summary>
        public void CharacterAttacksMonster()
        {
            SmartRandom r = new SmartRandom();
            targets.Clear();

            int index = r.Next(d.Waves[CurrentWave].Monsters.Count);
            targets.Add(d.Waves[CurrentWave].Monsters[index]);

            long damage = Character.TotalAbility.Attack - targets[0].TotalAbility.Defense;

            damage = damage <= 1 ? 1 : damage;

            targets[0].TotalAbility.HP -= damage;

            // 몬스터 사망
            if (targets[0].TotalAbility.HP <= 0)
                d.Waves[CurrentWave].Monsters.Remove(targets[0]);
        }

        public void CharacterSkillsMonster(Skill skill)
        {
            SmartRandom r = new SmartRandom();
            targets.Clear();

            //TODO

        }

        /// <summary>
        /// 몬스터가 캐릭터를 공격한다. (평타)
        /// TODO: 명중률, 회피율 구현
        /// </summary>
        /// <param name="attacker">몬스터</param>
        public void MonsterAttacksCharacter(Monster attacker)
        {
            SmartRandom r = new SmartRandom();

            long damage = attacker.TotalAbility.Attack - Character.TotalAbility.Defense;

            damage = damage <= 1 ? 1 : damage;

            Character.TotalAbility.HP -= damage;

            // 캐릭터 사망
            if (Character.TotalAbility.HP <= 0)
                ScreenManager.CurrentScreen = ScreenManager.Screen.Main;
        }
    }
}
