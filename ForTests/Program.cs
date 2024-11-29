using ChocolateShop.Core.Dots;
using ChocolateShop.DAL;

namespace ForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChocolateRepository repository = new ChocolateRepository();
            ChocolateDto data = new ChocolateDto()
            {
                Name="Cherry Jam",
                Cost=190,
                ProductDate="25.03.24",
                BestBefore=3,
                Weight=80,
                CompanyId=2,
                TypeId=1
            };
            repository.AddChocolate(data);
        }
    }
}
