﻿using ChocolateShop.Core;
using ChocolateShop.Core.Dtos;
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

                query = ChocolateQueries.GetChocolateAdditivesByChocolateIdQuery;
                result.Additives = connection.Query<AdditiveDto>(query, param).ToList();

                query = ChocolateQueries.GetChocolateCompanyByChocolateIdQuery;
                result.Company = connection.QueryFirst<CompanyDto>(query, param);

                query = ChocolateQueries.GetChocolateTypeByChocolateIdQuery;
                result.Type = connection.QueryFirst<TypeDto>(query, param);

                return result;
            }
        }

        public void AddChocolate(ChocolateDto chocolate, int CompanyId, int TypeId, List<int> AdditivesId)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = ChocolateQueries.AddChocolateQuery;
                var param = new { 
                    Name = chocolate.Name, 
                    Cost = chocolate.Cost, 
                    StorageTime = chocolate.StorageTime, 
                    Weight = chocolate.Weight,
                    CompanyId = CompanyId,
                    TypeId = TypeId
                };
                int ChocolateId = connection.QueryFirst<int>(query, param);

                query = ChocolateQueries.AddChocolateAdditivesQuery;
                foreach (int additiveId in AdditivesId)
                {
                    var additiveParam = new { 
                        ChocolateId=ChocolateId, 
                        AdditiveId=additiveId 
                    };
                    connection.Query(query, additiveParam);
                }

            }
        }
    }
}
