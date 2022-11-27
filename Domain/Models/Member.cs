using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Member : IEquatable<Member>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Dictionary<string, bool[]> RecurAvailablity;

        public bool Equals(Member? other)
        {
            if(other == null)
            {
                return false;
            }

            return Id == other.Id &&
                FullName.Equals(other.FullName) &&
                Email.Equals(other.Email) &&
                UserName.Equals(other.UserName);
        }
    }
}
