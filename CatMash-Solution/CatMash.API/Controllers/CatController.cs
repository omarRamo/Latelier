using CatMash.API.BusinessLogic;
using CatMash.API.Messages;
using CatMash.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CatController : Controller
    {
        private readonly ILogger<CatController> _logger;
        private readonly ICatService _catService;

        public CatController(ILogger<CatController> logger, ICatService catService)
        {
            _logger = logger;
            _catService = catService;
        }

        [HttpGet]
        [Route("cats")]
        public IActionResult GetAllCatsScores()
        {
            var catscoresResponses = _catService.GetCats();
            _logger.LogInformation("Get cats");
            return Ok(catscoresResponses);
        }

        [HttpGet]
        [Route("vote")]
        public IActionResult Candidates()
        {
            var catscoresResponses = _catService.GetCandidatesCats();

            return Ok(catscoresResponses);
        }

        [HttpPost]
        [Route("vote")]
        public void Vote([FromBody] VoteRequest voteRequest)
        {
            _catService.InsertVote(voteRequest);
        }

    }
}
