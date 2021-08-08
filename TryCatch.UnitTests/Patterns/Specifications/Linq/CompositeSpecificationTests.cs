// <copyright file="CompositeSpecificationTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Specifications.Linq
{
    using System;
    using FluentAssertions;
    using TryCatch.Patterns.Specifications;
    using TryCatch.Patterns.Specifications.Linq;
    using TryCatch.UnitTests.Patterns.Specifications.Mocks;
    using TryCatch.UnitTests.Patterns.Specifications.Mocks.Linq;
    using Xunit;

    public class CompositeSpecificationTests
    {
        private const string License = "DEFAULT_LICENSE";

        private readonly LicenseSpec sut;

        public CompositeSpecificationTests()
        {
            this.sut = new LicenseSpec(License);
        }

        [Fact]
        public void IsSatisfiedBy_ok()
        {
            // Arrange
            var candidate = new Taxi()
            {
                License = License,
            };

            // Act
            var actual = this.sut.IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void And_ok()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var createdBefore = new CreatedAtBeforeSpec(now);
            var candidate = new Taxi()
            {
                License = License,
                CreatedAt = now.AddDays(-10),
            };

            // Act
            var actual = this.sut.And(createdBefore).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void And_with_invalid_second_spec()
        {
            // Arrange
            var now = DateTime.UtcNow;
            CreatedAtBeforeSpec spec = null;
            var candidate = new Taxi()
            {
                License = License,
                CreatedAt = now.AddDays(-10),
            };

            // Act
            Action actual = () => this.sut.And(spec).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void And_with_invalid_first_spec()
        {
            // Arranges
            ISpecification<Taxi> first = null;

            // Act
            Action actual = () => _ = new AndSpecification<Taxi>(first, this.sut);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AndNot_ok()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var createdBefore = new CreatedAtBeforeSpec(now);
            var candidate = new Taxi()
            {
                License = License,
                CreatedAt = now.AddDays(10),
            };

            // Act
            var actual = this.sut.AndNot(createdBefore).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void AndNot_with_invalid_second_spec()
        {
            // Arrange
            var now = DateTime.UtcNow;
            CreatedAtBeforeSpec spec = null;
            var candidate = new Taxi()
            {
                License = License,
                CreatedAt = now.AddDays(10),
            };

            // Act
            Action actual = () => this.sut.AndNot(spec).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AndNot_with_invalid_first_spec()
        {
            // Arranges
            ISpecification<Taxi> first = null;

            // Act
            Action actual = () => _ = new AndNotSpecification<Taxi>(first, this.sut);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Or_ok()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var createdBefore = new CreatedAtBeforeSpec(now);
            var candidate = new Taxi()
            {
                License = "000-00-000-000",
                CreatedAt = now.AddDays(-10),
            };

            // Act
            var actual = this.sut.Or(createdBefore).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void Or_with_invalid_second_spec()
        {
            // Arrange
            var now = DateTime.UtcNow;
            CreatedAtBeforeSpec spec = null;
            var candidate = new Taxi()
            {
                License = "000-00-000-000",
                CreatedAt = now.AddDays(-10),
            };

            // Act
            Action actual = () => this.sut.Or(spec).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Or_with_invalid_first_spec()
        {
            // Arranges
            ISpecification<Taxi> first = null;

            // Act
            Action actual = () => _ = new OrSpecification<Taxi>(first, this.sut);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void OrNot_ok()
        {
            // Arrange
            var now = DateTime.UtcNow;
            var createdBefore = new CreatedAtBeforeSpec(now);
            var candidate = new Taxi()
            {
                License = License,
                CreatedAt = now.AddDays(10),
            };

            // Act
            var actual = this.sut.OrNot(createdBefore).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void OrNot_with_invalid_second_spec()
        {
            // Arrange
            var now = DateTime.UtcNow;
            CreatedAtBeforeSpec spec = null;
            var candidate = new Taxi()
            {
                License = License,
                CreatedAt = now.AddDays(10),
            };

            // Act
            Action actual = () => this.sut.OrNot(spec).IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void OrNot_with_invalid_first_spec()
        {
            // Arranges
            ISpecification<Taxi> first = null;

            // Act
            Action actual = () => _ = new OrNotSpecification<Taxi>(first, this.sut);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Not_ok()
        {
            // Arrange
            var candidate = new Taxi()
            {
                License = "0000-00-00-0000",
            };

            // Act
            var actual = this.sut.Not().IsSatisfiedBy(candidate);

            // Asserts
            actual.Should().BeTrue();
        }

        [Fact]
        public void Not_with_invalid_first_spec()
        {
            // Arranges
            ISpecification<Taxi> first = null;

            // Act
            Action actual = () => _ = new NotSpecification<Taxi>(first);

            // Asserts
            actual.Should().Throw<ArgumentNullException>();
        }
    }
}
