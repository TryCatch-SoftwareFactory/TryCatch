// <copyright file="IServiceCollectionExtensions.cs" company="TryCatch Software Factory">
// Copyright © TryCatch Software Factory All rights reserved.
// Licensed under the MIT license. See LICENSE.md file in the project root for full license information.
// </copyright>

namespace Microsoft.Extensions.DependencyInjection
{
    using System.Diagnostics.CodeAnalysis;
    using TryCatch.Patterns.Results;

    [ExcludeFromCodeCoverage]
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddResultBuilderFactory(this IServiceCollection services) =>
            services
                .AddScoped<IResultBuilderFactory, ResultBuilderFactory>()
                .AddScoped<IOpResultBuilder, OpResultBuilder>();

        public static IServiceCollection AddTypedPageResultBuilder<TEntity>(this IServiceCollection services)
            where TEntity : class => services.AddScoped<IPageResultBuilder<TEntity>, PageResultBuilder<TEntity>>();

        public static IServiceCollection AddTypedPayloadResultBuilder<TPayload>(this IServiceCollection services)
            where TPayload : class => services.AddScoped<IResultBuilder<TPayload>, ResultBuilder<TPayload>>();
    }
}
