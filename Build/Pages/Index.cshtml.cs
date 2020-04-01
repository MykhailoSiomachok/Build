using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Build.Model;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace Build.Pages
{
    public class IndexModel : PageModel
    {
        public string content { get; set; }
        public void OnGet()
        {

            if (string.IsNullOrWhiteSpace((string)HttpContext.Session.GetString("SessionUser")) == true)
            {
                content = "Need to Login!";
            }
            else
            {
                content = "You are logged";
            }
        }
    }
}
