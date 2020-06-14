using AutoMapper;
using CityInfo.API.Controllers;
using CityInfo.API_Core3_1_Services;
using Rhino.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CityInfo_Core3_1_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private readonly Cities1Controller _cities1Controller;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;

        private readonly Mock<ICityInfoRepository> _cityInfoRepositoryMock =
            new Mock<ICityInfoRepository>();

        private readonly Mock<IMapper> _mapperMock =
            new Mock<IMapper>();

        private readonly Mock<IMailService> _mailServiceMock =
            new Mock<IMailService>();

        public UnitTest1()
        {
            //_cityInfoRepository = MockRepository.GenerateMock<ICityInfoRepository>();
            //_mailService = MockRepository.GenerateMock<IMailService>();
            //_mapper = MockRepository.GenerateMock<IMapper>();
            //_cities1Controller = new Cities1Controller(_cityInfoRepository, _mapper, _mailService);

            _cities1Controller = new Cities1Controller(_cityInfoRepositoryMock.Object,
                                                       _mapperMock.Object,
                                                       _mailServiceMock.Object);
            int Test = 10;
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    int Test = 10;
        //}

        //[TestMethod]
        //public void TestMethod2()
        //{
        //    int Test = 10;
        //}

        [TestMethod]
        public void TestGetAllCities()
        {
            var Cities = _cities1Controller.GetCities();
            int Test = 10;
        }
    }
}
