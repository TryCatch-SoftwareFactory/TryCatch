// <copyright file="ValidatorNotFoundException.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Validators
{
    using System;

    /// <summary>
    /// Represents a validation not found exception that occurs when validation process fails.
    /// </summary>
    public class ValidatorNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorNotFoundException"/> class.
        /// </summary>
        public ValidatorNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ValidatorNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The <see cref="Exception"/> that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ValidatorNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
