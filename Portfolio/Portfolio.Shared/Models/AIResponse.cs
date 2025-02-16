using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portfolio.Shared.Models
{
    public class AIResponse
    {
        public int Index { get; set; }
        [JsonPropertyName("message")]
        public string? Message { get; set; }
        public object? Logprobs { get; set; }
        public string? FinishReason { get; set; }
        public List<Usage>? Usage { get; set; }
        public bool ViaAiChatService { get; set; }
    }

    public class Message
    {
        public string? Role { get; set; }
        public string? Content { get; set; }
        public object? Refusal { get; set; }
    }

    public class Usage
    {
        public string? Type { get; set; }
        public string? Model { get; set; }
        public int Amount { get; set; }
        public int Cost { get; set; }
    }
}
