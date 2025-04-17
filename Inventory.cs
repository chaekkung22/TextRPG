using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static TextRPG.Item;

namespace TextRPG
{
    internal class Inventory
    {
        public List<Item> InventoryItem { get; set; } = new List<Item>();
        public void InventoryList(Item newItem)
        {
            InventoryItem.Add(newItem);
        }

        public void InventoryMenu()
        {
            string show = $@"==인벤토리==
보유중인 아이템을 관리할 수 있습니다.

[아이템 목록]

1. 장착 관리
0. 나가기";
            int input = InputHelper.GetInt(show, 0, 1);
            if (input == 1)
            {

            }
            else return;
        }

    }
}
