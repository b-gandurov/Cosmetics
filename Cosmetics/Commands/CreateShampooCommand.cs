﻿using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
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
            int milliliters = ParseIntParameter(CommandParameters[4], "milliliters");
            UsageType usage = ParseUsageType(CommandParameters[5]);


            return CreateShampoo(name,brand,price,gender,milliliters,usage);
        }
        protected UsageType ParseUsageType(string value)
        {
            if (Enum.TryParse(value, true, out UsageType result))
            {
                return result;
            }
            throw new ArgumentException($"None of the enums in UsageType match the value {value}.");
        }

        private string CreateShampoo(string name, string brand, decimal price, GenderType gender, int milliliters, UsageType usage)
        {
            if (this.Repository.ProductExists(name))
            {
                throw new ArgumentException(string.Format($"Product with name {name} already exists!"));
            }

            this.Repository.CreateShampoo(name, brand, price, gender, milliliters, usage);

            return $"Shampoo with name {name} was created!";
        }

    }
}
