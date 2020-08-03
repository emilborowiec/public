using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.Map2d.ProcGen;
using PonderingProgrammer.Map2d.Svg;
using PonderingProgrammer.NProcGen.Web.Models;
using PonderingProgrammer.NtsToSvg;
using Svg;

namespace PonderingProgrammer.NProcGen.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GeneratorService _service = new GeneratorService();
        private readonly Map2dSvgRenderer _renderer = new Map2dSvgRenderer();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new MapViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult GenerateMap(PoppingRectanglesGenerationOptions options)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", new MapViewModel() { Options = options });
            }
            var map = _service.GenerateWithPoppingRectangles(options);
            var svg = _renderer.RenderToSvg(map, MapViewModel.Scale);

            var viewModel = new MapViewModel {Options = options, Svg = svg.GetHtml()};
            return View("Index", viewModel);
        }
    }
}
