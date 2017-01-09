using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RomanConverter.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace RomanConverterTests
{
  public class ApiTests
  {
    private readonly TestServer _server;
    private readonly HttpClient _client;
    
    public ApiTests()
    {
      // Arrange
      _server = new TestServer(new WebHostBuilder()
          .UseStartup<RomanConverter.Startup>());
      _client = _server.CreateClient();
    }

    [Fact]
    public async Task GetSingleRoman()
    {
      var jsonSerializerSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
    // Act
      var response = await _client.GetAsync("api/roman/1");
      response.EnsureSuccessStatusCode();

      var responseString = await response.Content.ReadAsStringAsync();

      NumberPair expectedResponse = new NumberPair() { Base10 = 1, Numeral = "I" };

      // Assert
      Assert.Equal(JsonConvert.SerializeObject(expectedResponse, Formatting.None, jsonSerializerSettings),
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
