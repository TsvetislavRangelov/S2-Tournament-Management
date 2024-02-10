using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Models;
using Business_Logic;
using Data_Access;

namespace S2_Synthesis.Pages
{
    public class LoginModel : PageModel
    {
       private readonly UserManager um = new UserManager(new UserData());
        [BindProperty]
        public new LoginUser User { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Remove("UserID");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                User found = um.LoginUser(User.Email, User.Password);
                if (found is null)
                {
                    ViewData["successMessage"] = "Your credentials are invalid. Please try again.";
                    return Page();
                }
                HttpContext.Session.SetString("UserID", found.Id.ToString());
                return new RedirectToPageResult("/Tournaments");
            }
            return Page();
        }
    }
}
