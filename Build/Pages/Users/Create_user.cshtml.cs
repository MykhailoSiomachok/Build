using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Build.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Build.Pages.Users
{
    public class Create_userModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public Create_userModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public string Email_occupied { get; set; }
        public void OnGet(string Email_occupied)
        {
            this.Email_occupied = Email_occupied;
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var email = (from user in _db.User
                             where user.Email == User.Email
                             select user.Email).FirstOrDefault();
                Email_occupied = email + " is occupied";
                if (Email_occupied != " is occupied")
                {
                    return RedirectToPage(new { Email_occupied });
                }
                var hashed_password = Crypto.HashPassword(User.Password);
                User.Password = hashed_password;
                User.Active = true;
                await _db.User.AddAsync(User);
                await _db.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}