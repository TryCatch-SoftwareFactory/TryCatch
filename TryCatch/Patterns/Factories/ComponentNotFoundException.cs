// <copyright file="ComponentNotFoundException.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Factories
{
    using System;

    /// <summary>
    /// Represents errors that occur when the service provider don't find the implementation for the interface requested.
    /// </summary>
    public class ComponentNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class.
        /// </summary>
        public ComponentNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ComponentNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentNotFoundException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The <see cref="Exception"/> that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public ComponentNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
