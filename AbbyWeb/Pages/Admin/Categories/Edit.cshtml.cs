using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public EditModel(IUnitOfWork db)
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
            if (Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Update(Category);
                _db.Save();
                TempData["success"] = "Category edited successfully";

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
