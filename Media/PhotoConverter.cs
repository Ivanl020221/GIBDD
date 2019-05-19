using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Media
{
    //Класс для работы с изображениями
    public class PhotoConverter
    {
        //Конвертация изображения в Байты
        public static byte[] ImageToByte(string path)
        {
            Bitmap bitmap = new Bitmap(path);
            var Converter = System.Drawing.Image.FromFile(path);
            using (MemoryStream ms = new MemoryStream())
            {
                Converter.Save(ms, bitmap.RawFormat);
                return ms.ToArray();
            }
        }
        //Байты в изображение
        public static BitmapImage ByteToImage(byte[] Array)
        {
            if (Array is null)
                return new BitmapImage(new Uri(@"\Resourses\null.png", UriKind.Relative));
            using (MemoryStream ms = new MemoryStream(Array,0,Array.Length))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
