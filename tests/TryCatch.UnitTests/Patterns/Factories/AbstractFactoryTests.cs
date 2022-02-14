// <copyright file="AbstractFactoryTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Factories
{
    using System;
    using FluentAssertions;
    using NSubstitute;
    using TryCatch.Patterns.Factories;
    using TryCatch.UnitTests.Patterns.Factories.Mocks;
    using Xunit;

    public class AbstractFactoryTests
    {
        private readonly IServiceProvider sp;

        private readonly FakeFactory sut;

        public AbstractFactoryTests()
        {
            this.sp = Substitute.For<IServiceProvider>();

            this.sut = new FakeFactory(this.sp);
        }

        [Fact]
        public void Construct_without_service_provider()
        {
            // Arrange
            IServiceProvider sp = null;

            // Act
            Action actual = () => _ = new FakeFactory(sp);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RegisterType_with_invalid_input()
        {
            // Arrange
            Type input = null;
            var output = typeof(FakeComponent);

            // Act
            Action actual = () => _ = this.sut.RegisterType(input, output);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RegisterType_with_invalid_output()
        {
            // Arrange
            var input = typeof(FakeInputComponent);
            Type output = null;

            // Act
            Action actual = () => _ = this.sut.RegisterType(input, output);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RegisterType_with_duplicated_component()
        {
            // Arrange
            var input = typeof(FakeInputComponent);
            var output = typeof(FakeComponent);
            this.sut.RegisterType(input, output);

            // Act
            Action actual = () => _ = this.sut.RegisterType(input, output);

            // Asserts
            actual.Should().Throw<DuplicateComponentException>();
        }

        [Fact]
        public void RegisterType_ok()
        {
            // Arrange
            var input = typeof(FakeInputComponent);
            var output = typeof(FakeComponent);

            // Act
            var actual = this.sut.RegisterType(input, output);

            // Asserts
            actual.Should().BeTrue();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void RegisterType_by_key_with_invalid_key(string key)
        {
            // Arrange
            var output = typeof(FakeComponent);

            // Act
            Action actual = () => _ = this.sut.RegisterType(key, output);

            // Asserts
            actual.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void RegisterType_by_key_with_key_and_invalid_output()
        {
            // Arrange
            var key = "key";
            Type output = null;

            // Act
            Action actual = () => _ = this.sut.RegisterType(key, output);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void RegisterType_by_key_with_duplicated_component()
        {
            // Arrange
            var key = "key";
            var output = typeof(FakeComponent);
            this.sut.RegisterType(key, output);

            // Act
            Action actual = () => _ = this.sut.RegisterType(key, output);

            // Asserts
            actual.Should().Throw<DuplicateComponentException>();
        }

        [Fact]
        public void RegisterType_by_key_ok()
        {
            // Arrange
            var key = "key";
            var output = typeof(FakeComponent);

            // Act
            var actual = this.sut.RegisterType(key, output);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void GetType_with_invalid_input()
        {
            // Arrange
            Type input = null;

            // Act
            Action actual = () => _ = this.sut.GetType(input);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetType_with_component_not_found()
        {
            // Arrange

            // Act
            Action actual = () => _ = this.sut.GetType(typeof(FakeInputComponent));

            // Asserts
            actual.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetType_with_component_not_resolved()
        {
            // Arrange
            this.sp.GetService(Arg.Any<Type>()).Returns(null);
            this.sut.RegisterType(typeof(FakeInputComponent), typeof(FakeComponent));

            // Act
            Action actual = () => _ = this.sut.GetType(typeof(FakeInputComponent));

            // Asserts
            actual.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetType_ok()
        {
            // Arrange
            this.sp.GetService(Arg.Any<Type>()).Returns(new FakeComponent());
            this.sut.RegisterType(typeof(FakeInputComponent), typeof(FakeComponent));

            // Act
            var actual = this.sut.GetType(typeof(FakeInputComponent)) as FakeComponent;

            // Asserts
            actual.Should().NotBeNull();
            actual.Should().BeOfType<FakeComponent>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void GetType_by_key_with_invalid_key(string key)
        {
            // Act
            Action actual = () => _ = this.sut.GetType(key);

            // Asserts
            actual.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GetType_by_key_with_component_not_found()
        {
            // Arrange
            var key = "key";

            // Act
            Action actual = () => _ = this.sut.GetType(key);

            // Asserts
            actual.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetType_by_key_with_component_not_resolved()
        {
            // Arrange
            var key = "key";
            this.sp.GetService(Arg.Any<Type>()).Returns(null);
            this.sut.RegisterType(key, typeof(FakeComponent));

            // Act
            Action actual = () => _ = this.sut.GetType(key);

            // Asserts
            actual.Should().Throw<ComponentNotFoundException>();
        }

        [Fact]
        public void GetType_by_key_ok()
        {
            // Arrange
            var key = "key";
            this.sp.GetService(Arg.Any<Type>()).Returns(new FakeComponent());
            this.sut.RegisterType(key, typeof(FakeComponent));

            // Act
            var actual = this.sut.GetType(key) as FakeComponent;

            // Asserts
            actual.Should().NotBeNull();
            actual.Should().BeOfType<FakeComponent>();
        }
    }
}
