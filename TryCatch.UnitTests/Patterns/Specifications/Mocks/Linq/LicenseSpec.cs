// <copyright file="LicenseSpec.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Specifications.Mocks.Linq
{
    using System;
    using System.Linq.Expressions;
    using TryCatch.Patterns.Specifications.Linq;

    public class LicenseSpec : CompositeSpecification<Taxi>
    {
        private readonly string license;

        public LicenseSpec(string license)
        {
            this.license = license;
        }

        public override Expression<Func<Taxi, bool>> AsExpression() => (candidate) =>
            candidate.License.Contains(this.license, StringComparison.InvariantCulture)
            || candidate.License.Equals(this.license, StringComparison.OrdinalIgnoreCase);
    }
}
