using AutoMapper;
using CityInfo.API.Controllers;
using CityInfo.API_Core3_1_Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace CityInfo_Core3_1_UnitTest
{
    [TestClass]
    class UnitTestCities
    {
        private readonly Cities1Controller _cities1Controller;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        public UnitTestCities()
        {
            _cityInfoRepository = MockRepository.GenerateMock<ICityInfoRepository>();
            _mailService = MockRepository.GenerateMock<IMailService>();
            _mapper = MockRepository.GenerateMock<IMapper>();
            _cities1Controller = new Cities1Controller(_cityInfoRepository, _mapper, _mailService);
        }

        [TestMethod]
        public void TestGetAllCities()
        {
            var Cities = _cities1Controller.GetCities();
            int Test = 10;
        }
    }
}
