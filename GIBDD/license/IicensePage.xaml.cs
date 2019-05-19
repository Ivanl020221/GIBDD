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

        System.Windows.Forms.MaskedTextBox Iicense = new System.Windows.Forms.MaskedTextBox();
        //Инициализация копонентов
        public IicensePage()
        {
            InitializeComponent();
            Iicense.Mask = "0000-000000";
            Iicense.TextChanged += this.Serach;
            IicenseMask.Child = Iicense;

        }

        private void Serach(object sender, EventArgs e)
        {
            long Number = Iicense.Text.Replace("-", "").ToExpLong();
            var Iicensee = context.Driving_license.Where(i => i.Number == Number);
            if (Iicensee.Count() > 0)
            {
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
            try
            {
               
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }
    }
}
