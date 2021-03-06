﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo_Core3_1_Data.Models
{
    public class CityLanguageDto
    {
        public int CityId { get; set; }

        public int LanguageId { get; set; }

        public CityWithoutPointsOfInterestDto City { get; set; }

        public LanguageDto Language { get; set; }

        //public string City { get; set; }

        //public string Language { get; set; }
    }
}
