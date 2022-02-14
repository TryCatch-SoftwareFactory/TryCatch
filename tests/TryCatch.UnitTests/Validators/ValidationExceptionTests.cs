// <copyright file="ValidationExceptionTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Validators
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using TryCatch.Validators;
    using Xunit;

    public class ValidationExceptionTests
    {
        [Fact]
        public void Construct_without_args()
        {
            // Arrange

            // Act
            var actual = new ValidationException();

            // Asserts
            actual.Message.Should().NotBeEmpty();
            actual.InnerException.Should().BeNull();
        }

        [Fact]
        public void Construct_with_message()
        {
            // Arrange
            var message = "some_message";

            // Act
            var actual = new ValidationException(message);

            // Asserts
            actual.Message.Should().Be(message);
        }

        [Fact]
        public void Construct_with_innerException()
        {
            // Arrange
            var message = "some_message";
            var innerException = new ArgumentNullException("other message");

            // Act
            var actual = new ValidationException(message, innerException);

            // Asserts
            actual.Message.Should().Be(message);
            actual.InnerException.Should().BeEquivalentTo(innerException);
        }

        [Fact]
        public void Construct_with_validation_result()
        {
            // Arrange
            var result = new ValidationResult();

            // Act
            var actual = new ValidationException(result);

            // Asserts
            actual.Result.Should().NotBeNull();
            actual.Result.IsSuccess.Should().BeTrue();
            actual.Result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Construct_with_null_validation_result()
        {
            // Arrange
            ValidationResult result = null;

            // Act
            var actual = new ValidationException(result);

            // Asserts
            actual.Result.Should().BeNull();
        }

        [Fact]
        public void Construct_with_validation_result_and_message()
        {
            // Arrange
            var result = new ValidationResult();
            var message = "some-extra-data";

            // Act
            var actual = new ValidationException(message, result);

            // Asserts
            actual.Result.Should().NotBeNull();
            actual.Result.IsSuccess.Should().BeTrue();
            actual.Result.Errors.Should().BeEmpty();
            actual.Message.Should().Be(message);
        }

        [Fact]
        public void Construct_with_null_validation_result_and_message()
        {
            // Arrange
            ValidationResult result = null;
            var message = "some-extra-data";

            // Act
            var actual = new ValidationException(message, result);

            // Asserts
            actual.Result.Should().BeNull();
            actual.Message.Should().Be(message);
        }

        [Fact]
        public void Construct_with_list_of_errors()
        {
            // Arrange
            var errors = new Dictionary<string, string[]>()
            {
                { "key1", new[] { "value1", "value2" } },
            };

            // Act
            var actual = new ValidationException(errors);

            // Asserts
            actual.Result.Should().NotBeNull();
            actual.Result.Errors.Should().BeEquivalentTo(errors);
        }

        [Fact]
        public void Construct_with_list_of_errors_and_message()
        {
            // Arrange
            var errors = new Dictionary<string, string[]>()
            {
                { "key1", new[] { "value1", "value2" } },
            };
            var message = "some-extra-data";

            // Act
            var actual = new ValidationException(message, errors);

            // Asserts
            actual.Result.Should().NotBeNull();
            actual.Result.Errors.Should().BeEquivalentTo(errors);
            actual.Message.Should().Be(message);
        }

        [Fact]
        public void Construct_with_null_list_of_errors()
        {
            // Arrange
            IDictionary<string, string[]> errors = null;

            // Act
            var actual = new ValidationException(errors);

            // Asserts
            actual.Result.Should().NotBeNull();
            actual.Result.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Construct_with_null_list_of_errors_and_message()
        {
            // Arrange
            IDictionary<string, string[]> errors = null;
            var message = "some-extra-data";

            // Act
            var actual = new ValidationException(message, errors);

            // Asserts
            actual.Result.Should().NotBeNull();
            actual.Result.Errors.Should().BeEmpty();
            actual.Message.Should().Be(message);
        }
    }
}
