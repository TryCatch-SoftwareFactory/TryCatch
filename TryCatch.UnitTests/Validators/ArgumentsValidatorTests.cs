// <copyright file="ArgumentsValidatorTests.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Validators
{
    using System;
    using System.Globalization;
    using FluentAssertions;
    using TryCatch.Validators;
    using Xunit;

    public class ArgumentsValidatorTests
    {
        [Fact]
        public void ThrowIfIsNull_with_valid_component()
        {
            // Arrange
            var component = new object();

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNull(component);

            // Asserts
            act.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowIfIsNull_with_invalid_component()
        {
            // Arrange
            object component = null;

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNull(component);

            // Asserts
            act.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(null, "The component can't be null: (Parameter 'component')")]
        [InlineData("", "The component can't be null: (Parameter 'component')")]
        [InlineData(" ", "The component can't be null: (Parameter 'component')")]
        [InlineData("exception message", "exception message (Parameter 'component')")]
        public void ThrowIfIsNull_with_invalid_component_and_message(string message, string expected)
        {
            // Arrange
            object component = null;

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNull(component, message);

            // Asserts
            act.Should().Throw<ArgumentNullException>().And.Message.Should().Be(expected);
        }

        [Fact]
        public void ThrowIfIsNullOrEmpty_valid_text()
        {
            // Arrange
            var text = "some text";

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNullOrEmpty(text);

            // Asserts
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ThrowIfIsNullOrEmpty_invalid_text(string text)
        {
            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNullOrEmpty(text);

            // Asserts
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ThrowIfIsNullEmptyOrWhiteSpace_valid_text()
        {
            // Arrange
            var text = "some text";

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(text);

            // Asserts
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowIfIsNullEmptyOrWhiteSpace_invalid_text(string text)
        {
            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(text);

            // Asserts
            act.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(null, "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData(" ", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("validation-message", "validation-message (Parameter 'value')")]
        public void ThrowIfIsLessThan_with_invalid_int(string message, string expected)
        {
            // Arrange
            const int threshold = 0;
            const int value = -1;

            var expectedMessage = expected
                .Replace("{value}", value.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture)
                .Replace("{threshold}", threshold.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture);

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value, message);

            // Asserts
            act.Should().Throw<ArgumentOutOfRangeException>().And.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void ThrowIfIsLessThan_with_valid_int()
        {
            // Arrange
            const int threshold = 0;
            const int value = 1;

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value);

            // Asserts
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null, "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData(" ", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("validation-message", "validation-message (Parameter 'value')")]
        public void ThrowIfIsLessThan_with_invalid_long(string message, string expected)
        {
            // Arrange
            const long threshold = 0L;
            const long value = -1L;

            var expectedMessage = expected
                .Replace("{value}", value.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture)
                .Replace("{threshold}", threshold.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture);

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value, message);

            // Asserts
            act.Should().Throw<ArgumentOutOfRangeException>().And.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void ThrowIfIsLessThan_with_valid_long()
        {
            // Arrange
            const long threshold = 0;
            const long value = 1;

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value);

            // Asserts
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null, "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData(" ", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("validation-message", "validation-message (Parameter 'value')")]
        public void ThrowIfIsLessThan_with_invalid_float(string message, string expected)
        {
            // Arrange
            const float threshold = 0.0F;
            const float value = -1.3F;

            var expectedMessage = expected
                .Replace("{value}", value.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture)
                .Replace("{threshold}", threshold.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture);

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value, message);

            // Asserts
            act.Should().Throw<ArgumentOutOfRangeException>().And.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void ThrowIfIsLessThan_with_valid_float()
        {
            // Arrange
            const float threshold = 0.0F;
            const float value = 1.0F;

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value);

            // Asserts
            act.Should().NotThrow<ArgumentException>();
        }

        [Theory]
        [InlineData(null, "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData(" ", "Value({value}) is less than threshold({threshold}) (Parameter 'value')")]
        [InlineData("validation-message", "validation-message (Parameter 'value')")]
        public void ThrowIfIsLessThan_with_invalid_DateTime(string message, string expected)
        {
            // Arrange
            var threshold = DateTime.UtcNow;
            var value = DateTime.UtcNow.AddDays(-1);

            var expectedMessage = expected
                .Replace("{value}", value.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture)
                .Replace("{threshold}", threshold.ToString(CultureInfo.CurrentCulture), StringComparison.CurrentCulture);

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value, message);

            // Asserts
            act.Should().Throw<ArgumentOutOfRangeException>().And.Message.Should().Be(expectedMessage);
        }

        [Fact]
        public void ThrowIfIsLessThan_with_valid_DateTime()
        {
            // Arrange
            var threshold = DateTime.UtcNow;
            var value = DateTime.UtcNow.AddDays(1);

            // Act
            Action act = () => ArgumentsValidator.ThrowIfIsLessThan(threshold, value);

            // Asserts
            act.Should().NotThrow<ArgumentException>();
        }
    }
}
