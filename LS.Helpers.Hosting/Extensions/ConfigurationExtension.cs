namespace LS.Helpers.Hosting.Extensions
{
    using JetBrains.Annotations;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Simple extensions for IConfiguration
    /// </summary>
    [UsedImplicitly]
    public static class ConfigurationExtension
    {
        /// <summary>
        /// My the connection string.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        [UsedImplicitly]
        public static string MyConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}