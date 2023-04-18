using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test_123451;

public class GithubController : ApiController 
{
    [HttpGet]
    public HttpResponseMessage GetGithub()
    {
        try
        {
            var gitHubClient = new GitHubClient();
            gitHubClient.BaseAddress = new Uri("https://github.com/");
            gitHubClient.Credentials = new NetworkCredential("username", "password");
            var response = gitHubClient.GetAsync("/user/repos").Result;
            if (response.IsSuccessStatusCode)
            {
                return Request.CreateResponse(HttpStatusCode.OK, response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Something went wrong");
            }
        }
        catch (Exception ex)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        }
    }
}