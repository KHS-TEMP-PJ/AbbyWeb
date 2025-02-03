using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]

    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _db;

        public CreateModel(IUnitOfWork db)
        {
            _db = db;
        }
        public FoodType FoodType { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (ModelState.IsValid)
            {
                _db.FoodType.Add(FoodType);
                _db.Save();
                TempData["success"] = "Food type created successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
