using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using System.Web;
using WebHotel.Commom;
using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.Authentication;
using WebHotel.DTO.AuthenticationDtos;
using WebHotel.Model;
using WebHotel.Models;
using WebHotel.Repository.EmailRepository;
using WebHotel.Service.TokenRepository;

namespace WebHotel.Repository.AuthenRepository
{
    public class AuthenRepository : ControllerBase, IAuthenRepository
    {
        private readonly MyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenRepository _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailRepository _mailRepository;
        private readonly IConfiguration _configuration;

        public AuthenRepository(MyDBContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ITokenRepository tokenService,
            SignInManager<ApplicationUser> signInManager,
            IMailRepository mailRepository,
            IConfiguration configuration
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _mailRepository = mailRepository;
            _configuration = configuration;
        }

        public async Task<object> Login([FromBody] LoginDto model)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(a => a.Email == model.Email || a.UserName == model.Email);

            if (user != null)
            {
                if (user.LockoutEnd >= DateTime.UtcNow)
                {
                    return
                    new StatusDto
                    {
                        StatusCode = 0,
                        Message = "Tài khoản đã bị khoá vì nhập sai 3 lần! Thời gian mở khoá là: " + user.LockoutEnd.Value.AddHours(7),
                    };
                }
                var check = await _signInManager.PasswordSignInAsync(user, model.Password!, false, true);

                if (check.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var authClaims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, user.UserName!),
                    new Claim(ClaimTypes.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = _tokenService.GetAccessToken(authClaims);
                    var refreshToken = _tokenService.GetRefreshToken();
                    var tokenInfo = _context.TokenInfos.FirstOrDefault(a => a.Usename == user.UserName);

                    if (tokenInfo == null)
                    {
                        var info = new TokenInfo
                        {
                            Usename = user.UserName,
                            RefreshToken = refreshToken,
                            RefreshTokenExpiry = DateTime.Now.AddDays(1)
                        };
                        await _context.TokenInfos.AddAsync(info);
                    }
                    else
                    {
                        tokenInfo.RefreshToken = refreshToken;
                        tokenInfo.RefreshTokenExpiry = DateTime.Now.AddDays(1);
                    }
                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        return new StatusDto
                        {
                            StatusCode = 0,
                            Message = ex.Message,
                        };
                    }

                    return new LoginResponseDto
                    {
                        AccessToken = token.TokenString,
                        RefreshToken = refreshToken,
                    };
                }
            }
            return new StatusDto
            {
                StatusCode = 0,
                Message = "Sai tài khoản hoặc mật khẩu!",
            };
        }

        public async Task<StatusDto> Registration([FromBody] RegisterDto model)
        {
            var status = new StatusDto();
            if (!ModelState.IsValid)
            {
                status.StatusCode = 0;
                status.Message = "Vui lòng điền đủ thông tin đăng ký";
                return status;
            }
            // check if user exists
            var userExistsEmail = await _userManager.FindByEmailAsync(model.Email!);
            var userExistsUserName = await _userManager.FindByNameAsync(model.UserName!);

            if (userExistsEmail != null)
            {
                status.StatusCode = 0;
                status.Message = "Email đã tồn tại trong hệ thống";
                return status;
            }
            if (userExistsUserName != null)
            {
                status.StatusCode = 0;
                status.Message = "UseName đã tồn tại trong hệ thống";
                return status;
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                Name = model.Name!,
                PhoneNumber = model.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, model.Password!);

            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Dữ liệu đủ, nhưng tạo mới tài khoản User lỗi!";
                return status;
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            string code = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user));

            var param = new Dictionary<string, string?>
            {
                {"email", model.Email },
                {"code", code }

            };
            string callBack = QueryHelpers.AddQueryString(_configuration["URL_HOST"]!.ToString() + "/user/confirm-email-register", param);

            if (_mailRepository.SendMail(new EmailRequestDto
            {
                To = user.Email,
                Subject = "Mail confim registed",
                Body = "<a href=\"" + callBack + "\">Link Confim</a>"
            }))
            {
                status.StatusCode = 1;
                status.Message = "Tạo mới thành công. Vui lòng kiểm tra email để kích hoạt tài khoản!";
            }
            else
            {
                status.StatusCode = 0;
                status.Message = "Tạo mới thành công, nhưng gửi mail thất bại";
            }

            return status;
        }

        public async Task<bool> ConfirmEmailRegister(string email, string code)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;
            var result = await _userManager.ConfirmEmailAsync(user, HttpUtility.UrlDecode(code));
            return result.Succeeded;
        }



        public async Task<StatusDto> RegistrationAdmin([FromBody] RegisterAdminDto model)
        {
            var status = new StatusDto();
            var userExists = _context.ApplicationUsers.AsNoTracking().Where(a => a.Email == model.Email || a.UserName == model.UserName).SingleOrDefault();
            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid email or username";
                return status;
            }
            var user = new ApplicationUser
            {
                UserName = model.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
                Email = model.Email,
                EmailConfirmed = true
            };
            // create a user here
            var result = await _userManager.CreateAsync(user, model.Password!);
            if (!result.Succeeded)
            {
                status.StatusCode = 0;
                status.Message = "Admin creation failed";
                return status;
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            status.StatusCode = 1;
            status.Message = "Sucessfully admin registered";
            return status;
        }

        public async Task<StatusDto> RequestResetPassword(string? email)
        {
            var status = new StatusDto();
            var user = await _userManager.FindByEmailAsync(email!);
            if (user is not null)
            {
                const string chars = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
                Random random = new Random();
                IEnumerable<string> string_Enumerable = Enumerable.Repeat(chars, 8);
                char[] arr = string_Enumerable.Select(s => s[random.Next(s.Length)]).ToArray();
                var password = "@T" + string.Join("", arr);

                await _userManager.RemovePasswordAsync(user);
                var check = await _userManager.AddPasswordAsync(user, password);

                if (check.Succeeded)
                {
                    _mailRepository.SendMail(new EmailRequestDto
                    {
                        To = user.Email,
                        Subject = "Mail reset mật khẩu tài khoản!",
                        Body = "Chào bạn, " + user.Name + "! Mật khẩu mới của bạn là: " + password + ". Vui lòng không đổi mật khẩu mới sau khi đăng nhập tài khoản!"
                    });
                    status.StatusCode = 1;
                    status.Message = "Vui lòng kiểm tra hòm thử để nhận mật khẩu mới!";
                    return status;
                }
                else
                {
                    status.StatusCode = 0;
                    status.Message = "Có lỗi trong quá trình reset mật khẩu mới! Vui lòng thử lại!";
                }
            }
            status.StatusCode = 0;
            status.Message = "Email không tồn tại trong hệ thống!";
            return status;
        }

        public async Task<StatusDto> RequestChangePassword(ForgotPasswordDto forgotPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordModel.Email!);
            if (user is null)
            {
                return new StatusDto { StatusCode = 0, Message = "Email không tồn tại" };
            }
            string token = HttpUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));
            var param = new Dictionary<string, string?>
            {
                {"token", token },
                {"email", forgotPasswordModel.Email }
            };
            var callBack = QueryHelpers.AddQueryString(forgotPasswordModel.ClientURI!, param);
            _mailRepository.SendMail(new EmailRequestDto
            {
                To = user.Email,
                Subject = "Mail confim change pass",
                Body = "Change password link: <a href=\"" + callBack + "\">Click Confirm</a>, " + token + ""
            });
            return new StatusDto { StatusCode = 1, Message = "Please check mail to change pass" };
        }

        public async Task<StatusDto> ConfirmChangePassword(ResetPasswordDto resetPasswordModel)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordModel.Email!);
            var check = await _userManager.ResetPasswordAsync(user!, HttpUtility.UrlDecode(resetPasswordModel.Token!), resetPasswordModel.NewPassword!);
            if (check.Succeeded)
            {
                return new StatusDto { StatusCode = 1, Message = "Change pass successfull" };
            }
            return new StatusDto { StatusCode = 0, Message = "Change pass failed" };
        }
    }
}
