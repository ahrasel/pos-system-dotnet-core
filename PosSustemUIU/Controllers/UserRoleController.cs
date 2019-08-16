using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PosSustemUIU.ViewModels;

namespace PosSustemUIU.Controllers
{
    [Authorize]
    public class UserRoleController : BaseCotroller
    {
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly RoleManager<IdentityRole> _roleManager; 

        public UserRoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        // GET: UserRoles
        public ActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(new UserRoleVM { Roles = roles});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Create(UserRoleVM model, object Session)
        {
            var roles = _roleManager.Roles;
            if(model.RoleName != null)
            {
                await _roleManager.CreateAsync(new IdentityRole{Name = model.RoleName});
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            await _roleManager.DeleteAsync(role);
            
            return RedirectToAction(nameof(Index));
        }

    }
}