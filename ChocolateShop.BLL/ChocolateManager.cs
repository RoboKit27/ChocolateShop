using AutoMapper;
using ChocolateShop.BLL.Mappers;
using ChocolateShop.Core.Dtos;
using ChocolateShop.Core.OutputModels;
using ChocolateShop.DAL;

namespace ChocolateShop.BLL
{
    public class ChocolateManager
    {

        private ChocolateRepository _chocolateRepository;
        private Mapper _mapper;

        public ChocolateManager()
        {
            this._chocolateRepository = new ChocolateRepository();
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new CompanyMapperProfile());
                cfg.AddProfile(new TypeMapperProfile());
                cfg.AddProfile(new ChocolateMapperProfile());
            });
            this._mapper = new Mapper(configuration);
        }

        public List<CompanyOutputModel> GetAllCompanies()
        {
            List<CompanyDto> companyDtos = this._chocolateRepository.GetAllChocolateCompanies();
            List<CompanyOutputModel> result = _mapper.Map<List<CompanyOutputModel>>(companyDtos);
            return result;
        }
        
        public List<TypeOutputModel> GetAllTypes()
        {
            List<TypeDto> typeDtos = this._chocolateRepository.GetAllChocolateTypes();
            List<TypeOutputModel> result = _mapper.Map<List<TypeOutputModel>>(typeDtos);
            return result;
        }
        
        public List<ChocolateOutputModel> GetAllChocolates()
        {
            List<ChocolateDto> chocolateDtos = this._chocolateRepository.GetAllChocolates();
            List<ChocolateOutputModel> result = _mapper.Map<List<ChocolateOutputModel>>(chocolateDtos);
            return result;
        }
    }
}
