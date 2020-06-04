using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo_Core3_1_Data.Models
{
    public class LanguageOfManipulation
    {
        [Required]
        public virtual string Name { get; set; }
    }
}
