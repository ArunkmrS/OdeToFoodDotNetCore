using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cusines { get; set; }

        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantID)
        {
            Cusines = htmlHelper.GetEnumSelectList<CusineType>();
            if (restaurantID.HasValue)
            {
                Restaurant = restaurantData.GetByID(restaurantID.Value);
            }
            else
            {
                Restaurant = new Restaurant();

            }

            if (Restaurant == null)
            {
                return RedirectToPage("./Edit");
            }
            return Page();
        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                Cusines = htmlHelper.GetEnumSelectList<CusineType>();
                return Page();

            }

            if (Restaurant.ID > 0)
            {
                TempData["Message"] = "Restaurant Updated Successfully";
                restaurantData.UpdateRestaurant(Restaurant);
            }
            else
            {
                TempData["Message"] = "Restaurant Added Successfully";
                restaurantData.Add(Restaurant);
            }
            restaurantData.commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.ID });
        }
    }
}