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

namespace Build.Pages.BuildingList
{
    public class CreateBuildingModel : PageModel
    {
        private ApplicationDBContext _db;

        public CreateBuildingModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Building Building { get; set; }
        public IEnumerable<Building> Buildings { get; set; }
        [BindProperty]
        public Building_User Building_User { get; set; }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost(int id)
        {
            if(ModelState.IsValid)
            {
                var userInfo = JsonConvert.DeserializeObject<User_info>(HttpContext.Session.GetString("SessionUser"));
                await _db.Building.AddAsync(Building);
                await _db.SaveChangesAsync();
                Buildings = await _db.Building.ToListAsync();
                Building_User.Building_id = Buildings.Last().Id;
                Building_User.User_id = userInfo.UserID;
                await _db.Building_User.AddAsync(Building_User);
                await _db.SaveChangesAsync();
                return RedirectToPage("List"); 
            }
            else
            {
                return Page();
            }
        }
    }
}