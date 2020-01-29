using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenge.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Credits { get; set; }
        public bool IsActive { get; set; }
        public DateTime AssignedDate { get; set; }
        public int TimeToStart => (StartDate - AssignedDate).Days;
    }
}
