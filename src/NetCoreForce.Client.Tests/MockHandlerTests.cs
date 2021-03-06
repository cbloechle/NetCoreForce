using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetCoreForce.Client;
using Xunit;
using NetCoreForce.Models;

namespace NetCoreForce.Client.Tests
{
    public class MockHandlerTests
    {
        [Fact]
        public async void MockHandlerTest()
        {
            var mockHandler = new MockHttpClientHandler();
            mockHandler.AddMockResponse(new Uri("http://example.org/test"), new HttpResponseMessage(HttpStatusCode.OK));

            var httpClient = new HttpClient(mockHandler);

            var response1 = await httpClient.GetAsync("http://example.org/notthere");
            var response2 = await httpClient.GetAsync("http://example.org/test");

            Assert.Equal(response1.StatusCode, HttpStatusCode.NotFound);
            Assert.Equal(response2.StatusCode, HttpStatusCode.OK);
        }
    }
}
