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
    public class DetailsModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public DetailsModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

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
    }
}
