using PIIIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for CashWindow.xaml
    /// </summary>
    public partial class CashWindow : Window
    {

        private VendingMachine vendingMachine;

        public CashWindow(VendingMachine vendingMachine_)
        {
            vendingMachine = vendingMachine_;
            InitializeComponent();
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            int bill = GetBill();

            if(bill < 0)         
                MessageBox.Show("You must select a bill");
            else
            {
                vendingMachine.MakeTransaction(bill);
                Close(); //closes window after transaction was complete
            }
                
            
        }

        private int GetBill()
        {
            string bill = "-1";
            foreach (RadioButton r in rdCash.Children.OfType<RadioButton>())
            {
                //Searches through radio buttons to see which has been selected
                if((bool)r.IsChecked)
                {
                    bill = r.Content
                        .ToString()
                        .Substring(0, r.Content.ToString().IndexOf("$"));
                    break;
                }
            }
            return Convert.ToInt32(bill);
        }
    }
}
