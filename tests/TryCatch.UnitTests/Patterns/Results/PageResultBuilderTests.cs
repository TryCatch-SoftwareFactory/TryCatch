// <copyright file="PageResultBuilderTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Results
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using TryCatch.Patterns.Results;
    using TryCatch.UnitTests.Patterns.Results.Mocks;
    using Xunit;

    public class PageResultBuilderTests
    {
        private readonly PageResultBuilder<FakeEntity> sut;

        public PageResultBuilderTests()
        {
            this.sut = new PageResultBuilder<FakeEntity>();
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
        public void WithItems_before_build()
        {
            // Act
            Action actual = () => this.sut.WithItems(Array.Empty<FakeEntity>());

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithCount_before_build()
        {
            // Act
            Action actual = () => this.sut.WithCount(1);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithMatched_before_build()
        {
            // Act
            Action actual = () => this.sut.WithMatched(1);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithOffset_before_build()
        {
            // Act
            Action actual = () => this.sut.WithOffset(1);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithSize_before_build()
        {
            // Act
            Action actual = () => this.sut.WithLimit(1);

            // Asserts
            actual.Should().Throw<ResultBuilderException>();
        }

        [Fact]
        public void WithCount_with_OutOfRange()
        {
            // Act
            Action actual = () => this.sut.Build().WithCount(-1);

            // Asserts
            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void WithMatched_with_OutOfRange()
        {
            // Act
            Action actual = () => this.sut.Build().WithMatched(-1);

            // Asserts
            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void WithOffset_with_OutOfRange()
        {
            // Act
            Action actual = () => this.sut.Build().WithOffset(0);

            // Asserts
            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void WithSize_with_OutOfRange()
        {
            // Act
            Action actual = () => this.sut.Build().WithLimit(0);

            // Asserts
            actual.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void WithItems_without_items()
        {
            // Arrange
            IEnumerable<FakeEntity> items = null;

            // Act
            Action actual = () => this.sut.Build().WithItems(items);

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
            actual.Items.Should().BeEmpty();
            actual.Count.Should().Be(0);
            actual.Matched.Should().Be(0);
            actual.Offset.Should().Be(0);
            actual.Limit.Should().Be(0);
        }

        [Fact]
        public void Create_with_values()
        {
            // Arrange
            var items = new HashSet<FakeEntity>()
            {
                new FakeEntity(),
            };

            // Act
            var actual = this.sut
                .Build()
                .WithCount(10)
                .WithLimit(10)
                .WithOffset(1)
                .WithMatched(1)
                .WithItems(items)
                .Create();

            // Asserts
            actual.Should().NotBeNull();
            actual.Count.Should().Be(10);
            actual.Limit.Should().Be(10);
            actual.Offset.Should().Be(1);
            actual.Matched.Should().Be(1);
            actual.Items.Should().BeEquivalentTo(items);
        }
    }
}
