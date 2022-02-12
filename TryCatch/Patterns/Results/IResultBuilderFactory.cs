// <copyright file="IResultBuilderFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    /// <summary>
    /// Abstract factory interface to create the more common result builders.
    /// </summary>
    public interface IResultBuilderFactory
    {
        /// <summary>
        /// Gets an instance of IOpResultBuilder.
        /// </summary>
        /// <returns>A <see cref="IOpResultBuilder"/> reference to IOpResultBuilder.</returns>
        IOpResultBuilder GetOperationResultBuilder();

        /// <summary>
        /// Gets an instance of IPageResultBuilder for TEntity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity used in the results of the query.</typeparam>
        /// <returns>A <see cref="IPageResultBuilder{TEntity}"/> reference to the page builder particularized for TEntity.</returns>
        IPageResultBuilder<TEntity> GetPageResultBuilder<TEntity>();

        /// <summary>
        /// Gets an instance of IResultBuilder for TPayload.
        /// </summary>
        /// <typeparam name="TPayload">Type of payload used in the results of the operation.</typeparam>
        /// <returns>A <see cref="IResultBuilder{TPayload}"/> reference to the page builder particularized for TPayload.</returns>
        IResultBuilder<TPayload> GetPayloadResultBuilder<TPayload>();
    }
}
