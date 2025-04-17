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
        public int Level { get; private set; } = 1;
        public int Attack { get; private set; }
        public int Deffense { get; private set; }
        public int Health { get; private set; }
        public int Gold { get; private set; }

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
            Deffense = 5;
            Health = 100;
            Gold = 1500;
        }

        public void ShowStatus()
        {
            string show = $@"==내 상태 보기==
Lv. {Level:D2}
{Name} ({Job})
공격력 : {Attack}
방어력 : {Deffense}
체 력 : {Health}
Gold : {Gold}G";

            Console.WriteLine(show);

        }

    }
}

