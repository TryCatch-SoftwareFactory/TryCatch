// <copyright file="ISpecificationFactory{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Specifications
{
    /// <summary>
    /// Specification factory interface. Allows getting the query specs for the filter object used as an argument.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity linked with the query specifications.</typeparam>
    public interface ISpecificationFactory<TEntity>
    {
        /// <summary>
        /// Gets a query specification for the filter object.
        /// </summary>
        /// <typeparam name="TFilterObject">Type of filter object.</typeparam>
        /// <param name="filterObject">A <see cref="TFilterObject"/> reference to the filter object.</param>
        /// <returns>A <see cref="ISpecification{TEntity}"/> reference to the specification.</returns>
        ISpecification<TEntity> GetSpecification<TFilterObject>(TFilterObject filterObject);

        /// <summary>
        /// Gets a query sort specification for the filter object.
        /// </summary>
        /// <typeparam name="TFilterObject">Type of filter object.</typeparam>
        /// <param name="filterObject">A <see cref="TFilterObject"/> reference to the filter object.</param>
        /// <returns>A <see cref="ISortSpecification{TEntity}"/> reference to the sort specification.</returns>
        ISortSpecification<TEntity> GetSortSpecification<TFilterObject>(TFilterObject filterObject);
    }
}
