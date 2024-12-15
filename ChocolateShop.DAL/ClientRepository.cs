using ChocolateShop.Core;
using ChocolateShop.Core.Dtos;
using ChocolateShop.DAL.Queries;
using Dapper;
using Npgsql;

namespace ChocolateShop.DAL
{
    public class ClientRepository
    {
        public List<ClientDto> GetAllClients()
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ClientQueries.GetAllClientsQuery;
                List<ClientDto> result = connection.Query<ClientDto>(query).ToList();

                return result;
            }
        }

        public ClientDto GetClientById(int id)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ClientQueries.GetClientByIdQuery;
                var param = new { Id = id };
                ClientDto result = connection.QueryFirst<ClientDto>(query, param);

                return result;
            }
        }

        public void AddClient(ClientDto client)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ClientQueries.AddClientQuery;
                var param = new
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Phone = client.Phone,
                    Password = client.Password,
                    Email = client.Email
                };
                connection.Query(query, param);

            }
        }
    }
}
