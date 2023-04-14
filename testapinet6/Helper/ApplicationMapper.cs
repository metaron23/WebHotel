using AutoMapper;
using WebHotel.DTO.DiscountDtos;
using WebHotel.DTO.DiscountRoomDetailDtos;
using WebHotel.DTO.ReservationDtos;
using WebHotel.DTO.RoomDtos;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.DTO.RoomTypeDtos;
using WebHotel.DTO.Token;
using WebHotel.DTO.UserDtos;
using WebHotel.Model;
using WebHotel.Models;

namespace WebHotel.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<TokenRequestDto, TokenResponseDto>().ReverseMap();

            CreateMap<UserProfileRequestDto, ApplicationUser>().ReverseMap();

            CreateMap<UserProfileResponseDto, ApplicationUser>().ReverseMap();

            CreateMap<RoomResponseDto, Room>().ReverseMap();
            CreateMap<RoomCreateDto, Room>().ReverseMap();

            CreateMap<RoomStarRequestDto, RoomStar>().ReverseMap();

            CreateMap<RoomTypeCreateDto, RoomType>().ReverseMap();

            CreateMap<ReservationCreateDto, Reservation>().ReverseMap();

            CreateMap<DiscountRequestDto, Discount>().ReverseMap();

            CreateMap<DiscountRoomDetailRequest, DiscountRoomDetail>().ReverseMap();
        }
    }
}
