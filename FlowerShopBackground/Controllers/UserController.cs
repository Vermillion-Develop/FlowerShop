using FlowerShopBackground.Data;
using FlowerShopSharedModels.Models;
using FlowerShopSharedModels.requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Diagnostics;

namespace FlowerShopBackground.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly AppDataContext _context;

        public UserController(AppDataContext context)
        {
            _context = context;
        }

        [HttpPost("loginIn")]
        public async Task<IActionResult> LoginIn([FromBody] LoginRequestDTO requestDTO)
        {
            try
            {
                if(requestDTO == null)
                {
                    return BadRequest();
                }
                var gettedUser = await (from u in _context.Users 
                                        join
                                        r in _context.Roles on u.RoleId equals r.Id
                                        join
                                        s in _context.Streets on u.StreetId equals s.Id into streetGroup
                                        from s in streetGroup.DefaultIfEmpty()
                                        join
                                        d in _context.DatalogsUsers on u.DatalogsId equals d.Id
                                        where d.Login == requestDTO.Login && d.Password == requestDTO.Password
                                        select new UserDTO()
                                        {
                                            Id = u.Id,
                                            Family = u.Family,
                                            Name = u.Name,
                                            Father = u.Father,
                                            Phone = u.Phone,
                                            RoleId = u.RoleId,
                                            DatalogsId = u.DatalogsId,
                                            StreetId = u.StreetId,
                                            Home = u != null? u.Home : "Не указана",
                                            Apartment = u != null? u.Apartment : "Не указана",

                                            RoleName = r.Name,
                                            StreetName = s != null? s.Name : "Не указана",
                                            LoginName = d.Login
                                        }).FirstOrDefaultAsync();
                return Ok(gettedUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDTO requestDTO)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var existingLogin = await (from d in _context.DatalogsUsers where d.Login == requestDTO.Login select d).FirstOrDefaultAsync();
                if(existingLogin != null)
                {
                    return BadRequest();
                }
                Datalogs newLog = new Datalogs()
                {
                    Login = requestDTO.Login,
                    Password = requestDTO.Password
                };
                await _context.DatalogsUsers.AddAsync(newLog);
                await _context.SaveChangesAsync();

                User newUser = new User()
                {
                    Family = requestDTO.Family,
                    Name = requestDTO.Name,
                    Father = requestDTO.Father,
                    Phone = requestDTO.Phone,
                    DatalogsId = newLog.Id,
                    StreetId = null,

                    RoleId = 2
                };
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return StatusCode(200);
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500);
            }
        }
    }
}
