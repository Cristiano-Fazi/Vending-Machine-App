using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PIIIProject.Models
{
    public class ShoppingCart
    {

        private Dictionary<string, List<VendingItem>> _products;


        public Dictionary<string, List<VendingItem>> ProductsInCart
        {
            get => _products;
            private set => _products = value;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal total = 0;

                foreach (List<VendingItem> v in ProductsInCart.Values)
                {
                    if(v.Count > 0)
                        total += v.Count * v.Last().Price;
                }

                return total;
            }
        }

        public ShoppingCart()
        {
            ProductsInCart = new Dictionary<string, List<VendingItem>>();
        }


        public void AddToCart(string code, VendingItem product)
        {
            if (ProductsInCart.ContainsKey(code))
            {
                ProductsInCart[code].Add(product);
                return;
            }

            ProductsInCart.Add(code, new List<VendingItem>());
            ProductsInCart[code].Add(product);
        }


        public string GenerateReceipt()
        {
            StringBuilder sb = new StringBuilder();

            foreach (List<VendingItem> product in ProductsInCart.Values)
            {
                if(product.Count > 0)
                    sb.AppendLine($"{product.Count} {product.Last().ProductName}(s): {(product.Count * product.Last().Price).ToString("C")}");
            }
            sb.AppendLine("Total: " + TotalPrice.ToString("C"));

            return sb.ToString();
        }

        public string GenerateReceipt(decimal bill) //overloaded method for cash payment
        {
            decimal change = bill - TotalPrice;

            if (change < 0)
                return null;

            StringBuilder sb = new StringBuilder();
            foreach (List<VendingItem> product in ProductsInCart.Values)
            {
                sb.AppendLine($"{product.Count} {product.Last().ProductName}(s): {(product.Count * product.Last().Price).ToString("C")}");
            }
            sb.AppendLine("Total: " + TotalPrice.ToString("C"));
            sb.AppendLine("Change: " + change.ToString("C"));

            return sb.ToString();
        }

        public void EmptyCart()
        {
            ProductsInCart.Clear();
        }
    }
}
