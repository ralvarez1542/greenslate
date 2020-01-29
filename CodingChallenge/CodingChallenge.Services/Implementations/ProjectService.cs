using AutoMapper;
using CodingChallenge.Models;
using CodingChallenge.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly Func<IDataService> _database;  
        private readonly ILogger<ProjectService> _logger;
        private readonly IMapper _mapper;

        public ProjectService(Func<IDataService> database, ILogger<ProjectService> logger, IMapper mapper)
        {
            _database = database;
            _logger = logger;
            _mapper = mapper;
        }
        public List<ProjectViewModel> GetAllProjectByUser(ProjectViewModel request)
        {
            try
            {
                var model = _database().UserProject.Where(x => x.UserId == request.Id || request.Id == 0).Include(e => e.User).Include(e => e.Project).ToList();

                var modelMapped = model.Select(s => new ProjectViewModel
                {
                    Id = s.ProjectId,
                    StartDate = s.Project.StartDate,
                    EndDate = s.Project.EndDate,
                    Credits = s.Project.Credits,
                    IsActive = s.IsActive,
                    AssignedDate = s.AssignedDate,
                });


                return _mapper.Map<List<ProjectViewModel>>(modelMapped);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting projects");
                throw new Exception("Unexpected error getting projects");
            }
        }
    }
}
