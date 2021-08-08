// <copyright file="ValidatorsFactoryTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Validators
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.UnitTests.Validators.Mocks;
    using TryCatch.Validators;
    using Xunit;

    public class ValidatorsFactoryTests
    {
        private readonly IServiceProvider serviceProvider;

        private readonly FakeValidatorsFactory sut;

        public ValidatorsFactoryTests()
        {
            this.serviceProvider = Substitute.For<IServiceProvider>();

            this.serviceProvider
                .GetService(Arg.Is(typeof(AddValidator)))
                .Returns(new AddValidator());

            this.serviceProvider
                .GetService(Arg.Is(typeof(FakeComponent)))
                .Returns(new FakeComponent());

            this.sut = new FakeValidatorsFactory(this.serviceProvider);
        }

        [Fact]
        public void Construct_Without_IServiceProvider()
        {
            // Arrange
            IServiceProvider serviceProvider = null;

            // Act
            Action act = () => _ = new FakeValidatorsFactory(serviceProvider);

            // Asserts
            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetValidator_with_invalid_key(string validatorKey)
        {
            // Arrange

            // Act
            Action act = () => _ = this.sut.GetValidator(validatorKey);

            // Asserts
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GetValidator_with_not_found_validator()
        {
            // Arrange
            const string validatorKey = "any-component";

            // Act
            Action act = () => _ = this.sut.GetValidator(validatorKey);

            // Asserts
            act.Should().Throw<ValidatorNotFoundException>();
        }

        [Fact]
        public void GetValidator_Ok()
        {
            // Arrange
            const string validatorKey = "add-validator";

            // Act
            var actual = this.sut.GetValidator(validatorKey);

            // Asserts
            actual.Should().NotBeNull();
            actual.Should().BeOfType(typeof(AddValidator));
        }
    }
}
