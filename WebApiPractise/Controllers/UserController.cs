using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiPractise.DAL;
using WebApiPractise.DTOs;
using WebApiPractise.Models;

namespace WebApiPractise.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AppDbContext _context { get; set; }
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var users = _context.Users.Where(p => p.IsDeleted == false);
            return users;
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _context.Users.Where(p => p.IsDeleted == false && p.Id == id).FirstOrDefault();
            if (user is null) return NotFound();
            return user;
        }
        [HttpPost]
        public ActionResult Post(UserCreateDto user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(404);
            }
            var newUser = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return StatusCode(201);

        }
    }
}
