using AutoMapper;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.RequestDto;
using Rookies_ASP.NETCoreAPI_2.API.Dtos.ResponseDto;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.Models;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.Repositories;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.RepositoryDtos;

namespace Rookies_ASP.NETCoreAPI_2.API.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public int Add(RequestPersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            Guid id = Guid.NewGuid();
            person.Id = id;
            return _personRepository.Add(person);
        }

        public int Delete(Guid id)
        {
            return _personRepository.Delete(id);
        }

        public List<ResponsePersonDto> GetPeople(ApiFilterPersonDto apiFilterPersonDto)
        {
            var repoFilterPersonDto = _mapper.Map<RepoFilterPersonDto>(apiFilterPersonDto);
            var people = _personRepository.GetPeople(repoFilterPersonDto);
            var peopleDtos = _mapper.Map<List<ResponsePersonDto>>(people);
            return peopleDtos;
        }

        public int Update(Guid id, RequestPersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            return _personRepository.Update(id, person);
        }
    }
}
