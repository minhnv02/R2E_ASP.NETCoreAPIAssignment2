using AutoMapper;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.RequestDto;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.ResponseDto;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.Models;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.RepositoryDtos;

namespace Rookies_ASP.NETCoreAPI_2.API.Dtos
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RequestPersonDto, Person>();
            CreateMap<Person, ResponsePersonDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => MapGender((int)src.Gender))); ;
            CreateMap<ApiFilterPersonDto, RepoFilterPersonDto>();
        }

        private string MapGender(int gender)
        {
            string genderStr = string.Empty;
            switch (gender)
            {
                case 0:
                    genderStr = "unknown";
                    break;
                case 1:
                    genderStr = "male";
                    break;
                case 2:
                    genderStr = "female";
                    break;
            }
            return genderStr;
        }

    }
}
