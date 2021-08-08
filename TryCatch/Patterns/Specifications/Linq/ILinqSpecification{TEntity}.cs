// <copyright file="ILinqSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications.Linq
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Linq Specification pattern interface.
    /// </summary>
    /// <typeparam name="TEntity">Entity type used on specifications over that queries to run.</typeparam>
    public interface ILinqSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets a LINQ expression with all specs about the filtering.
        /// </summary>
        /// <returns>A <see cref="Expression{Func{TEntity, bool}}"/> reference to linq expression.</returns>
        Expression<Func<TEntity, bool>> AsExpression();
    }
}
