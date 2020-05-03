using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Build.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Build.Pages.Users
{
    public class User_listModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public User_listModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public IEnumerable<User> Users { get; set; }
        public async Task<IActionResult> OnGet()
        {
            if (string.IsNullOrWhiteSpace((string)HttpContext.Session.GetString("SessionUser")) == true)
            {
                return RedirectToPage("/Index");
            }
            var userInfo = JsonConvert.DeserializeObject<User_info>(HttpContext.Session.GetString("SessionUser"));
            if (userInfo.UserRole != "admin")
            {
                return RedirectToPage("/Index");
            }
            else
            {
                Users = await _db.User.ToListAsync();
            }
            return Page();

        }
    }
}