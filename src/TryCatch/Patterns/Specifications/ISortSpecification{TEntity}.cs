// <copyright file="ISortSpecification{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Represents an interface to isolate the logic of the sorts specs in the queries context.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity that will be ordered in the query.</typeparam>
    public interface ISortSpecification<TEntity>
    {
        /// <summary>
        /// Allows getting a linq expression to sort a IQueryable collection.
        /// </summary>
        /// <returns>A <see cref="Expression{Func{TEntity, object}}"/> reference to the sort expression.</returns>
        Expression<Func<TEntity, object>> AsExpression();

        /// <summary>
        /// Indicates if the type of sorts is ascending.
        /// </summary>
        /// <returns>True if the sorts is ascending.</returns>
        bool IsAscending();
    }
}
