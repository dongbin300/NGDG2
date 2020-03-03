using System.Collections.Generic;

namespace NGDG2
{
    public class Dungeon
    {
        /// <summary>
        /// 던전 이름(ID)
        /// </summary>
        public string Name;

        /// <summary>
        /// 입장 권장레벨
        /// </summary>
        public int Level;

        /// <summary>
        /// 던전 웨이브
        /// </summary>
        public List<DungeonWave> Waves;

        /// <summary>
        /// 출현 몬스터 목록
        /// </summary>
        public List<Monster> MonsterBounds;

        /// <summary>
        /// 출현 몬스터 수
        /// </summary>
        public Bounds MonsterCountBounds;

        public Dungeon()
        {

        }

        public Dungeon(string name)
        {
            Name = name;

            switch (name)
            {
                case "고블린 방":
                    Make("3/고블린이병,고블린일병/2~3");
                    break;
                case "고블린 소굴":
                    Make("3/고블린이병,고블린일병,고블린상병,고블린병장/3~5");
                    break;
                case "고블린 기지":
                    Make("3/고블린상병,고블린병장,고블린하사/4~6");
                    break;
                case "고블린 아지트":
                    Make("3/고블린하사,고블린중사,고블린상사/4~5");
                    break;
                case "고블린 성":
                    Make("3/고블린이병,고블린상병,고블린중사,고블린상사/6~10");
                    break;
                case "고블린 왕국":
                    Make("5/고블린이병,고블린일병,고블린상병,고블린병장,고블린하사,고블린중사,고블린상사,고블린대장/8~10");
                    break;
            }
        }

        /// <summary>
        /// 던전 생성
        /// </summary>
        /// <param name="formattedDungeonInfo">ex) "3/고블린이병,고블린일병/3~5"</param>
        public void Make(string formattedDungeonInfo)
        {
            // 인포 파싱
            string[] infos = formattedDungeonInfo.Split('/');

            int waveCount = int.Parse(infos[0]);
            string[] monsterNames = infos[1].Split(',');
            string[] monsterCounts = infos[2].Split('~');

            // 몬스터 수 범위 구성
            var bound = new Bounds(int.Parse(monsterCounts[0]), int.Parse(monsterCounts[1]));

            // 몬스터 출현 목록 구성
            List<Monster> monsterList = new List<Monster>();
            foreach (string monsterName in monsterNames)
            {
                monsterList.Add(new Monster(monsterName));
            }

            // 던전 웨이브 생성
            Waves = new List<DungeonWave>();
            for (int i = 0; i < waveCount; i++)
            {
                Waves.Add(new DungeonWave(monsterList, bound.Get()));
            }
        }
    }
}
