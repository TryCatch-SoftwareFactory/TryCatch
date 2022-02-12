// <copyright file="IWritingRepository{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Repositories
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Basic command repository interface. Define the basic methods for a command repository.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity.</typeparam>
    public interface IWritingRepository<in TEntity>
    {
        /// <summary>
        /// Add the entity to the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the entity or create a new if it not exists.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> CreateOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Delete the entity from the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update the entity on the repository.
        /// </summary>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{bool}"/> representing the asynchronous operation with a success flag.</returns>
        Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
