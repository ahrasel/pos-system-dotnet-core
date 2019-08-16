using Microsoft.AspNetCore.Mvc;

namespace PosSustemUIU.Controllers
{
    public class BaseCotroller : Controller
    {
        public void Notification()
        {
            TempData["message"] = "Created";
        }
        
    }
}