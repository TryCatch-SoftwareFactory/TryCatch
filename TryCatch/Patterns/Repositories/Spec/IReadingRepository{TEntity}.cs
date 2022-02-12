// <copyright file="IReadingRepository{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Repositories.Spec
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TryCatch.Patterns.Specifications;

    /// <summary>
    /// Reading repository interface for TEntity with Specification pattern.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    public interface IReadingRepository<TEntity>
    {
        /// <summary>
        /// Gets Entity by criteria filter.
        /// </summary>
        /// <param name="spec">A <see cref="ISpecification{TEntity}"/> referentes to the where criteria.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the spec is null.</exception>
        /// <returns>A <see cref="Task{TEntity}"/> reference to found entity or null value if that does not exist.</returns>
        Task<TEntity> GetAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns the number of entities matches with filter criteria.
        /// </summary>
        /// <param name="spec">A <see cref="ISpecification{TEntity}"/> spec to be applied on the query (if is defined).</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <returns>A <see cref="Task{long}"/> reference representing the number of entities matches with filters criteria.</returns>
        Task<long> GetCountAsync(ISpecification<TEntity> spec = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the paginated entities using filter and order criteria (optional).
        /// </summary>
        /// <param name="offset">Offeset to be applied on the query.By default: 1.</param>
        /// <param name="limit">Size of page to be applied on the query.By default: 1000.</param>
        /// <param name="where">A <see cref="ISpecification{TEntity}"/> reference to the where criteria.</param>
        /// <param name="orderBy">A <see cref="ISortSpecification{TEntity}"/> order expression to be applied on the query (if is defined).</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <returns>A <see cref="IEnumerable{TEntity}"/> reference to the collection of entities that match with the arguments used.</returns>
        Task<IEnumerable<TEntity>> GetPageAsync(
            int offset = 1,
            int limit = 1000,
            ISpecification<TEntity> where = null,
            ISortSpecification<TEntity> orderBy = null,
            CancellationToken cancellationToken = default);
    }
}
