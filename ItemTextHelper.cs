using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public enum ItemDisplayMode
    {
        Normal,
        WithIndex,
        Inventory,
        InventoryWithIndex
    }
    public static class ItemTextHelper
    {
        public static string GenerateItemListText(List<Item> items, ItemDisplayMode mode = ItemDisplayMode.Normal)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                string priceText = item.IsSold ? "구매완료" : $"{item.Price,5} G";
                string valueText = item.Type == ItemType.Attack ? "공격력 +" : "방어력 +";
                string equipText = item.IsEquipped ? "[E]" : "";

                string line = "";

                switch (mode)
                {
                    case ItemDisplayMode.Normal:
                        line = $"{item.Name.PadRight(10)} | {valueText}{item.Value:D2} | {item.Explain.PadRight(20)} | {priceText}";
                        break;
                    case ItemDisplayMode.WithIndex:
                        line = $"{i + 1}. {item.Name.PadRight(10)} | {valueText}{item.Value:D2} | {item.Explain.PadRight(20)} | {priceText}";
                        break;
                    case ItemDisplayMode.Inventory:
                        line = $"{equipText}{item.Name.PadRight(10)} | {valueText}{item.Value:D2} | {item.Explain.PadRight(20)}";
                        break;
                    case ItemDisplayMode.InventoryWithIndex:
                        line = $"{i + 1}. {equipText}{item.Name.PadRight(10)} | {valueText}{item.Value:D2} | {item.Explain.PadRight(20)}";
                        break;
                }

                sb.AppendLine(line);
            }
            return sb.ToString();
        }

    }
}
