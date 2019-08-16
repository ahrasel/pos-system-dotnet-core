using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PosSustemUIU.Data;
using PosSustemUIU.Models;

namespace PosSustemUIU.Controllers
{
    public class EmployeeController : BaseCotroller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public EmployeeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        
        // GET: {Controller}
        public IActionResult Index()
        {
            return View( _userManager.Users);
        }
        
        // GET: {Controller}/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
        
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
        
            return View(user);
        }
        
        // GET: {Controller}/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: {Controller}/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                await _userManager.CreateAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        
        // GET: {Controller}/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        
        // POST: {Controller}/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationUser user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }
        
            if (ModelState.IsValid)
            {
                try
                {
                    await _userManager.UpdateAsync(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
        
        
        // POST: {Controller}/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Index));
        }
        
        private async Task<bool> UserExists(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user == null ? false : true;
        }

        public override Task<IActionResult> ChangeActiveStatus()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IActionResult> SoftDelete()
        {
            throw new System.NotImplementedException();
        }

        public override Task<IActionResult> Restore()
        {
            throw new System.NotImplementedException();
        }
    }
}