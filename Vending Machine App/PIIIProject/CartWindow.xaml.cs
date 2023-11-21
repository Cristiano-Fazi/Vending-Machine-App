using PIIIProject.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private ObservableCollection<VendingItem> cartList = new ObservableCollection<VendingItem>();

        private VendingMachine vendingMachine;

        public CartWindow(VendingMachine vendingMachine_)
        {
            vendingMachine = vendingMachine_;

            InitializeComponent();

            LvCartInit(); //sets the binding value for the list view

            TxtPreviousInit(); //Gets the list of previous transactions and prints it to screen

        }

        public void TxtPreviousInit()
        {
            const string FILE_PATH = "../../../Data/Transactions.txt";

            txtPreviousPurchases.Text = File.ReadAllText(FILE_PATH);
        }

        public void LvCartInit()
        {

            foreach (string code in vendingMachine.Cart.ProductsInCart.Keys)
            {
                foreach (VendingItem v in vendingMachine.Cart.ProductsInCart[code])
                {
                    //adds all vending items to a observable collection
                    cartList.Add(v);
                }
            }

            lvCurrentCart.ItemsSource = cartList;
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (lvCurrentCart.SelectedIndex > -1)
            {
                vendingMachine.RemoveFromCart(cartList[lvCurrentCart.SelectedIndex]); //Removes item from shopping cart
                cartList.Remove(cartList[lvCurrentCart.SelectedIndex]); //removes item from observable collection
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            Close(); //closes window
        }
    }
}
