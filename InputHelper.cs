using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal static class InputHelper
    {
        public static int GetInt(string message, int min , int max)
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    if(value >= min && value <= max)
                    {
                        return value;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"{min}부터 {max} 사이의 숫자를 입력해주세요.");
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("숫자를 입력해주세요.");
                    Thread.Sleep(1000);
                }
            }
        }

    }
}
