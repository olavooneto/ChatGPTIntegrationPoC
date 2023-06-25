using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyChatGPTApp.Services;

namespace MyChatGPTApp.Controllers
{
    [Route("[controller]")]
    public class OpenAIController : Controller
    {
        private readonly ILogger<OpenAIController> _logger;
        private readonly IOpenAIService _openAIService;

        public OpenAIController(ILogger<OpenAIController> logger, IOpenAIService openAIService) => (_logger, _openAIService) = (logger, openAIService);

        [HttpPost]
        [Route("CompleteSentence")]
        public async Task<IActionResult> CompleteSentence(string text)
        {
            var result = await _openAIService.CompleteSentence(text);

            return Ok(result);
        }

        [HttpPost]
        [Route("CompleteSentenceAdvancence")]
        public async Task<IActionResult> CompleteSentenceAdvancence(string text)
        {
            var result = await _openAIService.CompleteSentenceAdvance(text);

            return Ok(result);
        }

        [HttpPost]
        [Route("CheckProgramingLanguage")]
        public async Task<IActionResult> CheckProgramingLanguage(string text)
        {
            var result = await _openAIService.CheckProgramingLanguage(text);

            return Ok(result);
        }

        [HttpPost]
        [Route("CheckHeroIsFromMarvelOrDC")]
        public async Task<IActionResult> CheckHeroIsFromMarvelOrDC(string heroName)
        {
            var result = await _openAIService.CheckHeroIsFromMarvelOrDC(heroName);

            return Ok(result);
        }


        [HttpPost]
        [Route("ListPokemonCounters")]
        [ProducesResponseType(typeof(string), (int)System.Net.HttpStatusCode.OK)]
        public async Task<IActionResult> ReturnBestPokemonCounters(string pokemonName)
        {
            var result = await _openAIService.ReturnBestPokemonCounters(pokemonName);

            return Ok(result);
        }
    }
}