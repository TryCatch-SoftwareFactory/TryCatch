// <copyright file="IValidator.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// General validator interface.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Allows executing the associated validation process.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity to validate.</typeparam>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity to be validated.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="ValidationResult"/> reference to the validation process.</returns>
        ValidationResult Validate<TEntity>(TEntity entity);

        /// <summary>
        /// Allows executing the associated async validation process.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity to validate.</typeparam>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity to be validated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task{ValidationResult}"/> reference to the validation process.</returns>
        Task<ValidationResult> ValidateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Allows you to run the associated validation process. If any error takes place, then it throws a validation exception.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity to validate.</typeparam>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity to be validated.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        void ValidateAndThrowIfError<TEntity>(TEntity entity);

        /// <summary>
        /// Allows you to run the associated validation process. If any error takes place, then it throws a validation exception.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity to validate.</typeparam>
        /// <param name="entity">A <see cref="TEntity"/> reference to the entity to be validated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to the cancellation token.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if the entity is null.</exception>
        /// <returns>A <see cref="Task"/> reference to the task result.</returns>
        Task ValidateAndThrowIfErrorAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default);
    }
}
