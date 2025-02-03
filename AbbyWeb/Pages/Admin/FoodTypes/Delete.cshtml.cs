using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _db;
        public DeleteModel(IUnitOfWork db)
        {
            _db = db;
        }
        public FoodType FoodType { get; set; }
        public void OnGet(int id)
        {
            FoodType = _db.FoodType.GetFirstOrDefault(t=>t.Id==id);

        }
        public async Task<IActionResult> OnPost()
        {

            var typefromDB = _db.FoodType.GetFirstOrDefault(t => t.Id == FoodType.Id);
            if (typefromDB != null)
            {
                _db.FoodType.Remove(typefromDB);
                _db.Save();
                TempData["success"] = "Food type deleted successfully";

                return RedirectToPage("Index");

            }

            return Page();

        }
    }
}
