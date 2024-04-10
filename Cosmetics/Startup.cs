using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models.Enums;
using Cosmetics.Models;
using System;

namespace Cosmetics
{
    public class Startup
    {
        static void Main()
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine cosmeticsEngine = new Engine(commandFactory);
            cosmeticsEngine.Start();
         
        }
    }
}
