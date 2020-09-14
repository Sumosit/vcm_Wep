using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dom3.Models;
using System;

namespace dom3.Pages.People
{
    public class ProfileModel : PageModel
    {
        int Money;
        private readonly ApplicationContext _context;
        [BindProperty]
        public Person Person { get; set; }

        public ProfileModel(ApplicationContext db)
        {
            _context = db;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _context.People.FindAsync(id);
            Money = Person.Money;
            Money = (int)(Math.Log10(Money) + 1);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if ((int)(Math.Log10(Person.Money) + 1) <= Money)
            {
                return RedirectToPage("Too big number");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.People.Any(e => e.Id == Person.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("Index");
        }
    }
}