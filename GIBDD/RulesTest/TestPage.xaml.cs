using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace GIBDD.RulesTest
{
    /// <summary>
    /// Логика взаимодействия для TestPage.xaml
    /// </summary>
    public partial class TestPage : Page
    {
        string[] files = new string[]
        {
            @"C:\Users\DELL\source\repos\GIBDD\GIBDD\RulesTest\ImageTest\3-30-stoyanka-zapreshtena-po-chiotnym-chislam-mesyatsa.png",
            @"C:\Users\DELL\source\repos\GIBDD\GIBDD\RulesTest\ImageTest\4.1.5.png",
            @"C:\Users\DELL\source\repos\GIBDD\GIBDD\RulesTest\ImageTest\hello_html_m207c7853.jpg",
            @"C:\Users\DELL\source\repos\GIBDD\GIBDD\RulesTest\ImageTest\Ukraine_road_sign_3.36.gif",
            @"C:\Users\DELL\source\repos\GIBDD\GIBDD\RulesTest\ImageTest\Ukraine_road_sign_4.4.gif"
        };
        Image Global;
        //Инициализация копонетов
        public TestPage()
        {
            InitializeComponent();
            foreach (var file in files)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(file));
                image.MouseDown += this.Drag;

                Signs.Children.Add(image);
            }
        }

        //Поднять объект
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            Global = img;
            DragDrop.DoDragDrop(img, img.Source, DragDropEffects.All);
        }

        //Опустить объект
        private void DropImage(object sender, DragEventArgs e)
        {
            ((Image)sender).Source = Global.Source;
            ((Image)sender).IsEnabled = false;
        }
    }
}
