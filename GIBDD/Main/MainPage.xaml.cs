﻿using System;
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
using UtilitesLibruary;

namespace GIBDD.Main
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        //Переход на СПИСОК ДОКУМЕНТОВ для регистрации авто
        private void GoToInfo(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new RegisterAuto.RegisterInfo());
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
        //Переход на список документод для полученмия прав
        private void GoToIincense(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new license.LicenseInfo());
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Переход на список штрафов
        private void GoToFine(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Fine.FinesList());
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Переход на страницу подтверждения заявок
        private void GoToRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new Request.Request());
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
    }
}
