using System;
using System.Collections.Generic;
using System.Text;

namespace PIIIProject.Models
{
    public class VendingItem
    {
        private string _productName;

        private decimal _price;

        public string ProductName
        {
            get => _productName;
            private set => _productName = value;
        }

        public decimal Price
        {
            get => _price;
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                _price = value;
            }
        }

        public VendingItem(string name_, decimal price_)
        {
            ProductName = name_;
            Price = price_;
        }

    }
}
