using AutoMapper;
using ChocolateShop.Core.Dtos;
using ChocolateShop.Core.OutputModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateShop.BLL.Mappers
{
    public class ChocolateMapperProfile : Profile
    {
        public ChocolateMapperProfile()
        {
            CreateMap<ChocolateDto, ChocolateOutputModel>()
                .ForMember(dist=>dist.Company, opt=>opt.MapFrom(c=>c.Company.Name))
                .ForMember(dist=>dist.Country, opt=>opt.MapFrom(c=>c.Company.Country))
                .ForMember(dist=>dist.Type, opt=>opt.MapFrom(c=>c.Type.Name));
        }
    }
}
