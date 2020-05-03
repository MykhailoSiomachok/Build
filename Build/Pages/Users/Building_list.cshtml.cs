using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Build.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Build.Pages.Users
{
    public class Building_listModel : PageModel
    {
        private ApplicationDBContext _db;

        public Building_listModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public User User { get; set; }
        public IEnumerable<Building> Buildings { get; set; }
        public IEnumerable<Building_User> Entity { get; set; }
        public int user_id { get; set; }
        public async Task OnGet(int id)
        {
            User = await _db.User.FindAsync(id);
            Buildings = await _db.Building.ToListAsync();
            Entity = await _db.Building_User.ToListAsync();
            user_id = User.Id;
        }
    }
}