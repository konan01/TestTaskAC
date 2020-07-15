using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTaskAC.Models;

namespace TestTaskAC.Controllers
{
    public class HomeController : Controller
    {
        LinkedList<int> linkedlistnum1 = new LinkedList<int>();
        LinkedList<int> linkedlistnum2 = new LinkedList<int>();
        LinkedList<int> linkedlistsum = new LinkedList<int>();
        private void Parse(string number1, string numder2)
        {
            for (int i = 0; i < number1.Length; i++)
            {
                linkedlistnum1.AddLast(int.Parse(number1[i].ToString()));
            }
            for (int i = 0; i < numder2.Length; i++)
            {
                linkedlistnum2.AddLast(int.Parse(numder2[i].ToString()));
            }
            linkedlistnum1.Reverse();
            linkedlistnum2.Reverse();
            SumList(linkedlistnum1, linkedlistnum2);
        }

        private void SumList(LinkedList<int> List1, LinkedList<int> List2)
        {
            List1.Reverse();
            List2.Reverse();
            for (int i = 0; i < List1.Count; i++)
            {
                linkedlistsum.AddLast(List1.ElementAt(i) + List2.ElementAt(i));
            }
           
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Task2()
        {
            return View();
        }
        [HttpPost]
        public LinkedList<int> Task2(string Firstnum, string Secondnum)
        {
            string authData = $"Firstnum: {Firstnum}   Secondnum: {Secondnum}";
            Parse($"{Firstnum}",$"{Secondnum}");
            return linkedlistsum;
        }
        [HttpGet]
        public IActionResult Task3()
        {
            return View();
        }
        [HttpPost]
        public string Task3(string refstr)
        {
            string str = $"{refstr}";
            if (str == null) return "Строка пуста";
            str = string.Join("", str.Where(char.IsLetterOrDigit).Select(char.ToLower));
            for (var i = 0; i < str.Length / 2; i++)
            {
                if (char.ToLower(str[i]) != char.ToLower(str[str.Length - i - 1]))
                {
                    return "Строка " + str + " не является палиндромом";
                }
            }
            return "Строка " + str + " является палиндромом";
        }
        public string Task1(int[] nums)
        {
            int n=0;
            int sum=0;
            foreach (var item in nums)
            {
                if (item % 2 != 0)
                {
                    n++;
                    if (n == 2)
                    {
                        sum += Math.Abs(item);
                        n = 0;
                    }
                }
            }
            return $"Cумма по модулю равна {sum}";
        }

    }
}
