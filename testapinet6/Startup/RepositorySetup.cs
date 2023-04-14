using WebHotel.Repository.AuthenRepository;
using WebHotel.Repository.DiscountRepository;
using WebHotel.Repository.DiscountRoomDetailRepository;
using WebHotel.Repository.EmailRepository;
using WebHotel.Repository.ReservationRepository;
using WebHotel.Repository.RoomRepository;
using WebHotel.Repository.RoomStarRepository;
using WebHotel.Repository.RoomTypeRepository;
using WebHotel.Repository.UserProfileRepository;
using WebHotel.Service.FileService;
using WebHotel.Service.TokenRepository;

namespace WebHotel.Startup
{
    public static class RepositorySetup
    {
        public static IServiceCollection RepositoryService(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddScoped<IAuthenRepository, AuthenRepository>();

            services.AddScoped<IMailRepository, MailRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IRoomRepository, RoomRepository>();

            services.AddScoped<IRoomStarRepository, RoomStarRepository>();

            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddScoped<IDiscountRepository, DiscountRepository>();

            services.AddScoped<IDiscountRoomDetailRepository, DiscountRoomDetailRepository>();

            services.AddScoped<IReservationRepository, ReservationRepository>();

            return services;
        }
    }
}
