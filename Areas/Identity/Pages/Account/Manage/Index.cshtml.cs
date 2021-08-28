using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using MachineApp.DataAccess.Data;
using MachineApp.DataAccess.Repository.IRepository;
using MachineApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MachineApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext _db;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IUnitOfWork unitOfWork,
            IEmailSender emailSender,
            ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            
            [Required(ErrorMessage = "Fältet för E-Post krävs")]
            [EmailAddress]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Fältet för telefonnummer krävs")]
            [Display(Name = "Telefonnummer")]
            [MaxLength(10)]
            [Phone]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Fältet för produktnamn krävs")]
            [Display(Name = "Namn")]
            [MaxLength(50)]
            public string Name { get; set; }

            [Required(ErrorMessage = "Fältet för Gatuadress krävs")]
            [Display(Name = "Gatuadress")]
            [MaxLength(50)]
            public string Address { get; set; }

            [Required(ErrorMessage = "Fältet för Stad krävs")]
            [Display(Name = "Stad")]
            [MaxLength(50)]
            public string City { get; set; }

            [Required(ErrorMessage = "Fältet för Postnummer krävs")]
            [Display(Name = "Postnummer")]
            [MaxLength(50)]
            public string PostalCode { get; set; }

        }

        //private async Task LoadAsync(IdentityUser user)
        //{
        //    var userName = await _userManager.GetUserNameAsync(user);
        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

        //    Username = userName;

        //    Input = new InputModel
        //    {
        //        PhoneNumber = phoneNumber
        //    };
        //}

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Det gick inte att ladda användaren med ID '{_userManager.GetUserId(User)}'.");
            }

            var userFromDb = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == user.Email);

            Username = userFromDb.UserName;

            Input = new InputModel
            {
                Email = userFromDb.Email,
                PhoneNumber = userFromDb.PhoneNumber,
                Address = userFromDb.StreetAddress,
                City = userFromDb.City,
                Name = userFromDb.Name,
                PostalCode = userFromDb.PostalCode,
            };

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Det gick inte att ladda användaren med ID '{_userManager.GetUserId(User)}'.");
            }

            var userFromDb = await _db.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == user.Email);

            userFromDb.Name = Input.Name;
            userFromDb.StreetAddress = Input.Address;
            userFromDb.City = Input.City;
            userFromDb.PostalCode = Input.PostalCode;
            userFromDb.PhoneNumber = Input.PhoneNumber;
            await _db.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Din profil har uppdaterats";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Det gick inte att ladda användaren med ID  '{_userManager.GetUserId(User)}'.");
            }


            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { userId = userId, code = code },
                protocol: Request.Scheme);
            await _emailSender.SendEmailAsync(
                email,
                "Bekräfta din email",
                $"Bekräfta ditt konto genom att <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>klicka här</a>.");

            StatusMessage = "Verifieringsmeddelande skickat. Kontrollera din e-post.";
            return RedirectToPage();
        }
    }
}
