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
using UtilitesLibruary;

namespace GIBDD.license
{
    /// <summary>
    /// Логика взаимодействия для licenseInfo.xaml
    /// </summary>
    public partial class LicenseInfo : Page
    {
        //Инициализация копонетов
        public LicenseInfo()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Переход на передачу данных
        private void AddDocuments(object sender, RoutedEventArgs e)
        {
            try
            {
                NavigationService.Navigate(new IicensePage());
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
    }
}
