using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty]
        public ActivityInputModel Input { get; set; }
        
        public List<SelectListItem> ParentOptions { get; set; }
        public Activity CurrentActivity { get; set; }

        public void OnGet(int id)
        {
            CurrentActivity = _repository.Get(id);
            ParentOptions = _repository.FetchActivities()
                                       .Where(a => a.Id != id)
                                       .Select(a => new SelectListItem {Value = a.Id.ToString(), Text = a.Name,})
                                       .ToList();
            if (CurrentActivity != null)
            {
                Input = new ActivityInputModel
                {
                    Name = CurrentActivity.Name,
                    Description = CurrentActivity.Description,
                    ParentId = CurrentActivity.ParentId ?? 0,
                };
            }
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                CurrentActivity = _repository.Get(id);
                return Page();
            }
            
            CurrentActivity = _repository.Get(id) ?? new Activity();
            CurrentActivity.Name = Input.Name;
            CurrentActivity.Description = Input.Description;
            CurrentActivity.Parent = _repository.Get(Input.ParentId);
            
            _repository.Save(CurrentActivity);
            
            return new RedirectToPageResult("/Activities");
        }

        public class ActivityInputModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int ParentId { get; set; }
        }
    }
}