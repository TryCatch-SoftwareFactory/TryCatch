// <copyright file="ArgumentsValidator.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    using System;

    /// <summary>
    /// Arguments validator tool. Allows validating the most common rules for components arguments.
    /// </summary>
    public static class ArgumentsValidator
    {
        /// <summary>
        /// Allows validating if the argument is null.
        /// </summary>
        /// <typeparam name="T">Type of component.</typeparam>
        /// <param name="component">Component to be evaluated.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the component is null.</exception>
        public static void ThrowIfIsNull<T>(T component, string message = "")
            where T : class
        {
            if (component is null)
            {
                message = string.IsNullOrWhiteSpace(message) ? "The component can't be null:" : message;

                throw new ArgumentNullException(nameof(component), message);
            }
        }

        /// <summary>
        /// Allows validating if the text argument is null or empty.
        /// </summary>
        /// <param name="text">Text to be evaluated.</param>
        /// <exception cref="ArgumentException">It is thrown if the text is null or empty.</exception>
        public static void ThrowIfIsNullOrEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException($"'{nameof(text)}' can't be null or empty.", nameof(text));
            }
        }

        /// <summary>
        /// Allows validating if the text argument is null, empty or whitespace.
        /// </summary>
        /// <param name="text">Text to be evaluated.</param>
        /// <exception cref="ArgumentException">It is thrown if the text is null, empty or whitespace.</exception>
        public static void ThrowIfIsNullEmptyOrWhiteSpace(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"'{nameof(text)}' can't be null, empty or whitespace.", nameof(text));
            }
        }

        /// <summary>
        /// Allows validating if the value is less than the threshold used as a parameter.
        /// </summary>
        /// <param name="threshold">The threshold value for the comparison.</param>
        /// <param name="value">Value to evaluate.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if the values is less than the threshold.</exception>
        public static void ThrowIfIsLessThan(int threshold, int value, string message = "")
        {
            message = string.IsNullOrWhiteSpace(message)
                ? $"Value({value}) is less than threshold({threshold})"
                : message;

            if (value < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(value), message);
            }
        }

        /// <summary>
        /// Allows validating if the value is less than the threshold used as a parameter.
        /// </summary>
        /// <param name="threshold">The threshold value for the comparison.</param>
        /// <param name="value">Value to evaluate.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if the values is less than the threshold.</exception>
        public static void ThrowIfIsLessThan(long threshold, long value, string message = "")
        {
            message = string.IsNullOrWhiteSpace(message)
                ? $"Value({value}) is less than threshold({threshold})"
                : message;

            if (value < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(value), message);
            }
        }

        /// <summary>
        /// Allows validating if the value is less than the threshold used as a parameter.
        /// </summary>
        /// <param name="threshold">The threshold value for the comparison.</param>
        /// <param name="value">Value to evaluate.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if the values is less than the threshold.</exception>
        public static void ThrowIfIsLessThan(float threshold, float value, string message = "")
        {
            message = string.IsNullOrWhiteSpace(message)
                ? $"Value({value}) is less than threshold({threshold})"
                : message;

            if (value < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(value), message);
            }
        }

        /// <summary>
        /// Allows validating if the value is less than the threshold used as a parameter.
        /// </summary>
        /// <param name="threshold">The threshold value for the comparison.</param>
        /// <param name="value">Value to evaluate.</param>
        /// <param name="message">Error message.</param>
        /// <exception cref="ArgumentOutOfRangeException">It is thrown if the values is less than the threshold.</exception>
        public static void ThrowIfIsLessThan(DateTime threshold, DateTime value, string message = "")
        {
            message = string.IsNullOrWhiteSpace(message)
                ? $"Value({value}) is less than threshold({threshold})"
                : message;

            if (value < threshold)
            {
                throw new ArgumentOutOfRangeException(nameof(value), message);
            }
        }
    }
}
