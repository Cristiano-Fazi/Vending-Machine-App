using Microsoft.Win32;
using PIIIProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PIIIProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        private VendingMachine vendingMachine;

        public MainWindow()
        {
            const string DATA_PATH = "../../../Data/stock.csv";
            InitializeComponent();
            vendingMachine = new VendingMachine();

            try
            {
                LoadProducts(DATA_PATH); //Generate VendingItem objects from file

                LoadMachine(); //Write codes and prices from objects and print to screen
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void LoadMachine()
        {
            const byte CODE_START_INDEX = 3, CODE_SIZE = 3;
            string code;

            foreach (TextBlock txt in GetTextBlocks())
            {
                code = txt.Name.Substring(CODE_START_INDEX, CODE_SIZE); //Gets the code from the textblock names

                txt.Text = $"{code} | {vendingMachine.Products[code].Peek().Price.ToString("C")}";
                //Peek returns last item without removing it from stack, price is the same for each item in stack.
            }

        }

        public List<TextBlock> GetTextBlocks()
        {
            List<TextBlock> textBlocks = new List<TextBlock>();

            textBlocks.Add(txtA11);
            textBlocks.Add(txtA12);
            textBlocks.Add(txtA13);
            textBlocks.Add(txtB21);
            textBlocks.Add(txtB22);
            textBlocks.Add(txtB23);
            textBlocks.Add(txtC31);
            textBlocks.Add(txtC32);
            textBlocks.Add(txtC33);
            textBlocks.Add(txtD41);
            textBlocks.Add(txtD42);
            textBlocks.Add(txtD43);

            return textBlocks;
        }

        public List<Image> GetImages()
        {
            List<Image> imgs = new List<Image>();

            imgs.Add(imgA11);
            imgs.Add(imgA12);
            imgs.Add(imgA13);
            imgs.Add(imgB21);
            imgs.Add(imgB22);
            imgs.Add(imgB23);
            imgs.Add(imgC31);
            imgs.Add(imgC32);
            imgs.Add(imgC33);
            imgs.Add(imgD41);
            imgs.Add(imgD42);
            imgs.Add(imgD43);

            return imgs;
        }


        public void LoadProducts(string filePath)
        {
            const byte SIZE = 12;
            const byte CODE = 0, QUANTITY = 1, NAME = 2, PRICE = 3;
            Stack<VendingItem> items;

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line = "";
                string[] csv;
                string code, name;
                int quantity;
                decimal price;

                for (int i = 0; i < SIZE; i++)
                {
                    if (line == null)
                        break;
                    line = sr.ReadLine();
                    csv = line.Split(',');

                    code = csv[CODE];
                    name = csv[NAME];
                    quantity = Convert.ToInt32(csv[QUANTITY]);
                    price = Convert.ToDecimal(csv[PRICE]);
                    items = new Stack<VendingItem>();

                    for (int j = 0; j < quantity; j++)
                    {
                        items.Push(new VendingItem(name, price)); //Items are stored as a stack in the vending machine
                    }

                    vendingMachine.Products.Add(code, items);

                    if (quantity == 0)
                        ChangeImgVisibility(code, Visibility.Hidden); //If the product is out of stock hide it's image

                }
            }

        }

        #region keypad



        #endregion

        private void key_Click(object sender, RoutedEventArgs e)
        {
            const byte MAX_CHARS = 3;
            char key = (sender as Button).Content.ToString()[0]; //Gets the number of the key pressed

            ResetDisplayInvalid();

            //ensure input does not exceed 3 characters long
            if (CodeDisplay.Text.Length == MAX_CHARS)
                return;

            //ensure input follows code format of CHAR:NUMBER:NUMBER
            if (CodeDisplay.Text.Length > 0)
            {
                if (char.IsLetter(key))
                    return;
            }
            else
            {
                if (CodeDisplay.Text.Length < 1)
                {
                    if (char.IsDigit(key))
                        return;
                }

            }

            CodeDisplay.Text += key;
        }

        private void keyDel_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayInvalid();

            if (CodeDisplay.Text.Length > 0)
                CodeDisplay.Text = CodeDisplay.Text.Remove(CodeDisplay.Text.Length - 1); //removes last character from screen
        }

        public void ResetDisplayInvalid()
        {
            //if screen has inv code or no more, I want it to be reset to empty with any key press
            if (CodeDisplay.Text == "Inv code" || CodeDisplay.Text == "No More")
                CodeDisplay.Text = String.Empty;
        }

        private void keyEnter_Click(object sender, RoutedEventArgs e)
        {
            ResetDisplayInvalid();

            const byte MAX_CHARS = 3;
            if (CodeDisplay.Text.Length != MAX_CHARS)
                return;

            BuyProduct(CodeDisplay.Text);
        }

        private void keyCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow winCart = new CartWindow(vendingMachine);
            winCart.Show();
            winCart.Closed += new EventHandler(CartWindow_Closed); //CartWindow_Closed method subscribes to closed event
        }

        private void CartWindow_Closed(object sender, EventArgs e)
        {
            //Invoked when Cart window is closed, if product was out of stock and is now back in stock, the image is visible again
            foreach (string code in vendingMachine.Products.Keys)
            {
                if (vendingMachine.Products[code].Count > 0)
                    ChangeImgVisibility(code, Visibility.Visible);
            }
        }

        public void BuyProduct(string code)
        {
            //Adds specified VendingItem by its code to a list in vending machine
            if (vendingMachine.Products.ContainsKey(code)) //Checks if code is a valid code for a product
            {
                CodeDisplay.Text = String.Empty;

                if (vendingMachine.Products[code].Count > 0) //Check if product is in stock
                {
                    vendingMachine.Purchase(code);

                    if(vendingMachine.Products[code].Count == 0)
                    {
                        //If after purchase there is no more left in stock, hide image
                        ChangeImgVisibility(code, Visibility.Hidden);
                    }
                }
                else
                {
                    CodeDisplay.Text = "No More";
                }
            }
            else
            {
                CodeDisplay.Text = "Inv code";
            }
        }


        public void ChangeImgVisibility(string code, Visibility visibility)
        {
            foreach (Image img in GetImages())
            {
                if(img.Name.Contains(code))
                {
                    img.Visibility = visibility;
                }

            }
        }

        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            CashWindow cw = new CashWindow(vendingMachine);
            cw.Show();
        }

        private void btnCard_Click(object sender, RoutedEventArgs e)
        {
            vendingMachine.MakeTransaction();
        }
    }
}
