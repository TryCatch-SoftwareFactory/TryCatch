// <copyright file="CountResult.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Models
{
    using System;

    /// <summary>
    /// Represents the result of an element enumeration operation.
    /// </summary>
    public sealed class CountResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CountResult"/> class.
        /// </summary>
        public CountResult()
        {
            this.Count = DefaultValues.DefaultCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CountResult"/> class.
        /// </summary>
        /// <param name="count">The number of items matched.</param>
        public CountResult(long count = DefaultValues.DefaultCount)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Count can't be less than zero: {count}");
            }

            this.Count = count;
        }

        /// <summary>
        /// Gets the number of items matched.
        /// </summary>
        public long Count { get; }
    }
}
