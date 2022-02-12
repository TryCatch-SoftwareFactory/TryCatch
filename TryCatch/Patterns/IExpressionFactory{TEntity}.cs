// <copyright file="IExpressionFactory{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Expressions factory interface. Allows getting the linq expressions for the filter used as an argument.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity linked with the linq expression.</typeparam>
    public interface IExpressionFactory<TEntity>
    {
        /// <summary>
        /// Gets a linq expressions for the filter object.
        /// </summary>
        /// <typeparam name="TFilterObject">Type of filter object.</typeparam>
        /// <param name="filterObject">A <see cref="TFilterObject"/> reference to the filter object.</param>
        /// <returns>A <see cref="Expression{Func{TEntity, object}}"/> reference to the expression.</returns>
        Expression<Func<TEntity, bool>> GetExpression<TFilterObject>(TFilterObject filterObject);

        /// <summary>
        /// Gets a linq sort expressions for the filter object.
        /// </summary>
        /// <typeparam name="TFilterObject">Type of filter object.</typeparam>
        /// <param name="filterObject">A <see cref="TQueryObject"/> reference to the filter object.</param>
        /// <returns>A <see cref="Expression{Func{TEntity, object}}"/> reference to the sort expression.</returns>
        Expression<Func<TEntity, object>> GetSortExpression<TFilterObject>(TFilterObject filterObject);
    }
}
