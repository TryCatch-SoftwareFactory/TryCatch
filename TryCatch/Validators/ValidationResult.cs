// <copyright file="ValidationResult.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Representation of the validation result.
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        public ValidationResult()
        {
            this.Errors = new Dictionary<string, string[]>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        /// <param name="errors">A <see cref="IDictionary{string, string[]}"/> reference to the validation errors collection.</param>
        /// <exception cref="ArgumentNullException">It is thrown if the errors is null.</exception>
        public ValidationResult(IDictionary<string, string[]> errors)
        {
            ArgumentsValidator.ThrowIfIsNull(errors);

            this.Errors = errors;
        }

        /// <summary>
        /// Gets a value indicating whether the global result from validation is succeeded.
        /// </summary>
        public bool IsSuccess => !this.Errors.Any();

        /// <summary>
        /// Gets a reference with the validation error collection.
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }
    }
}
