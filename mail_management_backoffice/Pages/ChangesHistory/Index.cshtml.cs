using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;
using Microsoft.AspNetCore.Identity;

namespace mail_management_backoffice.Pages.ChangesHistory
{
    public class IndexModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(mail_management_backoffice.Data.MailManagementContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IList<ChangeHistory> ChangeHistory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ChangeHistory != null)
            {
                ChangeHistory = await _context.ChangeHistory
                .Include(c => c.Mail).ToListAsync();

                foreach (var item in ChangeHistory)
                {
                    item.UpdateUser = await _userManager.FindByIdAsync(item.UpdateUserID);
                }
            }
        }
    }
}
