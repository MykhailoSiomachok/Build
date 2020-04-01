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
    public class ListModel : PageModel
    {
        private readonly ApplicationDBContext _db;
       
        public ListModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public Building uilding;
        public IEnumerable<Building> Buildings { get; set; }
        public IEnumerable<Building_User> Entity { get; set; }

        [BindProperty]
        public string SearchInput { get; set; }
        [BindProperty]
        public string SortInput { get; set; }
        public int user_id { get; set; }
        public string user_role { get; set; }
        public async Task<IActionResult> OnGet()
        {
            
            if(string.IsNullOrWhiteSpace((string)HttpContext.Session.GetString("SessionUser")) == true)
            {
                return RedirectToPage("/Index");
            }
            var userInfo = JsonConvert.DeserializeObject<User_info>(HttpContext.Session.GetString("SessionUser"));
            user_id = userInfo.UserID;
            user_role = userInfo.UserRole;
            if (SearchInput == null)
            {
                Buildings = await _db.Building.ToListAsync();
            }
            Entity = await _db.Building_User.ToListAsync();
            return Page();
        }

        public void OnPost()
        {
            if (SearchInput != null)
            {
                Buildings = from building in _db.Building
                            where building.Street.Contains(SearchInput) ||
                            building.Square.ToString().Contains(SearchInput) ||
                            building.Year.ToString().Contains(SearchInput) ||
                            building.Price.ToString().Contains(SearchInput) ||
                            building.Number.ToString().Contains(SearchInput)
                            select building;
            }
            if(SortInput != null)
            {
                if(SortInput == "Street")
                {
                    Buildings = from building in _db.Building
                                orderby building.Street
                                select building;
                }
                if (SortInput == "Number")
                {
                    Buildings = from building in _db.Building
                                orderby building.Number
                                select building;
                }
                if (SortInput == "Square")
                {
                    Buildings = from building in _db.Building
                                orderby building.Square
                                select building;
                }
                if (SortInput == "Price")
                {
                    Buildings = from building in _db.Building
                                orderby building.Price
                                select building;
                }
                if (SortInput == "Year")
                {
                    Buildings = from building in _db.Building
                                orderby building.Year
                                select building;
                }
            }
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var Building = await _db.Building.FindAsync(id);
            if(Building == null)
            {
                return NotFound();
            }
            _db.Building.Remove(Building);
            await _db.SaveChangesAsync();

            return RedirectToPage("List");
        }
    }
}