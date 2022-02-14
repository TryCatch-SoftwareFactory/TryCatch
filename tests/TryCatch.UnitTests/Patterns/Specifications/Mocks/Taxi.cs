// <copyright file="Taxi.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.UnitTests.Patterns.Specifications.Mocks
{
    using System;
    using System.Collections.Generic;

    public class Taxi
    {
        public Taxi()
        {
            this.Drivers = new HashSet<string>();
            this.CreatedAt = DateTime.UtcNow;
        }

        public string License { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<string> Drivers { get; set; }
    }
}
