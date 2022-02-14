// <copyright file="ResultBuilderTests.cs" company="TryCatch Software Factory">
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

    public class ResultBuilderTests
    {
        private readonly ResultBuilder<FakeEntity> sut;

        public ResultBuilderTests()
        {
            this.sut = new ResultBuilder<FakeEntity>();
        }

        [Fact]
        public void Create_before_build()
        {
            // Act
            Action actual = () => this.sut.Create();

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithError_before_build()
        {
            // Arrange
            var errors = "some-error";

            // Act
            Action actual = () => this.sut.WithError(errors);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithPayload_before_build()
        {
            // Arrange
            FakeEntity entity = null;

            // Act
            Action actual = () => this.sut.WithPayload(entity);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithError_with_invalid_error()
        {
            // Arrange
            string errors = null;

            // Act
            Action actual = () => this.sut.Build().WithError(errors);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void WithPayload_with_invalid_payload()
        {
            // Arrange
            FakeEntity entity = null;

            // Act
            Action actual = () => this.sut.Build().WithPayload(entity);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Create_with_default_values()
        {
            // Act
            var actual = this.sut.Build().Create();

            // Asserts
            actual.Should().NotBeNull();
            actual.IsSucceeded.Should().BeTrue();
            actual.Errors.Should().BeEmpty();
            actual.Payload.Should().BeNull();
        }

        [Fact]
        public void Create_with_payload()
        {
            // Arrange
            var payload = new FakeEntity();

            // Act
            var actual = this.sut
                .Build()
                .WithPayload(payload)
                .Create();

            // Asserts
            actual.Should().NotBeNull();
            actual.IsSucceeded.Should().BeTrue();
            actual.Errors.Should().BeEmpty();
            actual.Payload.Should().BeEquivalentTo(payload);
        }

        [Fact]
        public void Create_with_errors()
        {
            // Arrange
            var errors = "errors";

            // Act
            var actual = this.sut
                .Build()
                .WithError(errors)
                .Create();

            // Asserts
            actual.Should().NotBeNull();
            actual.IsSucceeded.Should().BeFalse();
            actual.Errors.Should().Be(errors);
            actual.Payload.Should().BeNull();
        }
    }
}
