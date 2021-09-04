// <copyright file="PageModelTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Models
{
    using System;
    using FluentAssertions;
    using TryCatch.Models;
    using Xunit;

    public class PageModelTests
    {
        [Fact]
        public void Construct_with_default_value()
        {
            // Arrange

            // Act
            var actual = new PageModel();

            // Asserts
            actual.Offset.Should().Be(DefaultValues.DefaultOffset);
            actual.Limit.Should().Be(DefaultValues.DefaultPageLimit);
            actual.SortAs.Should().Be(DefaultValues.SortAsAscending);
            actual.SortAsAscending().Should().BeTrue();
        }

        [Fact]
        public void Construct_with_custom_value()
        {
            // Arrange
            var limit = 100;
            var offset = 10;
            var orderBy = "Id";
            var sortAs = DefaultValues.SortAsDescending;

            // Act
            var actual = new PageModel(limit, offset, orderBy, sortAs);

            // Asserts
            actual.Limit.Should().Be(limit);
            actual.Offset.Should().Be(offset);
            actual.OrderBy.Should().Be(orderBy);
            actual.SortAs.Should().Be(sortAs);
            actual.SortAsAscending().Should().BeFalse();
        }

        [Theory]
        [InlineData(DefaultValues.SortAsAscending, true)]
        [InlineData(DefaultValues.SortAsDescending, false)]
        [InlineData("INVALID_VALUE", true)]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData(" ", true)]
        public void Construct_with_invalid_value(string sortAs, bool expected)
        {
            // Arrange

            // Act
            var actual = new PageModel(sortAs: sortAs);

            // Asserts
            actual.SortAsAscending().Should().Be(expected);
        }
    }
}
