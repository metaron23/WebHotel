using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebHotel.Commom;
using WebHotel.DTO;
using WebHotel.DTO.AuthenticationDtos;
using WebHotel.Service.TokenRepository;

namespace WebHotel.Repository.AdminRepository.AuthenRepository
{
    public class AuthenAdminRepository : ControllerBase, IAuthenAdminRepository
    {
        private readonly MyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ITokenRepository _tokenService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenAdminRepository(MyDBContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ITokenRepository tokenService,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
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
                        Message = "Account has been locked because of wrong input 3 times! Unlocking times are: " + user.LockoutEnd.Value.AddHours(7),
                    };
                }
                var check = await _signInManager.PasswordSignInAsync(user, model.Password!, false, true);

                if (check.Succeeded)
                {
                    var roleAdmin = await _context.ApplicationUserRoles.SingleOrDefaultAsync(a => a.UserId == user!.Id && a.Role!.Name == "Admin");
                    if (roleAdmin == null)
                    {
                        return new StatusDto
                        {
                            StatusCode = 0,
                            Message = "Not have permission to access"
                        };
                    }
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
                Message = "Wrong account or password!",
            };
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
                await _roleManager.CreateAsync(new ApplicationRole(UserRoles.Admin));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            status.StatusCode = 1;
            status.Message = "Sucessfully admin registered";
            return status;
        }
    }
}
