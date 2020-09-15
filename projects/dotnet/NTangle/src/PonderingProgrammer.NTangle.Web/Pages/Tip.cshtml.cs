using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PonderingProgrammer.NTangle.DataAccess;
using PonderingProgrammer.NTangle.Model;

namespace PonderingProgrammer.NTangle.Web.Pages
{
    public class TipModel : PageModel
    {
        private readonly NTangleContext _context;
        private readonly ITipRepository _tipRepository;
        private readonly IActivityRepository _activityRepository;

        public TipModel(NTangleContext context, ITipRepository tipRepository, IActivityRepository activityRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _tipRepository = tipRepository ?? throw new ArgumentNullException(nameof(tipRepository));
            _activityRepository = activityRepository ?? throw new ArgumentNullException(nameof(activityRepository));
        }

        public TipInputModel Input { get; set; }
        public Tip CurrentTip { get; set; }
        public List<SelectListItem> ActivityOptions { get; set; }

        public void OnGet(int id)
        {
            CurrentTip = _tipRepository.FindById(id);
            
            ActivityOptions = _tipRepository.FetchAll()
                                       .Select(a => new SelectListItem {Value = a.Id.ToString(), Text = a.Name})
                                       .ToList();

            if (CurrentTip != null)
            {
                Input = new TipInputModel
                {
                    Name = CurrentTip.Name,
                    Summary =  CurrentTip.Summary,
                    ActivityId = CurrentTip.Activity.Id,
                    TipType = CurrentTip.TipType.ToString(),
                };
            }
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                CurrentTip = _tipRepository.FindById(id);
                return Page();
            }

            CurrentTip = _tipRepository.FindById(id) ?? new Tip(0, Input.Name,Enum.Parse<TipType>(Input.TipType));
            CurrentTip.Summary = Input.Summary;
            if (_activityRepository.FindById(Input.ActivityId) is {} activity)
            {
                activity.AddTip(CurrentTip);
            }
            else
            {
                _tipRepository.Add(CurrentTip);
            }

            _context.SaveChanges();
            
            return new RedirectResult("/Tips");
        }

        public class TipInputModel
        {
            public string Name { get; set; }
            public string Summary { get; set; }
            public string TipType { get; set; }
            public int ActivityId { get; set; }
        }
    }
}