using Buyer_seller_stock.Data;
using Buyer_seller_stock.Models;
using Buyer_seller_stock.Models.Entities;
using Buyer_seller_stock.Models.DTO;
using Microsoft.AspNetCore.Mvc;
namespace Buyer_seller_stock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("get-all-user")]
        public IActionResult getAllUser()
        {
            var user = dbContext.User.ToList();
            return Ok(user);
        }
        [HttpGet]
        [Route("get-all-user-by-userID")]
        public IActionResult getUsersByID(int id) {
            var userID = dbContext.User.Find(id);
            if (userID is null)
            {
                return NotFound();
            }
            return Ok(userID);
        }
        [HttpPost]
        [Route("add-User")]
        public IActionResult addUser(UserDTO addUserDTO)
        {
            var userEntity = new User()
            {
                UserId = addUserDTO.UserId,
                UserName = addUserDTO.UserName,
                TotalFunds = addUserDTO.TotalFunds,
            };
            dbContext.User.Add(userEntity);
            dbContext.SaveChanges();
            return Ok(userEntity);
        }
        [HttpPost]
        [Route("add-user-bulk")]
        public IActionResult AddUserBulk([FromBody] List<UserDTO> users)
        {
            var userList = new List<User>();

            foreach (var addUserDTO in users)
            {
                var userEntity = new User()
                {
                    UserId = addUserDTO.UserId,
                    UserName = addUserDTO.UserName,
                    TotalFunds = addUserDTO.TotalFunds,
                };
                userList.Add(userEntity);
            }

            dbContext.User.AddRange(userList);
            dbContext.SaveChanges();

            return Ok(userList);
        }

    }
}
