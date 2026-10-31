using FlowerShopBackground.Data;
using FlowerShopSharedModels.Models;
using FlowerShopSharedModels.requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                                        s in _context.Streets on u.StreetId equals s.Id
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
                                            Home = u.Home,
                                            Apartment = u.Apartment,

                                            RoleName = r.Name,
                                            StreetName = s.Name,
                                            LoginName = d.Login
                                        }).FirstOrDefaultAsync();
                return Ok(gettedUser);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
