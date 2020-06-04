using CityInfo_Core3_1_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API_Core3_1_Services
{
    public interface ILanguageRepository
    {
        IEnumerable<Language> GetLanguages();

        Language GetLanguage(int LanguageID);

        IEnumerable<City> GetCitiesFromLanguages(int LanguageID);

        bool LanguageExists(int LanguageID);
    }
}
