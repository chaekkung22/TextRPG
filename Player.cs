using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    internal class Player
    {

        private static Lazy<Player> instance = new Lazy<Player>(() => new Player());

        public static Player Instance => instance.Value;


        public string Name { get; private set; }
        public string Job { get; private set; }
        public int Level { get; set; } = 1;
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public Inventory Inventory { get; set; } = new Inventory();

        private Player() { }

        public static void CreateInstance(string name, string jobName)
        {
            instance = new Lazy<Player>(() => new Player(name, jobName));
        }

        private Player(string name, string jobName)
        {
            Name = name;
            Job = jobName;
            Attack = 10;
            Defense = 5;
            Health = 100;
            Gold = 3000;
        }

        public void ShowStatus()
        {
            equippedStats = Inventory.GetEquippedItemStats();
            string stat = Status();

            string show = $@"==내 상태 보기==
캐릭터의 정보가 표시됩니다.

{stat}

0. 나가기";
            int input = InputHelper.GetInt(show, 0, 0);
            return;
        }
        //아이템 추가 스탯 전역 변수
        private (int itemAtk, int itemDef, int itemHp) equippedStats = (0, 0, 0);
        
        
        //int는 단일 변수 타입이라 한 변수에만 쓸 수 있음. int (itemAtk~  << 불가능
        //(int itemAtk, int itemDef, int itemHp) << 가능
        //튜플 구조를 분해하려면 타입을 명시하거나, 타입을 자동으로 추론해 구조를 분해할 수 있게(var) 해야 함.

        string Status()
        {

            if (equippedStats == (0, 0, 0))
            {
                return $@"Lv. {Level:D2}
{Name} ({Job})
공격력 : {Attack}
방어력 : {Defense}
체 력 : {Health}
Gold : {Gold}G";
            }
            else
            {
                return $@"Lv. {Level:D2}
{Name} ({Job})
공격력 : {Attack} + ({equippedStats.itemAtk})
방어력 : {Defense} + ({equippedStats.itemDef})
체 력 : {Health} + ({equippedStats.itemHp})
Gold : {Gold}G";

            }
        }

    }
}

