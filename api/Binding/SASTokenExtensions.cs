namespace SASTokenAuthCustomBinding.Binding
{
    using System;
    using Microsoft.Azure.WebJobs;

    /// <summary>
    /// Called from Startup to load the custom binding when the Azure Functions host starts up.
    /// </summary>
    public static class SASTokenExtensions
    {
        public static IWebJobsBuilder AddSASTokenBinding(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SASTokenExtensionProvider>();
            return builder;
        }
    }
}