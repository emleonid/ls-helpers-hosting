using Microsoft.AspNetCore.Hosting;

namespace LS.Helpers.Hosting.Extensions
{
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// EnvironmentExtensions
    /// </summary>
    public static class EnvironmentExtensions
    {
        /// <summary>
        /// Determines whether this instance is testing.
        /// </summary>
        /// <param name="env">The env.</param>
        /// <returns>
        ///   <c>true</c> if the specified env is testing; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTesting(this IWebHostEnvironment env)
        {
            return env.IsEnvironment(StandardEnvironment.Test);
        }
    }
}
