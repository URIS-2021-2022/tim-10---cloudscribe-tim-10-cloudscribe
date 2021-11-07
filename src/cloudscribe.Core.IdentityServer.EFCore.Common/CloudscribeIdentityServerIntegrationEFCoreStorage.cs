using cloudscribe.Core.IdentityServer.EFCore.Interfaces;
using cloudscribe.Core.IdentityServer.EFCore.Mappers;
using IdentityServer4.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CloudscribeIdentityServerIntegrationEFCoreStorage
    {
        public static async Task InitializeDatabaseAsync(
            IServiceProvider scopedService
            , string siteId = null
            , IEnumerable<Client> initialClients = null,
            IEnumerable<ApiResource> initialApiResources = null,
            IEnumerable<IdentityResource> initialIdentityResources = null
            )
        {
           
                var grantContext = scopedService.GetRequiredService<IPersistedGrantDbContext>();
                var configContext = scopedService.GetRequiredService<IConfigurationDbContext>();
                try
                {
                    await grantContext.Database.MigrateAsync();
                    await configContext.Database.MigrateAsync();
                }
                catch(System.NotImplementedException)
                {
                    grantContext.Database.Migrate();
                }
                

                
               
                

                if(!string.IsNullOrEmpty(siteId) && (initialClients != null) && (!configContext.Clients.Any(x => x.SiteId == siteId)) && (initialApiResources != null) && 
                (!configContext.ApiResources.Any(x => x.SiteId == siteId)) && (initialIdentityResources != null) && (!configContext.IdentityResources.Any(x => x.SiteId == siteId)))

                {
                    
                        foreach (var client in initialClients)
                        {
                            var c = client.ToEntity();
                            c.SiteId = siteId;
                            configContext.Clients.Add(c);
                        }
                        
                    

                    
                        foreach (var scope in initialApiResources)
                        {
                            var s = scope.ToEntity();
                            s.SiteId = siteId;
                            configContext.ApiResources.Add(s);
                        }
                        
                    

                    
                        foreach (var scope in initialIdentityResources)
                        {
                            var s = scope.ToEntity();
                            s.SiteId = siteId;
                            configContext.IdentityResources.Add(s);
                        }

                        await configContext.SaveChangesAsync();
                    
                }


            

        }
    }
}
