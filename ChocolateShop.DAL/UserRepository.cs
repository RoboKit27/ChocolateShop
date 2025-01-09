using ChocolateShop.Core;
using ChocolateShop.Core.Dtos;
using ChocolateShop.DAL.Queries;
using Dapper;
using Npgsql;
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
        public void AddUser(UserDto user)
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
                    Phone = user.Phone,
                    RoleTd = user.RoleId
                };
                connection.Query(query, param);
            }
        }
        //public List<UserDto> GetAllUsers()
        //{
        //    string conectionString = Options.ConnectionString;
        //    using (var connection = new NpgsqlConnection(Options.ConnectionString))
        //    {
        //        string query = UserQueries.GetRoleQuery;
        //        connection.Open();
        //        List<UserDto> result = connection.Query<UserDto, RoleDto, UserDto>(query,
        //            (user, role) =>
        //            {
        //                user.Role = role;
        //                return user;
        //            },
        //            splitOn:"Id").ToList();
        //        return result;
        //    }
        //} 
    }
}

