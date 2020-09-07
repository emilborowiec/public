using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.NTangle.Core;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITipRepository _tipRepository;

        public List<Tip> Tips { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ITipRepository tipRepository)
        {
            _logger = logger;
            _tipRepository = tipRepository ?? throw new ArgumentNullException(nameof(tipRepository));
        }

        public void OnGet()
        {
            Tips = _tipRepository.FetchTips().ToList();
        }
    }
}
