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
using mail_management_backoffice.Enums;

namespace mail_management_backoffice.Pages.Mails
{
    public class EditModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public EditModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mail Mail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mails == null)
            {
                return NotFound();
            }

            var mail =  await _context.Mails.FirstOrDefaultAsync(m => m.ID == id);
            if (mail == null)
            {
                return NotFound();
            }
            Mail = mail;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var mailToUpdate = _context.Mails.FirstOrDefault(m => m.ID == Mail.ID);

            MailFlag previousFlag = mailToUpdate.Flag;
            MailStatus previousStatus = mailToUpdate.Status;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (mailToUpdate == null)
            {
                _context.Attach(Mail).State = EntityState.Modified;
            }

            mailToUpdate.Flag = Mail.Flag;
            mailToUpdate.Status = Mail.Status;
            mailToUpdate.UpdatedDate = DateTime.UtcNow;
            _context.Mails.Update(mailToUpdate);

            ChangeHistory changeHistory = new ChangeHistory(Mail.ID, previousFlag, DateTime.Now, previousStatus, Mail.Flag, Mail.Status, mailToUpdate.CreateUserId);
            
            _context.ChangeHistory.Add(changeHistory);
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MailExists(Mail.ID))
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

        private bool MailExists(int id)
        {
          return _context.Mails.Any(e => e.ID == id);
        }
    }
}
