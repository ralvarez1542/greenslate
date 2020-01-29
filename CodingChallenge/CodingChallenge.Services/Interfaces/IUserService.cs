using CodingChallenge.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAllUser();
    }
}
