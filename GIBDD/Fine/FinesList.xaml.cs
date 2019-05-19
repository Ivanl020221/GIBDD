using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace GIBDD.Fine
{
    /// <summary>
    /// Логика взаимодействия для FinesList.xaml
    /// </summary>
    public partial class FinesList : Page
    {
        GIBDDEntities context = new GIBDDEntities();

        MediaRead videoRead;

        MediaRead audioRead;

        //Иницализация копонетов
        public FinesList()
        {
            try
            {
                InitializeComponent();
                Number.SelectionChanged += this.Search;
                Fine.SelectionChanged += this.SelectItem;
                this.Audio.MediaOpened += this.OpenAudio;
                Rail.ValueChanged += this.SizeAudio;
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
          

        }

        private void SizeAudio(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try
            {
                Audio.Pause();
                Audio.Position = TimeSpan.FromSeconds(Rail.Value);
                Audio.Play();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
          

        }

        //Действие при загрузке аудио дорожки
        private void OpenAudio(object sender, RoutedEventArgs e)
        {
            try
            {
                Rail.Maximum = Audio.NaturalDuration.TimeSpan.TotalSeconds;
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        }

        //Выбор элемна
        private void SelectItem(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Fine.SelectedItem is Model.Fine fine)
                {
                    TextNumber.Text = fine.FineNuber.ToString();
                    Info.Text = fine.Offence1.Text;
                    Sum.Text = fine.Sum.ToString();
                    var video = context.Media?.Where(i => i.Fine == fine.FineNuber && i.Type == 2)?.FirstOrDefault()?.Media1;
                    var audio = context.Media?.Where(i => i.Fine == fine.FineNuber && i.Type == 1)?.FirstOrDefault()?.Media1;
                    videoRead = new Media.MediaRead(Media.Type.mp4, video);
                    audioRead = new Media.MediaRead(Media.Type.mp3, audio);
                    if (video is null)
                        Video.Source = null;
                    else
                        Video.Source = new Uri(videoRead.ReturnPath());
                    if (audio is null)
                        Audio.Source = null;
                    else
                        Audio.Source = new Uri(audioRead.ReturnPath());
                    if (fine.pay)
                    {
                        this.Paym.Background = Brushes.Green;
                        this.Paym.IsEnabled = false;
                    }
                    else
                    {
                        this.Paym.Background = Brushes.Transparent;
                        this.Paym.IsEnabled = true;
                        if ((DateTime.Now.Date - fine.Date.Date).Days < 15)
                        {
                            Prosent.ToolTip = new ToolTip().Content = "При оплате за две недели после штрафа скидка 50%";
                            Prosent.Text = "-50%";
                            Prosent.Foreground = Brushes.Green;
                            all.Text = (fine.Sum / 2).ToString();
                        }
                        if ((DateTime.Now.Date - fine.Date.Date).Days > 30)
                        {
                            Prosent.ToolTip = new ToolTip().Content = "Вы просрочили оплату штраф увеличен на 50%";
                            Prosent.Text = "+50%";
                            Prosent.Foreground = Brushes.Red;
                            all.Text = (fine.Sum + fine.Sum / 2).ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
         
        }
        //Поиск при вводе данных
        private void Search(object sender, RoutedEventArgs e)
        {
            try
            {
                SearchFine();

            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
           
        }
        //Поиск штрафов
        private void SearchFine()
        {
            try
            {
                long FineNumber = Number.Text.ToExpLong();
                var User = context.FinesDriver.Where(i => i.IDFine == FineNumber);
                var Fines = context.FinesDriver.Where(i => i.IDDriver == User.FirstOrDefault().IDDriver).Select(i => i.Fine);
                this.Fine.ItemsSource = Fines.OrderBy(i => i.pay).ToList();
                this.Fine.SelectedItem = Fines.Where(i => i.FineNuber == FineNumber).FirstOrDefault();

            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
          

        }

        //Оплатить выбраный штраф
        private void PayThis(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Fine.SelectedItem is Model.Fine fine)
                {
                    PayWindow pay = new PayWindow();
                    if ((bool)pay.ShowDialog())
                    {
                        fine.pay = true;
                        SearchFine();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
          


        }

        //Пуск видео
        private void PlayVideo(object sender, RoutedEventArgs e)
        {
            try
            {
                Video.Play();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
         
        }
        //Стоп аудио
        private void StopVideo(object sender, RoutedEventArgs e)
        {
            try
            {
                Video.Pause();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
           
        }
        //Запуск аудио
        private void PlayAudio(object sender, RoutedEventArgs e)
        {
            try
            {
                Audio.Play();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
           
        }
        //Остановка аудио
        private void StopAudio(object sender, RoutedEventArgs e)
        {
            try
            {
                Audio.Pause();
            }
            catch (Exception ex)
            {
                MessageUtilites.Error(ex.Message, ex.HResult);
            }
        
        }
    }
}
