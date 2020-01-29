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

        public IActionResult Index()
        {
            var model = new UserViewModel();
            SetupViewModel(model);
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


        private void SetupViewModel(UserViewModel model)
        {
            var user = _userService.GetAllUser();   

            model.Users = DropDown.GetDropDownPappingGeneric(
                user,
                nameof(model.Id),
                nameof(model.FullName),
                -1
            );

            model.Users.Insert(0, (new SelectListItem { Text = "USER NAME (Default '--')", Value = "0" }));
        }

    }
}
