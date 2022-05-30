using Microsoft.AspNetCore.Mvc.RazorPages;
using ClaimsIdentity.Interfaces;
using ClaimsIdentity.Models;
using ClaimsIdentity.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace ClaimsIdentity.Pages
{
    [Authorize]

    public class OstatnioSzukaneModel : PageModel
    {

        private readonly IPersonService _personService;
        private readonly UserManager<IdentityUser> _userManager;

        public UserListModelView Records { get; set; }

        public string? CurrentUserId { get; set; }

        public OstatnioSzukaneModel(IPersonService PersonService, UserManager<IdentityUser> userManager)
        {
            _personService = PersonService;
            _userManager = userManager;

        }

        public void OnGet()
        {
            Records = _personService.GetPeople();
            CurrentUserId = _userManager.GetUserId(HttpContext.User);
        }
    }
}
