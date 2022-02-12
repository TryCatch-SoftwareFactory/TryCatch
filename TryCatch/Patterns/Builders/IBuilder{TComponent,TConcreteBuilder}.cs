// <copyright file="IBuilder{TComponent,TConcreteBuilder}.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace TryCatch.Patterns.Builders
{
    /// <summary>
    /// Representation of the builder pattern through a generic interface. Allow building a TComponent instance with more complexity than
    /// with a basic constructor.Only define to basic methods - build and create - whose mission is to create a base instance of TComponent (build method)
    /// and return the reference(create method). Ref: https://en.wikipedia.org/wiki/Builder_pattern .
    /// </summary>
    /// <example>
    ///
    ///     // another operations...
    ///     var builder = sp.GetService(typeof(MyCarBuilder)) as MyCarBuilder;
    ///     // resolve the complex construction
    ///     var car = builder.build().withV12Engine().withBlackColor().withStickers().Create();
    ///     // more operations...
    ///
    /// </example>
    /// <typeparam name="TComponent">Type of component to build.</typeparam>
    /// <typeparam name="TConcreteBuilder">Type of concrete builder to implement.</typeparam>
    public interface IBuilder<TComponent, TConcreteBuilder>
        where TConcreteBuilder : IBuilder<TComponent, TConcreteBuilder>
    {
        /// <summary>
        /// Instance an internal TComponent reference and return the builder reference.
        /// </summary>
        /// <returns>Return a <see cref="TConcreteBuilder"/> reference to the current builder.</returns>
        TConcreteBuilder Build();

        /// <summary>
        /// Allows getting the current TComponent reference builded previously.
        /// </summary>
        /// <returns>Return a <see cref="TComponent"/> reference to the TComponent instance.</returns>
        TComponent Create();
    }
}
