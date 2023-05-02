using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebHotel.DTO;
using WebHotel.Helper;

namespace WebHotel.Service.NotifiHubService
{
    [Authorize]
    public class ChatHub : Hub<IHubService>
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ChatHub(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void SendChatMessage(string whoReceive, string message)
        {
            if (Context.User is not null)
            {
                var name = Context.User?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)!.Value!;
                //Clients.Caller.ReceiveMessage(name, message);
                foreach (var connectionID in _connections.GetConnections(name))
                {
                    Clients.Client(connectionID).ReceiveMessage(name, "Đã rõ");
                }
            }
        }

        public void SendChatMessageAuto(string message)
        {
            Clients.Caller.ReceiveMessage("admin", "Đã nhận tin nhắn");
        }

        public async Task GetAllRoom(bool status)
        {
            var userName = Context.User?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)!.Value!;
            var user = await _context.ApplicationUsers.SingleOrDefaultAsync(a => a.UserName == userName);
            if (status)
            {
                Notification notification = new Notification()
                {
                    CreateAt = DateTime.Now,
                    Description = "Get all room successfull",
                    Link = false,
                    Status = true,
                    Title = "Get Room",
                    UserId = user!.Id
                };
                //await _context.Notifications.AddAsync(notification);
                //await _context.SaveChangesAsync();

                var result = new NotificationDtos();
                var notifications = _context.Notifications.AsNoTracking().Where(a => a.UserId == user!.Id);
                result.Count = notifications.Count();
                result.Items = _mapper.Map<List<NotificationDto>>(await notifications.ToListAsync());
                await Clients.Caller.ReceiveNotification(result);
            }
        }

        public override Task OnConnectedAsync()
        {
            var name = Context.User?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)!.Value!;
            _connections.Add(name, Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var name = Context.User?.Claims.FirstOrDefault(a => a.Type == ClaimTypes.Name)!.Value!;
            _connections.Remove(name, Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}

