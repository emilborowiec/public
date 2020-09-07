using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.NTangle.Core;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class SetsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITipSetRepository _tipSetRepository;

        public List<TipSet> TipSets { get; set; }

        public SetsModel(ILogger<IndexModel> logger, ITipSetRepository tipSetRepository)
        {
            _logger = logger;
            _tipSetRepository = tipSetRepository ?? throw new ArgumentNullException(nameof(tipSetRepository));
        }

        public void OnGet()
        {
            TipSets = _tipSetRepository.FetchTipSets().ToList();
        }
    }
}