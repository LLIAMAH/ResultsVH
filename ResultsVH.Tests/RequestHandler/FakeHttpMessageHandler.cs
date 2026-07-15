using System.Net;
using System.Text;

namespace ResultsVH.Tests.RequestHandler;

internal sealed class FakeHttpMessageHandler(string json) : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json")
        };

        return Task.FromResult(response);
    }
}
