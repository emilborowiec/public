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
        private readonly IActivityRepository _activityRepository;

        public List<Activity> Activities { get; set; }

        public ActivitiesModel(ILogger<IndexModel> logger, IActivityRepository activityRepository)
        {
            _logger = logger;
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
        }

        public void OnGet()
        {
            Activities = _activityRepository.FetchActivities().ToList();
        }
    }
}