using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MachineApp.DataAccess.Repository.IRepository;
using MachineApp.Models;
using MachineApp.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace MachineApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Fältet för E-Post krävs")]
            [EmailAddress]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Fältet för Lösenord krävs")]
            [StringLength(100, ErrorMessage = "{0} måste innehålla minst {2} och max {1} tecken.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bekräfta lösenord")]
            [Compare("Password", ErrorMessage = "Lösenordet och bekräftelselösenordet matchar inte.")]
            public string ConfirmPassword { get; set; }
            [Required(ErrorMessage = "Fältet för produktnamn krävs")]
            [Display(Name = "Namn")]
            [MaxLength(50)]
            public string Name { get; set; }

            [Required(ErrorMessage = "Fältet för Gatuadress krävs")]
            [Display(Name = "Gatuadress")]
            [MaxLength(50)]
            public string StreetAddress { get; set; }
            [Required(ErrorMessage = "Fältet för Postnummer krävs")]
            [Display(Name = "Postnummer")]
            [MaxLength(50)]
            public string PostalCode { get; set; }
            [Required(ErrorMessage = "Fältet för Stad krävs")]
            [Display(Name = "Stad")]
            [MaxLength(50)]
            public string City { get; set; }

            [Required(ErrorMessage = "Fältet för telefonnummer krävs")]
            [Display(Name = "Telefonnummer")]
            [MaxLength(10)]
            public string PhoneNumber { get; set; }
            //public int? CompanyId { get; set; }

            public string Role { get; set; }

            //public IEnumerable<SelectListItem> CompanyList { get; set; }
            public IEnumerable<SelectListItem> RoleList { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            //if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
            //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi));
            //}
            ReturnUrl = returnUrl;
            Input = new InputModel()
            {

                RoleList = _roleManager.Roles.Where(u => u.Name != SD.Role_User_Indi).Select(x => x.Name).Select(i => new SelectListItem
                {
                    Text = i,
                    Value = i
                })
            };
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                //var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
                var user = new ApplicationUser()
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    StreetAddress = Input.StreetAddress,
                    PostalCode = Input.PostalCode,
                    City = Input.City,
                    Name = Input.Name,
                    PhoneNumber = Input.PhoneNumber,
                    Role = Input.Role,
                    //CompanyId = Input.CompanyId

                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    //if (User.IsInRole(SD.Role_Admin))
                    //{
                    //    //an admin has logged in and they try to create a new user
                    //    await _userManager.AddToRoleAsync(user, SD.Role_Admin);
                    //}
                    //else
                    //{
                    //    await _userManager.AddToRoleAsync(user, SD.Role_User_Indi);
                    //}

                    _logger.LogInformation("Användaren skapade ett nytt konto med lösenord.");

                    if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_Admin));
                    }
                    //if (!await _roleManager.RoleExistsAsync(SD.Role_User_Comp))
                    //{
                    //    await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Comp));
                    //}
                    if (!await _roleManager.RoleExistsAsync(SD.Role_User_Indi))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.Role_User_Indi));
                    }
                    if (user.Role == null)
                    {
                        await _userManager.AddToRoleAsync(user, SD.Role_User_Indi);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, user.Role);
                    }

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Bekräfta din E-Post",
                        $"Bekräfta ditt konto genom att<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>klicka här</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        if (user.Role == null)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);

                        }
                        else
                        {
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }

                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
