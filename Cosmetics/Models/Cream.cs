using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Cosmetics.Models
{

    public class Cream : Product, ICream
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 15;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 15;

        private ScentType _scentType;


        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent) : base(name, brand, price, gender)
        {
            _scentType = scent;

        }

        public ScentType ScentType
        {
            get
            {
                return _scentType;
            }
        }

        protected override string CustomInfo()
        {

            StringBuilder customInfo = new StringBuilder();
            customInfo.AppendLine($"#Scent: {_scentType}");

            return customInfo.ToString();
        }

        protected override void ValidateBrand(string brand)
        {
            ValidationHelper.ValidateStringLength(brand, BrandMinLength, BrandMaxLength);
        }



        protected override void ValidateName(string name)
        {
            ValidationHelper.ValidateStringLength(name, NameMinLength, NameMaxLength);
        }

        protected override void ValidatePrice(decimal price)
        {
            ValidationHelper.ValidateNonNegative(price, "Price");
        }
    }
}
