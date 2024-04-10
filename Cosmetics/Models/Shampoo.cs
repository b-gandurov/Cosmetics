using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Cosmetics.Models
{

    public class Shampoo : Product, IShampoo 
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private int _millilitres;
        private UsageType _usage;
      

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage) : base (name, brand, price, gender)
        {
            Millilitres = millilitres;
            _usage = usage;

        }

        public int Millilitres
        {
            get
            {
                return _millilitres;
            }
            set
            {
                ValidationHelper.ValidateNonNegative(value, "Millilitres");
            }
        }

        public UsageType Usage
        {
            get 
            {
              return _usage;
            }
        }

        protected override string CustomInfo()
        {

            StringBuilder customInfo = new StringBuilder();
            customInfo.AppendLine($"# Milliliters: {_millilitres}");
            customInfo.AppendLine($"# Usage: {_usage}");

            return customInfo.ToString();
        }

        protected override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength( brand, BrandMinLength, BrandMaxLength);
        }

     

        protected override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }

        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price,"Price");
        }
    }
}
