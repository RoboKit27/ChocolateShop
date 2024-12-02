using ChocolateShop.Core.Dots;
using ChocolateShop.DAL;

namespace ForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChocolateRepository repository = new ChocolateRepository();
            ChocolateDto chocolate = new ChocolateDto()
            {
                Name = "Banana",
                Cost = 300,
                ProductDate = "25.03.25",
                BestBefore = 3,
                Weight = 80,
                Company = new() { Id=1 },
                Type = new() { Id=3 }
            };
            repository.AddChocolate(chocolate);
        }
    }
}
