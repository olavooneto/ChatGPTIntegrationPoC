using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MyChatGPTApp.Configuration;
using OpenAI_API.Completions;
using OpenAI_API.Models;

namespace MyChatGPTApp.Services
{
    public class OpenAIService : IOpenAIService
    {
        private readonly OpenAiConfig _openAIConfig;
        public OpenAIService(IOptionsMonitor<OpenAiConfig> openAIConfig) => _openAIConfig = openAIConfig.CurrentValue;

        public async Task<string> CheckProgramingLanguage(string text)
        {
            // api instance
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

            var chat = api.Chat.CreateConversation();

            chat.AppendSystemMessage("you are a teacher who help new programmers understand things are programming languages or not. If the user tells you a programming language respond with yes, if a user tells you something which is not a programming language responde with no. You will only responde with yes or no. you do not say anything else.");

            chat.AppendUserInput(text);

            var response = await chat.GetResponseFromChatbotAsync();

            return response;
        }

        public async Task<string> CheckHeroIsFromMarvelOrDC(string text)
        {
            // api instance
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("you will inform if a informerd hero it's from Marvel or DC comics, also informs the name of the creator and the date that hero was created too");

            chat.AppendUserInput(text);

            return await chat.GetResponseFromChatbotAsync();
        }

        public async Task<string> ReturnBestPokemonCounters(string pokemonName)
        {
            // api instance
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);

            var chat = api.Chat.CreateConversation();
            chat.AppendSystemMessage("Based on the game Pokemon Go, you will inform the best 5 counters pokemon to fight againts the informed pokemon by user");

            chat.AppendUserInput(pokemonName);

            return await chat.GetResponseFromChatbotAsync();
        }

        public async Task<string> CompleteSentence(string text)
        {
            // api instance
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
            var result = await api.Completions.GetCompletion(text);

            return result;
        }

        public async Task<string> CompleteSentenceAdvance(string text)
        {
            // api instance
            var api = new OpenAI_API.OpenAIAPI(_openAIConfig.Key);
            var result = await api.Completions.CreateCompletionAsync(
                new CompletionRequest(text, model: Model.CurieText, temperature: 0.1));

            return result.Completions[0].Text;
        }
    }
}