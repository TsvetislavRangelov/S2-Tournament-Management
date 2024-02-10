using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Business_Logic;
using Data_Access;
using Models;

namespace S2_Synthesis.Pages
{
    public class TournamentsModel : PageModel
    {
        TournamentManager tm = new(new TournamentData(), null);
        UserManager um = new(new UserData());
        [BindProperty]
        public Tournament[] Tournaments { get; set; }
        [BindProperty]
        public User LoggedUser { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("UserID") is null) return new RedirectToPageResult("/Login");
            Tournaments = tm.GetTournaments().ToArray();
            LoggedUser = um.FindUserById(Int32.Parse(HttpContext.Session.GetString("UserID")));
            return null;
        }
        
    }
}
