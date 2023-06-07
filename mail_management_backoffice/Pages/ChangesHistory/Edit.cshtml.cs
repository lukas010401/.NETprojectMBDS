using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;

namespace mail_management_backoffice.Pages.ChangesHistory
{
    public class EditModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public EditModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ChangeHistory ChangeHistory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChangeHistory == null)
            {
                return NotFound();
            }

            var changehistory =  await _context.ChangeHistory.FirstOrDefaultAsync(m => m.ID == id);
            if (changehistory == null)
            {
                return NotFound();
            }
            ChangeHistory = changehistory;
           ViewData["MailID"] = new SelectList(_context.Mails, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChangeHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeHistoryExists(ChangeHistory.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ChangeHistoryExists(int id)
        {
          return _context.ChangeHistory.Any(e => e.ID == id);
        }
    }
}
