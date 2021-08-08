// <copyright file="ResultBuilderFactoryTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Results
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.Patterns.Results;
    using TryCatch.UnitTests.Patterns.Results.Mocks;
    using Xunit;

    public class ResultBuilderFactoryTests
    {
        private readonly IServiceProvider sp;

        private readonly ResultBuilderFactory sut;

        public ResultBuilderFactoryTests()
        {
            this.sp = Substitute.For<IServiceProvider>();

            this.sut = new ResultBuilderFactory(this.sp);
        }

        [Fact]
        public void Construct_without_serviceProvider()
        {
            // Arrange
            IServiceProvider sp = null;

            // Act
            Action action = () => _ = new ResultBuilderFactory(sp);

            // Asserts
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetOperationResultBuilder_Ok()
        {
            // Arrange
            var factory = Substitute.For<IOpResultBuilder>();
            this.sp.GetService(Arg.Any<Type>()).Returns(factory);

            // Act
            var actual = this.sut.GetOperationResultBuilder();

            // Asserts
            actual.Should().NotBeNull();
        }

        [Fact]
        public void GetPageResultBuilder_Ok()
        {
            // Arrange
            var factory = Substitute.For<IPageResultBuilder<FakeEntity>>();
            this.sp.GetService(Arg.Any<Type>()).Returns(factory);

            // Act
            var actual = this.sut.GetPageResultBuilder<FakeEntity>();

            // Asserts
            actual.Should().NotBeNull();
        }

        [Fact]
        public void GetPayloadResultBuilder_Ok()
        {
            // Arrange
            var factory = Substitute.For<IResultBuilder<FakeEntity>>();
            this.sp.GetService(Arg.Any<Type>()).Returns(factory);

            // Act
            var actual = this.sut.GetPayloadResultBuilder<FakeEntity>();

            // Asserts
            actual.Should().NotBeNull();
        }
    }
}
