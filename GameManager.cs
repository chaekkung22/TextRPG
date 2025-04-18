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


        public Inventory Inventory { get;  set; }
        public Shop Shop { get; set; }
        public Village Village { get; set; }

        private GameManager()
        { 
            Inventory = new Inventory();
            Shop = new Shop();
            Village = new Village(Shop,Inventory);
        }
        public void Run()
        {
            new Start().GetNameAndJob();
            Village.VillageMenu();
        }
    }
}
