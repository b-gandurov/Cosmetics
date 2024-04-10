using Cosmetics.Core;
using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using Cosmetics.Models.Enums;

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

            //CreateShampoo MyMan Nivea 10.99 Men 1000 EveryDay
            //CreateToothpaste White Colgate 10.99 Men calcium, fluorid
            //CreateCategory Shampoos
            //CreateCategory Toothpastes
            //AddToCategory Shampoos MyMan
            //AddToCategory Toothpastes White
            //AddToShoppingCart MyMan
            //AddToShoppingCart White
            //ShowCategory Shampoos
            //ShowCategory Toothpastes
            //TotalPrice
            //RemoveFromCategory Shampoos MyMan
            //ShowCategory Shampoos
            //RemoveFromShoppingCart MyMan
            //TotalPrice
        }
    }
}