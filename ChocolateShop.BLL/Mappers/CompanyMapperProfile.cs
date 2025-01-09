using AutoMapper;
using ChocolateShop.Core.Dtos;
using ChocolateShop.Core.OutputModels;

namespace ChocolateShop.BLL.Mappers
{
    public class CompanyMapperProfile : Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<CompanyDto, CompanyOutputModel>();
        }
    }
}
