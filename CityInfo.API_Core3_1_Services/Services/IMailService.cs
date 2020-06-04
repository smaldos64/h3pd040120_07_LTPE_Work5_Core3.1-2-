namespace CityInfo.API_Core3_1_Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}