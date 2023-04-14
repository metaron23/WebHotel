namespace WebHotel.Service.NotifiHub
{
    public interface IHubService
    {
        Task ReceiveMessage(string sender, string message);
    }
}
