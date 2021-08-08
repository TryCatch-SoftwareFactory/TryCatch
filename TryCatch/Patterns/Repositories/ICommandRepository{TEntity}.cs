// <copyright file="ICommandRepository{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Repositories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Command repository common interface. Define the basic methods for a command repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    public interface ICommandRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Add the entity to the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds the list of entities to the repository.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{TEntity}"/> reference to the list of <see cref="TEntity"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entities collection is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> AddAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the entity or create a new if it not exists.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the entity from the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the list of entities from the repository.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{TEntity}"/> reference to the list of <see cref="TEntity"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entities collection is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the entity on the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the list of entities on the repository.
        /// </summary>
        /// <param name="entities">A <see cref="IEnumerable{TEntity}"/> reference to the list of <see cref="TEntity"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entities collection is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
