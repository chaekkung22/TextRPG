using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Village
    {
        public void VillageMenu()
        {
            Console.Clear();
            string menu = @"스파르타 마을에 오신 여러분 환영합니다.
이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리
3. 상점

원하시는 행동을 입력해주세요.";

            int choice = InputHelper.GetInt(menu, 1, 3);

            if (choice == 1)
            {
                Player.Instance.ShowStatus();
                VillageMenu();
            }
            else if (choice == 2) 
            { }
            else 
            { }
        }
    }
}
