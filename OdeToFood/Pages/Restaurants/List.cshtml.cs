using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestaurantData restaurant;

        public string Message { get; set; }
        public IEnumerable<Restaurant> restaurants { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }
        public ListModel(IConfiguration configuration,
                         IRestaurantData restaurant)
        {
            this.configuration = configuration;
            this.restaurant = restaurant;
        }
        public void OnGet()
        {
            Message = configuration["Message"];
            restaurants = restaurant.GetRestaurantByName(SearchTerm);
        }
    }
}