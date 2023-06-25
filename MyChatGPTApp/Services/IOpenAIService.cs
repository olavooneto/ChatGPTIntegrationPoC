using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChatGPTApp.Services
{
    public interface IOpenAIService
    {
        Task<string> CompleteSentence(string text);
        Task<string> CompleteSentenceAdvance(string text);
        Task<string> CheckProgramingLanguage(string text);
        Task<string> CheckHeroIsFromMarvelOrDC(string text);
        Task<string> ReturnBestPokemonCounters(string pokemonName);
    }
}