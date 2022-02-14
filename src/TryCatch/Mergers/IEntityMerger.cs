// <copyright file="IEntityMerger.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Mergers
{
    /// <summary>
    /// Allows merging data from different data sources about the same entity.
    /// </summary>
    /// <typeparam name="TEntity">Type of entities to be merged.</typeparam>
    public interface IEntityMerger<TEntity>
    {
        /// <summary>
        /// Allows merging the current entity data with new values given by a new version of the entity.
        /// </summary>
        /// <param name="currentEntity">A <see cref="TEntity"/> reference to the current entity.</param>
        /// <param name="newEntity">A <see cref="TEntity"/> reference to the new version of the entity.</param>
        /// <exception cref="System.ArgumentNullException">It is thrown if any of the arguments are null.</exception>
        /// <returns>The <see cref="TEntity"/> reference to the entity with the values merged.</returns>
        TEntity MergeOnUpdate(TEntity currentEntity, TEntity newEntity);
    }
}
