// <copyright file="ResultBuilderException.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;

    /// <summary>
    /// Represents errors that occur when build or create a Result instance.
    /// </summary>
    public sealed class ResultBuilderException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBuilderException"/> class.
        /// </summary>
        public ResultBuilderException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBuilderException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        public ResultBuilderException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultBuilderException"/> class with a
        /// specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">
        /// The message that describes the error.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="Exception"/> that is the cause of the current exception, or a null reference if no inner exception is specified.
        /// </param>
        public ResultBuilderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
