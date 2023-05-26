namespace SASTokenAuthCustomBinding.Binding
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.WebJobs.Host.Bindings;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;


    /// <summary>
    /// Creates a <see cref="ClaimsPrincipal"/> instance for the supplied header and configuration values.
    /// </summary>
    /// <remarks>
    /// This is where the actual authentication happens - replace this code to implement a different authentication solution.
    /// </remarks>
    public class SASTokenValueProvider : IValueProvider
    {
        private const string AUTH_HEADER_NAME = "UserToken";
        private HttpRequest _request;
        private readonly string _managementApiUrl;
        private readonly string _apiVersion;

        public SASTokenValueProvider(HttpRequest request)
        {
            _request = request;
        }

        public Task<object> GetValueAsync()
        {
            try
            {
                // Get the token from the header
                if (_request.Headers.ContainsKey(AUTH_HEADER_NAME))
                {
                    var token = _request.Headers["UserToken"].ToString();
                    var userId = _request.Headers["UserId"].ToString();
                    var _managementApiUrl = _request.Headers["ManagementApiUrl"].ToString();;
                    var _apiVersion = _request.Headers["ApiVersion"].ToString();;

                    HttpMessageHandler handler = new HttpClientHandler();

                    var httpClient = new HttpClient(handler)
                    {
                        BaseAddress = new Uri(_managementApiUrl),
                        Timeout = new TimeSpan(0, 2, 0),
                    };

                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                    httpClient.DefaultRequestHeaders.Add("Authorization", token);

                    var url = $"users/{userId}";
                    HttpResponseMessage response = httpClient.GetAsync($"{url}?api-version={_apiVersion}").Result;
                    string content = string.Empty;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                        {
                            content = stream.ReadToEnd();
                        }

                        var result = JsonConvert.DeserializeObject<dynamic>(content);
                        var user = new ApimUser
                        {
                            UserId = result.name,
                            FirstName = result.properties.firstName,
                            LastName = result.properties.lastName,
                            Email = result.properties.email,
                            State = result.properties.state,
                            Groups = new List<string>()
                        };

                        var groupUrl = $"users/{userId}/groups";
                        HttpResponseMessage groupsResponse = httpClient.GetAsync($"{groupUrl}?api-version={_apiVersion}").Result;
                        if (groupsResponse.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            using (StreamReader stream = new StreamReader(groupsResponse.Content.ReadAsStreamAsync().Result))
                            {
                                content = stream.ReadToEnd();
                            }

                            var groupResult = JsonConvert.DeserializeObject<dynamic>(content);
                            foreach (var group in groupResult.value)
                            {
                                user.Groups.Add(group.properties.displayName.ToString());
                            }
                        }

                        return Task.FromResult<object>(SASTokenResult.Success(user));
                    }
                    else
                    {
                        using (StreamReader stream = new StreamReader(response.Content.ReadAsStreamAsync().Result))
                        {
                            content = stream.ReadToEnd();
                        }

                        return Task.FromResult<object>(SASTokenResult.Error(response.StatusCode.ToString() + " " + content));
                    }
                }
                else
                {
                    return Task.FromResult<object>(SASTokenResult.NoToken());
                }
            }
            catch (Exception ex)
            {
                return Task.FromResult<object>(SASTokenResult.Error(ex.Message));
            }
        }

        public Type Type => typeof(ClaimsPrincipal);

        public string ToInvokeString() => string.Empty;
    }
}