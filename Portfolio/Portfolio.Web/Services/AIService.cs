using System.Net.Http;
using System.Net;
using OpenAI;
using System.ClientModel;
using Newtonsoft.Json;
using Portfolio.Shared.Models;

namespace Portfolio.Web.Services
{
    public class AIService
    {
        private readonly OpenAI.Chat.ChatClient _chatClient;
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://localhost:7041"; // Ensure this matches your setup

        public AIService(IConfiguration configuration, HttpClient httpClient)
        {
            string? apiKey = configuration["OpenAIKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("OpenAI API Key is missing!");
            }

            var client = new OpenAIClient(apiKey);
            _chatClient = client.GetChatClient("gpt-4o-mini");
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string?> GetAIResponse(string prompt)
        {
            var messages = new List<OpenAI.Chat.ChatMessage>
                                            {
                                                OpenAI.Chat.ChatMessage.CreateUserMessage(prompt)
                                            };

            try
            {
                var response = await _chatClient.CompleteChatAsync(messages);
                return response?.ToString();
            }
            catch (ClientResultException ex) when (ex.Message.Contains("429"))
            {
                // Handle the rate limit error (HTTP 429)
                // You can implement retry logic, log the error, or return a user-friendly message
                return "Rate limit exceeded. Please try again later.";
            }
            catch (Exception ex)
            {
                // Handle other potential exceptions
                // Log the error or return a user-friendly message
                return $"An error occurred: {ex.Message}";
            }
        }
        public async Task<AIResponse?> GetResponseAsync(string userMessage)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ai/chat", new { Message = userMessage });
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AIResponse>(json); // Use JsonConvert instead of JsonSerializer
            }
            return new AIResponse { Message = "Error retrieving response." };
        }

    }

}
