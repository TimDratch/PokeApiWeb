using Microsoft.AspNetCore.Mvc;
using PokeApi.Contracts.Enums;
using PokeApiWeb.Services;
using System.Text.Json;

namespace PokeApiWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoveController : ControllerBase
    {

        readonly IPopulateDataFactory _dataFactory;
        public IPopulateDataService _dataService;
        ILogger<MoveController> _logger;


        public MoveController(ILogger<MoveController> logger, IPopulateDataFactory dataFactory)
        {
            _logger = logger;
            _dataFactory = dataFactory;
            _dataService = _dataFactory.Get(StoredData.Moves);
        }
        //Multi word moves seperated by '-'
        [HttpGet("{move}")]
        public async Task<string> GetMovesAsync(string move)
        {
            var moves = await _dataService.Populate();

            var movesEntry = moves.SingleOrDefault(x => x.Name == move);

            if (movesEntry is null)
                return "No matching Move";

            return JsonSerializer.Serialize(movesEntry) ?? "No matching Move";
        }
    }
}