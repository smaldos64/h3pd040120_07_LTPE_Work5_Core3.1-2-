using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo_Core3_1_Data.Models
{
    public class PointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // public int CityID { get; set; }
        // Navigation Property => ingen grund til at have dette felt med i vores
        // DTO model !!!
    }
}
