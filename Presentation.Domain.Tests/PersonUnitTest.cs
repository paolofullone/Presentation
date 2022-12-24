using FluentAssertions;
using Presentation.Domain.Entities;
using Presentation.Domain.Validation;

namespace Presentation.Domain.Tests
{
    public class PersonUnitTest
    {
        [Fact(DisplayName = "Create Person with valid State")]
        public void CreatePerson_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Person(fullName: "Paolo Fullone", email: "paolo.fullone@xpi.com.br", city: "Coronel Fabriciano", state: "MG", linkedinUrl: "https://www.linkedin.com/in/paolofullone/", birthDate: new DateTime(1978, 08, 10));

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Person with invalid State")]
        public void CreatePerson_WithInvalidState_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Person(fullName: "Paolo Fullone", email: "paolo.fullone@xpi.com.br", city: "Coronel Fabriciano", state: "Minas Gerais", linkedinUrl: "https://www.linkedin.com/in/paolofullone/", birthDate: new DateTime(1978, 08, 10));

            action.Should().Throw<DomainExceptionValidation>().WithMessage("The state is too long, maximum 2 characters");
        }

        [Fact(DisplayName = "Create Person with invalid Id")]
        public void CreatePerson_WithInvalidId_ThrowsDomainExceptionValidation()
        {
            Action action = () => new Person(id: -1, fullName: "Paolo Fullone", email: "paolo.fullone@xpi.com.br", city: "Coronel Fabriciano", state: "Minas Gerais", linkedinUrl: "https://www.linkedin.com/in/paolofullone/", birhtDate: new DateTime(1978, 08, 10));

            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid id value");
        }
    }
}