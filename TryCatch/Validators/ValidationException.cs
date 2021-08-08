// <copyright file="ValidationException.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents validation exception that occurs when validation process fails.
    /// </summary>
    public class ValidationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        public ValidationException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidationException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class with a
        /// specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The <see cref="Exception"/> that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="result">A <see cref="ValidationResult"/> reference to validation result.</param>
        public ValidationException(ValidationResult result)
        {
            this.Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="result">A <see cref="ValidationResult"/> reference to validation result.</param>
        public ValidationException(string message, ValidationResult result)
            : base(message)
        {
            this.Result = result;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="errors">A <see cref="IDictionary{string, string[]}"/> reference to validation errors collection.</param>
        public ValidationException(IDictionary<string, string[]> errors)
        {
            errors ??= new Dictionary<string, string[]>();

            this.Result = new ValidationResult(errors);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="errors">A <see cref="IDictionary{string, string[]}"/> reference to validation errors collection.</param>
        public ValidationException(string message, IDictionary<string, string[]> errors)
            : base(message)
        {
            errors ??= new Dictionary<string, string[]>();

            this.Result = new ValidationResult(errors);
        }

        /// <summary>
        /// Gets the reference to the validation result data.
        /// </summary>
        public ValidationResult Result { get; }
    }
}
