﻿using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Diagnostics;
using System.Text;

namespace Cosmetics.Models
{
    public abstract class Product : IProduct
    {
        private string _name;
        private string _brand;
        private decimal _price;
        private GenderType _gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Name = name;
            Brand = brand;
            Price = price;
            _gender = gender;
        }

        public string Name
        {
            get { return _name; }
            private set
            {
                ValidateName(value);
                _name = value;
            }
        }



        public string Brand
        {
            get { return _brand; }
            private set
            {
                ValidateBrand(value);
                _brand = value;
            }
        }

        public decimal Price
        {
            get { return _price; }
            private set
            {
                ValidatePrice(value);
                _price = value;
            }
        }

        public GenderType Gender
        {
            get { return _gender; }
        }

        public string Print()
        {
            StringBuilder productInfo = new StringBuilder();
            productInfo.AppendLine($"#{_name} {_brand}");
            productInfo.AppendLine($" #Price: {_price}");
            productInfo.AppendLine($" #Gender: {_gender}");
            productInfo.AppendLine(this.CustomInfo());
            productInfo.AppendLine($" ===");

            return productInfo.ToString();
        }

        protected abstract void ValidateName(string name);

        protected abstract void ValidateBrand(string brand);

        protected abstract void ValidatePrice(decimal price);

        protected abstract string CustomInfo();
    }
}
