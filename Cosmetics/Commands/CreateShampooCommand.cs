using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
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
            

            throw new NotImplementedException();
        }

    }
}
