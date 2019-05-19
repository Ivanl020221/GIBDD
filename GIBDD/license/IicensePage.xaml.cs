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
using GIBDD.Model;
using UtilitesLibruary;
using Media;

namespace GIBDD.license
{
    /// <summary>
    /// Логика взаимодействия для IicensePage.xaml
    /// </summary>
    public partial class IicensePage : Page
    {
        GIBDDEntities context = new GIBDDEntities();

        List<Model.Driving_license> Iicensee;

        List<Model.Request> Requests;

      

        System.Windows.Forms.MaskedTextBox Iicense = new System.Windows.Forms.MaskedTextBox();
        //Инициализация копонентов
        public IicensePage()
        {
            try
            {
                InitializeComponent();
                Iicense.Mask = "0000-000000";
                Iicense.TextChanged += this.Serach;
                IicenseMask.Child = Iicense;
                TypeReq.ItemsSource = context.TypeRequest.ToList();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
           
        }

        //Поиск новых прав
        private void Serach(object sender, EventArgs e)
        {

            try
            {
                long Number = Iicense.Text.Replace("-", "").ToExpLong();
                Iicensee = context.Driving_license.Where(i => i.Number == Number).ToList();
                if (Iicensee.Count() > 0)
                {
                    long id = Iicensee.FirstOrDefault().Driver.ToLong();
                    Requests = context.Request.Where(i => i.Driver == id).ToList();
                    if (Requests.Count < 0 || Requests?.FirstOrDefault()?.Status == 6 || Requests?.FirstOrDefault()?.Status == 3)
                    {
                        Gifts.IsEnabled = true;
                        TypeReq.IsEnabled = true;
                    }
                    else
                    {
                        Gifts.IsEnabled = false;
                        TypeReq.IsEnabled = false;
                        status.Text = Requests.FirstOrDefault().Status1.Name;
                        switch (Requests.FirstOrDefault().Status)
                        {
                            case 4:
                                OkRequest.Content = "Сдать тест";
                                OkRequest.IsEnabled = true;
                                break;
                            case 5:
                                OkRequest.Content = "Оплатить пошлину";
                                OkRequest.IsEnabled = true;
                                break;
                            default:
                                break;
                        }

                    }
                    string Nope = "Nope";
                    DriveIincense iincense = new DriveIincense();
                    iincense.LastName.Text = Iicensee.FirstOrDefault()?.Drivers?.LastName ?? Nope;
                    iincense.FirstName.Text = Iicensee.FirstOrDefault()?.Drivers?.FirstName ?? Nope;
                    iincense.MiddleName.Text = Iicensee.FirstOrDefault()?.Drivers?.MiddleName ?? Nope;
                    iincense.Interval.Text = $"{Iicensee.FirstOrDefault()?.StartDate.ToShortDateString() ?? Nope} - {Iicensee.FirstOrDefault()?.EndDate.ToShortDateString() ?? Nope}";
                    iincense.GIBDDNumber.Text = Iicensee.FirstOrDefault()?.GIBDDNumber ?? Nope;
                    iincense.Birthregion.Text = Iicensee.FirstOrDefault()?.RegionBirth ?? Nope;
                    iincense.RegRegion.Text = Iicensee.FirstOrDefault()?.Region1?.Name ?? Nope;
                    iincense.Photo.Source = PhotoConverter.ByteToImage(Iicensee.FirstOrDefault()?.Photo);
                    this.IicenseFrame.Navigate(iincense);
                }
                else
                {
                    this.IicenseFrame.Navigate(new EmptyPage());
                }
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Получение новых
        private void GetNew(object sender, RoutedEventArgs e)
        {
            try
            {
                Model.Request request = new Model.Request()
                {
                    Date = DateTime.Now,
                    Status = 1,
                    Driver = Iicensee.FirstOrDefault().Driver,
                    TypeRequest = (TypeReq.SelectedItem as TypeRequest).IdTypeRequset
                };
                context.Request.Add(request);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
          
          
        }

        //Действие по заявке
        private void EventReq(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (Requests.FirstOrDefault().Status)
                {
                    case 4:
                        NavigationService.Navigate(new RulesTest.TestPage());
                        break;
                    case 5:
                        Fine.PayWindow pay = new Fine.PayWindow();
                        pay.ShowDialog();

                        break;
                    default:
                        break;
                }
                NavigationService.Navigate(new LicenseInfo());
                Requests.FirstOrDefault().Status = 3;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
           
        }
    }
}
