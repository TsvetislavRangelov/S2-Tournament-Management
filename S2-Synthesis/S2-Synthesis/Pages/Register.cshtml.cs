using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Business_Logic;
using Data_Access;

namespace S2_Synthesis.Pages
{
    public class RegisterModel : PageModel
    {
        public string DefaultChoice = "Netherlands";
        public PasswordManager pm = new PasswordManager();
        public UserManager um = new UserManager(new UserData());
        public NationalityManager nm = new NationalityManager();   
        [BindProperty]
        public User RegisterUser { get; set; }
        public void OnGet()
        {
            HttpContext.Session.Remove("UserID");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                string hash = pm.HashPassword(RegisterUser.Password);               
                RegisterUser.Password = hash;
                um.RegisterUser(RegisterUser);
                ViewData["successMessage"] = "Registration successful. You can now log in.";
                return Page();
            }
            ViewData["successMessage"] = "One or more fields are invalid. Registration failed.";
            return null;
        }
    }
}
