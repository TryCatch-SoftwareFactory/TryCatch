// <copyright file="PageModel.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Models
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Represents a standard model for paging queries.
    /// </summary>
    public class PageModel
    {
        private readonly string[] sortAsValidValues = new[]
        {
            DefaultValues.SortAsAscending,
            DefaultValues.SortAsDescending,
        };

        private readonly bool sortAsAscendingByDefault;

        /// <summary>
        /// Initializes a new instance of the <see cref="PageModel"/> class.
        /// </summary>
        /// <param name="limit">Sets the limit value - page size - for the query.</param>
        /// <param name="offset">Sets the offset value, where the query must be started.</param>
        /// <param name="quickSearch">Sets the value of search criteria.</param>
        /// <param name="orderBy">Sets the field to be used to sort the query results.</param>
        /// <param name="sortAs">Sets the sort mode as ascending or descending. Only accepts ASC or DESC values.</param>
        /// <param name="sortAsAscendingByDefault">Sets the default sort mode as ascending. It is used when the sortAs value is invalid or is not set.</param>
        public PageModel(
            int limit = DefaultValues.DefaultPageLimit,
            int offset = DefaultValues.DefaultOffset,
            string quickSearch = "",
            string orderBy = "",
            string sortAs = DefaultValues.SortAsAscending,
            bool sortAsAscendingByDefault = true)
        {
            this.Limit = limit;
            this.Offset = offset;
            this.OrderBy = orderBy;
            this.QuickSearch = quickSearch;
            this.SortAs = sortAs;
            this.sortAsAscendingByDefault = sortAsAscendingByDefault;
        }

        /// <summary>
        /// Gets the size of the query.
        /// </summary>
        public int Limit { get; }

        /// <summary>
        /// Gets the offset to be applied in the query.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Gets the value of quick search criteria.
        /// </summary>
        public string QuickSearch { get; }

        /// <summary>
        /// Gets the field name used as sort criteria.
        /// </summary>
        public string OrderBy { get; }

        /// <summary>
        /// Gets the sort mode [ASC|DESC].
        /// </summary>
        public string SortAs { get; }

        /// <summary>
        /// Indicates if the query must be sorted as ascending.
        /// </summary>
        /// <returns>True value if it must be sorted as ascending.</returns>
        public bool SortAsAscending()
        {
            var sortAsAscending = this.sortAsAscendingByDefault;

            if (!string.IsNullOrWhiteSpace(this.SortAs) && this.sortAsValidValues.Contains(this.SortAs))
            {
                sortAsAscending = this.SortAs
                    .ToUpper(CultureInfo.InvariantCulture)
                    .Equals(DefaultValues.SortAsAscending, StringComparison.Ordinal);
            }

            return sortAsAscending;
        }
    }
}
