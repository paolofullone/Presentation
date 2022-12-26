using Presentation.Domain.Enums;
using Presentation.Domain.Validation;

namespace Presentation.Domain.Entities
{
    public sealed class PersonalInfo : Entity
    {
        public string FullName { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public DateTime BirthDate { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public string Animals { get; private set; } = string.Empty;
        public string FavoriteFood { get; private set; } = string.Empty;
        public string FavoriteMusic { get; private set; } = string.Empty;
        public string FavoriteMovie { get; private set; } = string.Empty;
        public string FavoriteTVShow { get; private set; } = string.Empty;
        public string FavoriteBook { get; private set; } = string.Empty;
        public string FavoriteSport { get; private set; } = string.Empty;
        public string LinkedinUrl { get; private set; } = string.Empty;
        public int PersonId { get; set; }
        public Person? Person { get; set; }


        public PersonalInfo(string fullName, string city, string state, DateTime birthDate, MaritalStatus maritalStatus, string animals, string favoriteFood, string favoriteMusic, string favoriteMovie,
            string favoriteTVShow, string favoriteBook, string favoriteSport, string linkedinUrl, int personId)
        {
            ValidateDomain(fullName, city, state, birthDate, maritalStatus, animals, favoriteFood, favoriteMusic, favoriteMovie, favoriteTVShow, favoriteBook, favoriteSport, linkedinUrl, personId);
        }

        public PersonalInfo(int id, string fullName, string city, string state, DateTime birthDate, MaritalStatus maritalStatus, string animals, string favoriteFood, string favoriteMusic, string favoriteMovie,
            string favoriteTVShow, string favoriteBook, string favoriteSport, string linkedinUrl, int personId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id value");
            Id = id;
            ValidateDomain(fullName, city, state, birthDate, maritalStatus, animals, favoriteFood, favoriteMusic, favoriteMovie, favoriteTVShow, favoriteBook, favoriteSport, linkedinUrl, personId);
        }

        // método usado no mapping do mediatr no projeto application para atualizar os dados, pois o set é privado
        public void Update(string fullName, string city, string state, DateTime birthDate, MaritalStatus maritalStatus, string animals, string favoriteFood, string favoriteMusic, string favoriteMovie,
            string favoriteTVShow, string favoriteBook, string favoriteSport, string linkedinUrl, int personId)
        {
            ValidateDomain(fullName, city, state, birthDate, maritalStatus, animals, favoriteFood, favoriteMusic, favoriteMovie, favoriteTVShow, favoriteBook, favoriteSport, linkedinUrl, personId);
        }

        private void ValidateDomain(string fullName, string city, string state, DateTime birthDate, MaritalStatus maritalStatus, string animals, string favoriteFood, string favoriteMusic, string favoriteMovie,
    string favoriteTVShow, string favoriteBook, string favoriteSport, string linkedinUrl, int personId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(fullName), "The name is required");
            DomainExceptionValidation.When(fullName.Length < 3, "The name is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(city), "The city is required");
            DomainExceptionValidation.When(city.Length < 3, "The city is too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(state), "The state is required");
            DomainExceptionValidation.When(state.Length > 2, "The state is too long, maximum 2 characters");
            DomainExceptionValidation.When(birthDate > DateTime.Now, "The birth date is greater than the current date");
            DomainExceptionValidation.When(birthDate > DateTime.Now, "The birthdate is invalid");
            DomainExceptionValidation.When(maritalStatus.ToString().Length < 3, "The marital status must be informed");
            DomainExceptionValidation.When(string.IsNullOrEmpty(animals), "You must inform if you have animals");
            DomainExceptionValidation.When(string.IsNullOrEmpty(favoriteFood), "You must inform your favorite food");
            DomainExceptionValidation.When(string.IsNullOrEmpty(favoriteMusic), "You must inform your favorite Music");
            DomainExceptionValidation.When(string.IsNullOrEmpty(favoriteTVShow), "You must inform your favorite TVShow");
            DomainExceptionValidation.When(string.IsNullOrEmpty(favoriteBook), "You must inform your favorite Book");
            DomainExceptionValidation.When(string.IsNullOrEmpty(favoriteSport), "You must inform your favorite Sport");
            DomainExceptionValidation.When(!Uri.IsWellFormedUriString(linkedinUrl, UriKind.Absolute), "The linkedin url is invalid");
            DomainExceptionValidation.When(personId < 0, "Invalid person id value");

            FullName = fullName;
            City = city;
            State = state;
            BirthDate = birthDate;
            MaritalStatus = maritalStatus;
            Animals = animals;
            FavoriteFood = favoriteFood;
            FavoriteMusic = favoriteMusic;
            FavoriteMovie = favoriteMovie;
            FavoriteTVShow = favoriteTVShow;
            FavoriteBook = favoriteBook;
            FavoriteSport = favoriteSport;
            LinkedinUrl = linkedinUrl;
            PersonId = personId;
        }
    }
}
