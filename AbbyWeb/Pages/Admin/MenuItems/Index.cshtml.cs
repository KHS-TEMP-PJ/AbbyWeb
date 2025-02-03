using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.MenuItems
{
    public class IndexModel : PageModel
    {
        //private readonly IUnitofWork _db;
        //public IEnumerable<MenuItem> MenuItems { get; set; }
        //public IndexModel(IUnitofWork db)
        //{
        //    _db = db;
        //}
        public void OnGet()
        {
           // MenuItems = _db.MenuItem.GetAll();
        }
    }
}
