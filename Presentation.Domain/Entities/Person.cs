﻿using Presentation.Domain.Validation;

namespace Presentation.Domain.Entities
{
    public sealed class Person : Entity
    {
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string LinkedinUrl { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }

        public Person(string fullName, string email, string password, string city, string state, string linkedinUrl, DateTime birthDate)
        {
            ValidateDomain(fullName, email, password, city, state, linkedinUrl, birthDate);
        }

        public Person(int id, string fullName, string email, string password, string city, string state, string linkedinUrl, DateTime birhtDate)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(fullName, email, password, city, state, linkedinUrl, birhtDate);
        }

        // método usado no mapping do mediatr no projeto application para atualizar os dados, pois o set é privado
        public void Update(string fullName, string email, string password, string city, string state, string linkedinUrl, DateTime birthDate)
        {
            ValidateDomain(fullName, email, password, city, state, linkedinUrl, birthDate);
        }

        private void ValidateDomain(string fullName, string email, string password, string city, string state, string linkedinUrl, DateTime birhtDate)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(fullName), "The name is required");
            DomainExceptionValidation.When(fullName.Length < 3, "The name is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "The email is required");
            DomainExceptionValidation.When(email.Length < 5, "The email is too short, minimum 5 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(password), "The password is required");
            DomainExceptionValidation.When(password.Length < 6, "The password is too short, minimum 6 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), "The city is required");
            DomainExceptionValidation.When(city.Length < 3, "The city is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(state), "The state is required");
            DomainExceptionValidation.When(state.Length > 2, "The state is too long, maximum 2 characters");
            DomainExceptionValidation.When(!Uri.IsWellFormedUriString(linkedinUrl, UriKind.Absolute), "The linkedin url is invalid");
            DomainExceptionValidation.When(birhtDate > DateTime.Now, "The birth date is greater than the current date");

            DomainExceptionValidation.When(birhtDate > DateTime.Now, "The birthdate is invalid");

            FullName = fullName;
            Email = email;
            Password = password;
            City = city;
            State = state;
            LinkedinUrl = linkedinUrl!;
            BirthDate = birhtDate;
        }
    }

}

