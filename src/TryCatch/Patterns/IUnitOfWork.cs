// <copyright file="IUnitOfWork.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a basic interface of the Unit of Work pattern to be implemented for an async environment.
    /// Ref: https://www.martinfowler.com/eaaCatalog/unitOfWork.html.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Allows confirming change over the context.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to cancellation token.</param>
        /// <returns>A <see cref="Task{bool}"/> reference which indicates if the changes commit was successful.</returns>
        Task<bool> CommitAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Allows rollback all changes over the context.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> reference to cancellation token.</param>
        /// <returns>A <see cref="Task{bool}"/> reference which indicates if the changes rollback was successful.</returns>
        Task<bool> RollbackAsync(CancellationToken cancellationToken = default);
    }
}
