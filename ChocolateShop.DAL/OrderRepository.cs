using ChocolateShop.Core.Dtos;
using ChocolateShop.Core;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChocolateShop.DAL.Queries;
using Dapper;

namespace ChocolateShop.DAL
{
    public class OrderRepository
    {
        public List<OrderDto> GetAllOrders()
        {
            using(var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = OrderQueries.GetAllOrdersQuery;
                List<OrderDto> result = connection.Query<OrderDto>(query).ToList();

                return result;
            }
        }
        public OrderDto GetOrderById(int id)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = OrderQueries.GetOrderByIdQuery;
                var param = new { Id = id };
                OrderDto result = connection.QueryFirst<OrderDto>(query, param);

                query = OrderQueries.GetOrderClientQuery;
                result.Client = connection.QueryFirst<ClientDto>(query, param);
                
                query = OrderQueries.GetOrderChocolatesQuery;
                List<int> chocolatesId = connection.Query<int>(query, param).ToList();

                decimal cost = 0;
                result.Chocolates = new();
                ChocolateRepository chocolateRepository = new ChocolateRepository();
                foreach (int chocolateId in chocolatesId)
                {
                    ChocolateDto chocolate = chocolateRepository.GetChocolateById(chocolateId);
                    result.Chocolates.Add(chocolate);
                    cost += chocolate.Cost;
                }

                result.Cost = cost;
                result.ChocolateAmount = result.Chocolates.Count;

                return result;
            }
        }
        public void AddOrder(string orderDate, int clientId, List<int> chocolates)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = OrderQueries.AddOrderQuery;
                var param = new
                {
                    Date=orderDate,
                    ClientId=clientId
                };
                int orderId = connection.QueryFirst<int>(query, param);

                query = OrderQueries.AddOrderChocolatesQuery;
                foreach (int chocolateId in chocolates)
                {
                    var chocolateParam = new
                    {
                        OrderId=orderId,
                        ChocolateId=chocolateId
                    };
                    connection.Query(query, chocolateParam);
                }

            }
        }
    }
}
