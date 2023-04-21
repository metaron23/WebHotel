using WebHotel.Repository.AdminRepository.AuthenRepository;
using WebHotel.Repository.AdminRepository.DiscountRepository;
using WebHotel.Repository.AdminRepository.DiscountRoomDetailRepository;
using WebHotel.Repository.AdminRepository.DiscountTypeRepository;
using WebHotel.Repository.AdminRepository.RoomRepository;
using WebHotel.Repository.AdminRepository.RoomStarRepository;
using WebHotel.Repository.AdminRepository.RoomTypeRepository;
using WebHotel.Repository.UserRepository.AuthenRepository;
using WebHotel.Repository.UserRepository.ReservationRepository;
using WebHotel.Repository.UserRepository.RoomUserRepository;
using WebHotel.Repository.UserRepository.UserProfileRepository;
using WebHotel.Service.EmailRepository;
using WebHotel.Service.FileService;
using WebHotel.Service.TokenRepository;

namespace WebHotel.Startup
{
    public static class RepositorySetup
    {
        public static IServiceCollection RepositoryService(this IServiceCollection services)
        {
            services.AddScoped<ITokenRepository, TokenRepository>();

            services.AddScoped<IAuthenUserRepository, AuthenUserRepository>();

            services.AddScoped<IAuthenAdminRepository, AuthenAdminRepository>();

            services.AddScoped<IMailService, MailService>();

            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IRoomAdminRepository, RoomAdminRepository>();

            services.AddScoped<IRoomUserRepository, RoomUserRepository>();

            services.AddScoped<IRoomStarRepository, RoomStarRepository>();

            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddScoped<IDiscountAdminRepository, DiscountAdminRepository>();

            services.AddScoped<IDiscountRoomDetailAdminRepository, DiscountRoomDetailADminRepository>();

            services.AddScoped<IReservationUserRepository, ReservationUserRepository>();

            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();

            services.AddScoped<IDiscountTypeAdminRepository, DiscountTypeAdminRepository>();

            return services;
        }
    }
}
