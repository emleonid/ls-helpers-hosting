namespace LS.Helpers.Hosting.Swagger
{
    using System;

    /// <summary>
    /// SwaggerForm
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class SwaggerFormAttribute : Attribute
    {
    }
}