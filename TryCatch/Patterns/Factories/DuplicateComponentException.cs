// <copyright file="DuplicateComponentException.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Factories
{
    using System;

    /// <summary>
    /// Represents duplicate component exception that occurs when register process fails.
    /// </summary>
    public sealed class DuplicateComponentException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateComponentException"/> class.
        /// </summary>
        public DuplicateComponentException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateComponentException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public DuplicateComponentException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicateComponentException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The <see cref="Exception"/> that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public DuplicateComponentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
