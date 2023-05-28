using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;
using Microsoft.AspNetCore.Authorization;

namespace mail_management_backoffice.Pages.Mails
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public IndexModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

        public IList<Mail> Mail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Mails != null)
            {
                Mail = await _context.Mails.ToListAsync();
            }
        }
    }
}
