using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        public int ID { get; set; }

        [Required,StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Location { get; set; }
        public CusineType CusineType { get; set; }

    }
}
