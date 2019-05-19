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
using Media;
using GIBDD.Model;

namespace GIBDD.Request
{
    /// <summary>
    /// Окно просмотра штрафов
    /// </summary>
    public partial class Request : Page
    {
        GIBDDEntities context = new GIBDDEntities();

        List<Model.Request> requests;

        Model.Drivers Driver;

        List<Model.Fine> fines;

        int Eventtype = -1;

        //инициализация копонетов
        public Request()
        {
            try
            {
                InitializeComponent();
                Fill();
                RequestList.SelectionChanged += this.SelectObject;
               
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Заполнить данные о заявках
        public void Fill()
        {
            try
            {
                requests = context.Request.Where(i => i.Status == 1).ToList();
                RequestList.ItemsSource = requests;
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        
        }

        //Выбор заявки на расмотрение
        private void SelectObject(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var Req = RequestList.SelectedItem as Model.Request;
                Driver = Req.Drivers;
                this.PassportMask.Text = Driver.passport.ToString();
                this.FirstName.Text = Driver.FirstName;
                this.LastName.Text = Driver.LastName;
                this.MiddleName.Text = Driver.MiddleName;
                this.DateOfBirth.Text = Driver.DateOfBirth.ToShortDateString();
                fines = context.FinesDriver.Where(i => i.IDDriver == Driver.IDDrivers).Select(i => i.Fine).ToList();
                var FineYear = fines.Where(i => DateTime.Now.Year - i.Date.Year < 1);
                Fine.ItemsSource = fines;
                if (FineYear.Count() < 20)
                {
                    InfoText.Text = "У водителя допустимое количество нарушений за последний год";
                    EventReq.Content = "Перевыпуск";
                    Eventtype = 0;
                }
                else
                {
                    if (FineYear.Where(i => i.type == 2).Count() == 0)
                    {
                        InfoText.Text = "Водитель должен оплатить гос пошлину";
                        EventReq.Content = "Отравить чек";
                        Eventtype = 1;
                    }
                    else
                    {
                        if (FineYear.Where(i => i.type == 2).Count() < 5)
                        {
                            InfoText.Text = "Водитель должен пройти тестирование";
                            EventReq.Content = "Отправить на тестирование";
                            Eventtype = 2;
                        }
                    }
                    if (FineYear.Where(i => i.type == 2).Count() > 5)
                    {
                        InfoText.Text = "Водитель должен пройти тестирование";
                        EventReq.Content = "Отправить на тестирование";
                        Eventtype = 2;

                    }
                }
            }
            catch (Exception ex)
            {

            }
          
        }

        //Отказ перевыпуска прав
        private void CancelReq(object sender, RoutedEventArgs e)
        {
            try
            {
                var Req = RequestList.SelectedItem as Model.Request;
                var res = MessageUtilites.Question("Вы уверены, что хотите отказать була... Водителю?");
                if (res == MessageBoxResult.Yes)
                    Req.Status = 7;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
      
        }

        //Прриянть действие отностиельно полукченных данных
        private void OkReq(object sender, RoutedEventArgs e)
        {
            try
            {
                var Req = RequestList.SelectedItem as Model.Request;
                switch (Eventtype)
                {
                    case 0:
                        Req.Status = 3;
                        break;
                    case 1:
                        Req.Status = 5;
                        break;
                    case 2:
                        Req.Status = 4;
                        break;
                    default:

                        break;
                }
                context.SaveChanges();
                Fill();

            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
         
        }
    }
}
