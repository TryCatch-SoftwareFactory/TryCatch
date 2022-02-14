// <copyright file="ResultBuilderFactory.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;
    using TryCatch.Validators;

    /// <summary>
    /// Implementation of IResultBuilder. Allows getting the more common result builders.
    /// </summary>
    public sealed class ResultBuilderFactory : IResultBuilderFactory
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBuilderFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">A <see cref="IServiceProvider"/> reference to the Service Provider.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the service provider is null.</exception>
        public ResultBuilderFactory(IServiceProvider serviceProvider)
        {
            ArgumentsValidator.ThrowIfIsNull(serviceProvider, nameof(serviceProvider));

            this.serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public IOpResultBuilder GetOperationResultBuilder() => this.serviceProvider.GetService(typeof(IOpResultBuilder)) as IOpResultBuilder;

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> GetPageResultBuilder<TEntity>() =>
            this.serviceProvider.GetService(typeof(IPageResultBuilder<TEntity>)) as IPageResultBuilder<TEntity>;

        /// <inheritdoc/>
        public IResultBuilder<TPayload> GetPayloadResultBuilder<TPayload>() =>
            this.serviceProvider.GetService(typeof(IResultBuilder<TPayload>)) as IResultBuilder<TPayload>;
    }
}
