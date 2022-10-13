using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace Todo.Services.Tests
{
    [TestClass]
    public class ApiTests
    {
        
        [TestMethod]
        public async Task CheckStatus_SendRequest_ShouldReturnOk()
        {
            // Arrange
            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();

            // Act
            HttpResponseMessage response = await httpClient.GetAsync("api/Todoitems");

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
