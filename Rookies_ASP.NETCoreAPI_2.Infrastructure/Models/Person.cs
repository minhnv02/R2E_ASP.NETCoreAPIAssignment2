using Rookies_ASP.NETCoreAPI_2.Common;
using System.ComponentModel.DataAnnotations;

namespace Rookies_ASP.NETCoreAPI_2.Infrastructure.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string? LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public TypeGender Gender { get; set; }
        [Required]
        public string? BirthPlace { get; set; }
    }
}
