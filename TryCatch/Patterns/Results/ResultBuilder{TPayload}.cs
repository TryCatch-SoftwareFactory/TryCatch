// <copyright file="ResultBuilder{TPayload}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;
    using TryCatch.Validators;

    /// <summary>
    /// Implementation of the operation - with payload - result builder.
    /// </summary>
    /// <typeparam name="TPayload">Type of payload associated with the operation.</typeparam>
    public class ResultBuilder<TPayload> : IResultBuilder<TPayload>
    {
        private Result<TPayload> result;

        /// <inheritdoc/>
        public IResultBuilder<TPayload> Build()
        {
            this.result = new Result<TPayload>();

            return this;
        }

        /// <inheritdoc/>
        public Result<TPayload> Create()
        {
            this.ThrowIfResultIsNotBuildBefore();

            return this.result;
        }

        /// <inheritdoc/>
        public IResultBuilder<TPayload> WithError(string errors)
        {
            this.ThrowIfResultIsNotBuildBefore();

            ArgumentsValidator.ThrowIfIsNull(errors, nameof(errors));

            this.result.Errors = errors;

            return this;
        }

        /// <inheritdoc/>
        public IResultBuilder<TPayload> WithPayload(TPayload payload)
        {
            this.ThrowIfResultIsNotBuildBefore();

            if (payload is null)
            {
                throw new ArgumentNullException(nameof(payload));
            }

            this.result.Payload = payload;

            return this;
        }

        private void ThrowIfResultIsNotBuildBefore()
        {
            if (this.result is null)
            {
                throw new ResultBuilderException("Result is null. You need to build it first.");
            }
        }
    }
}
