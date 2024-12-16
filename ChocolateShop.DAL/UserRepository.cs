using ChocolateShop.Core;
using ChocolateShop.Core.Dtos;
using ChocolateShop.DAL.Queries;
using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
namespace ChocolateShop.DAL
{
    internal class UserRepository
    {
        public List<UserDto> GetAllUsers()
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = UserQueries.GetAllUsersQuery;
                List<UserDto> result = connection.Query<UserDto>(query).ToList();

                return result;
            }
        }
        public UserDto GetUserById(int UserId)
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = UserQueries.GetUserByIdQuery;
                var param = new { Id = UserId };
                UserDto result = connection.QueryFirst<UserDto>(query, param);

                return result;
            }
        }
        public void AddUser(UserDto user, List<RoleDto> )
        {
            using (var connection = new NpgsqlConnection(Options.ConnectionString))
            {
                connection.Open();

                string query = UserQueries.AddUserQuery;
                var param = new
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = user.Password,
                    Phone = user.Phone
                };
                connection.Query(query, param);
            }
        }      
    }
}
