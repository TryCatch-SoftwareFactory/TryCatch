// <copyright file="ResultTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Results
{
    using System;
    using FluentAssertions;
    using TryCatch.Patterns.Results;
    using TryCatch.UnitTests.Patterns.Results.Mocks;
    using Xunit;

    public class ResultTests
    {
        [Fact]
        public void Construct_without_errors_and_payload()
        {
            // Arrange

            // Act
            var actual = new Result<FakeEntity>();

            // Asserts
            actual.IsSucceeded.Should().BeTrue();
            actual.Payload.Should().BeNull();
            actual.Errors.Should().BeEmpty();
        }

        [Fact]
        public void Construct_with_message()
        {
            // Arrange
            const string message = "set-message";

            // Act
            var actual = new Result<FakeEntity>(message);

            // Asserts
            actual.IsSucceeded.Should().BeFalse();
            actual.Errors.Should().Be(message);
            actual.Payload.Should().BeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Construct_with_invalid_message(string message)
        {
            // Arrange

            // Act
            Action actual = () => _ = new Result<FakeEntity>(message);

            // Asserts
            actual.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Construct_with_payload()
        {
            // Arrange
            var payload = new FakeEntity();

            // Act
            var actual = new Result<FakeEntity>(payload);

            // Asserts
            actual.IsSucceeded.Should().BeTrue();
            actual.Errors.Should().BeEmpty();
            actual.Payload.Should().BeEquivalentTo(payload);
        }

        [Fact]
        public void Construct_with_payload_and_message()
        {
            // Arrange
            const string message = "set-message";
            var payload = new FakeEntity();

            // Act
            var actual = new Result<FakeEntity>(payload, message);

            // Asserts
            actual.IsSucceeded.Should().BeFalse();
            actual.Errors.Should().Be(message);
            actual.Payload.Should().BeEquivalentTo(payload);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Construct_with_payload_and_invalid_message(string message)
        {
            // Arrange
            var payload = new FakeEntity();

            // Act
            Action actual = () => _ = new Result<FakeEntity>(payload, message);

            // Asserts
            actual.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Construct_with_null_payload_and_message()
        {
            // Arrange
            const string message = "set-message";
            FakeEntity payload = null;

            // Act
            var actual = new Result<FakeEntity>(payload, message);

            // Asserts
            actual.IsSucceeded.Should().BeFalse();
            actual.Errors.Should().Be(message);
            actual.Payload.Should().BeNull();
        }
    }
}
