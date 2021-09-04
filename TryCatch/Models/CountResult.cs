// <copyright file="CountResult.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Models
{
    using System;

    public class CountResult
    {
        public CountResult()
        {
            this.Count = DefaultValues.DefaultCount;
        }

        public CountResult(long count = DefaultValues.DefaultCount)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), $"Count can't be less than zero: {count}");
            }

            this.Count = count;
        }

        public long Count { get; }
    }
}
