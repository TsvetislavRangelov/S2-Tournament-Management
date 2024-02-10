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
    public class UserProfileModel : PageModel
    {
        public User Player { get; set; }
        private readonly UserManager um = new(new UserData());
        public Tournament[] tournaments;
        private readonly PlayerTournamentManager ptm = new(new PlayerTournamentData());
        public IActionResult OnGet()
        {
            if(HttpContext.Session.GetString("UserID") is null) return new RedirectToPageResult("/Error");
            this.tournaments = ptm.GetTournamentsForPlayer(Int32.Parse(HttpContext.Session.GetString("UserID")));
            this.Player = um.FindUserById(Int32.Parse(HttpContext.Session.GetString("UserID")));
            return null;
        }
    }
}
