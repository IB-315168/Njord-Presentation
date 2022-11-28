using Domain.DTOs;
using Domain.DTOs.Member;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HttpClients.ClientInterfaces
{
    public interface IAuthService
    {
        public Task LoginAsync(MemberLoginDTO dto);
        public Task LogoutAsync();
        public Task RegisterAsync(MemberEntity user);
        public Task<ClaimsPrincipal> GetAuthAsync();

        public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    }
}
