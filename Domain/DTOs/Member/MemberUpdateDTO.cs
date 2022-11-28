using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Member
{
    public class MemberUpdateDTO
    {
        public int Id { get; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Dictionary<string, bool[]> RecurAvailablity { get; set; }

        public MemberUpdateDTO(int Id)
        {
            this.Id = Id;
        }
    }
}
