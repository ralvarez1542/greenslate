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
    public class UserService : IUserService
    {
        private readonly Func<IDataService> _database;  
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;

        public UserService(Func<IDataService> database, ILogger<UserService> logger, IMapper mapper)
        {
            _database = database;
            _logger = logger;
            _mapper = mapper;
        }

        public List<UserViewModel> GetAllUser()
        {
            try
            {
                var model = _database().User.ToList();

                return _mapper.Map<List<UserViewModel>>(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Getting Users");
                throw new Exception("Unexpected error getting Users");
            }
        }
    }
}
