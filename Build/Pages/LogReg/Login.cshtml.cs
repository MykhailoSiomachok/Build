using System;
using System.Collections.Generic;
using System.Linq;
using Build.Model;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;

namespace Build.Pages.LogReg
{
    public class LoginModel : PageModel
    {
        public readonly ApplicationDBContext _db;

        [BindProperty]
        public User User { set; get; }
        public string Login_trouble { get; set; }
        public LoginModel(ApplicationDBContext db)
        {
            _db = db;
        }
        public void OnGet(string Login_trouble)
        {
            this.Login_trouble = Login_trouble;
        }
        public async Task<IActionResult> OnPost()
        {
            if(User.Email == null || User.Password == null)
            {
                return Page();
            }
            User user_entity = (from user in _db.User
                              where user.Email == User.Email
                              select user).FirstOrDefault();

            if(user_entity == null)
            {
                Login_trouble = "Invalid Username";
                return RedirectToPage(new { Login_trouble });
            }
            if (!Crypto.VerifyHashedPassword(user_entity.Password, User.Password))
            {
                Login_trouble = "Invalid Password";
            }
            else
            {
                var user_info = new User_info() { UserName = user_entity.Email, UserID = user_entity.Id, UserRole = user_entity.Role };
                HttpContext.Session.SetString("SessionUser", JsonConvert.SerializeObject(user_info));
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}