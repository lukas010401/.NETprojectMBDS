using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;

namespace mail_management_backoffice.Pages.ChangesHistory
{
    public class CreateModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public CreateModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["MailID"] = new SelectList(_context.Mails, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public ChangeHistory ChangeHistory { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ChangeHistory.Add(ChangeHistory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
