using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Build.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Build.Pages.BuildingList
{
    public class EditModel : PageModel
    {
        private ApplicationDBContext _db;

        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Building Building { get; set; }
        public async Task OnGet(int id)
        {
            Building = await _db.Building.FindAsync(id);
        }
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)  
            {
                var BuildingFromDB = await _db.Building.FindAsync(Building.Id);
                BuildingFromDB.Street = Building.Street;
                BuildingFromDB.Number = Building.Number;
                BuildingFromDB.Price = Building.Price;
                BuildingFromDB.Square = Building.Square;
                BuildingFromDB.Year = Building.Year;

                await _db.SaveChangesAsync();
                return RedirectToPage("List");
            }
            return RedirectToPage();
        }
    }
}