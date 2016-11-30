using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MyFirstDotNetCoreTests
{
  public class Class1
  {
    private readonly TestServer _server;
    private readonly HttpClient _client;
    public Class1()
    {
      // Arrange
      _server = new TestServer(new WebHostBuilder()
          .UseStartup<RomanConverter.Startup>());
      _client = _server.CreateClient();
    }

    [Fact]
    public async Task ReturnHelloWorld()
    {
      // Act
      var response = await _client.GetAsync("api/roman/1");
      response.EnsureSuccessStatusCode();

      var responseString = await response.Content.ReadAsStringAsync();

      // Assert
      Assert.Equal("I",
          responseString);
    }
  }
}

/*
using Xunit;

namespace MyFirstDotNetCoreTests
{
  public class Class1
  {
    [Fact]
    public void PassingTest()
    {
      Assert.Equal(4, Add(2, 2));
    }

    [Fact]
    public void FailingTest()
    {
      Assert.Equal(5, Add(2, 2));
    }

    int Add( int x, int y )
    {
      return x + y;
    }
  }
}
*/
