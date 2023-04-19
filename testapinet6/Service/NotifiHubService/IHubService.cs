namespace WebHotel.Service.NotifiHubService
{
    public interface IHubService
    {
        Task ReceiveMessage(string sender, string message);

        Task ReceiveNotification(string sender, string message);
    }
}
