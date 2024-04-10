using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);
            string name = CommandParameters[0];
            string brand = CommandParameters[1];
            decimal price = ParseDecimalParameter(CommandParameters[2],"price");
            GenderType gender = ParseGenderType(CommandParameters[3]);
            ScentType scent = ParseScentType(CommandParameters[4]);


            return CreateCream(name,brand,price,gender,scent);
        }
        protected UsageType ParseUsageType(string value)
        {
            if (Enum.TryParse(value, true, out UsageType result))
            {
                return result;
            }
            throw new ArgumentException($"None of the enums in UsageType match the value {value}.");
        }

        private string CreateCream(string name, string brand, decimal price, GenderType gender, ScentType scent)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Product with name {name} already exists!"));
            }

            this.Repository.CreateCream(name, brand, price, gender, scent);

            return $"Cream with name {name} was created!";
        }

    }
}
