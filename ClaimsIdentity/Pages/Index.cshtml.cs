using ClaimsIdentity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClaimsIdentity.Interfaces;
using ClaimsIdentity.ViewModels.User;
using Microsoft.AspNetCore.Identity;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IPersonService _personService;

    private readonly UserManager<IdentityUser> _userManager;

    public UserListModelView Records { get; set; }
    public string Result { get; set; }

    [BindProperty]
    public User User { get; set; }

    public IndexModel(ILogger<IndexModel> logger, IPersonService personService,
        UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _personService = personService;
        _userManager = userManager;
    }

    public void OnGet()
    {
        Records = _personService.GetTodayPeople();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            Result = $"{User.Name} urodził się w {User.Year} roku. ";
            if (User.IsLeapYear())
                Result += "To był rok przestępny.";
            else
                Result += "To nie był rok przestępny.";

            if (User.Surname != null)
            {
                User.Result = User.IsLeapYear();
                User.CreatedTime = DateTime.Now;
                User.OwnerId = _userManager.GetUserId(HttpContext.User);

                _personService.Insert(User);
            }
        }
        Records = _personService.GetTodayPeople();

        return Page();
    }
}
