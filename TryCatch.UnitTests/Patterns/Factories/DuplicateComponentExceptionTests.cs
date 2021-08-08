// <copyright file="DuplicateComponentExceptionTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Factories
{
    using System;
    using FluentAssertions;
    using TryCatch.Patterns.Factories;
    using Xunit;

    public class DuplicateComponentExceptionTests
    {
        [Fact]
        public void Construct_without_args()
        {
            // Arrange

            // Act
            var actual = new DuplicateComponentException();

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
            var actual = new DuplicateComponentException(message);

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
            var actual = new DuplicateComponentException(message, innerException);

            // Asserts
            actual.Message.Should().Be(message);
            actual.InnerException.Should().BeEquivalentTo(innerException);
        }
    }
}
