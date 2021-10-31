﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using cloudscribe.Core.IdentityServer.EFCore.Extensions;
using cloudscribe.Core.IdentityServer.EFCore.Interfaces;
using cloudscribe.Core.IdentityServer.EFCore.MSSQL;
using cloudscribe.Core.IdentityServer.EFCore.Stores;
using Microsoft.EntityFrameworkCore;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IdServerBuilderExtensions
    {
        public static IIdentityServerBuilder AddCloudscribeCoreEFIdentityServerStorageMSSQL(
            this IIdentityServerBuilder builder,
            string connectionString
            )
        {
            //builder.AddConfigurationStoreMSSQL(connectionString);    
            //builder.AddOperationalStoreMSSQL(connectionString);
            builder.Services.AddCloudscribeCoreIdentityServerEFStorageMSSQL(connectionString);

            return builder;
        }

        //public static IIdentityServerBuilder AddConfigurationStoreMSSQL(
        //    this IIdentityServerBuilder builder, 
        //    string connectionString,
        //    Action<DbContextOptionsBuilder> optionsAction = null)
        //{
            
        //    builder.Services.AddEntityFrameworkSqlServer()
        //        .AddDbContext<ConfigurationDbContext>((serviceProvider, options) =>
        //        options.UseSqlServer(connectionString)
        //               .UseInternalServiceProvider(serviceProvider)
        //               );

        //    builder.Services.AddCloudscribeCoreIdentityServerStores();

        //    builder.Services.AddScoped<IConfigurationDbContext, ConfigurationDbContext>();
            
        //    return builder;
        //}

        public static IIdentityServerBuilder AddConfigurationStoreCache(
            this IIdentityServerBuilder builder)
        {
            builder.Services.AddMemoryCache(); // TODO: remove once update idsvr since it does this
            builder.AddInMemoryCaching();

            // these need to be registered as concrete classes in DI for
            // the caching decorators to work
            builder.Services.AddTransient<ClientStore>();
            builder.Services.AddTransient<ResourceStore>();

            // add the caching decorators
            builder.AddClientStoreCache<ClientStore>();
            builder.AddResourceStoreCache<ResourceStore>();

            return builder;
        }

        //public static IIdentityServerBuilder AddOperationalStoreMSSQL(
        //    this IIdentityServerBuilder builder,
        //    string connectionString,
        //    Action<DbContextOptionsBuilder> optionsAction = null)
        //{
            
        //    builder.Services.AddEntityFrameworkSqlServer()
        //        .AddDbContext<PersistedGrantDbContext>((serviceProvider, options) =>
        //        options.UseSqlServer(connectionString)
        //               .UseInternalServiceProvider(serviceProvider)
        //               );

        //    builder.Services.AddScoped<IPersistedGrantDbContext, PersistedGrantDbContext>();
            
        //    return builder;
        //}

        public static IServiceCollection AddCloudscribeCoreIdentityServerEFStorageMSSQL(
            this IServiceCollection services,
            string connectionString
            )
        {
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<ConfigurationDbContext>((serviceProvider, options) =>
                options.UseSqlServer(connectionString)
                       .UseInternalServiceProvider(serviceProvider)
                       );

            services.AddCloudscribeCoreIdentityServerStores();

            services.AddScoped<IConfigurationDbContext, ConfigurationDbContext>();

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<PersistedGrantDbContext>((serviceProvider, options) =>
                options.UseSqlServer(connectionString)
                       .UseInternalServiceProvider(serviceProvider)
                       );

            services.AddScoped<IPersistedGrantDbContext, PersistedGrantDbContext>();

            return services;
        }




    }
}