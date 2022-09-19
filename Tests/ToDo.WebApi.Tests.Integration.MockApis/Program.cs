using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

var mock = WireMockServer.Start();

mock.Given(
    Request.Create()
        .WithPath("somePath"))
    .RespondWith(Response.Create()
        .WithBody("some response"));

Console.ReadKey();
mock.Stop();
mock.Dispose();