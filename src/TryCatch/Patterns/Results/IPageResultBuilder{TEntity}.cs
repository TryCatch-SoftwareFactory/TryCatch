// <copyright file="IPageResultBuilder{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System.Collections.Generic;
    using TryCatch.Patterns.Builders;

    /// <summary>
    /// Define the interface of Pagination query result (PageResult) builder.
    /// </summary>
    /// <typeparam name="TEntity">Type of entities associated with the query.</typeparam>
    public interface IPageResultBuilder<TEntity> : IBuilder<PageResult<TEntity>, IPageResultBuilder<TEntity>>
    {
        /// <summary>
        /// Allows setting the number of entities registered.
        /// </summary>
        /// <param name="count">Number of registers on the system.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">It is thrown if the argument is out of range.</exception>
        /// <returns>A <see cref="IPageResultBuilder{TEntity}"/> reference to the current builder.</returns>
        IPageResultBuilder<TEntity> WithCount(long count);

        /// <summary>
        /// Allows setting the number of matches in the query.
        /// </summary>
        /// <param name="matched">Number of matches.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">It is thrown if the argument is out of range.</exception>
        /// <returns>A <see cref="IPageResultBuilder{TEntity}"/> reference to the current builder.</returns>
        IPageResultBuilder<TEntity> WithMatched(long matched);

        /// <summary>
        /// Allows setting the items matched collection on the query.
        /// </summary>
        /// <param name="items">A <see cref="IEnumerable{TEntity}"/> reference to the items matched collection.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the items collection is null.</exception>
        /// <returns>A <see cref="IPageResultBuilder{TEntity}"/> reference to the current builder.</returns>
        IPageResultBuilder<TEntity> WithItems(IEnumerable<TEntity> items);

        /// <summary>
        /// Allows setting the offset has applied on the query.
        /// </summary>
        /// <param name="offset">Number of registers on the system.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">It is thrown if the argument is out of range.</exception>
        /// <returns>A <see cref="IPageResultBuilder{TEntity}"/> reference to the current builder.</returns>
        IPageResultBuilder<TEntity> WithOffset(int offset);

        /// <summary>
        /// Allows setting the limit - page size - has applied on the query.
        /// </summary>
        /// <param name="limit">Max size of page.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">It is thrown if the argument is out of range.</exception>
        /// <returns>A <see cref="IPageResultBuilder{TEntity}"/> reference to the current builder.</returns>
        IPageResultBuilder<TEntity> WithLimit(int limit);
    }
}
