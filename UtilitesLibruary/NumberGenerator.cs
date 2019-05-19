using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitesLibruary
{
    public class NumberGenerator
    {
        static Random random = new Random();

        static string[] Alpha = new string[] { "А", "В", "C", "Е", "Н", "К", "М", "О", "Р", "Т", "Х", "У" };

        //Генерация номера
        public static string GetNumber()
        {
            string Number = "";
            Number += Alpha[random.Next(0, Alpha.Length - 1)];
            for (int i = 0;i < 3;i++)
            {
                Number += random.Next(0, 9);
            }
            for (int i = 0;i < 2;i++)
            {
                Number += Alpha[random.Next(0, Alpha.Length - 1)];
            }
            return Number;
        }
    }
}
