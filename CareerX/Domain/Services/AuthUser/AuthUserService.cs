using Domain.Services.AuthUser.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthUser
{
    public class AuthUserService: IAuthUserService
    {
        private readonly IAuthUserRepository _authUserRepository;

        public AuthUserService(IAuthUserRepository userRepository)
        {
            _authUserRepository = userRepository;
        }
        public async Task<Domain.Models.AuthUser> AddToAuthUser(Domain.Models.AuthUser authUser)
        {
            return await _authUserRepository.AddToAuthUser(authUser);
        }
        public Guid GetUserId()
        {
            return Guid.NewGuid();
        }

        
    }
}
