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
    public class Inventory
    {
        public List<Item> InventoryItem { get; set; } = new List<Item>();
        public void InventoryList(Item newItem)
        {
            Player.Instance.Inventory.InventoryItem.Add(newItem);
        }

        public void InventoryMenu()
        {
            var inventory = Player.Instance.Inventory.InventoryItem;
            string listText = ItemTextHelper.GenerateItemListText(inventory, ItemDisplayMode.Inventory);

            string show = $@"==인벤토리==
보유중인 아이템을 관리할 수 있습니다.

[아이템 목록]

{listText}

1. 장착 관리
0. 나가기";
            int input = InputHelper.GetInt(show, 0, 1);
            if (input == 1)
            {
                EquipControl();
            }
            else return;
        }

        void EquipControl()
        {
            int itemLength = Player.Instance.Inventory.InventoryItem.Count;
            string listText = ItemTextHelper.GenerateItemListText(Player.Instance.Inventory.InventoryItem, ItemDisplayMode.InventoryWithIndex);
            string show = $@"==인벤토리 - 장착 관리 ==
보유중인 아이템을 관리할 수 있습니다.

[아이템 목록]

{listText}


착용/해제하고 싶은 아이템을 선택하세요.
0. 나가기";
            int input = InputHelper.GetInt(show, 0, itemLength);
            int item = input - 1;
            if (input == 0)
            {
                InventoryMenu();
            }
            else
            {
                Player.Instance.Inventory.InventoryItem[item].IsEquipped = !(Player.Instance.Inventory.InventoryItem[item].IsEquipped);
                InventoryMenu();
            }
        }

        public (int atk, int def, int hp) GetEquippedItemStats()
        {
            int totalAtk = 0;
            int totalDef = 0;
            int totalHp = 0;

            for (int i = 0; i < Player.Instance.Inventory.InventoryItem.Count; i++)
            {

                if (Player.Instance.Inventory.InventoryItem[i].IsEquipped)
                {
                    int value = Player.Instance.Inventory.InventoryItem[i].Value;

                    switch(Player.Instance.Inventory.InventoryItem[i].Type)
                    {
                        case ItemType.Attack:
                           totalAtk += value;
                            break;
                        case ItemType.Defence:
                            totalDef = value;
                            break;
                        case ItemType.Health:
                            totalHp = value;
                            break;

                    }
                }
            }

            return (totalAtk, totalDef, totalHp);
        }
    }
}
