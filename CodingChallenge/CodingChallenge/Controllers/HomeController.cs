using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodingChallenge.Models;
using CodingChallenge.Services.Interfaces;
using CodingChallenge.Utils;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CodingChallenge.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new UserViewModel();
            await SetupViewModel(model);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private async Task SetupViewModel(UserViewModel model)
        {
            var user = _userService.GetAllUser().Select(x => new UserViewModel { Id = x.Id, FullName = $"{x.FirstName} {x.LastName}" }).ToList();
            var defaultUser = user.Count > 0 ? user.FirstOrDefault() : new UserViewModel();

            model.Users = DropDown.GetDropDownPappingGeneric(
                user,
                nameof(defaultUser.Id),
                nameof(defaultUser.FullName)
            );

            model.Users.Insert(0, (new SelectListItem { Text = "USER NAME (Default '--')", Value = "0" }));
        }

    }
}
