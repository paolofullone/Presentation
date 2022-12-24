using System.ComponentModel.DataAnnotations;

namespace Presentation.Application.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The email is required.")]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = "The city is required.")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "The state is required.")]
        public string State { get; set; } = string.Empty;
        [Required(ErrorMessage = "The linkedin url is required.")]
        public string LinkedinUrl { get; set; } = string.Empty;
        [Required(ErrorMessage = "The birthdate is required.")]
        public DateTime BirthDate { get; set; }
    }
}
