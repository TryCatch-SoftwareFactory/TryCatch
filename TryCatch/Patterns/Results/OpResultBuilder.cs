// <copyright file="OpResultBuilder.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;

    /// <summary>
    /// Implementation of the operation result builder.
    /// </summary>
    public sealed class OpResultBuilder : IOpResultBuilder
    {
        private OpResult opResult;

        /// <inheritdoc/>
        public IOpResultBuilder Build()
        {
            this.opResult = new OpResult();

            return this;
        }

        /// <inheritdoc/>
        public OpResult Create()
        {
            this.ThrowIfResultIsNotBuildBefore();

            return this.opResult;
        }

        /// <inheritdoc/>
        public IOpResultBuilder WithError(string errors)
        {
            this.ThrowIfResultIsNotBuildBefore();

            this.opResult.Errors = errors ?? throw new ArgumentNullException(nameof(errors));

            return this;
        }

        private void ThrowIfResultIsNotBuildBefore()
        {
            if (this.opResult is null)
            {
                throw new ResultBuilderException("OpResult is null. You need to build it first.");
            }
        }
    }
}
