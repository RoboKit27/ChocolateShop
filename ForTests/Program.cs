using ChocolateShop.Core.Dtos;
using ChocolateShop.DAL;

namespace ForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> s = new List<int>() { 3, 4, 5, 6 };
            Console.WriteLine(s.IndexOf(2));
        }
    }
}
