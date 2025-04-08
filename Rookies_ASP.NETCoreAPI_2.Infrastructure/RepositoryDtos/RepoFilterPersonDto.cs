using Rookies_ASP.NETCoreAPI_2.Common;

namespace Rookies_ASP.NETCoreAPI_2.Infrastructure.RepositoryDtos
{
    public class RepoFilterPersonDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public TypeGender? Gender { get; set; }
        public string? BirthPlace { get; set; }
    }
}
