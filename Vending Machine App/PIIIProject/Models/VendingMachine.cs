using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace PIIIProject.Models
{
    public class VendingMachine
    {
        private Dictionary<string, Stack<VendingItem>> _products;

        private ShoppingCart _cart;

        private int _productsInCart;

        public ShoppingCart Cart
        {
            get => _cart;
            private set => _cart = value;
        }

        public int NumProductsInCart
        {
            get => _productsInCart;
            private set => _productsInCart = value;
        }


        public Dictionary<string, Stack<VendingItem>> Products
        {
            get => _products;
            private set => _products = value;
        }

        public VendingMachine()
        {
            Cart = new ShoppingCart();
            Products = new Dictionary<string, Stack<VendingItem>>();
            NumProductsInCart = 0;
        }

        public void RemoveFromCart(VendingItem product)
        {
            foreach (string code in Cart.ProductsInCart.Keys)
            {
                foreach (VendingItem v in Cart.ProductsInCart[code])
                {
                    if (v.ProductName != product.ProductName)
                        break;

                    Products[code].Push(product);
                    Cart.ProductsInCart[code].Remove(v);
                    NumProductsInCart--;
                    return;

                }
            }
        }

        public void Purchase(string code)
        {
            if (Products[code].Count < 1)
                throw new Exception("Insufficient stock to purchase product");

            Cart.AddToCart(code, Products[code].Pop());
            NumProductsInCart++;
        }

        private string StockToCSV() //Returns a string of the stock in csv format
        {
            StringBuilder sb = new StringBuilder();
            string name;
            decimal price;


            foreach (string code in Products.Keys)
            {
                if (Products[code].Count < 1)
                {
                    name = Cart.ProductsInCart[code].Last().ProductName;
                    price = Cart.ProductsInCart[code].Last().Price;
                }
                else
                {
                    name = Products[code].Peek().ProductName;
                    price = Products[code].Peek().Price;
                }
                sb.AppendLine($"{code},{Products[code].Count},{name},{price}");
            }

            return sb.ToString();
        }

        private void SaveStock()
        {

            MessageBoxResult result;
            //Ask if user wants to save stock
            result = MessageBox.Show("Would you like to save current vending stock?", "Save", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "CSV file (*.csv)|*.csv";
                if (sf.ShowDialog() == true)
                    File.WriteAllText(sf.FileName, StockToCSV()); //Saves stock as csv file
            }
        }

        public void MakeTransaction()
        {
            if (!CheckForProductsInCart())
            {
                return;
            }
            else
            {
                string receipt = Cart.GenerateReceipt();

                CompleteTransaction(receipt);
            }

        }

        public void MakeTransaction(decimal bill) //overloaded CompleteTransaction method, used if payment is cash
        {
            if (!CheckForProductsInCart())
            {
                return;
            }
            else
            {
                string receipt = Cart.GenerateReceipt(bill);

                if (receipt == null)
                {
                    MessageBox.Show("Insufficent funds.", "Receipt");
                }
                else
                {
                    CompleteTransaction(receipt);
                }
            }

        }

        private void CompleteTransaction(string receipt)
        {
            NumProductsInCart = 0;
            MessageBox.Show(receipt, "Receipt");
            SaveStock();
            Cart.EmptyCart();
            SaveTransaction(receipt);
        }

        private bool CheckForProductsInCart()
        {
            if (NumProductsInCart == 0)
            {
                MessageBox.Show("You have not selected anything to purchase.", "Receipt couldn't print");
                return false;
            }
            return true;
        }

        private void SaveTransaction(string receipt)
        {
            //Saves receipt to file
            const string SAVE_LOCATION = "../../../Data/Transactions.txt";

            File.AppendAllText(SAVE_LOCATION, receipt + "\n");
        }

    }
}
