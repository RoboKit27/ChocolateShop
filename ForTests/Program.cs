using ChocolateShop.Core.Dots;
using ChocolateShop.DAL;

namespace ForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ChocolateRepository repository = new ChocolateRepository();
            ChocolateDto chocolate = repository.GetChocolateById(1);
            //foreach (AdditiveDto additive in chocolate.Additives)
            //{
            //    Console.WriteLine($"{additive.Id} - {additive.Name}");
            //}
            Console.WriteLine($"{chocolate.Company.Id} - {chocolate.Company.Name} - {chocolate.Company.Country}");
        }
    }
}
