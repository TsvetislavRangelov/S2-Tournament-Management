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
    public class ViewTournamentModel : PageModel
    {
        public UserManager um = new(new UserData());
        public TournamentManager tm = new(new TournamentData(), null);
        public PlayerTournamentManager ptm = new(new PlayerTournamentData());
        [BindProperty]
        public Tournament Selected { get; set; }
        public int RegisteredPlayers { get; set; }
        public User LoggedUser { get; set; }
        public Game[] Games { get; set; }
        public User[] UsersForGames { get; set; }
        public List<int> Winners { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (HttpContext.Session.GetString("UserID") is null) return new RedirectToPageResult("/Login");
            if (id.HasValue)
            {
                HttpContext.Session.SetString("TournamentID", id.ToString());
                Selected = tm.GetTournament((int)id);
                RegisteredPlayers = ptm.GetPlayerCountForTournament((int)id);
                LoggedUser = um.FindUserById(Int32.Parse(HttpContext.Session.GetString("UserID")));
                Games = tm.GetGamesForTournament((int)id);
                Winners = tm.GetWinnersForTournament((int)id);
                
                
                
            }
            return null;
        }

        public IActionResult OnPostRegister()
        {
            Selected = tm.GetTournament(Int32.Parse(HttpContext.Session.GetString("TournamentID")));
            User current = um.FindUserById(Int32.Parse(HttpContext.Session.GetString("UserID")));
            ptm.RegisterPlayerForTournament(Selected.Id, current.Id);
            return OnGet(Selected.Id);
        }

        public IActionResult OnPostCancel() => new RedirectToPageResult("Tournaments");

        public IActionResult OnPostExit()
        {
            Selected = tm.GetTournament(Int32.Parse(HttpContext.Session.GetString("TournamentID")));
            User current = um.FindUserById(Int32.Parse(HttpContext.Session.GetString("UserID")));
            ptm.ExitTournament(Selected.Id, current.Id);
            return OnGet(Selected.Id);
        }
        
    }
}
