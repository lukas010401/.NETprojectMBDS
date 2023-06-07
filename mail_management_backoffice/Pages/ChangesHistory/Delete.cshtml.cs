using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;

namespace mail_management_backoffice.Pages.ChangesHistory
{
    public class DeleteModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public DeleteModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ChangeHistory ChangeHistory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ChangeHistory == null)
            {
                return NotFound();
            }

            var changehistory = await _context.ChangeHistory.FirstOrDefaultAsync(m => m.ID == id);

            if (changehistory == null)
            {
                return NotFound();
            }
            else 
            {
                ChangeHistory = changehistory;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ChangeHistory == null)
            {
                return NotFound();
            }
            var changehistory = await _context.ChangeHistory.FindAsync(id);

            if (changehistory != null)
            {
                ChangeHistory = changehistory;
                _context.ChangeHistory.Remove(ChangeHistory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
