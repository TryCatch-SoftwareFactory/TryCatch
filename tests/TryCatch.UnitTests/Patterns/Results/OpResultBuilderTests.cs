// <copyright file="OpResultBuilderTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Results
{
    using System;
    using FluentAssertions;
    using TryCatch.Patterns.Results;
    using Xunit;

    public class OpResultBuilderTests
    {
        private readonly OpResultBuilder sut;

        public OpResultBuilderTests()
        {
            this.sut = new OpResultBuilder();
        }

        [Fact]
        public void Create_before_build()
        {
            // Arrange

            // Act
            Action actual = () => this.sut.Create();

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithError_before_build()
        {
            // Arrange
            var errors = "some-errors";

            // Act
            Action actual = () => this.sut.WithError(errors);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithError_with_invalid_errors()
        {
            // Arrange
            string errors = null;

            // Act
            Action actual = () => this.sut.Build().WithError(errors);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Build_ok()
        {
            // Arrange

            // Act
            var actual = this.sut.Build();

            // Asserts
            actual.Should().Be(this.sut);
        }

        [Fact]
        public void Build_and_create()
        {
            // Arrange

            // Act
            var actual = this.sut.Build().Create();

            // Asserts
            actual.Should().NotBeNull();
            actual.IsSucceeded.Should().BeTrue();
        }

        [Theory]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData("some-error", false)]
        public void Build_with_error_and_create(string message, bool isSucceeded)
        {
            // Arrange

            // Act
            var actual = this.sut.Build().WithError(message).Create();

            // Asserts
            actual.Should().NotBeNull();
            actual.IsSucceeded.Should().Be(isSucceeded);
        }
    }
}
