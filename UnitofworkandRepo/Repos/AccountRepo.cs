using Microsoft.AspNetCore.Identity;
using UnitofworkandRepo.Interface;
using UnitofworkandRepo.Models;

namespace UnitofworkandRepo.Repos
{
    public class AccountRepo : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountRepo(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> signUpAsync(SignUp signUp)
        {
            var user = new ApplicationUser()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                UserName = signUp.Email
            };
            return await _userManager.CreateAsync(user,signUp.Password);
        }
    }
}
