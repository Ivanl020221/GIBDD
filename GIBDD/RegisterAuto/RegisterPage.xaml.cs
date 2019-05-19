using System;
using System.Collections.Generic;
using System.Drawing;
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
using GIBDD.Model;

namespace GIBDD.RegisterAuto
{
    /// <summary>
    /// Странциа регистрации трансорта
    /// </summary>
    public partial class RegisterPage : Page
    {
        System.Windows.Forms.MaskedTextBox Passport = new System.Windows.Forms.MaskedTextBox();

        System.Windows.Forms.MaskedTextBox VIN = new System.Windows.Forms.MaskedTextBox();

        System.Windows.Forms.MaskedTextBox PTS = new System.Windows.Forms.MaskedTextBox();

        GIBDDEntities context = new GIBDDEntities();

        List<Model.Region> Regions { get; set; }
        Drivers GetDrivers { get; set; }

        //Инициализация компонентов и выгрузка данных
        public RegisterPage()
        {
            try
            {
                this.InitializeComponent();
                Passport.Mask = "0000-000000";
                VIN.Mask = "AAAAAAAAAAAAAAAAA";
                PTS.Mask = "00 LL 000000";
                Passport.TextChanged += this.Search;
                this.PTSMask.Child = PTS;
                this.VINMask.Child = VIN;
                this.PassportMask.Child = Passport;
                this.Regions = context.Region.ToList();
                this.Region.ItemsSource = Regions.Select(i => i.IDRegion + " - " + i.Name);
                this.Region.KeyUp += this.Search;
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
        //Поиск региона
        private void Search(object sender, KeyEventArgs e)
        {
            long ID = 0;
            try
            {
                ID = this.Region.Text.ToLong();
            }
            catch (Exception)
            {
            }
            this.Regions = this.context.Region.Where(i => i.Name == Region.Text || i.IDRegion == ID).ToList();
            this.Region.ItemsSource = this.Regions.Select(i => i.IDRegion + " - " + i.Name);
            if (this.Regions.Count > 0)
                this.Region.IsDropDownOpen = true;
        }

        //Поиск человека по номеру паспорта
        private void Search(object sender, EventArgs e)
        {
            try
            {
                long passport = Passport.Text.Replace("-", "").ToExpLong();
                var Driver = context.Drivers.Where(i => i.passport == passport);
                if (Driver.Count() > 0)
                {
                    GetDrivers = Driver.FirstOrDefault();
                    this.FirstName.Text = Driver.FirstOrDefault().FirstName;
                    this.LastName.Text = Driver.FirstOrDefault().LastName;
                    this.MiddleName.Text = Driver.FirstOrDefault().MiddleName;
                    this.DateOfBirth.SelectedDate = Driver.FirstOrDefault().DateOfBirth;
                    this.FirstName.IsEnabled = false;
                    this.LastName.IsEnabled = false;
                    this.MiddleName.IsEnabled = false;
                    this.DateOfBirth.IsEnabled = false;
                }
                else
                {
                    GetDrivers = null;
                    this.FirstName.IsEnabled = true;
                    this.LastName.IsEnabled = true;
                    this.MiddleName.IsEnabled = true;
                    this.DateOfBirth.IsEnabled = true;
                }

            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Отчистить поиск региона
        private void Clear(object sender, RoutedEventArgs e)
        {
            this.Regions = context.Region.ToList();
            this.Region.ItemsSource = Regions.Select(i => i.IDRegion + " - " + i.Name);
        }

        //Принять введенные данные
        private void Acсept(object sender, RoutedEventArgs e)
        {
            if (this.LastName.Text != "" &&
                this.FirstName.Text != "" &&
                this.MiddleName.Text != "" &&
                this.DateOfBirth.SelectedDate != null &&
                this.VIN.Text.Length == VIN.Mask.Length ||
                this.PTS.Text.Length == PTS.Mask.Length &&
                this.Passport.Text.Length == Passport.Mask.Length &&
                this.Region.SelectedItem != null)
            {
                var result = MessageBox.Show("Вы уверены, что хотите отправить заявление", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (GetDrivers is null)
                    {
                        Drivers drivers = new Drivers
                        {
                            FirstName = FirstName.Text,
                            LastName = LastName.Text,
                            MiddleName = MiddleName.Text,
                            DateOfBirth = (DateTime)DateOfBirth.SelectedDate
                        };
                        context.Drivers.Add(drivers);
                        context.SaveChanges();
                        GetDrivers = drivers;
                      
                    }
                   
                    Cars cars = new Cars()
                    {
                        Number = NumberGenerator.GetNumber(),
                        PTS = this.PTS.Text.Replace(" ", ""),
                        Region = this.Regions[this.Region.SelectedIndex].IDRegion,
                        VIN = this.VIN.Text
                    };
                    context.Cars.Add(cars);
                    this.context.SaveChanges();
                    this.context.DriverCars.Add(new DriverCars { IDDriver = GetDrivers.IDDrivers, IDCar = cars.IDCar });
                    this.context.SaveChanges();
                    MessageBox.Show("Запись добавлена", "Инфо", MessageBoxButton.OK, MessageBoxImage.Information);
                    NavigationService.GoBack();
                }
            }
            else
            {
                MessageUtilites.Warning("Заполните обязательные поля отмеченные(*)");
            }
        }
    }
}
