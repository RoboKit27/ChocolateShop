using ChocolateShop.Core.Dtos;
using ChocolateShop.DAL;

namespace ForTests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClientRepository repository = new ClientRepository();
            ClientDto client = repository.GetClientById(3);
            Console.WriteLine($"{client.Id} - {client.Name} - {client.Phone} - {client.Gmail}");
        }
    }
}
