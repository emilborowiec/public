using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PonderingProgrammer.NTangle.Core;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class ActivityModel : PageModel
    {
        private readonly IActivityRepository _repository;

        public ActivityModel(IActivityRepository repository)
        {
            _repository = repository;
        }

        public string Name { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost(int? id, string name)
        {
            var activity = new Activity {Name = name};
            _repository.Save(activity);
            return new RedirectToPageResult("/Activities");
        }
    }
}