namespace miniProject.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using miniProject.Database;
    using miniProject.Database.Models;
    using miniProject.DTO;
    using Newtonsoft.Json;
    using PaginationLibrary;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="UsersController" />.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// Defines the _context.
        /// </summary>
        private readonly DatabaseContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="context">The context<see cref="DatabaseContext"/>.</param>
        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// The GetUsers.
        /// </summary>
        /// <returns>The <see cref="Task{ActionResult{IEnumerable{User}}}"/>.</returns>
        [HttpGet]
        public ActionResult GetUsers([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var users = _context.Users.ToPagedList(pageNumber,pageSize).Select(x => new UserDTO()
            {
                CreateDate = x.CreateDate,
                State = x.State,
                Email = x.Email,
                Name = x.Name,
                Password = x.Password,
                UID = x.UID,
                UpdateDate = x.UpdateDate
            }).ToPagedList(pageNumber, pageSize);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(users.GetMetaData()));

            return Ok(users);
        }

        /// <summary>
        /// The GetUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{User}}"/>.</returns>
        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            try
            {
                var user = _context.Users.SingleOrDefault(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return Ok(new UserDTO()
                {
                    CreateDate = user.CreateDate,
                    State = user.State,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    UID = user.UID,
                    UpdateDate = user.UpdateDate
                });
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }

        /// <summary>
        /// The PutUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="user">The user<see cref="User"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// The PostUser.
        /// </summary>
        /// <param name="user">The user<see cref="User"/>.</param>
        /// <returns>The <see cref="Task{ActionResult{User}}"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDTO user)
        {
            var newUser = new User() //Creating a DTO
            {
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                State = user.State
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Created("GetUser", newUser);
        }

        /// <summary>
        /// The DeleteUser.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// The UserExists.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
