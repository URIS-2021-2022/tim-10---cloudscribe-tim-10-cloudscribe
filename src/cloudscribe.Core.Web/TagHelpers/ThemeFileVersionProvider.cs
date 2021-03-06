using cloudscribe.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using System;
using System.Security.Cryptography;


namespace cloudscribe.Core.Web.TagHelpers
{
    /// <summary>
    /// Provides version hash for a specified file.
    /// </summary>
    public class ThemeFileVersionProvider
    {
        private const string VersionKey = "v";
        private static readonly char[] QueryStringAndFragmentTokens = new[] { '?', '#' };
        private readonly IFileProvider _fileProvider;
        private readonly IMemoryCache _cache;
        private readonly PathString _requestPathBase;
        private readonly MultiTenantOptions _multiTenantOptions;

        /// <summary>
        /// Creates a new instance of <see cref="ThemeFileVersionProvider"/>.
        /// </summary>
        /// <param name="fileProvider">The file provider to get and watch files.</param>
        /// <param name="cache"><see cref="IMemoryCache"/> where versioned urls of files are cached.</param>
        /// <param name="requestPathBase">The base path for the current HTTP request.</param>
        public ThemeFileVersionProvider(
            MultiTenantOptions multiTenantOptions,
            IFileProvider fileProvider,
            IMemoryCache cache,
            PathString requestPathBase
            )
        {
            _multiTenantOptions = multiTenantOptions;
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _requestPathBase = requestPathBase;
        }

        /// <summary>
        /// Adds version query parameter to the specified file path.
        /// </summary>
        /// <param name="path">The path of the file to which version should be added.</param>
        /// <returns>Path containing the version query string.</returns>
        /// <remarks>
        /// The version query string is appended with the key "v".
        /// </remarks>
        public string AddFileVersionToPath(string path, string mappedPath)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (mappedPath == null)
            {
                throw new ArgumentNullException(nameof(mappedPath));
            }

            var resolvedPath = mappedPath;

            var queryStringOrFragmentStartIndex = path.IndexOfAny(QueryStringAndFragmentTokens);
            if (queryStringOrFragmentStartIndex != -1)
            {
                resolvedPath = path.Substring(0, queryStringOrFragmentStartIndex);
            }

            Uri uri;
            if (Uri.TryCreate(resolvedPath, UriKind.Absolute, out uri) && !uri.IsFile)
            {
                // Don't append version if the path is absolute.
                return path;
            }

            string value;
            if (!_cache.TryGetValue(path, out value))
            {

                //this was a breaking change in 3.0, was getting an error here if not setting Size
                //but according to docs this should not be needed unless setting SizeLimit on the MemoryCache
                //and I can't find any place where we are doing that.
                //It seems that EFCore may be doing that as the problem does not happen when using NoDb
                //The memory size limit does not have a defined unit of measure because the cache has no mechanism to measure the size of entries.
                //The app could specify the size of all entries as 1, and the size limit is the count of entries.
                //https://docs.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-3.0
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                { 
                    Size = _multiTenantOptions.ThemeFileCacheSize
                };
                cacheEntryOptions.AddExpirationToken(_fileProvider.Watch(resolvedPath));
                var fileInfo = _fileProvider.GetFileInfo(resolvedPath);

                if (!fileInfo.Exists &&
                    _requestPathBase.HasValue &&
                    resolvedPath.StartsWith(_requestPathBase.Value, StringComparison.OrdinalIgnoreCase))
                {
                    var requestPathBaseRelativePath = resolvedPath.Substring(_requestPathBase.Value.Length);
                    cacheEntryOptions.AddExpirationToken(_fileProvider.Watch(requestPathBaseRelativePath));
                    fileInfo = _fileProvider.GetFileInfo(requestPathBaseRelativePath);
                }

                if (fileInfo.Exists)
                {
                    value = QueryHelpers.AddQueryString(path, VersionKey, GetHashForFile(fileInfo));
                }
                else
                {
                    // if the file is not in the current server.
                    value = path;
                }

                value = _cache.Set<string>(path, value, cacheEntryOptions);
            }

            return value;
        }

        private static string GetHashForFile(IFileInfo fileInfo)
        {
            //System.Security.Cryptography.SHA256.Create
            //using (var sha256 = CryptographyAlgorithms.CreateSHA256())
            using (var sha256 = SHA256.Create())
            {
                using (var readStream = fileInfo.CreateReadStream())
                {
                    var hash = sha256.ComputeHash(readStream);
                    return WebEncoders.Base64UrlEncode(hash);
                }
            }
        }
    }
}
