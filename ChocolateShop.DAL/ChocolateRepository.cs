using ChocolateShop.Core;
using ChocolateShop.Core.Dots;
using ChocolateShop.DAL.Queries;
using Dapper;
using Npgsql;

namespace ChocolateShop.DAL
{
    public class ChocolateRepository
    {
        public List<ChocolateDto> GetAllChocolates()
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ChocolateQueries.GetAllChocolatesQuery;
                List<ChocolateDto> result = connection.Query<ChocolateDto>(query).ToList();

                return result;
            }
        }
        public ChocolateDto GetChocolateById(int id)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ChocolateQueries.GetChocolateByIdQuery;
                var param = new { Id = id };
                ChocolateDto result = connection.QueryFirst<ChocolateDto>(query, param);

                return result;
            }
        }
        public void AddChocolate(ChocolateDto data)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ChocolateQueries.AddChocolate;
                var param = new { 
                    Name = data.Name, 
                    Cost = data.Cost, 
                    ProductDate = data.ProductDate, 
                    BestBefore = data.BestBefore, 
                    Weight = data.Weight, 
                    CompanyId = data.CompanyId, 
                    TypeId = data.TypeId 
                };
                connection.Query<ChocolateDto>(query, param);
            }
        }
    }
}
