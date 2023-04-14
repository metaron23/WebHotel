using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.Authentication;
using WebHotel.DTO.AuthenticationDtos;

namespace WebHotel.Repository.AuthenRepository
{
    public interface IAuthenRepository
    {
        //Login
        Task<object> Login([FromBody] LoginDto model);
        //Register and send mail confirm
        Task<StatusDto> Registration([FromBody] RegisterDto model);
        //Register with admin
        Task<StatusDto> RegistrationAdmin([FromBody] RegisterAdminDto model);
        //Confirm successful registration by mail
        Task<bool> ConfirmEmailRegister(string email, string code);
        // Confirm successful change pass
        Task<StatusDto> RequestResetPassword(string? email);
        Task<StatusDto> RequestChangePassword(ForgotPasswordDto forgotPasswordModel);
        Task<StatusDto> ConfirmChangePassword(ResetPasswordDto resetPasswordModel);
    }
}
