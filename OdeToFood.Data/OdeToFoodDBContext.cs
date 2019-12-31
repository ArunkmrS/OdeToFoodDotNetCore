using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Data
{
    class OdeToFoodDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
