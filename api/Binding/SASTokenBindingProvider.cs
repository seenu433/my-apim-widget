namespace SASTokenAuthCustomBinding.Binding
{
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs.Host.Bindings;

    /// <summary>
    /// Provides a new binding instance for the function host.
    /// </summary>
    public class SASTokenBindingProvider : IBindingProvider
    {
        public Task<IBinding> TryCreateAsync(BindingProviderContext context)
        {
            IBinding binding = new SASTokenBinding();
            return Task.FromResult(binding);
        }
    }

}