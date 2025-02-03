using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public EditModel(IUnitOfWork db)
        {
            _db = db;
        }
        public FoodType FoodType { get; set; }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.GetFirstOrDefault(t => t.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            
            if (ModelState.IsValid)
            {
                _db.FoodType.Update(FoodType);
                _db.Save();
                TempData["success"] = "Food type edited successfully";

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
