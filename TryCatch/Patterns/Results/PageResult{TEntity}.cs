// <copyright file="PageResult{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents a standard structure of the results of a paged query.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity.</typeparam>
    public sealed class PageResult<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageResult{TEntity}"/> class.
        /// </summary>
        public PageResult()
        {
            this.Items = new HashSet<TEntity>();
            this.Matched = 0;
            this.Offset = 0;
            this.Count = 0;
            this.Limit = 0;
        }

        /// <summary>
        /// Gets the elements of the result of the query.
        /// </summary>
        public IEnumerable<TEntity> Items { get; internal set; }

        /// <summary>
        /// Gets the collection max size of results.
        /// </summary>
        public long Limit { get; internal set; }

        /// <summary>
        /// Gets the number of matches items with the query.
        /// </summary>
        public long Matched { get; internal set; }

        /// <summary>
        /// Gets the offset applied on the query.
        /// </summary>
        public long Offset { get; internal set; }

        /// <summary>
        /// Gets the number of items before the query had applied.
        /// </summary>
        public long Count { get; internal set; }
    }
}
