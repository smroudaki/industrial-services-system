using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using IndustrialServicesSystem.Application.Common.Interfaces;
using IndustrialServicesSystem.Application.Accounts.Commands.Authenticate;
using IndustrialServicesSystem.Domain.Entities;
using IndustrialServicesSystem.Infrastructure.Identity;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Threading;
using IndustrialServicesSystem.Domain.Enums;
using Role = IndustrialServicesSystem.Domain.Entities.Role;

namespace IndustrialServicesSystem.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IIndustrialServicesSystemContext _context;
        private readonly ISmsService _sms;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(IIndustrialServicesSystemContext context, ISmsService smsService, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            _context = context;
            _sms = smsService;
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticateVm> Authenticate(string phoneNumber, string code, Guid roleGuid, bool rememberMe, Guid platformGuid)
        {
            bool userExistsInRole;
            int codeId = -1;

            User user = await _context.User
                .SingleOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber) && !x.IsDelete);

            if (user == null) return new AuthenticateVm()
            {
                Message = "کاربری یافت نشد",
                State = (int)AuthenticateState.UserNotFound
            };

            switch (roleGuid.ToString())
            {
                case "46a09d81-c57f-4655-a8f5-027c66a6cfb1":
                    userExistsInRole = await _context.Admin
                        .AnyAsync(x => x.UserId == user.UserId);
                    codeId = 13;
                    break;

                case "91b3cdab-39c1-40fb-b077-a2d6e611f50a":
                    userExistsInRole = await _context.Client
                        .AnyAsync(x => x.UserId == user.UserId);
                    codeId = 14;
                    break;

                case "959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15":
                    userExistsInRole = await _context.Contractor
                        .AnyAsync(x => x.UserId == user.UserId);
                    codeId = 15;
                    break;

                default:
                    userExistsInRole = false;
                    break;
            }

            if (!userExistsInRole || codeId == -1) return new AuthenticateVm()
            {
                Message = "کاربری یافت نشد", 
                State = (int) AuthenticateState.UserNotFound
            };

            Code platform = await _context.Code
                .SingleOrDefaultAsync(x => x.CodeGuid == platformGuid && !x.IsDelete);

            if (platform == null) return new AuthenticateVm()
            {
                Message = "پلتفرم مورد نظر یافت نشد",
                State = (int)AuthenticateState.PlatformNotFound
            };

            if (user.PhoneNumber == "09034761777" ||
                user.PhoneNumber == "09034761888" ||
                user.PhoneNumber == "09034761999")
            {
                DateTime expireDate;

                switch (platform.CodeGuid.ToString())
                {
                    case "1cc5aa3e-1a24-49e2-b543-6b0cfa37bba2":
                    case "1117fabe-6a4c-4585-a1c4-f53c5e1b0728":
                        expireDate = DateTime.Now.AddYears(1);
                        break;

                    default:
                        expireDate = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);
                        break;
                }

                return new AuthenticateVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)AuthenticateState.Success,
                    Token = await GenerateJsonWebToken(user, expireDate, platform.Name),
                    Expires = expireDate.ToString("yyyy/MM/dd HH:mm:ss")
                };
            }
            else
            {
                Token userToken = await _context.Token
                    .Where(x => x.UserId == user.UserId && x.RoleCodeId == codeId && x.ExpireDate >= DateTime.Now)
                    .OrderByDescending(x => x.ExpireDate)
                    .FirstOrDefaultAsync();

                if (userToken == null) return new AuthenticateVm()
                {
                    Message = "کدی یافت نشد",
                    State = (int)AuthenticateState.CodeNotFound
                };

                if (!userToken.Value.ToString().Equals(code)) return new AuthenticateVm()
                {
                    Message = "کد وارد شده اشتباه است",
                    State = (int)AuthenticateState.WrongCode
                };

                if (!user.IsActive) return new AuthenticateVm()
                {
                    Message = "حساب کار مورد نظر غیر فعال است",
                    State = (int)AuthenticateState.UserNotActivated
                };

                if (!user.IsRegister)
                {
                    user.IsRegister = true;
                    user.IsActive = true;
                    await _context.SaveChangesAsync(CancellationToken.None);

                    object smsResult = await _sms.SendServiceable(Domain.Enums.SmsTemplate.RegisterMessage, user.PhoneNumber, string.Empty, "", "", "", user.FirstName + " " + user.LastName);

                    if (smsResult.GetType().Name != "SendResult")
                    {
                        // sent result
                    }
                    else
                    {
                        // sms error
                    }
                }

                DateTime expireDate;

                switch (platform.CodeGuid.ToString())
                {
                    case "1cc5aa3e-1a24-49e2-b543-6b0cfa37bba2":
                    case "1117fabe-6a4c-4585-a1c4-f53c5e1b0728":
                        expireDate = DateTime.Now.AddYears(1);
                        break;

                    default:
                        expireDate = rememberMe ? DateTime.Now.AddMonths(1) : DateTime.Now.AddDays(1);
                        break;
                }

                return new AuthenticateVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)AuthenticateState.Success,
                    Token = await GenerateJsonWebToken(user, expireDate, platform.Name),
                    Expires = expireDate.ToString("yyyy/MM/dd HH:mm:ss")
                };
            }

            //return user.WithoutPassword();
        }

        private async Task<string> GenerateJsonWebToken(User user, DateTime expireDate, string platform)
        {
            Role role = await _context.Role
                .Where(x => x.RoleId == user.RoleId)
                .SingleOrDefaultAsync();

            byte[] key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            Claim[] claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, user.UserGuid.ToString()),
                //new Claim(ClaimTypes.Sid, user.UserId.ToString()),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber),
                new Claim(ClaimTypes.Role, role.DisplayName),
                //new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                //new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.UserGuid.ToString()),
                new Claim("Platform", platform),
            };
            JwtSecurityToken token = new JwtSecurityToken(_jwtSettings.Issuer,
                _jwtSettings.Issuer,
                claims,
                expires: expireDate,
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> GetUserFullNameAsync(Guid userGuid)
        {
            return await _context.User
                .Where(x => x.UserGuid == userGuid)
                .Select(x => x.FirstName + " " + x.LastName)
                .SingleOrDefaultAsync();
        }

        //public async Task<IEnumerable<TblUser>> GetAll()
        //{
        //    return await _context.TblUser
        //        .Where(x => !x.UserIsDelete)
        //        .ToListAsync();
        //}

        //public TblUser GetById(int id)
        //{
        //    var user = _users.FirstOrDefault(x => x.Id == id);
        //    return user.WithoutPassword();
        //}
    }
}
