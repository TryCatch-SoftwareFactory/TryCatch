// <copyright file="IOpResultBuilder.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System;
    using TryCatch.Patterns.Builders;

    /// <summary>
    /// Define the interface of Operation result (OpResult) builder.
    /// </summary>
    public interface IOpResultBuilder : IBuilder<OpResult, IOpResultBuilder>
    {
        /// <summary>
        /// Allows setting an error message about the operation results.
        /// </summary>
        /// <param name="errors">Error message.</param>
        /// <exception cref="ArgumentNullException">If the error is null, throws it.</exception>
        /// <returns>A <see cref="IOpResultBuilder"/> reference to the builder.</returns>
        IOpResultBuilder WithError(string errors);
    }
}
