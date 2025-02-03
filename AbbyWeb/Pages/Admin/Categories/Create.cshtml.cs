using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace AbbyWeb.Pages.Admin.Categories
{
    [BindProperties]

    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public CreateModel(IUnitOfWork db)
        {
            _db = db;
        }
        public Category Category { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if(Category.Name==Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Category.Add(Category);
                _db.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
