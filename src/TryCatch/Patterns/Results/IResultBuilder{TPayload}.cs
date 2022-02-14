// <copyright file="IResultBuilder{TPayload}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;
    using TryCatch.Patterns.Builders;

    /// <summary>
    /// Define the interface of Operation result - with payload - builder.
    /// </summary>
    /// <typeparam name="TPayload">Type of payload associated with the operation.</typeparam>
    public interface IResultBuilder<TPayload> : IBuilder<Result<TPayload>, IResultBuilder<TPayload>>
    {
        /// <summary>
        /// Allows setting the operation payload data.
        /// </summary>
        /// <param name="payload">A <see cref="TPayload"/> reference to the operation payload data.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the payload is null.</exception>
        /// <returns>A <see cref="IResultBuilder{TEntity}"/> reference to the builder.</returns>
        IResultBuilder<TPayload> WithPayload(TPayload payload);

        /// <summary>
        /// Allows setting an error message about the operation results.
        /// </summary>
        /// <param name="errors">Error message.</param>
        /// <exception cref="ArgumentNullException">If the error is null, throws it.</exception>
        /// <returns>A <see cref="IResultBuilder{TEntity}"/> reference to the builder.</returns>
        IResultBuilder<TPayload> WithError(string errors);
    }
}
