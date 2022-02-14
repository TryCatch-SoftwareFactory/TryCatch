// <copyright file="AnyDriverSpec.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Specifications.Mocks.InMemory
{
    using System.Linq;
    using TryCatch.Patterns.Specifications.InMemory;

    public class AnyDriverSpec : CompositeSpecification<Taxi>
    {
        public override bool IsSatisfiedBy(Taxi candidate) => candidate.Drivers != null && candidate.Drivers.Any();
    }
}
