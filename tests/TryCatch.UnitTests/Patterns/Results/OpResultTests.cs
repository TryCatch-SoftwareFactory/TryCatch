// <copyright file="OpResultTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Results
{
    using System;
    using FluentAssertions;
    using TryCatch.Patterns.Results;
    using Xunit;

    public class OpResultTests
    {
        [Fact]
        public void Construct_without_errors()
        {
            // Arrange

            // Act
            var actual = new OpResult();

            // Asserts
            actual.IsSucceeded.Should().BeTrue();
        }

        [Fact]
        public void Construct_with_message()
        {
            // Arrange
            const string message = "set-message";

            // Act
            var actual = new OpResult(message);

            // Asserts
            actual.IsSucceeded.Should().BeFalse();
            actual.Errors.Should().Be(message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Construct_with_invalid_message(string message)
        {
            // Arrange

            // Act
            Action actual = () => _ = new OpResult(message);

            // Asserts
            actual.Should().Throw<ArgumentException>();
        }
    }
}
