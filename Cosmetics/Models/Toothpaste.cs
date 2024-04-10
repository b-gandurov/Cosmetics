using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string _ingredients;
        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)

               : base(name, brand, price, gender)
        {
            if (ingredients == null)
            {
                throw new ArgumentNullException();
            }
            _ingredients = ingredients;
        }

        public string Ingredients => _ingredients;

        protected override string CustomInfo()
        {
            return $" #Ingredients: {Ingredients}";
        }

        protected override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength, "Name");
        }
        protected override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength, "Brand");
        }
        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }


    }


}
