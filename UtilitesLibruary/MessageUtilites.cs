using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UtilitesLibruary
{
    public class MessageUtilites
    {
        //Вывод ошибки
        public static void Error(string Message, int Code)
        {
            MessageBox.Show(Message, $"Ошибка - {Code}", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Вывод Предупрежедения
        public static void Warning(string Message)
        {
            MessageBox.Show(Message, $"Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
