using cloudscribe.Core.IdentityServerIntegration;

namespace cloudscribe.Core.IdentityServer.EFCore.PostgreSql
{
    public class StorageInfo : IStorageInfo
    {
        public string StoragePlatform { get { return "Entity Framework with PostgreSql"; } }
    }
}
