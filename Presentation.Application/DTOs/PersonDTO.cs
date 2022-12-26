using System.ComponentModel.DataAnnotations;

namespace Presentation.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string Email { get; set; } = string.Empty;
    }
}
