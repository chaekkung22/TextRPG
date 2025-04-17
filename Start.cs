using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class Start
    {    
        string name;
        string jobName = "";
        public void GetNameAndJob()
        {
            Console.Clear();
            GetName();
            GetJob();
            
            int choice = InputHelper.GetInt($"이름 : {name} \n직업 : {jobName} \n맞으면 1을, 다시 작성하려면 0을 눌러주세요.", 0, 1);
            if (choice == 0)
            {
                GetNameAndJob();
            }
        }
        void GetName()
        {
            Console.Clear();
            Console.Write("이름을 입력해주세요. : ");
            name = Console.ReadLine();
            Console.WriteLine($"당신의 이름은 {name} 입니다.");
            Thread.Sleep(1000);
        }

        void GetJob()
        {
            int jobNum = InputHelper.GetInt("직업을 선택해 주세요." +
                "\n1. 전사 \n2. 마법사 \n3. 궁수 \n4. 도적", 1, 4);

            switch ((Job)jobNum)
            {
                case Job.Warrior:
                    jobName = "전사";
                    break;

                case Job.Wizard:
                    jobName = "마법사";
                    break;

                case Job.Archer:
                    jobName = "궁수";
                    break;

                case Job.Thief:
                    jobName = "도적";
                    break;
            }
            Console.Clear();
            Console.WriteLine($"{jobName}을 선택하셨습니다.");
        }


        enum Job
        {
            Warrior = 1,
            Wizard,
            Archer,
            Thief
        }
    }
}

