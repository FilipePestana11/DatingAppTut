using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public UsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public ActionResult GetAllUsers()
        {
            var AppUsers = _db.AppUsers;
            if (AppUsers != null)
                return Ok(AppUsers);
            else
                return Ok(new { status = "0", message = "No Records found" });
        }

        [Route("{Id}")]
        public ActionResult GetUser(int Id)
        {
            var User = _db.AppUsers.Find(Id);
            if (User != null)
                return Ok(User);
            else
                return Ok(new { status = "0", message = "No User found" });
        }
    }
}
