using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Clients;
using ToDoListApi.Models.WordOfDayModel;
using ToDoListApi.Models.DefinitionOfWordModel;

namespace ToDoListApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordOfDayController : ControllerBase
    {
        private readonly ILogger<WordOfDayController> _logger;
        private readonly WordOfDayClient _client;
        private readonly DefinitionOfWordClient _dclient;
        
        public WordOfDayController(ILogger<WordOfDayController> logger, WordOfDayClient client, DefinitionOfWordClient dclient)
        {
            _logger = logger;
            _client = client;
            _dclient = dclient;
        }
        [HttpGet]
        public async Task<DefinitionRoot> GetDefinitionAsync()
        {
            [HttpGet("GetWordOfDay")]
            async Task<WordOfDayRoot> GetRandomWord()
            {
                var word = await _client.GetRandomWord();
                return word;
            }
            WordOfDayRoot wr = GetRandomWord().Result;
            string word = wr.Word;
            DefinitionRoot definition = await _dclient.GetDefinitionOfWordAsync(word);
            if (definition.entries.Count == 0)
            {
                word = GetRandomWord().Result.Word;
                if (wr.Word.Contains(' '))
                {
                    word = GetRandomWord().Result.Word;
                }
                definition = await _dclient.GetDefinitionOfWordAsync(word);
            }         
            return definition;
        }
        
        
       

    }
}
