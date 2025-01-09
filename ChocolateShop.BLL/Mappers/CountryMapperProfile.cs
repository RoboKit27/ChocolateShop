using AutoMapper;
using ChocolateShop.Core.Dtos;
using ChocolateShop.Core.OutputModels;

namespace ChocolateShop.BLL.Mappers
{
    public class CountryMapperProfile : Profile
    {
        public CountryMapperProfile()
        {
            CreateMap<CompanyDto, CountryOutputModel>()
                .ForMember(dist=>dist.Name, opt=>opt.MapFrom(srs=>srs.Country));
        }
    }
}
