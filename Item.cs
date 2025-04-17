using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Item
    {
        public enum ItemType
        {
            Attack,
            Defence
        }

        public struct ItemInfo
        {
            public string Name;
            public int Value;
            public string Explain;
            public int Price;
            public ItemInfo(string name, int value, string explain, int price)
            {
                Name = name;
                Value = value;
                Explain = explain;
                Price = price;
            }
        }

    }
}
