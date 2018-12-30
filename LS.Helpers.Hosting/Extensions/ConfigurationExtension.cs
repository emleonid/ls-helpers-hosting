using Microsoft.Extensions.Configuration;

namespace LS.Helpers.Hosting.Extensions
{
    /// <summary>
    /// Simple extensions for IConfiguration
    /// </summary>
    public static class ConfigurationExtension
    {
        /// <summary>
        /// Mies the connection string.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static string MyConnectionString(this IConfiguration configuration)
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}