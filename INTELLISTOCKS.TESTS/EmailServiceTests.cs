using INTELLISTOCKS.SERVICES;

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Xunit;

namespace INTELLISTOCKS.TESTS
{
    public class EmailServiceTests
    {
        [Fact]
        public async Task SendEmailAsync_SendsEmail_WhenCalled()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("{}"),
                })
                .Verifiable();

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://send.api.mailtrap.io/")
            };

            var emailService = new EmailService(httpClient);
            string toEmail = "recipient@example.com";
            string subject = "Test Subject";
            string message = "Test Message";

            // Act
            await emailService.SendEmailAsync(toEmail, subject, message);

            // Assert
            mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post  // Verifica se é um POST
                    && req.RequestUri == new Uri("https://sandbox.api.mailtrap.io/api/send/3236923")
                    && req.Content.Headers.ContentType.MediaType == "application/json"
                    && req.Content.ReadAsStringAsync().Result.Contains(toEmail)
                ),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}
