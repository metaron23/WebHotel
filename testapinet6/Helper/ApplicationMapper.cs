﻿using AutoMapper;
using Database.Models;
using WebHotel.DTO;
using WebHotel.DTO.DiscountDtos;
using WebHotel.DTO.DiscountReservationDetailDtos;
using WebHotel.DTO.DiscountRoomDetailDtos;
using WebHotel.DTO.DiscountServiceDetailDtos;
using WebHotel.DTO.DiscountTypeDtos;
using WebHotel.DTO.ReservationDtos;
using WebHotel.DTO.RoomDtos;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.DTO.RoomTypeDtos;
using WebHotel.DTO.ServiceAttachDetailDtos;
using WebHotel.DTO.ServiceAttachDtos;
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

            CreateMap<RoomRequestDto, Room>().ReverseMap();

            CreateMap<RoomStarRequestDto, RoomStar>().ReverseMap();

            CreateMap<RoomTypeRequestDto, RoomType>().ReverseMap();

            CreateMap<RoomTypeResponseDto, RoomType>().ReverseMap();

            CreateMap<ReservationCreateDto, Reservation>().ReverseMap();

            CreateMap<DiscountRequestDto, Discount>().ReverseMap();

            CreateMap<DiscountRoomDetailRequest, DiscountRoomDetail>().ReverseMap();

            CreateMap<DiscountReservationDetailRequest, DiscountReservationDetail>().ReverseMap();

            CreateMap<DiscountServiceDetailRequest, DiscountServiceDetail>().ReverseMap();

            CreateMap<DiscountUpdateDto, Discount>().ReverseMap();

            CreateMap<DiscountResponseDto, Discount>()
                .ReverseMap()
                .ForMember(destination => destination.NameType, options => options.MapFrom(source => source.DiscountType.Name))
                .ForMember(destination => destination.Email, options => options.MapFrom(source => source.Creator.Email))
                .ForMember(destination => destination.Roles, options => options.MapFrom(source => source.Creator.UserRoles.Select(a => a.Role!.Name).ToList()));

            CreateMap<DiscountType, DiscountTypeResponseDto>().ReverseMap();

            CreateMap<ServiceAttach, ServiceAttachRequestDto>().ReverseMap();

            CreateMap<ServiceAttachResponseDto, ServiceAttach>().ReverseMap();

            CreateMap<ServiceAttachDetail, ServiceAttachDetailRequestDto>().ReverseMap();

            CreateMap<ServiceAttachDetailResponseDto, ServiceAttachDetail>().ReverseMap();

            CreateMap<Notification, NotificationDto>().ReverseMap();
        }
    }
}
