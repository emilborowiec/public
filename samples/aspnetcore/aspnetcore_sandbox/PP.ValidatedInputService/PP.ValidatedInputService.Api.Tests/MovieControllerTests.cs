using System.Linq;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using PP.ValidatedInputService.Api.DTOs;
using PP.ValidatedInputService.Api.Models;
using Xunit;
using System.Text.Json.Serialization;

namespace PP.ValidatedInputService.Api.Tests
{
    public class MovieControllerTests : IClassFixture<WebApplicationFactory<PP.ValidatedInputService.Api.Startup>>
    {
        private readonly WebApplicationFactory<PP.ValidatedInputService.Api.Startup> _factory;

        public MovieControllerTests(WebApplicationFactory<PP.ValidatedInputService.Api.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task TestGetMoviesWithValidInput()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/movie");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<Movie>>>(json, options);
            Assert.NotNull(apiResponse.Data);
            Assert.Equal(12, apiResponse.Data.Count);
        }

        [Fact]
        public async Task TestGetMoviesWithInvalidInput()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/movie?phrase=Lo");

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            options.Converters.Add(new JsonStringEnumConverter());
            var apiResponse = JsonSerializer.Deserialize<ApiResponse<object>>(json, options);
            Assert.NotNull(apiResponse.Error);
            Assert.Equal(1, apiResponse.Error.ValidationErrors.Length);
        }
    }
}
