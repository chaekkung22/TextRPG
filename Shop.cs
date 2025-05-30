﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Shop
    {
        List<Item> shopItems = new List<Item>();

        public void ShopMenu()
        {
            string listText = ItemTextHelper.GenerateItemListText(shopItems,ItemDisplayMode.Normal);

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
            string listWithIndexText = ItemTextHelper.GenerateItemListText(shopItems, ItemDisplayMode.WithIndex);
            int itemLength = shopItems.Count;

            string show = $@"==상점 - 아이템 구매==
필요한 아이템을 얻을 수 있는 상점입니다.

[보유 골드]
{Player.Instance.Gold} G

[아이템 목록]

{listWithIndexText}

구매할 아이템의 번호를 입력하세요.
0. 나가기";
            int input = InputHelper.GetInt(show, 0, itemLength);
            int item = input - 1;
            if (input == 0)
                ShopMenu();
            else
            {
                if (shopItems[item].IsSold)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                    Thread.Sleep(1000);
                    ShopMenu();
                }
                else if (Player.Instance.Gold <= shopItems[item].Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                    Thread.Sleep(1000);
                    ShopMenu();
                }
                else
                {
                    Console.WriteLine("구매를 완료했습니다.");
                    Thread.Sleep(1000);
                    Player.Instance.Gold -= shopItems[item].Price;
                    shopItems[item].IsSold = true;

                    Player.Instance.Inventory.InventoryList(shopItems[item]); // 입력한 번호의 아이템을 인벤토리에 저장

                    ShopMenu();
                }
            }
        }

        public Shop()
        {
            shopItems = new List<Item>()
            {
                new Item("수련자 갑옷", 5, "수련에 도움을 주는 갑옷입니다.", 1000, ItemType.Defence),
                new Item("무쇠 갑옷", 9, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000,ItemType.Defence),
                new Item("스파르타의 갑옷", 15, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500,ItemType.Defence),
                new Item("낡은 검", 2, "쉽게 볼 수 있는 낡은 검 입니다.", 600,ItemType.Attack),
                new Item("청동 도끼", 5, "어디선가 사용된 흔적이 있는 도끼입니다.", 1500, ItemType.Attack),
                new Item("스파르타의 창", 7, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2100, ItemType.Attack)
            };
        }
    }
}
