using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services.AuthUser.Interface
{
    public interface IAuthUserRepository
    {
        Task<Domain.Models.AuthUser> AddToAuthUser(Domain.Models.AuthUser authUser);


        string? CreateToken(Domain.Models.AuthUser user);
    }
}
