using mail_management_backoffice.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace mail_management_backoffice.Pages
{
    public class RegisterModel : PageModel
    {
        public UserManager<IdentityUser> UserManager;  
        public SignInManager<IdentityUser> SignInManager;

        [BindProperty]
        public Register Model {  get; set; }

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() { 
            if(ModelState.IsValid) {
                var user = new IdentityUser()
                {
                    UserName = Model.Email,
                    Email = Model.Email
                };

                var result = await UserManager.CreateAsync(user, Model.Password);
                if(result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToPage("/Register");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Page();
        }   
    }
}
