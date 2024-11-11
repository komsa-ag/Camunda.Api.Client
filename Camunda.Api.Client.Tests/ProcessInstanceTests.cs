using RichardSzalay.MockHttp;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Camunda.Api.Client.Tests;

public class ProcessInstanceTests
{
  [Fact]
  public async Task GetList()
  {
    MockHttpMessageHandler mockHttp = new();

    mockHttp.Expect(HttpMethod.Post, "http://localhost:8080/engine-rest")
      .Respond(HttpStatusCode.OK, "text/html", "OK");

    CamundaClient client = CamundaClient.Create("http://localhost:8080/engine-rest", mockHttp);

    Assert.NotNull(await client.ProcessInstances.Query().List());
  }
}