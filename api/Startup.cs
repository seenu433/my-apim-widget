using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using SASTokenAuthCustomBinding.Binding;

[assembly: FunctionsStartup(typeof(MyApimWidget.Startup))]
namespace MyApimWidget
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var wbBuilder = builder.Services.AddWebJobs(x => { return; });
            wbBuilder.AddExtension<SASTokenExtensionProvider>();
        }
    }
}