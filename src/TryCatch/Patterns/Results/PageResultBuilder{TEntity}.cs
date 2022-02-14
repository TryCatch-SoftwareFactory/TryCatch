// <copyright file="PageResultBuilder{TEntity}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Results
{
    using System.Collections.Generic;
    using TryCatch.Validators;

    /// <summary>
    /// Implementation of the Pagination query result builder.
    /// </summary>
    /// <typeparam name="TEntity">Type of entities associated with the query.</typeparam>
    public sealed class PageResultBuilder<TEntity> : IPageResultBuilder<TEntity>
    {
        private PageResult<TEntity> pageResult;

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> Build()
        {
            this.pageResult = new PageResult<TEntity>();

            return this;
        }

        /// <inheritdoc/>
        public PageResult<TEntity> Create()
        {
            this.ThrowIfResultIsNotBuildBefore();

            return this.pageResult;
        }

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> WithItems(IEnumerable<TEntity> items)
        {
            ArgumentsValidator.ThrowIfIsNull(items, nameof(items));

            this.ThrowIfResultIsNotBuildBefore();

            this.pageResult.Items = items;

            return this;
        }

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> WithMatched(long matched)
        {
            ArgumentsValidator.ThrowIfIsLessThan(0, matched, nameof(matched));

            this.ThrowIfResultIsNotBuildBefore();

            this.pageResult.Matched = matched;

            return this;
        }

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> WithOffset(int offset)
        {
            ArgumentsValidator.ThrowIfIsLessThan(1, offset, nameof(offset));

            this.ThrowIfResultIsNotBuildBefore();

            this.pageResult.Offset = offset;

            return this;
        }

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> WithLimit(int limit)
        {
            ArgumentsValidator.ThrowIfIsLessThan(1, limit, nameof(limit));

            this.ThrowIfResultIsNotBuildBefore();

            this.pageResult.Limit = limit;

            return this;
        }

        /// <inheritdoc/>
        public IPageResultBuilder<TEntity> WithCount(long count)
        {
            ArgumentsValidator.ThrowIfIsLessThan(0, count, nameof(count));

            this.ThrowIfResultIsNotBuildBefore();

            this.pageResult.Count = count;

            return this;
        }

        private void ThrowIfResultIsNotBuildBefore()
        {
            if (this.pageResult is null)
            {
                throw new ResultBuilderException("PageResult is null. You need to build it first.");
            }
        }
    }
}
