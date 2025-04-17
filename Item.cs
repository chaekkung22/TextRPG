using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {


        public struct ItemInfo
        {
            public string Name;
            public int Value;
            public string Explain;
            public int Price;
            public ItemType Type;

            public ItemInfo(string name, int value, string explain, int price, ItemType type)
            {
                Name = name;
                Value = value;
                Explain = explain;
                Price = price;
                Type = type;
            }
        }

    } 
    public enum ItemType
        {
            Attack,
            Defence
        }
}
