// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebAnimalPassport.Models.Data;

namespace WebAnimalPassport.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [DisplayName("Отчество")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Patronymic { get; set; }

            [DisplayName("Регион")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Region { get; set; }

            [DisplayName("Страна")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Country { get; set; }

            [DisplayName("Адрес")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Address { get; set; }

            [DisplayName("Индекс")]
            [MaxLength(1000, ErrorMessage = "Максимальная длина - 1000 символов!")]
            public string Index { get; set; }
        }

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var patronymic = user.Patronymic;
            var region = user.Region;
            var country = user.Country;
            var address = user.Address;
            var index = user.Index;

            Username = userName;
            Name = user.Name;
            Surname = user.Surname;
            City = user.City;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Patronymic = patronymic,
                Address = address,
                Index = index,
                Country = country,
                Region = region
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            var patronymic = user.Patronymic;
            var region = user.Region;
            var country = user.Country;
            var address = user.Address;
            var index = user.Index;
            if (Input.Patronymic != patronymic)
            {
                user.Patronymic = Input.Patronymic;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Country != country)
            {
                user.Country = Input.Country;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Address != address)
            {
                user.Address = Input.Address;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Index != index)
            {
                user.Index = Input.Index;
                await _userManager.UpdateAsync(user);
            }
            if (Input.Region != region)
            {
                user.Region = Input.Region;
                await _userManager.UpdateAsync(user);
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
