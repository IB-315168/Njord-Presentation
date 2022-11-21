using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project : IEquatable<Project>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        ICollection<Requirement> Requirements { get; set; }


        public Project(int id, string name, int teamId, DateTime startDate)
        {
            Id = id;
            Name = name;
            TeamId = teamId;
            StartDate = startDate;
        }

        public bool Equals(ProjectEntity? other)
        {
            if(other == null)
            {
                return false;
            }

            return Id == other.Id && Name == other.Name && TeamId == other.TeamId;
        }
    }
}
