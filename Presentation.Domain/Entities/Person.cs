using Presentation.Domain.Validation;

namespace Presentation.Domain.Entities
{
    public sealed class Person : Entity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string LinkedinUrl { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }

        public Person(string fullName, string email, string city, string state, string linkedinUrl, DateTime birthDate)
        {
            ValidateDomain(fullName, email, city, state, linkedinUrl, birthDate);
        }

        public Person(int id, string fullName, string email, string city, string state, string linkedinUrl, DateTime birhtDate)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(fullName, email, city, state, linkedinUrl, birhtDate);
        }

        private void ValidateDomain(string fullName, string email, string city, string state, string linkedinUrl, DateTime birhtDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(fullName), "The name is required");
            DomainExceptionValidation.When(fullName.Length < 3, "The name is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "The email is required");
            DomainExceptionValidation.When(email.Length < 5, "The email is too short, minimum 5 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), "The city is required");
            DomainExceptionValidation.When(city.Length < 3, "The city is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(state), "The state is required");
            DomainExceptionValidation.When(state.Length > 2, "The state is too long, maximum 2 characters");
            DomainExceptionValidation.When(linkedinUrl?.Length > 0 && !Uri.IsWellFormedUriString(linkedinUrl, UriKind.Absolute), "The linkedin url is invalid");
            DomainExceptionValidation.When(birhtDate > DateTime.Now, "The birth date is greater than the current date");

            DomainExceptionValidation.When(birhtDate > DateTime.Now, "The birthdate is invalid");

            FullName = fullName;
            Email = email;
            City = city;
            State = state;
            LinkedinUrl = linkedinUrl!;
            BirthDate = birhtDate;
        }
    }

}

