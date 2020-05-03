using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Build.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Build.Pages.Users
{
    public class ActivationModel : PageModel
    {
        private ApplicationDBContext _db;

        public ActivationModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            User = await _db.User.FindAsync(id);
            User.Active = !User.Active;
            await _db.SaveChangesAsync();
            return RedirectToPage("User_list");
        }
    }
}