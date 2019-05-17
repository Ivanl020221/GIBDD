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

namespace GIBDD.RegisterAuto
{
    /// <summary>
    /// Логика взаимодействия для RegisterInfo.xaml
    /// </summary>
    public partial class RegisterInfo : Page
    {
        public RegisterInfo()
        {
            InitializeComponent();
        }

        //Переход на регистрацию авто
        private void AddDocuments(object sender, RoutedEventArgs e)
        {
            try
            {
                this.NavigationService.Navigate(new RegisterPage());
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
    }
}
