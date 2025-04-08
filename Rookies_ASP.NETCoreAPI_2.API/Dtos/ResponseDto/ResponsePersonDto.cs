using System.ComponentModel.DataAnnotations;

namespace Rookies_ASP.NETCoreAPI_2.API.Dtos.ResponseDto
{
    public class ResponsePersonDto
    {
        public Guid Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? BirthPlace { get; set; }
    }
}
