using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;

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


        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage)
            : base(name, brand, price, gender)
        {
            ValidationHelper.ValidateNonNegative(millilitres, "Millilitres");
            _millilitres = millilitres;
            _usage = usage;
        }

        public int Millilitres => _millilitres;

        public UsageType Usage => _usage;

        protected override string CustomInfo()
        {
            StringBuilder customInfo = new StringBuilder();
            customInfo.AppendLine($" #Milliliters: {Millilitres}");
            customInfo.AppendLine($" #Usage: {Usage}");

            return customInfo.ToString();
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
