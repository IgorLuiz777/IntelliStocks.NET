using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace INTELLISTOCKS.SERVICES
{
    public class EmailService
    {
        private readonly HttpClient _httpClient;

        public EmailService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://send.api.mailtrap.io/");
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var emailData = new
            {
                from = new { email = "rm99809@fiap.com.br", name = "IntelliStocks" },
                to = new[]
                {
                    new { email = toEmail }
                },
                subject = subject,
                text = message
            };

            var jsonContent = JsonConvert.SerializeObject(emailData);
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", 
                "3ca9dadc2d39f58ac1bd546d90c0fa1d");

            var response = await _httpClient.PostAsync("https://sandbox.api.mailtrap.io/api/send/3236923", 
                httpContent);
            response.EnsureSuccessStatusCode();
        }
    }
}