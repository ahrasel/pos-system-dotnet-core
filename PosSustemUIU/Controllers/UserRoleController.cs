using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PosSustemUIU.Controllers
{
    public class UserRoleController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager; 
        private readonly RoleManager<IdentityRole> _roleManager; 

        public UserRoleController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        // GET: Students
        public ActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        } 
    }
}