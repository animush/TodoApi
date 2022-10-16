using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services.Tests
{
    [TestClass]
    public class TodoItemIntegrationTests
    {
        [TestMethod]
        public async Task CheckStatus_SendRequest_ShouldReturnOkAsync()
        {
            // Arrange
            WebApplicationFactory<Program> webHost = new WebApplicationFactory<Program>().WithWebHostBuilder(_ => { });
            HttpClient httpClient = webHost.CreateClient();
            // Act
            HttpResponseMessage response = await httpClient.GetAsync("api/TodoItems/test");
            //Assert 
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
