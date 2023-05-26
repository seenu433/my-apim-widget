namespace SASTokenAuthCustomBinding.Binding
{
    using Microsoft.Azure.WebJobs.Host.Config;

    /// <summary>
    /// Wires up the attribute to the custom binding.
    /// </summary>
    public class SASTokenExtensionProvider : IExtensionConfigProvider
    {
        public void Initialize(ExtensionConfigContext context)
        {
            // Creates a rule that links the attribute to the binding
            var provider = new SASTokenBindingProvider();
            var rule = context.AddBindingRule<SASTokenAttribute>().Bind(provider);
        }
    }
}