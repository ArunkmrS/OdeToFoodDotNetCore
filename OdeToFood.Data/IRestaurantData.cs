using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);

        Restaurant GetByID(int ID);

        Restaurant UpdateRestaurant(Restaurant restaurant);

        int commit();

        Restaurant Add(Restaurant newRestaurant);
    }

    public class InMemoryData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryData()
        {
            restaurants = new List<Restaurant>()
           {
               new Restaurant{ID = 1, Name="Arun's Pizza", Location="Gurugram", CusineType= CusineType.French},
               new Restaurant{ID = 2, Name="Biryani", Location="Bangalore", CusineType= CusineType.Indian},
               new Restaurant{ID = 3, Name="Andre Testa Wan", Location="Gurugram", CusineType= CusineType.Mexican},
               new Restaurant{ID = 4, Name="French Collection", Location="Delhi", CusineType= CusineType.French}
           };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.ID = restaurants.Max(r => r.ID) + 1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
            
        }

        public int commit()
        {
            return 1;
        }

        public Restaurant GetByID(int ID)
        {
            return restaurants.SingleOrDefault(r => r.ID == ID);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
                   
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            Restaurant restaurant1 = restaurants.SingleOrDefault(r => r.ID == restaurant.ID);
            if (restaurant1!=null)
            {
                restaurant1.Name = restaurant.Name;
                restaurant1.CusineType = restaurant.CusineType;
                restaurant1.Location = restaurant.Location;
            }
            return restaurant1;
        }
    }
}
