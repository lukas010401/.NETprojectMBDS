using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;
using Microsoft.AspNetCore.Identity;

namespace mail_management_backoffice.Pages.Mails
{
    public class CreateModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;
        public UserManager<IdentityUser> UserManager;
        public SignInManager<IdentityUser> SignInManager;

        public CreateModel(mail_management_backoffice.Data.MailManagementContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Mail Mail { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            Mail.CreateUser = await SignInManager.UserManager.GetUserAsync(User);
            Mail.CreatedDate = DateTime.UtcNow;
            _context.Mails.Add(Mail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
