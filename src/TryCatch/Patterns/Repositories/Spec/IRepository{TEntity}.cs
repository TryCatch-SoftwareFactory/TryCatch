// <copyright file="IRepository{TEntity}.cs" company="TryCatch Software Factory">
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
    /// The generic repository pattern interface based on the specification pattern as a mechanism for query filtering.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity used in the repository.</typeparam>
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Add the entity to the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the entity or create a new if it not exists.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> CreateOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the entity from the repository.
        /// </summary>
        /// <param name="spec">A <see cref="ISpecification{TEntity}"/> reference to delete entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the spec is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> DeleteAsync(ISpecification<TEntity> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a reference to a first entity that matches with the where criteria passed as argument.
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
        /// <returns>A <see cref="Task{long}"/> representing the number of entities matches with filters criteria.</returns>
        Task<long> GetCountAsync(ISpecification<TEntity> spec = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the paginated entities using filter and order criteria (optional).
        /// </summary>
        /// <param name="offset">Offeset to be applied on the query.By default: 1.</param>
        /// <param name="limit">Size of page to be applied on the query.By default: 1000.</param>
        /// <param name="where">A <see cref="ISpecification{TEntity}"/> reference to the where criteria.</param>
        /// <param name="orderBy">A <see cref="ISortSpecification{TEntity}"/> order expression to be applied on the query (if is defined).</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <returns>A <see cref="Task{IEnumerable{TEntity}}"/> reference to the collection of entities that match with the arguments used.</returns>
        Task<IEnumerable<TEntity>> GetPageAsync(
            int offset = 1,
            int limit = 1000,
            ISpecification<TEntity> where = null,
            ISortSpecification<TEntity> orderBy = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the entity on the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
