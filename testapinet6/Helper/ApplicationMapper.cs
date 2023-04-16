using AutoMapper;
using Database.Models;
using WebHotel.DTO.DiscountDtos;
using WebHotel.DTO.DiscountRoomDetailDtos;
using WebHotel.DTO.ReservationDtos;
using WebHotel.DTO.RoomDtos;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.DTO.RoomTypeDtos;
using WebHotel.DTO.TokenDtos;
using WebHotel.DTO.UserDtos;

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

            CreateMap<DiscountUpdateDto, Discount>().ReverseMap();

            CreateMap<DiscountResponseDto, Discount>()
                .ReverseMap()
                .ForMember(destination => destination.NameType, options => options.MapFrom(source => source.DiscountType.Name))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Creator.Email))
                .ForMember(destination => destination.Roles, options => options.MapFrom(source => source.Creator.UserRoles.Select(a => a.Role!.Name).ToList()));
        }
    }
}
