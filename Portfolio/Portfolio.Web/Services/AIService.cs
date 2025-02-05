using Microsoft.Extensions.AI;
using OpenAI;
using System.Threading.Tasks;

namespace Portfolio.Web.Services
{
    public class AIService
    {
        private readonly OpenAI.Chat.ChatClient _chatClient;

        public AIService(IConfiguration configuration)
        {
            string? apiKey = configuration["OpenAIKey"];
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("OpenAI API Key is missing!");
            }

            var client = new OpenAIClient(apiKey);
            _chatClient = client.GetChatClient("gpt-4o");
        }

        public async Task<string?> GetAIResponse(string prompt)
        {
            var messages = new List<ChatMessage>
                                    {
                                        new ChatMessage(ChatRole.User, prompt)
                                    };

            var response = await _chatClient.CompleteChatAsync((IEnumerable<OpenAI.Chat.ChatMessage>)messages);

            return response?.ToString();
        }
    }
}
