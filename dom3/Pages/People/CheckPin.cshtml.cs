using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dom3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dom3.Pages.People
{
    public class CheckPinModel : PageModel
    {
        private readonly ApplicationContext _context;
        [BindProperty]
        public Person Person { get; set; }
        public CheckPinModel(ApplicationContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(int id, int newpin)
        {
            return Redirect(Url.Page("Profile", new {id = id, pin = newpin }));
        }
    }
}
