using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using UtilitesLibruary;


namespace GIBDD
{
    /// <summary>
    /// Главное окно
    /// </summary>
    public partial class MainWindow : Window
    {
        //Инициализация копонентов
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                MainFrame.Navigated += this.Navigating;
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Вывод названия страницы
        private void Navigating(object sender, NavigationEventArgs e)
        {
            try
            {
                if (((Frame)sender).Content is Page page)
                    this.Title = $"ГИБДД - {page.Title}";

            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Переход на предыдущую страницу
        private void GoBack(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainFrame.CanGoBack)
                    MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
        //Выход из приложения
        private void Exit(object sender, RoutedEventArgs e)
        {
            try
            {
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
    }
}
