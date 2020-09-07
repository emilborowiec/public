using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.NTangle.Core;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class ActivitiesModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITipRepository _tipRepository;

        public List<Activity> Activities { get; set; }

        public ActivitiesModel(ILogger<IndexModel> logger, ITipRepository tipRepository)
        {
            _logger = logger;
            _tipRepository = tipRepository ?? throw new ArgumentNullException(nameof(tipRepository));
        }

        public void OnGet()
        {
            Activities = _tipRepository.FetchActivities().ToList();
        }
    }
}