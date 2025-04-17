using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class GameManager
    {
        private static Lazy<GameManager> instance = new Lazy<GameManager>(() => new GameManager());
        public static GameManager Instance => instance.Value;

        private GameManager() { }
        public void Run()
        {
            new Start().GetNameAndJob();
            new Village().VillageMenu();
        }
    }
}
