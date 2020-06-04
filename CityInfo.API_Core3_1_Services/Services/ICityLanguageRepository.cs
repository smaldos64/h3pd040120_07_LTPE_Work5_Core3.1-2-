using CityInfo_Core3_1_Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API_Core3_1_Services
{
    public interface ICityLanguageRepository
    {
        #region From_CityLanguage
        IEnumerable<CityLanguage> GetAllCitiesLanguages();

        IEnumerable<CityLanguage> GetAllCitiesFromLanguageID(int LanguageID);

        IEnumerable<CityLanguage> GetAllLanguagesFromCityID(int CityID);

        void AddCityLanguage(CityLanguage cityLanguage);

        bool Save();
        #endregion
    }
}
