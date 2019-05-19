using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilitesLibruary;
namespace Media
{
    //Класс для чтения видео или аудио
    public class MediaRead
    {
        String Path = AppDomain.CurrentDomain.BaseDirectory;
        string ReturPath { get; set; }

        //Создание временного файла
        public MediaRead(Type type, byte[] Array)
        {
            if (!(Array is null))
            {
                Random ra = new Random();
                ReturPath = $"{Path}\\{ra.Next()}.{type}";
                File.WriteAllBytes(ReturPath, Array);
            }
        }
        //Возвращение элемента
        public string ReturnPath()
        {
            return ReturPath;
        }

        public void Delete()
        {
            try
            {
                File.Delete(this.ReturPath);

            }
            catch (Exception)
            {
            }
        }

        //Удаление файла
        ~MediaRead()
        {
            Delete();
        }
    }

    //Список форматов
    public enum Type
    {
        mp3,
        mp4
    }
}
