using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.DAL.Queries
{
    public static class ChocolateQueries
    {
        public const string GetAllChocolatesQuery = "select \"Id\" from \"Chocolate\";";
        public const string GetChocolateByIdQuery = "select \"Id\", \"Name\", \"Cost\", \"StorageTime\", \"Weight\" from \"Chocolate\" where \"Id\"=@Id;";
        public const string GetChocolateAdditivesByChocolateIdQuery = "select A.\"Id\", A.\"Name\" from \"Additive\" as A join \"Chocolate_Additive\" as CA on CA.\"AdditiveId\"=A.\"Id\" join \"Chocolate\" as CH on CH.\"Id\"=CA.\"ChocolateId\" where CA.\"ChocolateId\"=@Id";
        public const string GetChocolateCompanyByChocolateIdQuery = "select COM.\"Id\", COM.\"Name\", COM.\"Country\" from \"Company\" as COM join \"Chocolate\" as CH on CH.\"CompanyId\"=COM.\"Id\" where CH.\"Id\"=@Id";
        public const string GetChocolateTypeByChocolateIdQuery = "select T.\"Id\", T.\"Name\" from \"Type\" as T join \"Chocolate\" as CH on CH.\"TypeId\"=T.\"Id\" where CH.\"Id\"=@Id";
        public const string GetAllChocolateCompaniesQuery = "select \"Id\", \"Name\", \"Country\" from \"Company\";";
        public const string GetAllChocolateTypesQuery = "select \"Id\", \"Name\" from \"Type\";";

        public const string AddChocolateQuery = "insert into \"Chocolate\"(\"Name\", \"Cost\", \"StorageTime\", \"Weight\", \"CompanyId\", \"TypeId\") values (@Name, @Cost, @StorageTime, @Weight, @CompanyId, @TypeId) returning \"Id\";";
        public const string AddChocolateAdditivesQuery = "insert into \"Chocolate_Additive\"(\"ChocolateId\",\"AdditiveId\") values (@ChocolateId,@AdditiveId)";
    }
}
