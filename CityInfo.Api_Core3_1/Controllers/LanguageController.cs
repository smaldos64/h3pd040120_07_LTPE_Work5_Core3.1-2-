using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo_Core3_1_Data.Context;
using CityInfo_Core3_1_Data.Entities;
using CityInfo_Core3_1_Data.Models;
using CityInfo.API_Core3_1_Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace CityInfo.Api_Core3_1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityLanguageController : ControllerBase
    {
        private readonly ICityLanguageRepository _cityLanguageRepository;
        private readonly IMapper _mapper;

        public CityLanguageController(ICityLanguageRepository cityLanguageRepository,
                                      IMapper _mapper)
        {
            this._cityLanguageRepository = cityLanguageRepository;
            this._mapper = _mapper;
        }

        // GET: api/CityLanguage/GetAllCitiesAndLanguages
        [HttpGet]
        [ActionName("GetAllCitiesAndLanguages")]
        public IActionResult GetAllCitiesAndLanguages(bool includeRelations = false)
        {
            var cityLanguageEntities = this._cityLanguageRepository.GetAllCitiesLanguages();

            if (false == includeRelations)
            {
                IEnumerable<CityLanguageWithoutRelationsDto> CityLanguageDtos = _mapper.Map<IEnumerable<CityLanguageWithoutRelationsDto>>(cityLanguageEntities);
                return Ok(CityLanguageDtos);
            }
            else
            {
                IEnumerable<CityLanguageDto> CityLanguageDtos = _mapper.Map<IEnumerable<CityLanguageDto>>(cityLanguageEntities);
                return Ok(CityLanguageDtos);
            }
        }

        // GET: api/CityLanguage/GetAllCitiesFromLanguageID/5
        // Linjen herover viser formatet for, hvordan vi skal nå vores metode herunder,
        // når vi ønsker at kalde denne fra f.eks.Postman.
        [HttpGet("{LanguageId}")]
        [ActionName("GetAllCitiesFromLanguageID")]
        // Normalt er navnet angivet i ActionName direktivet og navnet angivet i 
        // metoden/funktionen det samme. I tilfældet her er navnet begge steder :
        // GetAllCitiesFromLanguageID. Ønsker man af en eller anden grund at bruge
        // et andet ActionName end metodenavnet : GetAllCitiesFromLanguageID,
        // skal man angive dette i ActionName direktivet.
        // Hvis f.eks. vi ønsker at anvende et ActionName : h3pd040120_Tester, skal dette
        // følgelig skrives i ActionName direktivet. Og formatet for at nå vores 
        // metode/funktion herunder fra f.eks. Postman, skal da være :
        // api/CityLanguage/h3pd040120_Tester/5

        public IActionResult GetAllCitiesFromLanguageID(int LanguageId, bool includeRelations = false)
        // Det er vigtigt, at vores "navigationsparameter" (Id) i vores metode/funktion
        // er stavet nøjagtig på samme måde og med små/store bogstaver som angivet i linjen
        // [HttpGet("{Id}")]
        {
            var cityLanguageEntities = this._cityLanguageRepository.GetAllCitiesFromLanguageID(LanguageId);

            if (false == includeRelations)
            {
                IEnumerable<CityLanguageWithoutRelationsDto> CityLanguageDtos = _mapper.Map<IEnumerable<CityLanguageWithoutRelationsDto>>(cityLanguageEntities);
                return Ok(CityLanguageDtos);
            }
            else
            {
                IEnumerable<CityLanguageDto> CityLanguageDtos = _mapper.Map<IEnumerable<CityLanguageDto>>(cityLanguageEntities);
                return Ok(CityLanguageDtos);
            }
        }

        [HttpGet("{CityId}")]
        [ActionName("GetAllLanguagesFromCityID")]
        public IActionResult GetAllLanguagesFromCityID(int CityId, bool includeRelations = false)
        {
            var cityLanguageEntities = this._cityLanguageRepository.GetAllLanguagesFromCityID(CityId);

            if (false == includeRelations)
            {
                IEnumerable<CityLanguageWithoutRelationsDto> CityLanguageDtos = _mapper.Map<IEnumerable<CityLanguageWithoutRelationsDto>>(cityLanguageEntities);
                return Ok(CityLanguageDtos);
            }
            else
            {
                IEnumerable<CityLanguageDto> CityLanguageDtos = _mapper.Map<IEnumerable<CityLanguageDto>>(cityLanguageEntities);
                return Ok(CityLanguageDtos);
            }
        }

        // POST: api/CityLanguage
        [HttpPost]
        [ActionName("PostCityLanguage")]
        public IActionResult PostCityLanguage([FromBody] CityLanguage cityLanguage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this._cityLanguageRepository.AddCityLanguage(cityLanguage);

            try
            {
                if (this._cityLanguageRepository.Save())
                {
                    return Ok(cityLanguage.CityId);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception Error)
            {
                return Ok(0);
            }

        }

        // PUT: api/CityLanguage/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
