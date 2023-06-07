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
using Microsoft.AspNetCore.Identity;

namespace mail_management_backoffice.Pages.Mails
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(mail_management_backoffice.Data.MailManagementContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        /*public string FlagSort { get; set; }
        public string StatusSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }*/

        public string CurrentFilter { get; set; }

        public IList<Mail> Mail { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            IQueryable<Mail> mailsIQ = from s in _context.Mails
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                mailsIQ = mailsIQ.Where(s => s.Sender.Contains(searchString)
                                       || s.Messenger.Contains(searchString)
                                       || s.MailObject.Contains(searchString));
            }

            /*if (_context.Mails != null)
            {
                Mail = await _context.Mails.ToListAsync();
            }*/

            Mail = await mailsIQ.Include(m => m.Recipients).AsNoTracking().ToListAsync();

            foreach(var item in Mail)
            {
                item.CreateUser = await _userManager.FindByIdAsync(item.CreateUserId);
            }
        }

        /*public async Task OnGetAsync(string sortOrder)
        {

            FlagSort = sortOrder == "Flag" ? "flag_desc" : "";
            StatusSort = sortOrder == "Status" ? "status_desc" : "";
            DateSort = sortOrder == "CreatedDate" ? "date_desc" : "CreatedDate";

            IQueryable<Mail> mailsIQ = from s in _context.Mails
                                       select s;

            switch (sortOrder)
            {
                case "Flag":
                    mailsIQ = mailsIQ.OrderByDescending(s => s.Flag);
                    break;
                case "flag_desc":
                    mailsIQ = mailsIQ.OrderByDescending(s => s.Flag);
                    break;
                case "Status":
                    mailsIQ = mailsIQ.OrderBy(s => s.Status);
                    break;
                case "status_desc":
                    mailsIQ = mailsIQ.OrderByDescending(s => s.Status);
                    break;
                case "CreatedDate":
                    mailsIQ = mailsIQ.OrderBy(s => s.CreatedDate);
                    break;
                case "date_desc":
                    mailsIQ = mailsIQ.OrderByDescending(s => s.CreatedDate);
                    break;
                default:
                    mailsIQ = mailsIQ.OrderBy(s => s.CreatedDate);
                    break;
            }

            /*if (_context.Mails != null)
            {
                Mail = await _context.Mails.ToListAsync();
            }*/

            /*Mail = await mailsIQ.AsNoTracking().ToListAsync();
        }*/
    }
}
