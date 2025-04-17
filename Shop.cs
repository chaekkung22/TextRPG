using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        List<Item.ItemInfo> shopItems = new List<Item.ItemInfo>();

        public void ShopMenu()
        {
            ItemList();
            string listText = ItemListText();

            string show = $@"==상점==
필요한 아이템을 얻을 수 있는 상점입니다.

[보유 골드]
{Player.Instance.Gold} G

[아이템 목록]

{listText}

1. 아이템 구매
0. 나가기";

            int input = InputHelper.GetInt(show, 0, 1);
            if (input == 1)
            {
                BuyItem();
            }
            else return;
        }

        void BuyItem()
        {

        }

        public void ItemList()
        {
            shopItems = new List<Item.ItemInfo>()
            {
                new Item.ItemInfo("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, ItemType.Defence),
                new Item.ItemInfo("무쇠 갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000,ItemType.Defence),
                new Item.ItemInfo("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500,ItemType.Defence),
                new Item.ItemInfo("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600,ItemType.Attack),
                new Item.ItemInfo("청동 도끼", 5, "어디선가 사용된 흔적이 있는 도끼입니다.", 1500, ItemType.Attack),
                new Item.ItemInfo("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2100, ItemType.Attack)
            };
        }

        string ItemListText()
        {
            string result = "";
            for (int i = 0; i < shopItems.Count; i++)
            { 
                var item = shopItems[i];

                string valueText = item.Type == ItemType.Attack
                    ? "공격력 +"
                    : "방어력 +";
                result += $"{item.Name.PadRight(10)} | {valueText}{item.Value:D2} | {item.Explain.PadRight(20)} | {item.Price,5} G\n\n";
            }
            return result;
        }
    }
}
