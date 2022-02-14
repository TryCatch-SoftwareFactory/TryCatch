// <copyright file="PageResultTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Results
{
    using FluentAssertions;
    using TryCatch.Patterns.Results;
    using TryCatch.UnitTests.Patterns.Results.Mocks;
    using Xunit;

    public class PageResultTests
    {
        [Fact]
        public void Construct_with_default_values()
        {
            // Arrange

            // Act
            var actual = new PageResult<FakeEntity>();

            // Asserts
            actual.Items.Should().BeEmpty();
            actual.Limit.Should().Be(0);
            actual.Matched.Should().Be(0);
            actual.Offset.Should().Be(0);
            actual.Count.Should().Be(0);
        }
    }
}
