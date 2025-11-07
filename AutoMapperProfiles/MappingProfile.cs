using AutoMapper;
using MyExpenditure.Model;

namespace MyExpenditure.AutoMapperProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expenditure, ExpenditureDto>();
            CreateMap<ExpenditureCreateDto, Expenditure>();
            CreateMap<ExpenditureUpdateDto, Expenditure>();

        }
    }
}
