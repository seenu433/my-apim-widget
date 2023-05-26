namespace SASTokenAuthCustomBinding.Binding
{
    using System;
    using Microsoft.Azure.WebJobs.Description;

    /// <summary>
    /// A custom attribute that lets you pass an <see cref="SASTokenResult"/> into an function definition.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
    [Binding]
    public sealed class SASTokenAttribute : Attribute
    {
    }
}