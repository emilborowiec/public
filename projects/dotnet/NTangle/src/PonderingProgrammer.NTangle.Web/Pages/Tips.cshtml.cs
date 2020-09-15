using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.NTangle.DataAccess;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class TipsModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITipRepository _tipRepository;

        public TipsModel(ILogger<IndexModel> logger, ITipRepository tipRepository)
        {
            _logger = logger;
            _tipRepository = tipRepository;
        }

        public List<Tip> Tips { get; set; }
        
        public void OnGet()
        {
            Tips = _tipRepository.FetchAll().ToList();
        }
    }
}