using CodingChallenge.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Services.Interfaces
{
    public interface IDataService
    {
        DbSet<User> User { get; set; }
        DbSet<Project> Project { get; set; }
        DbSet<UserProject> UserProject { get; set; }

        void Save();
    }
}
