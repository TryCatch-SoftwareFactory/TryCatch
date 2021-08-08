// <copyright file="Result{TPayload}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;
    using TryCatch.Validators;

    /// <summary>
    /// Represents a generic operation result with payload data.
    /// </summary>
    /// <typeparam name="TPayload">Type of payload data.</typeparam>
    public class Result<TPayload>
        where TPayload : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TPayload}"/> class.
        /// </summary>
        public Result()
        {
            this.Errors = string.Empty;

            this.Payload = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TPayload}"/> class.
        /// </summary>
        /// <param name="errors">Error message.</param>
        /// <exception cref="ArgumentException">It is thrown if the errors are null, empty or whitespace.</exception>
        public Result(string errors = "")
        {
            ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(errors);

            this.Errors = errors;

            this.Payload = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TPayload}"/> class.
        /// </summary>
        /// <param name="payload">A <see cref="TPayload"/> reference payload of the operation.</param>
        public Result(TPayload payload)
        {
            this.Errors = string.Empty;

            this.Payload = payload;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result{TPayload}"/> class.
        /// </summary>
        /// <param name="payload">A <see cref="TPayload"/> reference Payload of the operation.</param>
        /// <param name="errors">Error message.</param>
        /// <exception cref="ArgumentException">It is thrown if the errors are null, empty or whitespace.</exception>
        public Result(TPayload payload, string errors = "")
        {
            ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(errors);

            this.Errors = errors;

            this.Payload = payload;
        }

        /// <summary>
        /// Gets a value indicating whether if no error has occurred.
        /// </summary>
        public bool IsSucceeded => string.IsNullOrWhiteSpace(this.Errors);

        /// <summary>
        /// Gets the errors message.
        /// </summary>
        public string Errors { get; internal set; }

        /// <summary>
        /// Gets the operation payload.
        /// </summary>
        public TPayload Payload { get; internal set; }
    }
}
