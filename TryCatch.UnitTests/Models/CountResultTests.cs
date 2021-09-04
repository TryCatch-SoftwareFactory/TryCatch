// <copyright file="CountResultTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Models
{
    using System;
    using FluentAssertions;
    using TryCatch.Models;
    using Xunit;

    public class CountResultTests
    {
        [Fact]
        public void Construct_with_default_value()
        {
            // Arrange

            // Act
            var actual = new CountResult();

            // Asserts
            actual.Count.Should().Be(DefaultValues.DefaultCount);
        }

        [Fact]
        public void Construct_with_custom_value()
        {
            // Arrange
            var expected = 100;

            // Act
            var actual = new CountResult(expected);

            // Asserts
            actual.Count.Should().Be(expected);
        }

        [Fact]
        public void Construct_with_invalid_value()
        {
            // Arrange
            var expected = -1;

            // Act
            Action actual = () => _ = new CountResult(expected);

            // Asserts
            actual.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
