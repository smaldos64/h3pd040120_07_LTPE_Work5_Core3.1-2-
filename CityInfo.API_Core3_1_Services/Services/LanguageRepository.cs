using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo_Core3_1_Data.Context;
using CityInfo_Core3_1_Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API_Core3_1_Services
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly CityInfoContext _context;

        public LanguageRepository(CityInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Language> GetLanguages()
        {
            var collection = _context.Languages.
                Include(l => l.CityLanguages).
                ThenInclude(c => c.City) as IQueryable<Language>;

            collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(l => l.LanguageName);

            return collection.ToList();
        }

        public IEnumerable<City> GetCitiesFromLanguages(int LanguageID)
        {
            var collection = _context.Cities.
                Include(c => c.CityLanguages).
                ThenInclude(l => l.Language).
                Where(c => c.CityLanguages.Any(l => l.LanguageId == LanguageID))
                as IQueryable<City>;

            //collection = collection.OrderByDescending(c => c.CityLanguages.Count).ThenBy(l => l.LanguageName);

            return collection.ToList();
        }

        public Language GetLanguage(int LanguageID)
        {
            return (_context.Languages.Find(LanguageID));
        }
        
        public bool LanguageExists(int LanguageID)
        {
            if (null != _context.Languages.Find(LanguageID))
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
    }
}
