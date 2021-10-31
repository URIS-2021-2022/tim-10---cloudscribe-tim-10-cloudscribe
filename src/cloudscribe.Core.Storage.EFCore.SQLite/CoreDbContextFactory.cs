﻿using cloudscribe.Core.Storage.EFCore.Common;
using Microsoft.EntityFrameworkCore;

namespace cloudscribe.Core.Storage.EFCore.SQLite
{
    public class CoreDbContextFactory : ICoreDbContextFactory
    {
        public CoreDbContextFactory(DbContextOptions<CoreDbContext> options)
        {
            _options = options;
        }

        private DbContextOptions<CoreDbContext> _options;

        public ICoreDbContext CreateContext()
        {
            return new CoreDbContext(_options);
        }
    }
}
