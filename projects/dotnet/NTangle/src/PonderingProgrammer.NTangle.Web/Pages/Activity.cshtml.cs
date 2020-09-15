using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PonderingProgrammer.NTangle.DataAccess;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class ActivityModel : PageModel
    {
        private readonly NTangleContext _context;
        private readonly IActivityRepository _repository;

        public ActivityModel(NTangleContext context, IActivityRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [BindProperty]
        public ActivityInputModel Input { get; set; }
        
        public List<SelectListItem> ParentOptions { get; set; }
        public Activity CurrentActivity { get; set; }

        public void OnGet(int id)
        {
            CurrentActivity = _repository.FindById(id);
            ParentOptions = _repository.FetchNonDescendantActivities(CurrentActivity)
                                       .Select(a => new SelectListItem {Value = a.Id.ToString(), Text = a.Name})
                                       .ToList();
            if (CurrentActivity != null)
            {
                Input = new ActivityInputModel
                {
                    Name = CurrentActivity.Name,
                    Description = CurrentActivity.Description,
                    ParentId = CurrentActivity.Parent?.Id ?? 0,
                };
            }
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                CurrentActivity = _repository.FindById(id);
                return Page();
            }
            
            CurrentActivity = _repository.FindById(id) ?? new Activity(0, Input.Name);
            CurrentActivity.Description = Input.Description;
            if (_repository.FindById(Input.ParentId) is {} parent)
            {
                parent.AddChild(CurrentActivity);
            }
            else
            {
                _repository.Add(CurrentActivity);
            }

            _context.SaveChanges();
            
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