using Rookies_ASP.NETCoreAPI_2.Infrastructure.Models;
using Rookies_ASP.NETCoreAPI_2.Infrastructure.RepositoryDtos;

namespace Rookies_ASP.NETCoreAPI_2.Infrastructure.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPeople(RepoFilterPersonDto filterPersonDto);
        int Add(Person person);
        int Delete(Guid id);
        int Update(Guid id, Person person);
    }
}
