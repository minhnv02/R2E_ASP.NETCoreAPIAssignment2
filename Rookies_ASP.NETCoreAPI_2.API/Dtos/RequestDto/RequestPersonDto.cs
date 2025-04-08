using Rookies_ASP.NETCoreAPI_2.Common;
using System.ComponentModel.DataAnnotations;

namespace Rookies_ASP.NETCoreAPI_2.API.Dtos.RequestDto
{
    public class RequestPersonDto
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EnumDataType(typeof(TypeGender))]
        public TypeGender Gender { get; set; }
        [Required]
        public string? BirthPlace { get; set; }
    }
}
