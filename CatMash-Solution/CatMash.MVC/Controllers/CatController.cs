using CatMash.MVC.BusinessLogic;
using CatMash.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.MVC.Controllers
{
    public class CatController : Controller
    {
        private readonly ILogger<CatController> _logger;
        private readonly ICatService _catService;

        public CatController(ILogger<CatController> logger, ICatService catService)
        {
            _logger = logger;
            _catService = catService;
        }
        
        public async Task<ActionResult> Cats()
        {
            CatsModel model = await _catService.GetCats();
            return View(model);
        }

        public async Task<IActionResult> Vote()
        {
            var cats = await _catService.GetCatsForVote();
            var model = new VoteModel
            {
                FirstCat = cats.Item1,
                SecondCat = cats.Item2,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Vote([FromBody] VoteModel model)
        {
            try
            {
                await _catService.SendVote(model);
                return Json("OK");
            }
            catch
            {
                return Json("KO");
            }
        }


    }
}
