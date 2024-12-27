using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.AuthUser.Interface
{
    public interface IAuthUserService
    {
        Task<Domain.Models.AuthUser> AddToAuthUser(Domain.Models.AuthUser authUser);
        Guid GetUserId();
    }
}
