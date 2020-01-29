using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodingChallenge.Models;
using CodingChallenge.Services.Interfaces;
using CodingChallenge.Models.Datatable;

namespace CodingChallenge.Controllers
{
    public class UserController : Controller
    {
        private readonly IProjectService _userProjectService;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IProjectService userProjectService)
        {
            _logger = logger;
            _userProjectService = userProjectService;
        }

        [HttpPost]
        public IActionResult GetProjectByUser([FromBody]ProjectViewModel request)
        {
            try
            {
                var modelList = _userProjectService.GetAllProjectByUser(request);

                var response = new DataTableResponseViewModel<ProjectViewModel>
                {
                    Data = modelList,
                    RecordsFiltered = modelList.Count,
                    RecordsTotal = modelList.Count
                };

                return Json(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting projects");
                ViewBag.ErrorMessage = "Unexpected error projects";

                var response = new DataTableResponseViewModel<ProjectViewModel>
                {
                    Data = new List<ProjectViewModel>(),
                    RecordsFiltered = 0,
                    RecordsTotal = 0,
                    Error = "Unexpected error getting projects"
                };

                return Json(response);
            }
        }
    }
}
