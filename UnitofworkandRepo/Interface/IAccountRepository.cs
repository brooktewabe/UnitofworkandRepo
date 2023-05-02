using Microsoft.AspNetCore.Identity;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo.Interface
{
    public interface IAccountRepository
    {
        Task<IdentityResult> signUpAsync(SignUp signUp);
    }
}
