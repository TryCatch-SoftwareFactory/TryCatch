// <copyright file="OpResult.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using TryCatch.Validators;

    /// <summary>
    /// Representation of the one common operation result.
    /// </summary>
    public sealed class OpResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpResult"/> class.
        /// </summary>
        public OpResult()
        {
            this.Errors = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OpResult"/> class.
        /// </summary>
        /// <exception cref="System.ArgumentException">It is thrown if the errors are null, empty or whitespace.</exception>
        /// <param name="errors">Error message.</param>
        public OpResult(string errors = "")
        {
            ArgumentsValidator.ThrowIfIsNullEmptyOrWhiteSpace(errors);

            this.Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether if no error has occurred.
        /// </summary>
        public bool IsSucceeded => string.IsNullOrWhiteSpace(this.Errors);

        /// <summary>
        /// Gets the errors message.
        /// </summary>
        public string Errors { get; internal set; }
    }
}
