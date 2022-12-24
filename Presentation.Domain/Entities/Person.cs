using Presentation.Domain.Validation;

namespace Presentation.Domain.Entities
{
    public sealed class Person : Entity
    {
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public DateTime BirhtDate { get; private set; }

        public Person(string fullName, string email, string city, string state, DateTime birhtDate)
        {
            ValidateDomain(fullName, email, city, state, birhtDate);
        }

        public Person(int id, string fullName, string email, string city, string state, DateTime birhtDate)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(fullName, email, city, state, birhtDate);
        }

        private void ValidateDomain(string fullName, string email, string city, string state, DateTime birhtDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(fullName), "The name is required");
            DomainExceptionValidation.When(fullName.Length < 3, "The name is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "The email is required");
            DomainExceptionValidation.When(email.Length < 5, "The email is too short, minimum 5 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), "The city is required");
            DomainExceptionValidation.When(city.Length < 3, "The city is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(state), "The state is required");
            DomainExceptionValidation.When(state.Length < 3, "The state is too short, minimum 3 characters");
            DomainExceptionValidation.When(birhtDate > DateTime.Now, "The birthdate is invalid");

            FullName = fullName;
            Email = email;
            City = city;
            State = state;
            BirhtDate = birhtDate;
        }
    }

}

