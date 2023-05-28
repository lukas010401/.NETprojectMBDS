using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace mail_management_backoffice.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> SignInManager;
        public LogoutModel(SignInManager<IdentityUser> signInManager) {
            this.SignInManager = signInManager; 
        }    
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLogoutAsync()
        {
            await SignInManager.SignOutAsync();
            return RedirectToPage("Login");
        }

        public IActionResult OnPostDontLogout()
        {
            return RedirectToPage("Mails/Index");
        }
    }
}
