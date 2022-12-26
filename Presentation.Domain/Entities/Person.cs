using Presentation.Domain.Validation;

namespace Presentation.Domain.Entities
{
    public sealed class Person : Entity
    {
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public int? PersonalInfoId { get; set; }
        public PersonalInfo? PersonalInfo { get; set; }

        public Person(string email, string password)
        {
            ValidateDomain(email, password);
        }

        public Person(int id, string email, string password)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(email, password);
        }

        // método usado no mapping do mediatr no projeto application para atualizar os dados, pois o set é privado

        public void Update(string email, string password)
        {
            ValidateDomain(email, password);
        }

        public void Update(string email, string password, int personalInfoId, PersonalInfo personalInfo)
        {
            ValidateDomain(email, password);
            PersonalInfoId = personalInfoId;
            PersonalInfo = personalInfo;
        }

        private void ValidateDomain(string email, string password)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "The email is required");
            // TODO: validate email format using regex
            DomainExceptionValidation.When(email.Length < 5, "The email is too short, minimum 5 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "The password is required");
            DomainExceptionValidation.When(password.Length < 8, "The password is too short, minimum 8 characters");
            Email = email;
            Password = password;
        }
    }
}

