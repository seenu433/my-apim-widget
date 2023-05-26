namespace SASTokenAuthCustomBinding.Binding
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Contains the result of an sas token check.
    /// </summary>
    public sealed class ApimUser
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email {get; set;}

        public string State { get; set; }

        public List<string> Groups { get; set; }
    }
}