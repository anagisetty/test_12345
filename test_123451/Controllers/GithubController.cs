using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test_123451;

namespace test_123451
{
    public class GitHubController : ApiController
    {
        public HttpResponseMessage GetGitHubConfiguration()
        {
            try
            {
                //Get GitHub Configuration from the database
                var gitHubConfiguration = GetGitHubConfigurationFromDataBase();

                //Create response and return
                return Request.CreateResponse(HttpStatusCode.OK, gitHubConfiguration);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        private GitHubConfiguration GetGitHubConfigurationFromDataBase()
        {
            //TODO: Implement Database Logic to get GitHub Configuration
            return new GitHubConfiguration
            {
                UserName = "test_123451",
                Token = "asdgjadsfhgfdgdjhagjds",
                URL = "https://github.com/test_123451"
            };
        }
    }
}

public class GitHubConfiguration
{
    public string UserName { get; set; }
    public string Token { get; set; }
    public string URL { get; set; }
}