using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public DeleteModel(IUnitOfWork db)
        {
            _db = db;
        }
        public Category Category { get; set; }
        public void OnGet(int id)
        {
            Category = _db.Category.GetFirstOrDefault(u=>u.Id==id);

        }
        public async Task<IActionResult> OnPost()
        {

            var catefromDB = _db.Category.GetFirstOrDefault(u => u.Id == Category.Id);
            if (catefromDB != null)
            {
                _db.Category.Remove(catefromDB);
                _db.Save();
                TempData["success"] = "Category deleted successfully";

                return RedirectToPage("Index");

            }

            return Page();

        }
    }
}
