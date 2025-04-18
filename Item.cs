using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{

    public class Item
    {
        public string Name;
        public int Value;
        public string Explain;
        public int Price;
        public ItemType Type;
        public bool IsSold;
        public bool IsEquipped;


        public Item(string name, int value, string explain, int price, ItemType type)
        {
            Name = name;
            Value = value;
            Explain = explain;
            Price = price;
            Type = type;
            IsSold = false;
            IsEquipped = false;
        }
    }
    public enum ItemType
    {
        Attack,
        Defence,
        Health
    }
}
