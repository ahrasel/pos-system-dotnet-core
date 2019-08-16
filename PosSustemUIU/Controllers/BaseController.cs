using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PosSustemUIU.Controllers
{
    public abstract class BaseCotroller : Controller
    {
        public abstract Task<IActionResult> ChangeActiveStatus();
        public abstract Task<IActionResult> SoftDelete();
        public abstract Task<IActionResult> Restore();
        public void Notification()
        {
            TempData["message"] = "Created";
        }
        
    }
}