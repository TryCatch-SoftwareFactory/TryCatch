// <copyright file="ValidationResultTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Validators
{
    using System.Collections.Generic;
    using FluentAssertions;
    using TryCatch.Validators;
    using Xunit;

    public class ValidationResultTests
    {
        [Fact]
        public void Construct_without_errors()
        {
            // Arrange

            // Act
            var actual = new ValidationResult();

            // Asserts
            actual.Errors.Should().BeEmpty();
            actual.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Construct_with_errors()
        {
            // Arrange
            var errors = new Dictionary<string, string[]>()
            {
                { "key1", new[] { "value1", "value2" } },
            };

            // Act
            var actual = new ValidationResult(errors);

            // Asserts
            actual.Errors.Should().BeEquivalentTo(errors);
            actual.IsSuccess.Should().BeFalse();
        }
    }
}
