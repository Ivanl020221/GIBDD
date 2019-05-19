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
using System.Windows.Shapes;

namespace GIBDD.Fine
{
    /// <summary>
    /// Доилогове окно оплаты
    /// </summary>
    public partial class PayWindow : Window
    {
        System.Windows.Forms.MaskedTextBox Cart = new System.Windows.Forms.MaskedTextBox();
        System.Windows.Forms.MaskedTextBox MY = new System.Windows.Forms.MaskedTextBox();
        System.Windows.Forms.MaskedTextBox CV = new System.Windows.Forms.MaskedTextBox();

        //Инициализация копонетов
        public PayWindow()
        {
            InitializeComponent();
            Cart.Mask = "0000-0000-0000-0000";
            MY.Mask = "00/00";
            CV.Mask = "000";
            CartNum.Child = Cart;
            MMYY.Child = MY;
            CVV.Child = CV;
        }
        //Принять оплату
        private void Ok(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
