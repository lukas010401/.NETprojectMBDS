﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mail_management_backoffice.Data;
using mail_management_backoffice.Models;

namespace mail_management_backoffice.Pages.Mails
{
    public class DetailsModel : PageModel
    {
        private readonly mail_management_backoffice.Data.MailManagementContext _context;

        public DetailsModel(mail_management_backoffice.Data.MailManagementContext context)
        {
            _context = context;
        }

      public Mail Mail { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mails == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails.FirstOrDefaultAsync(m => m.ID == id);
            if (mail == null)
            {
                return NotFound();
            }
            else 
            {
                Mail = mail;
            }
            return Page();
        }
    }
}
