using AutoMapper;
using Database.Data;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO;
using WebHotel.DTO.RoomDtos;
using WebHotel.Service.FileService;

namespace WebHotel.Repository.AdminRepository.RoomRepository
{
    public partial class RoomAdminRepository : IRoomAdminRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public RoomAdminRepository(MyDBContext context, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _mapper = mapper;
            _fileService = fileService;
        }

        public async Task<StatusDto> Update(string? id, RoomRequestDto roomCreateDto)
        {
            var room = await _context.Rooms.SingleOrDefaultAsync(a => a.Id == id);
            if (room is not null)
            {
                _mapper.Map(roomCreateDto, room);
                try
                {
                    await _context.AddAsync(room);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Created successfully" };
                }
                catch (Exception ex)
                {
                    return new StatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
                }
            }
            return new StatusDto { StatusCode = 0, Message = "Room not exists" };

        }

        public async Task<StatusDto> Delete(string? id)
        {
            var room = await _context.Rooms.SingleOrDefaultAsync(a => a.Id == id);
            if (room is not null)
            {
                try
                {
                    _context.Remove(room);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Removed successfully" };
                }
                catch (Exception ex)
                {
                    return new StatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
                }
            }
            return new StatusDto { StatusCode = 0, Message = "Room not exists" };

        }

        public async Task<StatusDto> Create(RoomRequestDto roomCreateDto)
        {
            var room = _mapper.Map<Room>(roomCreateDto);
            try
            {
                if (roomCreateDto.RoomPicture is not null)
                {
                    var checkSendFile = await _fileService.SendFile("Room/" + roomCreateDto.RoomNumber, roomCreateDto.RoomPicture!);
                    if (checkSendFile.Status == 1)
                    {
                        room.RoomPicture = checkSendFile.Url;
                    }
                    else
                    {
                        return new StatusDto { StatusCode = 0, Message = checkSendFile.Errors };
                    }
                }
                await _context.AddAsync(room);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Room created successfully!" };
            }
            catch (DbUpdateException ex)
            {
                return new StatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
            }
        }
    }
}
