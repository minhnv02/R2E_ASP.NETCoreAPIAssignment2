using Rookies_ASP.NETCoreAPI_2.Common;
using System.ComponentModel.DataAnnotations;

namespace Rookies_ASP.NETCoreAPI_2.API.Dtos.RequestDto
{
    public class ApiFilterPersonDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [EnumDataType(typeof(TypeGender))]
        public TypeGender? Gender { get; set; }
        public string? BirthPlace { get; set; }
    }
}
