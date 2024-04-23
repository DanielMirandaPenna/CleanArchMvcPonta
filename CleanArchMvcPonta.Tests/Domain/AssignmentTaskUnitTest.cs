using Bogus;
using CleanArchMvcPonta.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvcPonta.Tests.Domain
{
    public class AssignmentTaskUnitTest
    {
        private readonly Faker _faker;

        public AssignmentTaskUnitTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void CreateAssignmentTask_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new AssignmentTask(_faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(10));
            action.Should()
                 .NotThrow<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateAssignmentTask_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = () => new AssignmentTask(_faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(2), _faker.Random.AlphaNumeric(10));
            action.Should()
                .Throw<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid description. Too short");
        }
        [Fact]
        public void CreateAssignmentTask_ShortDescriptionValue_DomainExceptionLongDescription()
        {
            Action action = () => new AssignmentTask(_faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(300), _faker.Random.AlphaNumeric(10));
            action.Should()
                .Throw<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid descriptionle. Too long");
        }

        [Fact]
        public void CreateAssignmentTask_MissingDescriptionValue_DomainExceptionLongDescription()
        {
            Action action = () => new AssignmentTask(_faker.Random.AlphaNumeric(10), "", _faker.Random.AlphaNumeric(10));
            action.Should()
                .Throw<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid description. description is required");
        }


        [Fact]
        public void CreateAssignmentTask_ShortTitletionValue_DomainExceptionShortDescription()
        {
            Action action = () => new AssignmentTask(_faker.Random.AlphaNumeric(2), _faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(10));
            action.Should()
                .Throw<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Title. Too short");
        }
        [Fact]
        public void CreateAssignmentTask_ShortTitleValue_DomainExceptionLongDescription()
        {
            Action action = () => new AssignmentTask(_faker.Random.AlphaNumeric(300), _faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(10));
            action.Should()
                .Throw<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Title. Too long");
        }

        [Fact]
        public void CreateAssignmentTask_MissingTitleValue_DomainExceptionLongDescription()
        {
            Action action = () => new AssignmentTask("", _faker.Random.AlphaNumeric(10), _faker.Random.AlphaNumeric(10));
            action.Should()
                .Throw<CleanArchMvcPonta.Domain.Validation.DomainExceptionValidation>()
                   .WithMessage("Invalid Title. Title is required");
        }


    }
}