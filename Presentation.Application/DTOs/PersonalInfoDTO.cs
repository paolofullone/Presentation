using Presentation.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Application.DTOs
{
    public class PersonalInfoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name is required.")]
        public string FullName { get; set; } = string.Empty;
        [Required(ErrorMessage = "The City is required.")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "The state is required.")]
        public string State { get; set; } = string.Empty;
        [Required(ErrorMessage = "The birthdate is required.")]
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            }
        }
        [Required(ErrorMessage = "The marital status is required")]
        public MaritalStatus MaritalStatus { get; set; }
        [Required(ErrorMessage = "Please inform if you have animals")]
        public string Animals { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Favorite Food is required")]
        public string FavoriteFood { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Favorite Music is required")]
        public string FavoriteMusic { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Favorite Movie is required")]
        public string FavoriteMovie { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Favorite TV Show is required")]
        public string FavoriteTVShow { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Favorite Book is required")]
        public string FavoriteBook { get; set; } = string.Empty;
        [Required(ErrorMessage = "The Favorite Sport is required")]
        public string FavoriteSport { get; set; } = string.Empty;
        [Required(ErrorMessage = "The linkedin url is required.")]
        public string LinkedinUrl { get; set; } = string.Empty;
        public int PersonId { get; set; }
    }
}
