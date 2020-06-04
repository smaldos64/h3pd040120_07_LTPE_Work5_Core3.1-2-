using CityInfo_Core3_1_Data.Context;
using CityInfo_Core3_1_Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API_Core3_1_Services
{
    public class CityLanguageRepository : ICityLanguageRepository
    {
        #region General
        private readonly CityInfoContext _context;

        public CityLanguageRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        #endregion

        #region From_CityLanguage
        public IEnumerable<CityLanguage> GetAllCitiesLanguages()
        {
            var collection = _context.CityLanguages.
                Include(c => c.City).
                Include(l => l.Language)
                as IQueryable<CityLanguage>;

            collection = collection.OrderByDescending(c => c.City.CityLanguages.Count);
            
            return collection.ToList();
        }

        public IEnumerable<CityLanguage> GetAllCitiesFromLanguageID(int LanguageID)
        {
            var collection = _context.CityLanguages.Where(l => l.LanguageId == LanguageID)
                as IQueryable<CityLanguage>;

            collection = collection.OrderByDescending(c => c.City.CityLanguages.Count);

            return collection.ToList();
        }

        public IEnumerable<CityLanguage> GetAllLanguagesFromCityID(int CityID)
        {
            var collection = _context.CityLanguages.Where(c => c.CityId == CityID).
                Include(c => c.City).
                Include(l => l.Language)
                as IQueryable<CityLanguage>;

            collection = collection.OrderByDescending(l => l.Language.CityLanguages.Count);

            return collection.ToList();
        }

        public void AddCityLanguage(CityLanguage cityLanguage)
        {
            _context.CityLanguages.Add(cityLanguage);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        #endregion
    }
}
