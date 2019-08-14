using Microsoft.AspNetCore.Mvc;

namespace PosSustemUIU.Components
{
    public class DataTable : ViewComponent
    {
        private readonly dynamic _list;

        public DataTable(dynamic list)
        {
            this._list = list;
        }

        public IViewComponentResult Invoke()
        {
            return View(_list);
        }
    }
}