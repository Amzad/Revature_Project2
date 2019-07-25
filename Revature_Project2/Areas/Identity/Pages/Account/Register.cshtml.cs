using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Revature_Project2.Data;
using Revature_Project2.Models;

namespace Revature_Project2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IHttpClientFactory clientFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _clientFactory = clientFactory;
    }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        { 
            
            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }


            [Required]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Address")]
            public string Address { get; set; }

            [Required]
            [Phone]
            [Display(Name = "Phone Number")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public virtual ICollection<Order> Orders { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                Customer user = new Customer { Username = Input.Email, CustomerEmail = Input.Email, CustomerFirstName = Input.FirstName, CustomerLastName = Input.LastName, CustomerPhoneNumber = Input.PhoneNumber, CustomerAddress = Input.Address, Password = Input.Password };

                var httpClient = _clientFactory.CreateClient("API");
                var response = await httpClient.PostAsJsonAsync("https://localhost:44376/api/create", user);
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;

                    Dictionary<string, string> tokenDictionary =
                            JsonConvert.DeserializeObject<Dictionary<string, string>>(result);

                    var access_token = tokenDictionary["access_token"];
                    var Email = tokenDictionary["email"];
                    var firstName = tokenDictionary["firstName"];
                    var lastName = tokenDictionary["lastName"];
                    var customerID = tokenDictionary["customerID"];


                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, Email ),
                        new Claim("firstName", firstName),
                        new Claim("lastName", lastName),
                        new Claim("customerID", customerID),
                        new Claim("access_token", access_token)
                    };
                    var iden = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(29),

                        IsPersistent = true

                    };
                    var principal = new ClaimsPrincipal(iden);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);
                    _logger.LogInformation("User created a new account with password.");

                    return LocalRedirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, response.ReasonPhrase);
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
